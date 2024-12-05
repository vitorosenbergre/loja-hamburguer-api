using System.Text.Json.Serialization;

public class Status
{
    public int Id { get; set; }
    public string Name { get; set; } = null!;

    // Relacionamento com Orders (Um-para-Muitos)
    [JsonIgnore]
    public ICollection<Order> Orders { get; set; } = new List<Order>();
}
