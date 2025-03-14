namespace OrderApp
{
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
                Console.WriteLine("4. View Orders");
                Console.WriteLine("5. Apply Discount to an Order");
                Console.WriteLine("6. Cancel an Order");
                Console.WriteLine("7. Exit");

                Console.Write($"Your choice: ");
                string input = Console.ReadLine();

                // Check if the input is a valid option
                if (!int.TryParse(input, out int option) || option < 1 || option > 7)
                {
                    Console.WriteLine("Invalid input! Enter a value between 1 and 7. Try again.");
                    Console.WriteLine();
                    continue;
                }
                switch (option)
                {
                    case 1:
                        Console.WriteLine("Starting to create an order...");
                        orderService.CreateSampleOrder();
                        break;
                    case 2:
                        Console.WriteLine("Preparing to send order to warehouse...");
                        orderService.SendOrderToWarehouse();
                        break;
                    case 3:
                        Console.WriteLine("Preparing to send order to shipping...");
                        orderService.SendOrderToShipping();
                        break;
                    case 4:
                        Console.WriteLine("Fetching orders...");
                        orderService.ViewOrders();
                        break;
                    case 5:
                        Console.WriteLine("Preparing to apply discount to an order...");
                        orderService.ApplyDiscountToOrder();
                        break;
                    case 6:
                        Console.WriteLine("Preparing to cancel an order...");
                        orderService.CancelOrder();
                        break;
                    case 7:
                        Console.WriteLine("Thanks for visiting! Goodbye!");
                        return; // Exit the application
                }

                Console.WriteLine();
            }
    } 
    }
}