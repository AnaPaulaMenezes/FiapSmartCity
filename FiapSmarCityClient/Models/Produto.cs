using System;

namespace FiapSmartCityClient.Models
{
    public class Produto
    {
        public int IdProduto { get; set; }
        public String NomeProduto { get; set; }
        public String Caracteristicas { get; set; }
        public double PrecoMedio { get; set; }
        public String Logotipo { get; set; }
        public bool Ativo { get; set; }
        public int IdTipoProduto { get; set; }

    }

    
}