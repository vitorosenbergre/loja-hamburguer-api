using System.Text.Json.Serialization;

public class UserOrder
{
    public int OrderId { get; set; }
    
    [JsonIgnore]
    public Order? Order { get; set; } = null!;

    public int UserId { get; set; }
    [JsonIgnore]
    public User? User { get; set; } = null!;
}
