using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace APICatalago.Models;

    [Table("Categorias")]
public class categoria
{
    
    public categoria()
    {
        Produtos = new Collection<produto>();
    }

    [Key]
    public int CategoriaId { get; set; }

    [StringLength(80)]
    [Required]
    public string? Nome { get; set; }

    [StringLength(300)]
    [Required]
    public string? ImagemUrl { get; set; }

    public ICollection<produto>? Produtos { get; set; }
}
