using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace APICatalago.Migrations
{
    /// <inheritdoc />
    public partial class NovoProdutos : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder mb)
        {
            mb.Sql("Isert INTO Produtos (nome, descricao, preco, imagemUrl, Estoque, DataCadastro, CategoriaId) " +
         "VALUES ('Coca-cola Zero', 'Refrigerante de Cola 250 ml', 5.45, 'cocacola.jpg', 50, NOW(), 1)");

            mb.Sql("Isert INTO Produtos (nome, descricao, preco, imagemUrl, Estoque, DataCadastro, CategoriaId) " +
                   "VALUES ('Pão com frango', 'Pão com frango junto com tomate', 8.50, 'PaoFrango.jpg', 15, NOW(), 2)");

            mb.Sql("Isert INTO Produtos (nome, descricao, preco, imagemUrl, Estoque, DataCadastro, CategoriaId) " +
                   "VALUES ('Bolo 2kg', 'Bolo de chocolate com ninho', 15.99, 'bolo.jpg', 5, NOW(), 3)");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder mb)
        {
            mb.Sql("Delete from Produtos");
        }
    }
}
