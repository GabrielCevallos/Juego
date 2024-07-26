using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpacecraftGame
{
    public enum EnemyType
    {
        Normal, FinalBoss
    }
    internal class Enemy
    {
        public bool Alive { get; set; }
        public float  Health { get; set; }
        public Point Position { get; set; }
        public Window WindowC { get; set; }
        public ConsoleColor Color { get; set; }
        public EnemyType EnemyTypeE { get; set; }
        public List<Point> EnemyPositions { get; set; }
        public Enemy(Point position, ConsoleColor color, Window window, EnemyType enemyType)
        {
            Position = position;
            Color = color;
            WindowC = window;
            EnemyTypeE = enemyType;
            Alive = true;
            Health = 100;
            EnemyPositions = new List<Point>();
        }

        public void Draw()
        {
            switch (EnemyTypeE)
            {
                case EnemyType.Normal:
                    NormalDraw();
                break;
                case EnemyType.FinalBoss:
                    BossDraw();
                break;
            }
        }

        public void NormalDraw()
        {
            Console.ForegroundColor = Color;
            int x = Position.X;
            int y = Position.Y;

            Console.SetCursorPosition(x + 1, y);
            Console.Write("▀▄▄▄▀");
            Console.SetCursorPosition(x + 1, y + 1);
            Console.Write("█▀█▀█");
            Console.SetCursorPosition(x + 1, y + 2);
            Console.Write("█████");
            Console.SetCursorPosition(x, y + 3);
            Console.Write("█ █ █ █");

            EnemyPositions.Clear();

            EnemyPositions.Add(new Point(x + 1, y));
            EnemyPositions.Add(new Point(x + 5, y));

            EnemyPositions.Add(new Point(x + 2, y + 1));
            EnemyPositions.Add(new Point(x + 3, y + 1));
            EnemyPositions.Add(new Point(x + 4, y + 1));

            EnemyPositions.Add(new Point(x + 1, y + 2));
            EnemyPositions.Add(new Point(x + 2, y + 2));
            EnemyPositions.Add(new Point(x + 3, y + 2));
            EnemyPositions.Add(new Point(x + 4, y + 2));
            EnemyPositions.Add(new Point(x + 5, y + 2));

            EnemyPositions.Add(new Point(x + 1, y + 3));
            EnemyPositions.Add(new Point(x + 2, y + 3));
            EnemyPositions.Add(new Point(x + 3, y + 3));
            EnemyPositions.Add(new Point(x + 4, y + 3));
            EnemyPositions.Add(new Point(x + 5, y + 3));

            EnemyPositions.Add(new Point(x, y + 4));
            EnemyPositions.Add(new Point(x + 2, y + 4));
            EnemyPositions.Add(new Point(x + 4, y + 4));
            EnemyPositions.Add(new Point(x + 6, y + 4));
        }

        public void BossDraw()
        {
            Console.ForegroundColor= Color;
            int x = Position.X;
            int y = Position.Y;

            Console.SetCursorPosition(x + 2, y);
            Console.Write("▀▄  ▄▀");
            Console.SetCursorPosition(x + 1, y + 1);
            Console.Write("▄█▀██▀█▄");
            Console.SetCursorPosition(x, y + 2);
            Console.Write("█▀██████▀█");
            Console.SetCursorPosition(x + 2, y + 3);
            Console.Write("▄▀  ▀▄");
            
            EnemyPositions.Clear();

            EnemyPositions.Add(new Point(x + 2, y));
            EnemyPositions.Add(new Point(x + 3, y));
            EnemyPositions.Add(new Point(x + 6, y));
            EnemyPositions.Add(new Point(x + 7, y));

            EnemyPositions.Add(new Point(x + 1, y + 1));
            EnemyPositions.Add(new Point(x + 2, y + 1));
            EnemyPositions.Add(new Point(x + 3, y + 1));
            EnemyPositions.Add(new Point(x + 4, y + 1));
            EnemyPositions.Add(new Point(x + 5, y + 1));
            EnemyPositions.Add(new Point(x + 6, y + 1));
            EnemyPositions.Add(new Point(x + 7, y + 1));
            EnemyPositions.Add(new Point(x + 8, y + 1));

            EnemyPositions.Add(new Point(x, y + 2));
            EnemyPositions.Add(new Point(x + 1, y + 2));
            EnemyPositions.Add(new Point(x + 2, y + 2));
            EnemyPositions.Add(new Point(x + 3, y + 2));
            EnemyPositions.Add(new Point(x + 4, y + 2));
            EnemyPositions.Add(new Point(x + 5, y + 2));
            EnemyPositions.Add(new Point(x + 6, y + 2));
            EnemyPositions.Add(new Point(x + 7, y + 2));
            EnemyPositions.Add(new Point(x + 8, y + 2));
            EnemyPositions.Add(new Point(x + 9, y + 2));

            EnemyPositions.Add(new Point(x + 2, y + 3));
            EnemyPositions.Add(new Point(x + 3, y + 3));
            EnemyPositions.Add(new Point(x + 6, y + 3));
            EnemyPositions.Add(new Point(x + 7, y + 3));
        }

        public void Clear()
        {
            foreach (Point item in EnemyPositions)
            {
                Console.SetCursorPosition(item.X, item.Y);
                Console.Write(" ");
            }
        }
    } 
}
