using SeaBattleGame.Properties; // Импортируем свойства проекта SeaBattleGame
using System; // Импортируем базовые библиотеки .NET
using System.Collections.Generic; // Импортируем коллекции .NET
using System.Linq; // Импортируем LINQ для работы с коллекциями
using System.Windows.Forms; // Импортируем библиотеку для создания форм и управления ими

namespace SeaBattle // Объявляем пространство имен SeaBattle
{
    public class Board // Объявляем класс Board
    {
        public int Size { get; private set; } // Размер поля, доступен только для чтения
        public List<Ship> Ships { get; private set; } // Список кораблей на поле, доступен только для чтения
        public HashSet<Tuple<int, int>> Shots { get; private set; } // Набор координат, куда уже были сделаны выстрелы, доступен только для чтения
        private Random random; // Генератор случайных чисел

        public Board(int size) // Конструктор класса Board
        {
            Size = size; // Устанавливаем размер поля
            Ships = new List<Ship>(); // Инициализируем список кораблей
            Shots = new HashSet<Tuple<int, int>>(); // Инициализируем набор выстрелов
            random = new Random(); // Инициализируем генератор случайных чисел
        }

        public void AddShip(Ship ship) // Метод для добавления корабля на поле
        {
            Ships.Add(ship); // Добавляем корабль в список кораблей
        }

        public bool Shoot(Tuple<int, int> position) // Метод для обработки выстрела по указанной позиции
        {
            Shots.Add(position); // Добавляем позицию в набор выстрелов
            foreach (var ship in Ships) // Проходим по всем кораблям на поле
            {
                if (ship.Positions.Contains(position)) // Если координаты выстрела совпадают с позицией корабля
                {
                    ship.Hit(position); // Отмечаем попадание по кораблю
                    return true; // Возвращаем true, так как выстрел был успешным
                }
            }
            return false; // Возвращаем false, если выстрел был неудачным
        }

        public bool AreAllShipsSunk() // Метод для проверки, потоплены ли все корабли
        {
            return Ships.All(ship => ship.IsSunk); // Возвращаем true, если все корабли потоплены
        }

        public void PlaceShipsRandomly() // Метод для случайного размещения кораблей на поле
        {
            PlaceShipRandomly(Settings.Default.BattleshipCount, 4); // Размещаем линкоры
            PlaceShipRandomly(Settings.Default.SubmarineCount, 3); // Размещаем подводные лодки
            PlaceShipRandomly(Settings.Default.DestroyerCount, 2); // Размещаем эсминцы
            PlaceShipRandomly(Settings.Default.TorpedoBoatCount, 1); // Размещаем торпедные катера
        }

        private void PlaceShipRandomly(int count, int size) // Метод для случайного размещения корабля определенного размера
        {
            for (int i = 0; i < count; i++) // Проходим по количеству кораблей, которые нужно разместить
            {
                bool placed = false; // Флаг, указывающий на успешное размещение корабля
                int attempts = 0; // Счетчик попыток размещения

                while (!placed && attempts < 100) // Пытаемся разместить корабль, пока не удастся или не достигнем 100 попыток
                {
                    int row = random.Next(Size); // Генерируем случайную строку
                    int col = random.Next(Size); // Генерируем случайный столбец
                    bool horizontal = random.Next(2) == 0; // Случайным образом выбираем горизонтальное или вертикальное размещение

                    List<Tuple<int, int>> positions = new List<Tuple<int, int>>(); // Список для хранения позиций корабля
                    for (int j = 0; j < size; j++) // Проходим по размеру корабля
                    {
                        int r = row + (horizontal ? 0 : j); // Рассчитываем строку для текущей позиции корабля
                        int c = col + (horizontal ? j : 0); // Рассчитываем столбец для текущей позиции корабля
                        if (r >= Size || c >= Size || PositionsOccupied(r, c)) // Проверяем, выходит ли позиция за пределы поля или занята
                        {
                            positions.Clear(); // Очищаем список позиций, если размещение невозможно
                            break; // Прерываем цикл
                        }
                        positions.Add(Tuple.Create(r, c)); // Добавляем позицию в список
                    }

                    if (positions.Count == size) // Если удалось набрать нужное количество позиций для корабля
                    {
                        Ships.Add(new Ship(positions)); // Создаем новый корабль и добавляем его в список
                        placed = true; // Устанавливаем флаг успешного размещения
                    }
                    attempts++; // Увеличиваем счетчик попыток
                }

                if (!placed) // Если после 100 попыток не удалось разместить корабль
                {
                    MessageBox.Show($"Не удалось разместить корабль размером {size} после {attempts} попыток."); // Выводим сообщение об ошибке
                }
            }
        }

        private bool PositionsOccupied(int row, int col) // Метод для проверки, занята ли позиция на поле
        {
            foreach (var ship in Ships) // Проходим по всем кораблям
            {
                foreach (var pos in ship.Positions) // Проходим по всем позициям текущего корабля
                {
                    if (Math.Abs(pos.Item1 - row) <= 1 && Math.Abs(pos.Item2 - col) <= 1) // Если позиция находится в радиусе 1 клетки от заданной
                    {
                        return true; // Возвращаем true, так как позиция занята
                    }
                }
            }
            return false; // Возвращаем false, если позиция свободна
        }

        public bool ValidateShipPlacement(List<Tuple<int, int>> positions) // Метод для валидации размещения корабля
        {
            int length = positions.Count; // Получаем количество позиций
            if (length < 1 || length > 4) // Если количество позиций меньше 1 или больше 4
                return false; // Возвращаем false, так как размещение некорректно

            positions = positions.OrderBy(p => p.Item1).ThenBy(p => p.Item2).ToList(); // Сортируем позиции

            bool isHorizontal = positions.All(p => p.Item1 == positions[0].Item1); // Проверяем, все ли позиции находятся в одной строке
            bool isVertical = positions.All(p => p.Item2 == positions[0].Item2); // Проверяем, все ли позиции находятся в одном столбце

            if (!isHorizontal && !isVertical) // Если корабль не горизонтальный и не вертикальный
                return false; // Возвращаем false

            for (int i = 1; i < length; i++) // Проверяем расстояние между соседними позициями
            {
                int rowDiff = positions[i].Item1 - positions[i - 1].Item1; // Разница в строках между текущей и предыдущей позициями
                int colDiff = positions[i].Item2 - positions[i - 1].Item2; // Разница в столбцах между текущей и предыдущей позициями

                if ((isHorizontal && colDiff != 1) || (isVertical && rowDiff != 1)) // Если разница не равна 1
                    return false; // Возвращаем false, так как корабль размещен неправильно
            }

            foreach (var pos in positions) // Проверяем, заняты ли позиции на поле
            {
                if (PositionsOccupied(pos.Item1, pos.Item2)) // Если позиция занята
                    return false; // Возвращаем false
            }

            return true; // Возвращаем true, если все проверки пройдены
        }

        public void PlacePlayerShips(List<Tuple<int, int>> positions) // Метод для размещения кораблей игрока
        {
            Ships.Clear(); // Очищаем список кораблей
            var ships = GetShipsFromPositions(positions); // Получаем корабли из позиций

            foreach (var shipPositions in ships) // Проходим по всем кораблям
            {
                Ships.Add(new Ship(shipPositions)); // Добавляем корабль в список
            }
        }

        public List<List<Tuple<int, int>>> GetShipsFromPositions(List<Tuple<int, int>> positions) // Метод для получения кораблей из позиций
        {
            var ships = new List<List<Tuple<int, int>>>(); // Список для хранения кораблей
            var visited = new HashSet<Tuple<int, int>>(); // Набор для отслеживания посещенных позиций

            foreach (var position in positions) // Проходим по всем позициям
            {
                if (!visited.Contains(position)) // Если позиция не посещена
                {
                    var ship = new List<Tuple<int, int>>(); // Список для хранения позиций```csharp
                    var queue = new Queue<Tuple<int, int>>(); // Очередь для обхода соседних позиций
                    queue.Enqueue(position); // Добавляем текущую позицию в очередь

                    while (queue.Count > 0) // Пока очередь не пуста
                    {
                        var pos = queue.Dequeue(); // Извлекаем позицию из очереди
                        if (!visited.Contains(pos)) // Если позиция не посещена
                        {
                            visited.Add(pos); // Добавляем позицию в набор посещенных
                            ship.Add(pos); // Добавляем позицию в текущий корабль

                            var neighbors = GetNeighbors(pos, positions); // Получаем соседние позиции
                            foreach (var neighbor in neighbors) // Проходим по соседним позициям
                            {
                                if (!visited.Contains(neighbor)) // Если соседняя позиция не посещена
                                {
                                    queue.Enqueue(neighbor); // Добавляем соседнюю позицию в очередь
                                }
                            }
                        }
                    }

                    ships.Add(ship); // Добавляем текущий корабль в список кораблей
                }
            }

            return ships; // Возвращаем список кораблей
        }

        private List<Tuple<int, int>> GetNeighbors(Tuple<int, int> position, List<Tuple<int, int>> positions) // Метод для получения соседних позиций
        {
            var neighbors = new List<Tuple<int, int>>(); // Список для хранения соседних позиций

            if (positions.Contains(Tuple.Create(position.Item1 - 1, position.Item2))) // Если позиция выше текущей есть в списке позиций
                neighbors.Add(Tuple.Create(position.Item1 - 1, position.Item2)); // Добавляем ее в список соседних
            if (positions.Contains(Tuple.Create(position.Item1 + 1, position.Item2))) // Если позиция ниже текущей есть в списке позиций
                neighbors.Add(Tuple.Create(position.Item1 + 1, position.Item2)); // Добавляем ее в список соседних
            if (positions.Contains(Tuple.Create(position.Item1, position.Item2 - 1))) // Если позиция слева от текущей есть в списке позиций
                neighbors.Add(Tuple.Create(position.Item1, position.Item2 - 1)); // Добавляем ее в список соседних
            if (positions.Contains(Tuple.Create(position.Item1, position.Item2 + 1))) // Если позиция справа от текущей есть в списке позиций
                neighbors.Add(Tuple.Create(position.Item1, position.Item2 + 1)); // Добавляем ее в список соседних
            return neighbors; // Возвращаем список соседних позиций
        }

        public bool ValidateAllShips(List<List<Tuple<int, int>>> ships) // Метод для проверки корректности всех кораблей
        {
            int singleCellShips = ships.Count(ship => ship.Count == 1); // Считаем количество кораблей размером 1
            int doubleCellShips = ships.Count(ship => ship.Count == 2); // Считаем количество кораблей размером 2
            int tripleCellShips = ships.Count(ship => ship.Count == 3); // Считаем количество кораблей размером 3
            int quadrupleCellShips = ships.Count(ship => ship.Count == 4); // Считаем количество кораблей размером 4

            if (singleCellShips != Settings.Default.TorpedoBoatCount || // Если количество торпедных катеров не совпадает с настройками
                doubleCellShips != Settings.Default.DestroyerCount || // Если количество эсминцев не совпадает с настройками
                tripleCellShips != Settings.Default.SubmarineCount || // Если количество подводных лодок не совпадает с настройками
                quadrupleCellShips != Settings.Default.BattleshipCount) // Если количество линкоров не совпадает с настройками
            {
                return false; // Возвращаем false, если количество кораблей не соответствует настройкам
            }

            foreach (var ship in ships) // Проходим по всем кораблям
            {
                if (!ValidateShipPlacement(ship)) // Если размещение корабля некорректно
                {
                    return false; // Возвращаем false
                }
            }

            return true; // Возвращаем true, если все корабли размещены корректно
        }

        public int GetHitCount() // Метод для получения количества попаданий
        {
            return Ships.Sum(ship => ship.Hits.Count); // Суммируем количество попаданий по всем кораблям
        }
    }
}
