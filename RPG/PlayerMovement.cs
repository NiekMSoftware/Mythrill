using RPG.exceptions;

namespace RPG
{
    public class PlayerMovement
    {
        private const char PlayerChar = '@';
        private const int Delay = 16;

        private int x = 0;
        private int y = 0;

        public void Start()
        {
            Console.CursorVisible = false;

            Console.Clear();
            WritePlayer();

            while (true)
            {
                HandleInput();
                Thread.Sleep(Delay);
            }
        }

        private void HandleInput()
        {
            if (Console.KeyAvailable)
            {
                var key = Console.ReadKey(intercept: true).Key;

                switch (key)
                {
                    case ConsoleKey.DownArrow:
                        Move(0, 1);
                        break;
                    case ConsoleKey.UpArrow:
                        Move(0, -1);
                        break;
                    case ConsoleKey.LeftArrow:
                        Move(-1, 0);
                        break;
                    case ConsoleKey.RightArrow:
                        Move(1, 0);
                        break;
                    case ConsoleKey.Escape:
                        Environment.Exit(0);
                        break;
                }
            }
        }

        private void Move(int deltaX, int deltaY)
        {
            // update the player pos
            x += deltaX;
            y += deltaY;

            // check boundaries
            if(x < 0) x = 0;
            if(y < 0) y = 0;

            // get the window dimensions
            int windowWidth = Console.WindowWidth;
            int windowHeight = Console.WindowHeight;

            // check right and bottom boundaries
            if (x >= windowWidth) x = windowWidth - 1;
            if (y >= windowHeight) y = windowHeight - 1;

            // Redraw player
            Console.Clear();
            WritePlayer();
        }

        private void WritePlayer()
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.SetCursorPosition(x, y);
            Console.Write(PlayerChar);
            Console.ResetColor();
        }
    }
}