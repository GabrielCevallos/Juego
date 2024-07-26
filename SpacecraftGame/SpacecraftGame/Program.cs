using SpacecraftGame;
using System.Drawing;
/*
 * MaxSize of console window
Console.WriteLine("Max. Witdh: " + Console.LargestWindowWidth);     -> 1904
Console.WriteLine("Max. Height: " + Console.LargestWindowHeight);   -> 61
Console.SetCursorPosition(7, 7);
Console.Write("HelloWorld!");   -> Text starts from the (7, 7) position
*/

Window window;
Spacecraft spacecraft;
Enemy enemy1;
Enemy enemy2;
Enemy finalBoss;

bool play = true;
void Start()
{
    window = new Window(900, 61, ConsoleColor.Black, new Point(5, 3), new Point(115, 29));
    window.DrawFrame();

    spacecraft = new Spacecraft(new Point(80, 15), ConsoleColor.Magenta, window);
    spacecraft.Draw();

    enemy1 = new Enemy(new Point(50, 10), ConsoleColor.Red, window, EnemyType.Normal);
    enemy1.Draw();

    enemy2 = new Enemy(new Point(25, 10), ConsoleColor.Yellow, window, EnemyType.Normal);
    enemy2.Draw();

    finalBoss = new Enemy(new Point(70, 10), ConsoleColor.White, window, EnemyType.FinalBoss);
    finalBoss.Draw();
}

void Game()
{
    while (play)
    {
        spacecraft.Move(2);
        spacecraft.Shoot();
        if (spacecraft.Health <= 0)
        {
            play = false;
            spacecraft.Die();
        }
    }
}
Start();
Game();
Console.ReadKey();  //Window is active until a key is typed
