using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Security.Cryptography.X509Certificates;

namespace SpacecraftGame
{   public enum BulletType
    {
        Basic, Special
    }
    internal class Bullet
    {
        public Point Position { get; set; }
        public ConsoleColor Color { get; set; }
        public BulletType BulletTypeB {  get; set; }
        public List<Point> BulletPositions { get; set; }
        private DateTime _time;
        public Bullet (Point position, ConsoleColor color, BulletType bulletType)
        {
            Position = position;
            Color = color;
            BulletTypeB = bulletType;
            BulletPositions = new List<Point> ();
            _time = DateTime.Now;
        }

        public void Draw()
        {
            Console.ForegroundColor = Color;
            int x = Position.X;
            int y = Position.Y;

            BulletPositions.Clear ();

            switch (BulletTypeB)
            {
                case BulletType.Basic:
                    Console.SetCursorPosition(x, y);
                    Console.Write("║");
                    BulletPositions.Add(new Point(x, y));
                    break;
                case BulletType.Special:
                    Console.SetCursorPosition(x, y);
                    Console.Write("▄█▄");
                    Console.SetCursorPosition(x, y + 1);
                    Console.Write("███");
                    Console.SetCursorPosition (x + 1, y + 2);
                    Console.Write("▀");

                    BulletPositions.Add(new Point(x, y));
                    BulletPositions.Add(new Point(x + 1, y));
                    BulletPositions.Add(new Point(x + 2, y));

                    BulletPositions.Add(new Point(x, y + 1));
                    BulletPositions.Add(new Point(x + 1, y + 1));
                    BulletPositions.Add(new Point(x + 2, y + 1));

                    BulletPositions.Add(new Point(x + 1, y + 2));
                    break;
            }

        }
        public void Clear()
        {
            foreach (Point item in BulletPositions)
            {
                Console.SetCursorPosition(item.X, item.Y);
                Console.Write(" ");
            }

        }

        public bool Move(int velocity, int limit)
        { 
            if (DateTime.Now > _time.AddMilliseconds(30))
            {
                Clear();

                switch (BulletTypeB)
                {
                    case BulletType.Basic:
                        Position = new Point(Position.X, Position.Y - velocity);
                        if (Position.Y <= limit)
                            return true;
                        break;
                    case BulletType.Special:
                        Position = new Point(Position.X, Position.Y - velocity);
                        if (Position.Y <= limit)
                            return true;
                        break;
                }
                Draw();
                _time = DateTime.Now;
            }
            return false;
        }
    }
}
