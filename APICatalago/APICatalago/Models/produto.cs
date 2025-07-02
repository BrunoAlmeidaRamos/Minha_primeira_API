using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.CompilerServices;
namespace APICatalago.Models;

    [Table("Produtos")]
public class produto
{
    [Key]
    public int ProdutoId { get; set; }

    [Required]
    [StringLength(80)]
    public string? nome { get; set; }

    [Required]
    [StringLength(300)]
    public string? descricao { get; set; }

    [Required]
    [Column(TypeName = "decimal (10,2)")]
    public decimal preco { get; set; }

    [Required]
    [StringLength(300)]
    public string? imagemUrl { get; set; }
    public bool Estoque { get; set; }
    public DateTime DataCadastro { get; set; }
    public int CategoriaId { get; set; }
    public categoria? Categoria { get; set; }
}
