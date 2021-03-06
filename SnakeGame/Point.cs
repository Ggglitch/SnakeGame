﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace SnakeGame
{
    class Point : Colored
    {
        // Координаты точки
        internal int X { get; set; }
        internal int Y { get; set; }
        // Символ точки
        internal char Ch { get; set; }

        public Point()
        {

        }

        public Point(int x, int y, char ch)
        {
            X = x;
            Y = y;
            Ch = ch;
        }

        // Клонирование точки
        public Point(Point p)
        {
            X = p.X;
            Y = p.Y;
            Ch = p.Ch;
        }

        // Рисование точки
        public void Draw()
        {
            Console.SetCursorPosition(X, Y);
            Console.BackgroundColor = bgColor;
            Console.ForegroundColor = fgColor;
            Console.Write(Ch);
            Console.ResetColor();
        }

        // Стирание точки
        public void Undraw()
        {
            Console.SetCursorPosition(X, Y);
            Console.BackgroundColor = bgColor;
            Console.ForegroundColor = fgColor;
            Console.Write(' ');
            Console.ResetColor();
        }

        // Смещение точки на offset пунктов в заданном направлении
        public void Move(int offset, Direction direction)
        {
            switch (direction)
            {
                case Direction.Right:
                    X += offset;
                    break;
                case Direction.Left:
                    X -= offset;
                    break;
                case Direction.Down:
                    Y += offset;
                    break;
                case Direction.Up:
                    Y -= offset;
                    break;
                default:
                    break;
            }
        }

        // Проверка столкновений с точкой
        public bool IsHit(Point p)
        {
            return p.X == X && p.Y == Y;
        }

        // Перегрузка операторов
        public static Point operator +(Point p1, Point p2)
        {
            return new Point(p1.X + p2.X, p1.Y + p2.Y, p1.Ch);
        }

        public static Point operator -(Point p1, Point p2)
        {
            return new Point(p1.X - p2.X, p1.Y - p2.Y, p1.Ch);
        }

        public override string ToString()
        {
            return X + ", " + Y + ", " + Ch;
        }
    }
}
