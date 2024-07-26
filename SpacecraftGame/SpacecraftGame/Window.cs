using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpacecraftGame
{
    internal class Window
    {   
        //Console Window Size
        public int Width { get; set; }
        public int Height { get; set; }
        //Color
        public ConsoleColor Color { get; set; }

        //Videogame frame
        public Point UpperLimit { get; set; }
        public Point LowerLimit { get; set; }


        //Constructor
        public Window(int width, int height, ConsoleColor color, Point upperLimit, Point lowerLimit) 
        {
            Width = width;
            Height = height;
            Color = color;
            UpperLimit = upperLimit;
            LowerLimit = lowerLimit;

            Init();
        }
        //Initialize the console window
        private void Init()
        {
            Console.SetWindowSize(Width, Height);   //Number of characters in the console window
            Console.Title = "Spacecraft Game";
            Console.CursorVisible = false;  //Cursor disappears
            Console.BackgroundColor = Color;
            Console.Clear();    //Clear the console buffer
        }
        //Draw the videogame frame
        public void DrawFrame() 
        {   
            Console.ForegroundColor = ConsoleColor.DarkBlue;
            for (int i = UpperLimit.X; i <= LowerLimit.X; i++)
            {
                Console.SetCursorPosition(i, UpperLimit.Y);
                Console.Write("═");
                Console.SetCursorPosition(i, LowerLimit.Y);
                Console.Write("═");
            }

            for (int i = UpperLimit.Y; i <= LowerLimit.Y; i++)
            {
                Console.SetCursorPosition(UpperLimit.X, i);
                Console.Write("║");
                Console.SetCursorPosition(LowerLimit.X, i);
                Console.Write("║");
            }
            
            Console.SetCursorPosition(UpperLimit.X, UpperLimit.Y);
            Console.Write("╔");
            Console.SetCursorPosition(UpperLimit.X, LowerLimit.Y);
            Console.Write("╚");
            Console.SetCursorPosition(LowerLimit.X, UpperLimit.Y);
            Console.Write("╗");
            Console.SetCursorPosition(LowerLimit.X, LowerLimit.Y);
            Console.Write("╝");
        }
    }
}
