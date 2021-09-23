using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FiapSmartCity.Models
{
    public class Produto
    {
        [Key]
        public int IdProduto { get; set; }
        public String NomeProduto { get; set; }
        public String Caracteristicas { get; set; }
        public decimal PrecoMedio { get; set; }
        public String Logotipo { get; set; }
        public bool Ativo { get; set; }
        public int IdTipo { get; set; }
        public TipoProduto Tipo { get; set; }
    }
}