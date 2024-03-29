﻿using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ApiCatalogo.Models
{

    [Table("Categorias")] // indicando que quero mapear pra tabela categorias. mas ao definir o dbset eu já faço isso também.
    public class Categoria
    {



        public Categoria()
        {
            Produtos = new Collection<Produto>();
        }

        [Key]
        public int CategoriaId { get; set; }   // chave primária // pra identificar kda categoria
        [Required]
        [StringLength(80)]
        public string? Nome { get; set; }

        [Required]
        [StringLength(300)]
        public string? ImagemUrl { get; set; }

        public ICollection<Produto>?Produtos { get; set; }

    }
}
