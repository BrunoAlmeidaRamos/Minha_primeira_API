using APICatalago.Context;
using APICatalago.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace APICatalago.Controllers;

[Route("[controller]")]
[ApiController]
public class ProdutosController : ControllerBase
{
    private readonly AppDbContext _context;

    public ProdutosController(AppDbContext context)
    {
        _context = context;
    }

    [HttpGet]
    public ActionResult<IEnumerable<produto>> Get()
    {
        var produtos = _context.Produtos.AsNoTracking().ToList();
        if (produtos is null)
        {
            return NotFound("Produtos não econtrados");
        }
        return produtos;
    }

    [HttpGet ("{id:int}", Name= "ObterProduto")]
    public ActionResult<produto> Get(int id)
    {
        var produto = _context.Produtos.FirstOrDefault(p => p.ProdutoId == id);
        if (produto is null)
        {
            return NotFound("Produto não encontrado");
        }
        return produto;
    }

    [HttpPost]
    public ActionResult Post(produto produto)
    {
        if (produto is null)
        return BadRequest("Produto inválido");
        
        _context.Produtos.Add(produto);
        _context.SaveChanges();

        return new CreatedAtRouteResult("ObterProduto", new { id = produto.ProdutoId }, produto);

    }

    [HttpPut("{id:int}")]
    public ActionResult put(int id, produto produto)
    {
        if (id != produto.ProdutoId)
        {
            return BadRequest();
        }

        _context.Entry(produto).State = EntityState.Modified;
        _context.SaveChanges();

        return Ok(produto);
    }

    [HttpDelete("{id:int}")]

    public ActionResult Delete(int id)
    {
        var produto = _context.Produtos.FirstOrDefault(p => p.ProdutoId == id);
        if (produto is null)
        {
            return NotFound("Produto não encontrado");
        }
            
        _context.Produtos.Remove(produto);
        _context.SaveChanges();

        return Ok("Produto removido com sucesso");

    }


}
