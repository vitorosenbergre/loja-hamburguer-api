using System.Text.Json.Serialization;

public class OrderProduct
{
    public int OrderId { get; set; }

    [JsonIgnore]
    public Order? Order { get; set; }= null!;

    public int ProductId { get; set; }

    [JsonIgnore]
    public Product? Product { get; set; } = null!;
}
