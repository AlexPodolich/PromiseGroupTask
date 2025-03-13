class Program
{
   static void Main(string[] args)
   {
        OrderService orderService = new OrderService();

        Console.WriteLine("Welcome to the Order Processing System!");


        while (true)
        {
            Console.WriteLine("Select what operation do you want to choose:");
            Console.WriteLine("1. Create a sample order");
            Console.WriteLine("2. Exit");

            string input = Console.ReadLine();

            // Check if the input is a valid option (1-8)
            if (!int.TryParse(input, out int option) || option < 1 || option > 2)
            {
                Console.WriteLine("Invalid input! Enter a value between 1 and 2. Try again.");
                Console.WriteLine();
                continue;
            }
            switch (option)
            {
                case 1:
                    orderService.CreateSampleOrder();
                    break;
                case 2:
                    return; // Exit the application
            }

            Console.WriteLine();
        }
   } 
}