using FiapSmartCity.Models;
using FiapSmartCity.Repository.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FiapSmartCity.Repository
{
    public class ProdutoRepository
    {
        private readonly DataBaseContext context;

        public ProdutoRepository()
        {
            context = new DataBaseContext();
        }

        public Produto Consultar(int id)
        {
            var prod = context.Produto.Include(t => t.Tipo)
                .FirstOrDefault(p => p.IdProduto == id);
            return prod;
        }
    }
}
