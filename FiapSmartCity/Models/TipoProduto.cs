using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace FiapSmartCity.Models
{
    public class TipoProduto
    {
        [Key]
        public int IdTipo { get; set; }

        [Required(ErrorMessage = "Descrição obrigatória!")]
        [StringLength(50,
            MinimumLength = 3,
            ErrorMessage = "A descrição deve ter, no mínimo, 3 e, no máximo, 50 caracteres")]
        [Display(Name = "Descrição:")]
        public String DescricaoTipo { get; set; }
        public bool Comercializado { get; set; }

        public IList<Produto> Produtos { get; set; }
    }
}