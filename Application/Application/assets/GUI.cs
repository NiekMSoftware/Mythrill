namespace Application.assets
{
    public class GUI
    {
        public static string GameTitle(string title) => $"=== {title} ===\n\n";
        public static string Selection(int index, string prompt) => $"{index}) {prompt}\n";
        public static string Title(string title) => $"=== {title}\n";

        public static int GetInput(string log) {
            int input = -10;
            
            Console.Write(log);

            while (input == -10) {
                // Try to convert the input to an integer
                try {
                    input = Convert.ToInt32(Console.ReadLine());
                }
                catch (FormatException e) {
                    Console.WriteLine("Invalid format!" +
                                      "\nPlease enter the correct format to continue!");
                }
            }

            return input;
        }
    }
}