using System.Text.Json.Serialization;

public class Order
{
    public int Id { get; set; }
    public int StatusId { get; set; }
    public float Value { get; set; }

    [JsonIgnore]
    public Status? Status { get; set; }  = null!;

    // Relacionamento Muitos-para-Muitos entre Order e Product
    public ICollection<OrderProduct> OrderProducts { get; set; } = new List<OrderProduct>();

    // Relacionamento Muitos-para-Muitos entre Order e User
    public ICollection<UserOrder> UserOrders { get; set; } = new List<UserOrder>();

}
