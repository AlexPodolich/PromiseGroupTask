class Program
{
   static void Main(string[] args)
   {
        OrderService orderService = new OrderService();

        Console.WriteLine("Welcome to the Order Processing System!");
        Console.WriteLine();

        while (true)
        {
            Console.WriteLine("Select what operation do you want to choose:");
            Console.WriteLine("1. Create a sample order");
            Console.WriteLine("2. Send an order to warehouse");
            Console.WriteLine("3. Send an order to shipping");
            Console.WriteLine("4. Exit");

            Console.Write($"Your choice: ");
            string input = Console.ReadLine();

            Console.WriteLine($"Your choice: {input}");

            // Check if the input is a valid option
            if (!int.TryParse(input, out int option) || option < 1 || option > 4)
            {
                Console.WriteLine("Invalid input! Enter a value between 1 and 4. Try again.");
                Console.WriteLine();
                continue;
            }
            switch (option)
            {
                case 1:
                    orderService.CreateSampleOrder();
                    break;
                case 2:
                    orderService.SendOrderToWarehouse();
                    break;
                case 3:
                    orderService.SendOrderToShipping();
                    break;
                case 4:
                    Console.WriteLine("Thanks for visiting! Goodbye!");
                    return; // Exit the application
            }

            Console.WriteLine();
        }
   } 
}