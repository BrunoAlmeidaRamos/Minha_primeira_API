﻿using APICatalago.Context;
using APICatalago.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace APICatalago.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class CategoriasController : ControllerBase
    {
        private readonly AppDbContext _context;

        public CategoriasController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet("produtos")]

        public ActionResult<IEnumerable<categoria>> GetCategoriasProdutos()
        {
            return _context.Categorias.Include(p => p.Produtos).ToList();
            //return _context.Categorias.Include(p => p.Produtos).Where(c => c.CategoriaId <= 5).ToList(); // filtro para retornar apenas as primeiras 5 categorias
        }

        [HttpGet]
        public ActionResult<IEnumerable<categoria>> Get()
        {

            // Tratamentos de erro
            try
            {
                return _context.Categorias.AsNoTracking().ToList();
            }
            catch (Exception)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, "Ocorreu um problema ao tratar a sua solicitação");
            }

        }

        [HttpGet("{id:int}", Name = "ObterCategoria")]
        public ActionResult<categoria> Get(int id)
        {
            var categoria = _context.Categorias.FirstOrDefault(p => p.CategoriaId == id);
            if (categoria is null)
            {
                return NotFound("Categoria não encontrado");
            }
            return Ok(categoria);
        }

        [HttpPost]
        public ActionResult Post(categoria categoria)
        {
            if (categoria is null)
                return BadRequest("Categoria inválido");

            _context.Categorias.Add(categoria);
            _context.SaveChanges();

            return new CreatedAtRouteResult("ObterCategoria", new { id = categoria.CategoriaId }, categoria);

        }

        [HttpPut("{id:int}")]
        public ActionResult put(int id, categoria categoria)
        {
            if (id != categoria.CategoriaId)
            {
                return BadRequest();
            }

            _context.Entry(categoria).State = EntityState.Modified;
            _context.SaveChanges();

            return Ok(categoria);
        }

        [HttpDelete("{id:int}")]
        public ActionResult Delete(int id)
        {
            var categoria = _context.Categorias.FirstOrDefault(p => p.CategoriaId == id);
            if (categoria is null)
            {
                return NotFound("Categoria não encontrado");
            }

            _context.Categorias.Remove(categoria);
            _context.SaveChanges();

            return Ok("Categoria removido com sucesso");

        }
    }
}
