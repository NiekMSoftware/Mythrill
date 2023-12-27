namespace RPG
{
    public class InputSystem
    {
        public static int GetPlayerDecision(string prompt)
        {
            const int uninitialized = -1;
            int input = uninitialized;

            Console.Write(prompt);

            while (input == uninitialized)
            {
                try
                {
                    input = Convert.ToInt32(Console.ReadLine());
                }
                catch (FormatException)
                {
                    Console.WriteLine("Invalid index.");
                    Console.Write(prompt);
                }
            }
            
            return input;
        }

        public static int GetAiDecision()
        {
            Random random = new Random();
            return random.Next(1, 4);
        }
    }
}