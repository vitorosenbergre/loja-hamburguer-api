using System.Text.Json.Serialization;

public class User
{
    public int Id { get; set; }
    public string Name { get; set; } = null!;
    public string Email { get; set; } = null!;
    public string Password { get; set; } = null!;

    // Relacionamento com UsersOrders (Muitos-para-Muitos)
    [JsonIgnore]
     public ICollection<UserOrder> UserOrders { get; set; } = new List<UserOrder>();
}
