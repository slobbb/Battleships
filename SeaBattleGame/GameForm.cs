using MaterialSkin;
using MaterialSkin.Controls;
using SeaBattle;
using SeaBattleGame.Properties;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Media;
using System.Reflection;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;
using System.Threading;

public partial class GameForm : MaterialForm
{
    // Основные переменные класса GameForm
    private Game game; // Экземпляр игры
    private int boardSize; // Размер игрового поля
    private Random random; // Генератор случайных чисел
    private string playerName; // Имя игрока

    // Изображения для попаданий и промахов
    private Image hitImage; // Изображение попадания
    private Image missImage; // Изображение промаха

    // Переменные для размещения кораблей
    private bool isPlacingShips = true; // Флаг, указывающий на режим размещения кораблей
    private List<Tuple<int, int>> shipPositions = new List<Tuple<int, int>>(); // Список позиций кораблей

    // Звуковые эффекты
    private SoundPlayer hitSound; // Звук попадания
    private SoundPlayer missSound; // Звук промаха
    private SoundPlayer backgroundMusic; // Фоновая музыка

    private Stopwatch gameTimer; // Добавляем Stopwatch для отслеживания времени игры
    private System.Windows.Forms.Label lblGameTime;

    // Конструктор формы GameForm
    public GameForm(string playerName)
    {
        InitializeComponent(); // Инициализация компонентов формы
        this.playerName = playerName; // Установка имени игрока
        random = new Random(); // Инициализация генератора случайных чисел
        LoadImages(); // Загрузка изображений
        LoadSounds(); // Загрузка звуков
        InitializeGame(); // Инициализация игры
        SyncSettings(); // Синхронизация настроек

        // Установка текста для информации о кораблях
        lblShipInfo.Text = $"Информация о кораблях: {Settings.Default.BattleshipCount} линкоров, {Settings.Default.SubmarineCount} подводных лодок, {Settings.Default.DestroyerCount} эсминцев, {Settings.Default.TorpedoBoatCount} торпедных катеров.";
        gameTimer = new Stopwatch(); // Инициализируем таймер

        lblGameTime = new Label(); // Инициализируем и настраиваем Label
        lblGameTime.AutoSize = true;
        lblGameTime.Location = new Point(15, 985); // Указываем желаемую позицию
        this.Controls.Add(lblGameTime); // Добавляем Label на форму

        System.Windows.Forms.Timer uiTimer = new System.Windows.Forms.Timer(); // Используем System.Windows.Forms.Timer
        uiTimer.Interval = 1000; // Обновление каждую секунду
        uiTimer.Tick += (s, e) => lblGameTime.Text = $"Время игры: {gameTimer.Elapsed:mm\\:ss}";
        uiTimer.Start();
    }


    // Метод для загрузки изображений
    private void LoadImages()
    {
        string basePath = AppDomain.CurrentDomain.BaseDirectory; // Получение базового пути к текущему домену приложения
        string hitImagePath = Path.Combine(basePath, "Resources", "hit.png"); // Путь к изображению попадания
        string missImagePath = Path.Combine(basePath, "Resources", "miss.png"); // Путь к изображению промаха

        if (File.Exists(hitImagePath) && File.Exists(missImagePath))
        {
            hitImage = Image.FromFile(hitImagePath); // Загрузка изображения попадания
            missImage = Image.FromFile(missImagePath); // Загрузка изображения промаха
        }
        else
        {
            MessageBox.Show("Изображения для игры не найдены в папке Resources"); // Вывод сообщения об ошибке
        }
    }

    // Метод для загрузки звуков
    private void LoadSounds()
    {
        string basePath = AppDomain.CurrentDomain.BaseDirectory; // Получение базового пути к текущему домену приложения
        string hitSoundPath = Path.Combine(basePath, "Resources", "hit.wav"); // Путь к звуку попадания
        string missSoundPath = Path.Combine(basePath, "Resources", "miss.wav"); // Путь к звуку промаха
        string backgroundMusicPath = Path.Combine(basePath, "Resources", "background_music.wav"); // Путь к фоновому звуку

        if (File.Exists(hitSoundPath) && File.Exists(missSoundPath))
        {
            hitSound = new SoundPlayer(hitSoundPath); // Загрузка звука попадания
            missSound = new SoundPlayer(missSoundPath); // Загрузка звука промаха
        }
        else
        {
            MessageBox.Show("Звуковые файлы не найдены в папке Resources"); // Вывод сообщения об ошибке
        }

        if (File.Exists(backgroundMusicPath))
        {
            backgroundMusic = new SoundPlayer(backgroundMusicPath); // Загрузка фоновой музыки
        }
    }

    // Метод для инициализации игры
    private void InitializeGame()
    {
        boardSize = Settings.Default.BoardSize; // Получение размера игрового поля из настроек
        game = new Game(boardSize); // Инициализация игры с заданным размером поля
        SetupBoards(); // Настройка игровых полей

        game.ComputerBoard.PlaceShipsRandomly(); // Случайное размещение кораблей на поле компьютера

        // Получение количества кораблей различных типов
        int battleshipCount = game.ComputerBoard.Ships.Count(s => s.Positions.Count == 4);
        int submarineCount = game.ComputerBoard.Ships.Count(s => s.Positions.Count == 3);
        int destroyerCount = game.ComputerBoard.Ships.Count(s => s.Positions.Count == 2);
        int torpedoBoatCount = game.ComputerBoard.Ships.Count(s => s.Positions.Count == 1);

        // Вывод информации о кораблях компьютера
        MessageBox.Show($"Корабли на поле компьютера: линкоров - {battleshipCount}, подводных лодок - {submarineCount}, эсминцев - {destroyerCount}, торпедных катеров - {torpedoBoatCount}");

        UpdateScores(); // Обновление счетов

        // Если включена фоновая музыка и она загружена, воспроизводим её
        if (Settings.Default.MusicEnabled && backgroundMusic != null)
        {
            backgroundMusic.PlayLooping(); // Воспроизведение музыки в цикле
        }
    }

    // Метод для настройки игровых полей
    private void SetupBoards()
    {
        playerField.ColumnCount = boardSize; // Установка количества столбцов в поле игрока
        playerField.RowCount = boardSize; // Установка количества строк в поле игрока
        for (int i = 0; i < boardSize; i++)
        {
            playerField.Columns[i].Width = 40; // Установка ширины столбцов
            playerField.Rows[i].Height = 40; // Установка высоты строк
        }

        computerField.ColumnCount = boardSize; // Установка количества столбцов в поле компьютера
        computerField.RowCount = boardSize; // Установка количества строк в поле компьютера
        for (int i = 0; i < boardSize; i++)
        {
            computerField.Columns[i].Width = 40; // Установка ширины столбцов
            computerField.Rows[i].Height = 40; // Установка высоты строк
        }

        // Настройка полей для игрока и компьютера
        playerField.ReadOnly = true; // Поле игрока только для чтения
        computerField.ReadOnly = true; // Поле компьютера только для чтения

        playerField.SelectionMode = DataGridViewSelectionMode.CellSelect; // Режим выделения ячеек для поля игрока
        computerField.SelectionMode = DataGridViewSelectionMode.CellSelect; // Режим выделения ячеек для поля компьютера
        playerField.DefaultCellStyle.SelectionBackColor = playerField.DefaultCellStyle.BackColor; // Цвет выделения ячеек для поля игрока
        playerField.DefaultCellStyle.SelectionForeColor = playerField.DefaultCellStyle.ForeColor; // Цвет текста в выделенных ячейках для поля игрока
        computerField.DefaultCellStyle.SelectionBackColor = computerField.DefaultCellStyle.BackColor; // Цвет выделения ячеек для поля компьютера
        computerField.DefaultCellStyle.SelectionForeColor = computerField.DefaultCellStyle.ForeColor; // Цвет текста в выделенных ячейках для поля компьютера

        // Добавление обработчиков событий для кликов по ячейкам полей
        computerField.CellClick += ComputerField_CellClick;
        playerField.CellClick += PlayerField_CellClick;
    }

    // Метод для обработки кликов по ячейкам поля игрока
    private void PlayerField_CellClick(object sender, DataGridViewCellEventArgs e)
    {
        if (!isPlacingShips) // Если не в режиме размещения кораблей, выходим
            return;

        var position = Tuple.Create(e.RowIndex, e.ColumnIndex); // Получаем позицию ячейки

        if (shipPositions.Contains(position)) // Если позиция уже занята
        {
            shipPositions.Remove(position); // Удаляем позицию из списка
            playerField.Rows[e.RowIndex].Cells[e.ColumnIndex].Style.BackColor = Color.White; // Сбрасываем цвет ячейки
        }
        else
        {
            shipPositions.Add(position); // Добавляем позицию в список
            playerField.Rows[e.RowIndex].Cells[e.ColumnIndex].Style.BackColor = GetShipColor(); // Устанавливаем цвет ячейки для размещенного корабля
        }

        playerField.Rows[e.RowIndex].Cells[e.ColumnIndex].Style.SelectionBackColor = playerField.Rows[e.RowIndex].Cells[e.ColumnIndex].Style.BackColor; // Обновление цвета выделения
        playerField.UpdateCellValue(e.ColumnIndex, e.RowIndex); // Принудительное обновление ячейки
        playerField.Refresh(); // Обновление таблицы
    }

    // Метод для валидации и размещения кораблей игрока
    private void ValidateAndPlaceShips()
    {
        var ships = game.PlayerBoard.GetShipsFromPositions(shipPositions); // Получаем корабли из позиций
        if (game.PlayerBoard.ValidateAllShips(ships)) // Проверяем корректность размещения всех кораблей
        {
            game.PlacePlayerShips(shipPositions); // Размещаем корабли игрока
            isPlacingShips = false; // Завершаем режим размещения кораблей
            MessageBox.Show("Все корабли размещены! Начинайте игру."); // Уведомление о завершении размещения
        }
        else
        {
            MessageBox.Show("Ошибка в размещении кораблей. Проверьте, что все корабли размещены правильно и не касаются друг друга."); // Сообщение об ошибке размещения
        }
    }

    // Обработчик события нажатия на кнопку начала игры
    private void btnStartGame_Click(object sender, EventArgs e)
    {
        ValidateAndPlaceShips();
        if (!isPlacingShips) // Если корабли успешно размещены
        {
            gameTimer.Start(); // Запуск таймера при начале игры
        }
    }

    // Метод для обработки кликов по ячейкам поля компьютера
    private async void ComputerField_CellClick(object sender, DataGridViewCellEventArgs e)
    {
        if (isPlacingShips || game.IsGameOver) // Если размещение кораблей не завершено или игра окончена
        {
            MessageBox.Show("Игра окончена или размещение кораблей не завершено!"); // Сообщение об ошибке
            return;
        }

        var position = Tuple.Create(e.RowIndex, e.ColumnIndex); // Получаем позицию ячейки
        if (game.PlayerShoot(position)) // Если выстрел игрока успешен
        {
            DisplayHitOrMiss(computerField, e.RowIndex, e.ColumnIndex, true); // Отображение попадания
            if (Settings.Default.SoundEffectsEnabled && hitSound != null) // Если звуковые эффекты включены и звук попадания загружен
            {
                PlaySoundAsync(hitSound); // Воспроизведение звука попадания
            }
        }
        else
        {
            DisplayHitOrMiss(computerField, e.RowIndex, e.ColumnIndex, false); // Отображение промаха
            if (Settings.Default.SoundEffectsEnabled && missSound != null) // Если звуковые эффекты включены и звук промаха загружен
            {
                PlaySoundAsync(missSound); // Воспроизведение звука промаха
            }
        }

        if (game.ComputerBoard.AreAllShipsSunk()) // Если все корабли компьютера потоплены
        {
            MessageBox.Show("Вы выиграли!"); // Сообщение о победе
            SaveResult(playerName, game.PlayerScore); // Сохранение результата игры
            return;
        }

        await Task.Delay(2000); // Задержка перед ходом компьютера
        ComputerTurn(); // Ход компьютера
        UpdateScores(); // Обновление счетов
    }

    // Метод для выполнения хода компьютера
    private List<Tuple<int, int>> hitPositions = new List<Tuple<int, int>>(); // Список позиций удачных выстрелов

    // Метод для выполнения хода компьютера
    private void ComputerTurn()
    {
        int row, col;
        Tuple<int, int> position;

        if (hitPositions.Any()) // Если есть удачные выстрелы, атакуем рядом с ними
        {
            var lastHit = hitPositions.Last();
            var possiblePositions = new List<Tuple<int, int>>
        {
            Tuple.Create(lastHit.Item1 - 1, lastHit.Item2),
            Tuple.Create(lastHit.Item1 + 1, lastHit.Item2),
            Tuple.Create(lastHit.Item1, lastHit.Item2 - 1),
            Tuple.Create(lastHit.Item1, lastHit.Item2 + 1)
        };

            var validPositions = possiblePositions.Where(p => p.Item1 >= 0 && p.Item1 < boardSize && p.Item2 >= 0 && p.Item2 < boardSize && !game.PlayerBoard.Shots.Contains(p)).ToList();

            if (validPositions.Any())
            {
                position = validPositions[random.Next(validPositions.Count)];
            }
            else
            {
                do
                {
                    row = random.Next(boardSize); // Генерация случайной строки
                    col = random.Next(boardSize); // Генерация случайного столбца
                    position = Tuple.Create(row, col); // Создание позиции
                } while (game.PlayerBoard.Shots.Contains(position));
            }
        }
        else
        {
            do
            {
                row = random.Next(boardSize); // Генерация случайной строки
                col = random.Next(boardSize); // Генерация случайного столбца
                position = Tuple.Create(row, col); // Создание позиции
            } while (game.PlayerBoard.Shots.Contains(position)); // Проверка, что выстрел не был сделан ранее
        }

        if (game.ComputerShoot(position)) // Если выстрел компьютера успешен
        {
            DisplayHitOrMiss(playerField, position.Item1, position.Item2, true); // Отображение попадания
            if (Settings.Default.SoundEffectsEnabled && hitSound != null) // Если звуковые эффекты включены и звук попадания загружен
            {
                PlaySoundAsync(hitSound); // Воспроизведение звука попадания
            }
            hitPositions.Add(position); // Добавляем позицию удачного выстрела в список
        }
        else
        {
            DisplayHitOrMiss(playerField, position.Item1, position.Item2, false); // Отображение промаха
            if (Settings.Default.SoundEffectsEnabled && missSound != null) // Если звуковые эффекты включены и звук промаха загружен
            {
                PlaySoundAsync(missSound); // Воспроизведение звука промаха
            }
        }

        if (game.PlayerBoard.AreAllShipsSunk()) // Если все корабли игрока потоплены
        {
            gameTimer.Stop(); // Остановка таймера при завершении игры
            MessageBox.Show($"Компьютер выиграл!\nВремя игры: {gameTimer.Elapsed:mm\\:ss}"); // Сообщение о поражении
            SaveResult("Компьютер", game.ComputerScore); // Сохранение результата игры
        }

        UpdateScores(); // Обновление счетов
    }

    // Метод для отображения попадания или промаха
    private void DisplayHitOrMiss(DataGridView field, int row, int col, bool isHit)
    {
        var targetCell = field.Rows[row].Cells[col]; // Получение целевой ячейки
        var image = isHit ? hitImage : missImage; // Выбор изображения в зависимости от результата выстрела

        var bmp = new Bitmap(image, new Size(40, 40)); // Создание Bitmap с нужным размером

        PictureBox pictureBox = new PictureBox
        {
            Image = bmp, // Установка изображения
            SizeMode = PictureBoxSizeMode.StretchImage, // Режим растягивания изображения
            Width = 40,
            Height = 40
        };

        field.Controls.Add(pictureBox); // Добавление PictureBox в ячейку DataGridView
        pictureBox.Location = targetCell.DataGridView.GetCellDisplayRectangle(col, row, true).Location; // Установка позиции PictureBox
    }

    // Метод для обновления счетов
    private void UpdateScores()
    {
        lblPlayerScore.Text = $"Очки игрока: {game.PlayerScore}"; // Обновление счета игрока
        lblComputerScore.Text = $"Очки компьютера: {game.ComputerScore}"; // Обновление счета компьютера
    }

    // Метод для сохранения результата игры
    private void SaveResult(string playerName, int score)
    {
        string filePath = "results.txt";
        using (StreamWriter writer = new StreamWriter(filePath, true))
        {
            writer.WriteLine($"{DateTime.Now}: {playerName} - {score} очков, время игры: {gameTimer.Elapsed}");
        }
    }

    // Обработчик события нажатия на кнопку сдачи
    private void btnSurrender_Click(object sender, EventArgs e)
    {
        gameTimer.Stop();
        MessageBox.Show($"Вы сдались. Игра окончена.\nВремя игры: {gameTimer.Elapsed:mm\\:ss}"); // Сообщение о сдаче
        SaveResult(playerName, game.PlayerScore); // Сохранение результата игры
        this.Close(); // Закрытие текущей формы
        MainMenu mainMenu = new MainMenu(); // Создание новой формы главного меню
        mainMenu.Show(); // Отображение формы главного меню
    }

    // Метод для применения цветовой схемы
    private void ApplyColorScheme()
    {
        var materialSkinManager = MaterialSkinManager.Instance; // Получение экземпляра MaterialSkinManager
        materialSkinManager.AddFormToManage(this); // Добавление текущей формы в управление MaterialSkinManager
        switch (Settings.Default.ColorScheme) // Применение цветовой схемы в зависимости от настроек
        {
            case 0:
                materialSkinManager.ColorScheme = new ColorScheme(Primary.Blue600, Primary.Blue700, Primary.Blue200, Accent.LightBlue200, TextShade.WHITE);
                break;
            case 1:
                materialSkinManager.ColorScheme = new ColorScheme(Primary.Red600, Primary.Red700, Primary.Red200, Accent.Pink200, TextShade.WHITE);
                break;
            case 2:
                materialSkinManager.ColorScheme = new ColorScheme(Primary.Green600, Primary.Green700, Primary.Green200, Accent.LightGreen200, TextShade.WHITE);
                break;
        }
    }

    // Метод для получения цвета корабля в зависимости от цветовой схемы
    private Color GetShipColor()
    {
        switch (Settings.Default.ColorScheme) // Возвращение цвета корабля в зависимости от цветовой схемы
        {
            case 0:
                return Color.LightBlue;
            case 1:
                return Color.Pink;
            case 2:
                return Color.LightGreen;
            default:
                return Color.DarkViolet;
        }
    }

    // Метод для синхронизации настроек
    private void SyncSettings()
    {
        ApplyColorScheme(); // Применение цветовой схемы
        LoadImages(); // Загрузка изображений
        LoadSounds(); // Загрузка звуков
    }

    // Обработчик события загрузки формы
    private void GameForm_Load(object sender, EventArgs e)
    {
        SyncSettings(); // Синхронизация настроек при загрузке формы
    }

    // Метод-заглушка для клика по метке очков компьютера
    private void lblComputerScore_Click(object sender, EventArgs e)
    {
    }

    // Метод-заглушка для клика по метке очков игрока
    private void lblPlayerScore_Click(object sender, EventArgs e)
    {
    }

    // Метод-заглушка для клика по метке информации о кораблях
    private void lblShipInfo_Click(object sender, EventArgs e)
    {
    }

    // Метод для воспроизведения звука в отдельном потоке
    private void PlaySoundAsync(SoundPlayer sound)
    {
        Task.Run(() =>
        {
            sound.PlaySync(); // Воспроизведение звука синхронно в отдельном потоке
        });
    }
}
