using FiapSmartCity.Models;
using FiapSmartCity.Repository.Context;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;


namespace FiapSmartCity.Repository
{
    public class TipoProdutoRepository
    {
       
        private readonly DataBaseContext context;

        public TipoProdutoRepository()
        {
            context = new DataBaseContext();
        }

        public IList<TipoProduto> Listar()
        {
            return context.TipoProduto.ToList();
        }


        public TipoProduto Consultar(int id)
        {
            return context.TipoProduto.Find(id);
        }


        public void Inserir(TipoProduto tipoProduto)
        {
            context.TipoProduto.Add(tipoProduto);
            context.SaveChanges();
        }

        public void Alterar(TipoProduto tipoProduto)
        {
            context.TipoProduto.Update(tipoProduto);
            context.SaveChanges();
        }

        public void Excluir(int id)
        {
  
            var tipoProduto = new TipoProduto()
            {
                IdTipo = id
            };

            context.TipoProduto.Remove(tipoProduto);
            context.SaveChanges();
        }

        public IList<TipoProduto> ListarOrdenadoPorNome()
        {
            var lista =
                context.TipoProduto.OrderBy(t => t.DescricaoTipo).ToList<TipoProduto>();

            return lista;
        }

        public IList<TipoProduto> ListarTiposComercializados(bool selecao)
        {
            var lista =
                context.TipoProduto.Where(t => t.Comercializado == selecao && t.IdTipo > 2)
                        .OrderByDescending(t => t.DescricaoTipo).ToList<TipoProduto>();

            return lista;
        }

        public IList<Produto> ConsultarProdutosPorTipo(int idTipo)
        {
            var tipoProduto =
                context.TipoProduto
                    .Include(t => t.Produtos)
                    .FirstOrDefault(t => t.IdTipo == idTipo);

            return tipoProduto.Produtos;
        }

    }
}