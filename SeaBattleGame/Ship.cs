using System;
using System.Collections.Generic;

namespace SeaBattle
{
    // Класс Ship представляет корабль и управляет его состоянием
    public class Ship
    {
        // Позиции, занимаемые кораблем на доске
        public List<Tuple<int, int>> Positions { get; private set; }

        // Позиции, в которые попали выстрелы
        public List<Tuple<int, int>> Hits { get; private set; }

        // Свойство, которое возвращает true, если корабль потоплен (все его позиции были подбиты)
        public bool IsSunk => Hits.Count == Positions.Count;

        // Свойство, которое возвращает размер корабля
        public int Size => Positions.Count;

        // Конструктор класса Ship, принимает список позиций, занимаемых кораблем
        public Ship(List<Tuple<int, int>> positions)
        {
            Positions = positions; // Инициализация позиций корабля
            Hits = new List<Tuple<int, int>>(); // Инициализация списка попаданий
        }

        // Метод для обработки попадания в корабль
        public void Hit(Tuple<int, int> position)
        {
            // Если позиция корабля была подбита и не была учтена ранее, добавляем её в список попаданий
            if (Positions.Contains(position) && !Hits.Contains(position))
            {
                Hits.Add(position); // Добавление позиции в список попаданий
            }
        }
    }
}
