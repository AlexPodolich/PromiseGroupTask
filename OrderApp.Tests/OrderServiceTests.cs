using NUnit.Framework;
using OrderApp;
using System;
using System.IO;

namespace OrderApp.Tests
{
    [TestFixture]
    public class OrderServiceTests
    {
        [Test]
        public void CreateSampleOrder_ValidInput_CreatesOrder()
        {
            // Arrange
            var input = new StringReader("100\nLaptop\nCompany\n123 Main St\nCard\n");
            Console.SetIn(input);

            var output = new StringWriter();
            Console.SetOut(output);

            var orderService = new OrderService();

            // Act
            orderService.CreateSampleOrder();

            // Assert
            string consoleOutput = output.ToString();
            Assert.That(consoleOutput, Does.Contain("Order created with ID: 1"));
            Assert.That(orderService.GetOrders(), Has.Exactly(1).Items); // Ensure the order was added
        }

        [Test]
        public void CreateSampleOrder_InvalidOrderAmount_ShowsErrorMessage()
        {
            // Arrange
            var input = new StringReader("invalid\n100\nLaptop\nCompany\n123 Main St\nCard\n");
            Console.SetIn(input);

            var output = new StringWriter();
            Console.SetOut(output);

            var orderService = new OrderService();

            // Act
            orderService.CreateSampleOrder();

            // Assert
            string consoleOutput = output.ToString();
            Assert.That(consoleOutput, Does.Contain("Invalid input. Please enter a valid order amount greater than zero."));
        }

        [Test]
        public void SendOrderToWarehouse_ValidOrder_SendsToWarehouse()
        {
            // Arrange
            var orderService = new OrderService();
            var order = new Order(1, 100, "Product", CustomerType.Company, "Address", PaymentMethod.Card);
            orderService.GetOrders().Add(order);

            var input = new StringReader("1\n");
            Console.SetIn(input);

            var output = new StringWriter();
            Console.SetOut(output);

            // Act
            orderService.SendOrderToWarehouse();

            // Assert
            string consoleOutput = output.ToString();
            Assert.That(consoleOutput, Does.Contain("Order sent to warehouse."));
            Assert.That(orderService.GetOrders()[0].Status, Is.EqualTo(OrderStatus.InWarehouse));
        }

        [Test]
        public void SendOrderToWarehouse_CashOnDeliveryAmountOver2500_ReturnsToCustomer()
        {
            // Arrange
            var orderService = new OrderService();
            var order = new Order(1, 3000, "Product", CustomerType.Company, "Address", PaymentMethod.CashOnDelivery);
            orderService.GetOrders().Add(order);

            var input = new StringReader("1\n");
            Console.SetIn(input);

            var output = new StringWriter();
            Console.SetOut(output);

            // Act
            orderService.SendOrderToWarehouse();

            // Assert
            string consoleOutput = output.ToString();
            Assert.That(consoleOutput, Does.Contain("Order returned to customer due to cash on delivery with amount >= 2500."));
            Assert.That(orderService.GetOrders()[0].Status, Is.EqualTo(OrderStatus.ReturnedToCustomer));
        }

        [Test]
        public void SendOrderToShipping_ValidOrder_SendsToShipping()
        {
            // Arrange
            var orderService = new OrderService();
            var order = new Order(1, 100, "Product", CustomerType.Company, "Address", PaymentMethod.Card);
            orderService.GetOrders().Add(order);

            var input = new StringReader("1\n");
            Console.SetIn(input);

            var output = new StringWriter();
            Console.SetOut(output);

            // Act
            orderService.SendOrderToShipping();

            // Assert
            string consoleOutput = output.ToString();
            Assert.That(consoleOutput, Does.Contain("Order shipped successfully."));
            Assert.That(orderService.GetOrders()[0].Status, Is.EqualTo(OrderStatus.Closed));
        }

        [Test]
        public void ViewOrders_NoOrders_ShowsNoOrdersMessage()
        {
            // Arrange
            var output = new StringWriter();
            Console.SetOut(output);

            var orderService = new OrderService();

            // Act
            orderService.ViewOrders();

            // Assert
            string consoleOutput = output.ToString();
            Assert.That(consoleOutput, Does.Contain("No orders available."));
        }

        [Test]
        public void ViewOrders_WithOrders_DisplaysOrders()
        {
            // Arrange
            var orderService = new OrderService();
            var order = new Order(1, 100, "Product", CustomerType.Company, "Address", PaymentMethod.Card);
            orderService.GetOrders().Add(order);

            var output = new StringWriter();
            Console.SetOut(output);

            // Act
            orderService.ViewOrders();

            // Assert
            string consoleOutput = output.ToString();
            Assert.That(consoleOutput, Does.Contain("Order ID: 1"));
            Assert.That(consoleOutput, Does.Contain("Product: Product"));
            Assert.That(consoleOutput, Does.Contain("Amount: $100.00"));
        }
    }
}