namespace MythrillRPG.classes.user_interface
{
    /* GUI class needs to have the following:
     * - static void to show Title
     * - (OPTIONAL) static void to show State Name
     * - static void to show which options the player has
     * - static int to gather the input without an exception occurring
     */

    public class GUI
    {
        // static void GameTitle will have a string as parameter
            // reason on being it called void is due to coloring
            // of the font at a later moment
        public static void GameTitle(string title)
        {
            // OPTIONAL: Make this ASCII
            Console.WriteLine($"=== {title} ===");
        }

        // Show what the options are that the player has
        public static void PlayerOptions(int index, string option)
        {
            Console.WriteLine($"{index}) {option}");
        }

        // Function to gather input of the player
        public static int GetInput(string prompt)
        {
            // Create a local int input
            int input = -10;

            // Write out the prompt, this will probably be: '>'
            Console.Write(prompt);

            // Use the input integer in a loop
            while (input == -10)
            {
                // try catching the input without exception
                try
                {
                    // Save the input
                    input = Convert.ToInt32(Console.ReadLine());
                }
                catch (FormatException e)
                {
                    // Write out an error
                    Console.WriteLine($"Input was in the wrong format!\n" +
                                      $"Please enter a valid input.");
                }
            }

            // return input
            return input;
        }
    }
}