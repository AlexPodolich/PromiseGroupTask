public class Order
{
    public int Id { get; private set; }
    public decimal OrderAmount { get; private set; }
    public string ProductName { get; private set; }
    public CustomerType CustomerType { get; private set; }
    public string DeliveryAddress { get; private set; }
    public PaymentMethod PaymentMethod { get; private set; }
    public OrderStatus Status { get; private set; }

    public Order(int id, decimal orderAmount, string productName, CustomerType customerType, string deliveryAddress, PaymentMethod paymentMethod)
    {
        if (id <= 0)
        {
            throw new ArgumentException("Order ID must be a positive integer.");
        }
        Id = id;

        UpdateOrderAmount(orderAmount);
        UpdateProductName(productName);
        UpdateCustomerType(customerType);
        UpdateDeliveryAddress(deliveryAddress);
        UpdatePaymentMethod(paymentMethod);

        Status = OrderStatus.New;
    }

    public void UpdateOrderAmount(decimal newAmount)
    {
        if (newAmount <= 0)
        {
            throw new ArgumentException("Order amount must be greater than zero.");
        }
        OrderAmount = newAmount;
    }

    public void UpdateProductName(string newProductName)
    {
        if (string.IsNullOrWhiteSpace(newProductName))
        {
            throw new ArgumentException("Product name cannot be null or empty.");
        }
        ProductName = newProductName;
    }

    public void UpdateCustomerType(CustomerType newCustomerType)
    {
        if (!Enum.IsDefined(typeof(CustomerType), newCustomerType))
        {
            throw new ArgumentException("Invalid customer type.");
        }
        CustomerType = newCustomerType;
    }

    public void UpdateDeliveryAddress(string newAddress)
    {
        if (string.IsNullOrWhiteSpace(newAddress))
        {
            throw new ArgumentException("Delivery address cannot be null or empty.");
        }
        DeliveryAddress = newAddress;
    }

    public void UpdatePaymentMethod(PaymentMethod newPaymentMethod)
    {
        if (!Enum.IsDefined(typeof(PaymentMethod), newPaymentMethod))
        {
            throw new ArgumentException("Invalid payment method.");
        }
        PaymentMethod = newPaymentMethod;
    }

    public void UpdateStatus(OrderStatus newStatus)
    {
        if (!Enum.IsDefined(typeof(OrderStatus), newStatus))
        {
            throw new ArgumentException("Invalid order status.");
        }
        Status = newStatus;
    }

    public void ApplyDiscount(decimal discount)
    {
        if (discount <= 0)
        {
            throw new ArgumentException("Discount must be greater than zero.");
        }

        if (discount >= OrderAmount)
        {
            throw new ArgumentException("Discount cannot be greater than or equal to the order amount.");
        }

        OrderAmount -= discount;
    }
}