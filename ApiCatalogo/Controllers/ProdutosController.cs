﻿using ApiCatalogo.Contexto;
using ApiCatalogo.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ApiCatalogo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProdutosController : ControllerBase
    {
        private readonly AppDbContext _context;

        public ProdutosController(AppDbContext context)
        {
            _context = context;
        }

        //retornar todos os produtos


        [HttpGet("/todosprodutos")]

        public ActionResult<IEnumerable<Produto>> Get()
        {
            var produtos = _context.Produtos.ToList();   //estou acessando a tabela de produtos do meu context e listando

            if (produtos is null)
            {
                return NotFound("Produtos não encontrados");
            }

            return produtos;
        }



        [HttpGet("{id:int}", Name="ObterProduto")]

        public async Task<ActionResult<Produto>>Get(int id) 

        {
            var produto = await _context.Produtos.AsNoTracking().FirstOrDefaultAsync(p => p.ProdutoId == id);   

            if(produto is null)
            {
                return NotFound("Produto não encontrado");

               
            }
            return produto;
        }


        [HttpPost]

        public ActionResult Post(Produto produto)
        {


            if (produto is null)
                return BadRequest();

            _context.Produtos.Add(produto); // incluo no contexto do entity
            _context.SaveChanges(); // os dados persistem na tabela


            return new CreatedAtRouteResult("ObterProduto", 
                new { id = produto.ProdutoId }, produto);

        }

        [HttpPut("{id:int}")]

        public ActionResult Put(int id, Produto produto)
        {
            if (id != produto.ProdutoId)
            {
                return BadRequest();
            }

            _context.Entry(produto).State = EntityState.Modified;
            _context.SaveChanges();

            return Ok();

        }


        [HttpDelete("{id:int}")]

        public ActionResult Delete(int id) { 
        
            var produto = _context.Produtos.FirstOrDefault(p => p.ProdutoId == id);

            if (produto is null)
            {
                return NotFound("Produto não localizado");
            }

            _context.Produtos.Remove(produto);
            _context.SaveChanges();

            return Ok(produto); 
        
        }
    }
}
