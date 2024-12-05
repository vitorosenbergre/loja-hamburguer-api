using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

public class Product
{
    // Identificador único do produto
    [Required(ErrorMessage = "Não é necessário colocar o ID")]
    public int Id { get; set; }

    // Nome do produto, obrigatório e com limite de caracteres
    [Required(ErrorMessage = "O nome do produto é obrigatório.")]
    [StringLength(100, ErrorMessage = "O nome do produto não pode ter mais de 100 caracteres.")]
    public string? Name { get; set; }

    // Preço do produto, obrigatório e deve ser um valor positivo
    [Required(ErrorMessage = "O preço do produto é obrigatório.")]
    [Range(0.01, double.MaxValue, ErrorMessage = "O preço deve ser um valor positivo.")]
    public decimal Price { get; set; }

    [Required(ErrorMessage = "A imagem do produto é obrigatória.")]
    public string PathImage { get; set; } = null!;


    [Required(ErrorMessage = "A descrição base do produto é obrigatória.")]
    public string BaseDescription { get; set; } = null!;

    [Required(ErrorMessage = "A descrição completa do produto é obrigatória.")]
    public string FullDescription { get; set; } = null!;

    [Required(ErrorMessage = "A categoria do produto é obrigatória.")]
    public int CategoryId { get; set; }

    // Referência para o objeto Category (não obrigatório na requisição, é populado automaticamente pelo EF)
    [JsonIgnore]
    public Category? Category { get; set; } // Aqui, deve ser nullable

    // Relacionamento com OrdersProducts (Muitos-para-Muitos)
    [JsonIgnore]
    public ICollection<OrderProduct> OrderProducts { get; set; } = new List<OrderProduct>();
}
