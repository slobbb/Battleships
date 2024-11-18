using System;
using System.IO;
using System.Windows.Forms;
using MaterialSkin;
using MaterialSkin.Controls;
using SeaBattleGame.Properties;

public partial class MainMenu : MaterialForm
{
    // Конструктор класса MainMenu
    public MainMenu()
    {
        InitializeComponent();

        var materialSkinManager = MaterialSkinManager.Instance;
        materialSkinManager.AddFormToManage(this);
        SyncSettings();
    }

    public void SyncSettings()
    {
        var materialSkinManager = MaterialSkinManager.Instance;
        materialSkinManager.AddFormToManage(this);
        switch (Settings.Default.ColorScheme)
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

    // Обработчик клика по кнопке "Начать игру"
    private void btnStartGame_Click(object sender, EventArgs e)
    {
        // Отображение диалогового окна для ввода имени игрока
        string playerName = Prompt.ShowDialog("Введите ваше имя", "Начать игру");
        if (!string.IsNullOrEmpty(playerName)) // Если имя не пустое
        {
            this.Hide(); // Скрываем текущее окно
            try
            {
                GameForm gameForm = new GameForm(playerName); // Создаем новый экземпляр формы игры
                gameForm.Show(); // Отображаем форму игры
                MessageBox.Show("GameForm instance created and shown."); // Отладочное сообщение
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при создании GameForm: {ex.Message}");
            }
        }
        else
        {
            MessageBox.Show("Пожалуйста, введите имя.");
        }
    }

    // Обработчик клика по кнопке "Результаты"
    private void btnResults_Click(object sender, EventArgs e)
    {
        string filePath = "results.txt"; // Путь к файлу с результатами
        if (File.Exists(filePath)) // Если файл существует
        {
            string results = File.ReadAllText(filePath); // Чтение содержимого файла
            MessageBox.Show(results, "Результаты"); // Отображение результатов в сообщении
        }
        else
        {
            MessageBox.Show("Результатов нет", "Результаты"); // Сообщение о том, что результатов нет
        }
    }

    // Обработчик клика по кнопке "Настройки"
    private void btnSettings_Click(object sender, EventArgs e)
    {
        SettingsForm settingsForm = new SettingsForm(this); // Создаем новый экземпляр формы настроек и передаем MainMenu
        settingsForm.ShowDialog(); // Отображаем форму настроек
    }

    // Обработчик клика по кнопке "Выход"
    private void btnExit_Click(object sender, EventArgs e)
    {
        Application.Exit(); // Завершение работы приложения
    }

    // Пустой метод-заглушка для загрузки формы
    private void MainMenu_Load(object sender, EventArgs e)
    {
        // Заглушка для события загрузки формы
    }
}

// Вспомогательный класс для отображения диалоговых окон
public static class Prompt
{
    // Метод для отображения диалогового окна с текстовым полем
    public static string ShowDialog(string text, string caption)
    {
        Form prompt = new Form()
        {
            Width = 500, // Ширина окна
            Height = 150, // Высота окна
            FormBorderStyle = FormBorderStyle.FixedDialog, // Фиксированный стиль границы
            Text = caption, // Заголовок окна
            StartPosition = FormStartPosition.CenterScreen // Центрирование окна на экране
        };
        Label textLabel = new Label() { Left = 50, Top = 20, Text = text }; // Создание метки с текстом
        TextBox textBox = new TextBox() { Left = 50, Top = 50, Width = 400 }; // Создание текстового поля
        Button confirmation = new Button() { Text = "Ok", Left = 350, Width = 100, Top = 70, DialogResult = DialogResult.OK }; // Создание кнопки подтверждения
        confirmation.Click += (sender, e) => { prompt.Close(); }; // Закрытие окна при клике на кнопку
        prompt.Controls.Add(textLabel); // Добавление метки в форму
        prompt.Controls.Add(textBox); // Добавление текстового поля в форму
        prompt.Controls.Add(confirmation); // Добавление кнопки подтверждения в форму
        prompt.AcceptButton = confirmation; // Установка кнопки подтверждения по умолчанию

        // Отображение диалогового окна и возврат текста из текстового поля при подтверждении
        return prompt.ShowDialog() == DialogResult.OK ? textBox.Text : "";
    }
}
