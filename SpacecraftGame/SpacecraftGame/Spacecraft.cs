using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpacecraftGame
{
    internal class Spacecraft
    {
        public float Health { get; set; }
        public Point Position { get; set; }
        public ConsoleColor Color { get; set; }
        public Window WindowC { get; set; }
        public List<Point> PositionsSpacecraft { get; set; }
        public List<Bullet> Bullets { get; set; }
        public float Overload { get; set; }
        public bool OverloadCond { get; set; }
        public float SpecialBullet { get; set; }

        public Spacecraft(Point position, ConsoleColor color, Window window) 
        { 
            Position = position;
            Color = color;
            WindowC = window;
            Health = 100;
            PositionsSpacecraft = new List<Point>();
            Bullets = new List<Bullet>();
        }

        public void Draw() 
        {
            Console.ForegroundColor = Color;
            int x = Position.X;
            int y = Position.Y;

            Console.SetCursorPosition(x + 3, y);
            Console.Write("A");

            Console.SetCursorPosition(x + 1, y + 1);
            Console.Write("<{X}>");

            Console.SetCursorPosition(x, y + 2);
            Console.Write("± W W ±");

            PositionsSpacecraft.Clear();

            PositionsSpacecraft.Add(new Point(x + 3, y));

            PositionsSpacecraft.Add(new Point(x + 1, y + 1));
            PositionsSpacecraft.Add(new Point(x + 2, y + 1));
            PositionsSpacecraft.Add(new Point(x + 3, y + 1));
            PositionsSpacecraft.Add(new Point(x + 4, y + 1));
            PositionsSpacecraft.Add(new Point(x + 5, y + 1));

            PositionsSpacecraft.Add(new Point(x, y + 2));
            PositionsSpacecraft.Add(new Point(x + 2, y + 2));
            PositionsSpacecraft.Add(new Point(x + 4, y + 2));
            PositionsSpacecraft.Add(new Point(x + 6, y + 2));
        }

        public void Clear()
        {
            foreach (Point item in PositionsSpacecraft)
            {
                Console.SetCursorPosition(item.X, item.Y);
                Console.Write(" ");
            }
        }

        public void Keyboard(ref Point distance, int velocity)
        {
            ConsoleKeyInfo key = Console.ReadKey(true);

            if (key.Key == ConsoleKey.W)
                distance = new Point(0, -1);
            if (key.Key == ConsoleKey.S)
                distance = new Point(0, 1);
            if (key.Key == ConsoleKey.D)
                distance = new Point(1, 0);
            if (key.Key == ConsoleKey.A)
                distance = new Point(-1, 0);

            distance.X *= velocity;
            distance.Y *= velocity;

            if (key.Key == ConsoleKey.RightArrow)
            {
                if (!OverloadCond)
                {
                    Bullet bullet = new Bullet(new Point(Position.X + 6, Position.Y + 2),
                    ConsoleColor.Yellow, BulletType.Basic);
                    Bullets.Add(bullet);
                    Overload += 1.0f;

                    if (Overload >= 100)
                    {
                        OverloadCond = true;
                        Overload = 100;
                    }                       
                }              
            }
            if (key.Key == ConsoleKey.LeftArrow)
            {
                if (!OverloadCond)
                {
                    Bullet bullet = new Bullet(new Point(Position.X, Position.Y + 2),
                    ConsoleColor.Yellow, BulletType.Basic);
                    Bullets.Add(bullet);

                    Overload += 1.0f;
                    if (Overload >= 100)
                    {
                        OverloadCond = true;
                        Overload = 100;
                    }              
                }
            }

            if (key.Key == ConsoleKey.UpArrow)
            {
                if (SpecialBullet >= 100)
                {
                    Bullet bullet = new Bullet(new Point(Position.X + 2, Position.Y - 2),
                        ConsoleColor.Red, BulletType.Special);
                    Bullets.Add(bullet);
                    SpecialBullet = 0;
                }
            }
        }

        public void Collisions(Point distance)
        {
            Point positionAux = new Point(Position.X + distance.X, Position.Y + distance.Y);
            if (positionAux.X <= WindowC.UpperLimit.X)
                positionAux.X = WindowC.UpperLimit.X + 1;
            if (positionAux.X + 6 >= WindowC.LowerLimit.X)
                positionAux.X = WindowC.LowerLimit.X - 7;
            if (positionAux.Y <= (WindowC.UpperLimit.Y) + 15)
                positionAux.Y = (WindowC.UpperLimit.Y + 1) + 15;
            if (positionAux.Y + 2 >= WindowC.LowerLimit.Y)
                positionAux.Y = WindowC.LowerLimit.Y - 3;

            Position = positionAux;
        }

        public void Information()
        {
            Console.ForegroundColor = ConsoleColor.White;
            Console.SetCursorPosition(WindowC.UpperLimit.X, WindowC.UpperLimit.Y - 1);
            Console.Write("Health: " + (int)Health + " %  ");

            if (Overload <= 0)
                Overload = 0;
            else
                Overload -= 0.0007f;

            if (Overload <= 50)
                OverloadCond = false;
            
            if (OverloadCond)
                Console.ForegroundColor = ConsoleColor.Red;
            else
                Console.ForegroundColor = ConsoleColor.White;

            Console.SetCursorPosition(WindowC.UpperLimit.X + 17, WindowC.UpperLimit.Y - 1);
            Console.Write("Overload: " + (int)Overload + " %  ");

            Console.ForegroundColor= ConsoleColor.White;
            Console.SetCursorPosition(WindowC.UpperLimit.X + 35, WindowC.UpperLimit.Y - 1);
            Console.Write("Special Bullet: " + (int)SpecialBullet + " %  ");

            if (SpecialBullet >= 100)
                SpecialBullet = 100;
            else
                SpecialBullet += 0.0007f;
        }

        public void Move(int velocity) 
        { 
            if (Console.KeyAvailable)
            {
                Clear();
                Point distance = new Point();
                Keyboard(ref distance, velocity);
                Collisions(distance);
                Draw();
            }
            Information();
        }

        public void Shoot()
        {
            for (int i = 0; i < Bullets.Count; i++)
            {
                if (Bullets[i].Move(1, WindowC.UpperLimit.Y))
                {
                    Bullets.Remove(Bullets[i]);
                }
            }
        }

        public void Die()
        {
            Console.ForegroundColor = Color;
            foreach(Point item  in PositionsSpacecraft)
            {
                Console.SetCursorPosition(item.X, item.Y);
                Console.Write("░");
                Thread.Sleep(200);
            }

            foreach (Point item in PositionsSpacecraft)
            {
                Console.SetCursorPosition(item.X, item.Y);
                Console.Write(" ");
                Thread.Sleep(200);
            }
        }
    }
}
