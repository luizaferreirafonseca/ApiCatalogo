using ApiCatalogo.Models;
using Microsoft.EntityFrameworkCore;

namespace ApiCatalogo.Contexto
{
    public class AppDbContext : DbContext // quando eu faço a herança, o entity é adicionado. Ela realiza a comunicação entre as entidades e o banco de dados relacional. 
    {
        public AppDbContext(DbContextOptions <AppDbContext> options) : base(options)
        {

        }

        public DbSet<Categoria>?Categorias { get; set; }
        public DbSet<Produto>?Produtos { get; set; }
    }
}
