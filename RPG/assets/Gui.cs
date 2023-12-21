namespace RPG.assets
{
    public class Gui
    {
        public static void GameTitle(string title)
        {
            Console.ForegroundColor = ConsoleColor.Red;

            Console.WriteLine("=== " + title + " ===\n\n");

            Console.ResetColor();
        }

        public static void GameState(string state)
        {
            Console.ForegroundColor = ConsoleColor.Green;

            Console.WriteLine("=== " + state);

            Console.ResetColor();
        }

        public static void ShowOptions(int value, string option)
        {
            Console.WriteLine(value + $") {option}");
        }

        public static int GetInput(string prompt)
        {
            var input = -10;

            Console.Write(prompt);

            while (input == -10)
            {
                try
                {
                    input = Convert.ToInt32(Console.ReadLine());
                }
                catch (FormatException)
                {
                    Console.Write("No valid input, please enter integer values.\n" +
                                      $"{prompt}");
                }
            }

            return input;
        }
    }
}