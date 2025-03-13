public class Order
{
    public int Id {get; set;}
    public decimal OrderAmount {get; set;}
    public string ProductName {get; set;}
    public string CustomerType {get; set;}
    public string DeliveryAddress {get; set;}
    public string PaymentMethod {get; set;}
    public OrderStatus Status {get; set;}

    public Order(int id, decimal orderAmount, string productName, string customerType, string deliveryAddress, string paymentMethod){
        Id = id;
        OrderAmount = orderAmount;
        ProductName = productName;
        CustomerType = customerType;
        DeliveryAddress = deliveryAddress;
        PaymentMethod = paymentMethod;
        Status = OrderStatus.New;
    }
}