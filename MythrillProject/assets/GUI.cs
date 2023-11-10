namespace MythrillProject.assets
{
    public class GUI
    {
        // TODO: Change the return type from string to void at a later point
        public static string GameTitle(string title) => $"=== {title} ===\n\n";
        public static string StateOptions(int index, string opt) => $"{index}) {opt}\n";
        public static string StateName(string name) => $"=== {name}\n";
        
        // Create a method to gather input
        public static int GetInput(string prompt) {
            // Create a local integer for the inputs
            int input = -10;

            // Write out the prompt
            Console.Write(prompt);

            while (input == -10) {
                // Try to catch an new input
                try {
                    input = Convert.ToInt32(Console.ReadLine());
                    break;
                }
                catch (FormatException message) {
                    // Catch custom exception and deploy a message
                    Console.WriteLine(message);
                }
            }

            // Return the given input
            return input;
        }
    }
}