using System;
using System.Collections.Generic;
using System.Linq;
namespace FiapSmartCityClient.Models
{
    public class TipoProduto
    {
        public int IdTipo { get; set; }
        public String DescricaoTipo { get; set; }
        public bool Comercializado { get; set; }

        public List<Produto> Produtos { get; set; }

        public TipoProduto()
        {
            this.Produtos = new List<Produto>();
        }
       
    }
}