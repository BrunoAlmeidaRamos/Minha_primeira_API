using System.Collections.ObjectModel;

namespace APICatalago.Models;

public class categoria
{

    public categoria()
    {
        Produtos = new Collection<produto>();
    }
    public int CategoriaId { get; set; }
    public string? Nome { get; set; }
    public string? ImagemUrl { get; set; }

    public ICollection<produto>? Produtos { get; set; }
}
