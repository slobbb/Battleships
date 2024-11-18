using System;
using System.Collections.Generic;
using System.Linq;

namespace SeaBattle
{
    // Класс Game управляет основными аспектами игры
    public class Game
    {
        // Игровая доска игрока
        public Board PlayerBoard { get; private set; }

        // Игровая доска компьютера
        public Board ComputerBoard { get; private set; }

        // Свойство, указывающее, закончена ли игра
        public bool IsGameOver => PlayerBoard.AreAllShipsSunk() || ComputerBoard.AreAllShipsSunk();

        // Очки игрока, считающиеся по количеству попаданий по кораблям компьютера
        public int PlayerScore => ComputerBoard.Ships.Sum(ship => ship.Hits.Count);

        // Очки компьютера, считающиеся по количеству попаданий по кораблям игрока
        public int ComputerScore => PlayerBoard.Ships.Sum(ship => ship.Hits.Count);

        // Конструктор класса Game, принимает размер доски
        public Game(int boardSize)
        {
            PlayerBoard = new Board(boardSize); // Создание доски игрока
            ComputerBoard = new Board(boardSize); // Создание доски компьютера
        }

        // Метод для выполнения выстрела игрока по позиции на доске компьютера
        public bool PlayerShoot(Tuple<int, int> position)
        {
            return ComputerBoard.Shoot(position); // Возвращает результат выстрела (попадание или промах)
        }

        // Метод для выполнения выстрела компьютера по позиции на доске игрока
        public bool ComputerShoot(Tuple<int, int> position)
        {
            return PlayerBoard.Shoot(position); // Возвращает результат выстрела (попадание или промах)
        }

        // Метод для размещения кораблей игрока
        public void PlacePlayerShips(List<Tuple<int, int>> positions)
        {
            PlayerBoard.PlacePlayerShips(positions); // Размещение кораблей на доске игрока
        }
    }
}
