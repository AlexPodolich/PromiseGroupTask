namespace OrderApp
{
    public class OrderService
    {
        private List<Order> orders = new List<Order>();
        private int orderIdCounter = 1;

        public void CreateSampleOrder()
        {
            try{
                decimal orderAmount;

                Console.Write("Enter order amount: ");

                // Validate Order Amount
                while (!decimal.TryParse(Console.ReadLine(), out orderAmount) || orderAmount <= 0)
                {
                    Console.WriteLine("Invalid input. Please enter a valid order amount greater than zero.");
                    Console.Write("Enter order amount: ");
                }

                Console.Write("Enter product name: ");
                string productName = Console.ReadLine();
                
                // Validate Product Name
                while (string.IsNullOrWhiteSpace(productName))
                {
                    Console.WriteLine("Product name cannot be empty.");
                    Console.Write("Enter product name: ");
                    productName = Console.ReadLine();
                }

                Console.Write("Enter customer type (Company/Individual): ");
                string customerTypeInput = Console.ReadLine();

                CustomerType customerType;

                // Validate Customer Type
                while (!Enum.TryParse(customerTypeInput, true, out customerType) || !Enum.IsDefined(typeof(CustomerType), customerType))
                {
                    Console.WriteLine("Invalid customer type. Please enter 'Company' or 'Individual'.");
                    Console.Write("Enter customer type (Company/Individual): ");
                    customerTypeInput = Console.ReadLine();
                }


                Console.Write("Enter delivery address: ");
                string deliveryAddress = Console.ReadLine();

                // Validate Delivery Address
                while (string.IsNullOrWhiteSpace(deliveryAddress))
                {
                    Console.WriteLine("Delivery address cannot be empty.");
                    Console.Write("Enter delivery address: ");
                    deliveryAddress = Console.ReadLine();
                }

                Console.Write("Enter payment method (Card/CashOnDelivery): ");
                string paymentMethodInput = Console.ReadLine();

                PaymentMethod paymentMethod;
                // Validate Payment Method
                while (!Enum.TryParse(paymentMethodInput, true, out paymentMethod) || !Enum.IsDefined(typeof(PaymentMethod), paymentMethod))
                {
                    Console.WriteLine("Invalid payment method. Please enter 'Card' or 'CashOnDelivery'.");
                    Console.Write("Enter payment method (Card/CashOnDelivery): ");
                    paymentMethodInput = Console.ReadLine();
                }

                // Create the order
                Order newOrder = new Order(orderIdCounter++, orderAmount, productName, customerType, deliveryAddress, paymentMethod);
                orders.Add(newOrder);

                Console.WriteLine($"Order created with ID: {newOrder.Id}");
            }catch (Exception ex)
            {
                Console.WriteLine($"Error creating order: {ex.Message}");
            }
        }

        public void SendOrderToWarehouse(){
            try
            {
                Console.Write("Enter order ID to send to warehouse: ");
                // Validate ID
                if (!int.TryParse(Console.ReadLine(), out int orderId))
                {
                    Console.WriteLine("Invalid order ID. Please enter a valid integer.");
                    return;
                }

                // Find the order by ID
                Order order = orders.Find(o => o.Id == orderId);
                if (order == null)
                {
                    Console.WriteLine("Order not found.");
                    return;
                }

                // Check if the order is already in the warehouse
                if (order.Status == OrderStatus.InWarehouse)
                {
                    Console.WriteLine("Order is already in the warehouse.");
                    return;
                }

                // Check if the order meets the business condition for cash on delivery
                if (order.PaymentMethod == PaymentMethod.CashOnDelivery && order.OrderAmount >= 2500)
                {
                    // Return the order to the customer
                    order.UpdateStatus(OrderStatus.ReturnedToCustomer);
                    Console.WriteLine("Order returned to customer due to cash on delivery with amount >= 2500.");
                }
                else
                {
                    // Send the order to the warehouse
                    order.UpdateStatus(OrderStatus.InWarehouse);
                    Console.WriteLine("Order sent to warehouse.");
                }
            }catch (Exception ex)
            {
                Console.WriteLine($"Error creating order: {ex.Message}");
            }
        }

        public void SendOrderToShipping()
        {
            try
            {
                Console.Write("Enter order ID to send to shipping: ");
                // Validate ID
                if (!int.TryParse(Console.ReadLine(), out int orderId))
                {
                    Console.WriteLine("Invalid order ID. Please enter a valid integer.");
                    return;
                }

                // Find the order by ID
                Order order = orders.Find(o => o.Id == orderId);
                if (order == null)
                {
                    Console.WriteLine("Order not found.");
                    return;
                }

                // Check if the order is already in shipping or shipped
                if (order.Status == OrderStatus.InShipping || order.Status == OrderStatus.Closed)
                {
                    Console.WriteLine("Order is already in shipping or has been shipped.");
                    return;
                }

                // Validate delivery address
                if (string.IsNullOrWhiteSpace(order.DeliveryAddress))
                {
                    Console.WriteLine("Order cannot be shipped without a delivery address.");
                    return;
                }

                // Send the order to shipping
                order.UpdateStatus(OrderStatus.InShipping);
                Console.WriteLine("Order sent to shipping. Waiting for shipment confirmation...");

                Thread.Sleep(5000); // Wait for 5 seconds

                order.UpdateStatus(OrderStatus.Closed);
                Console.WriteLine("Order shipped successfully.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error sending order to shipping: {ex.Message}");
            }
        }

        public void ViewOrders()
        {
            if (orders.Count == 0)
            {
                Console.WriteLine("No orders available.");
                return;
            }

            Console.WriteLine("List of Orders:");
            Console.WriteLine("============================================");

            foreach (var order in orders)
            {
                Console.WriteLine($"Order ID: {order.Id}");
                Console.WriteLine($"Product: {order.ProductName}");
                Console.WriteLine($"Amount: {order.OrderAmount:C}");
                Console.WriteLine($"Customer Type: {order.CustomerType}");
                Console.WriteLine($"Delivery Address: {order.DeliveryAddress}");
                Console.WriteLine($"Payment Method: {order.PaymentMethod}");
                Console.WriteLine($"Status: {order.Status}");
                Console.WriteLine("============================================");
            }
        }

        public List<Order> GetOrders()
        {
            return orders;
        }

    }
}