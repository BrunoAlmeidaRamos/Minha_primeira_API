namespace APICatalago.Models;

public class produto
{
    public int ProdutoId { get; set; }
    public string? nome { get; set; }
    public string? descricao { get; set; }
    public decimal preco { get; set; }
    public string? imagemUrl { get; set; }
    public bool Estoque { get; set; }
    public DateTime DataCadastro { get; set; }
    public int CategoriaId { get; set; }
    public categoria? Categoria { get; set; }
}
