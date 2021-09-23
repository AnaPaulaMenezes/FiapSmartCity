using FiapSmartCity.Controllers.Filtros;
using FiapSmartCity.Models;
using FiapSmartCity.Repository;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace FiapSmartCity.Controllers
{
    public class TipoProdutoController : Controller
    {

        private readonly TipoProdutoRepository tipoProdutoRepository;
        private readonly ProdutoRepository produtoRepository;

        public TipoProdutoController()
        {
            tipoProdutoRepository = new TipoProdutoRepository();
            produtoRepository = new ProdutoRepository();
        }

        [LogFilter]
        [HttpGet]
        public IActionResult Index()
        {
            var listaTipo = tipoProdutoRepository.ListarOrdenadoPorNome();
            return View(listaTipo);
        }

        [HttpGet]
        public ActionResult Cadastrar()
        {
            return View(new TipoProduto());
        }

        [HttpPost]
        public ActionResult Cadastrar(Models.TipoProduto tipoProduto)
        {
            if (ModelState.IsValid)
            {
                tipoProdutoRepository.Inserir(tipoProduto);

                @TempData["mensagem"] = "Tipo cadastrado com sucesso!";
                return RedirectToAction("Index", "TipoProduto");

            }
            else
            {
                return View(tipoProduto);
            }
        }

        [HttpGet]
        public ActionResult Editar(int Id)
        {
            var tipoProduto = tipoProdutoRepository.Consultar(Id);
            return View(tipoProduto);
        }

        [HttpPost]
        public ActionResult Editar(Models.TipoProduto tipoProduto)
        {

            if (ModelState.IsValid)
            {
                tipoProdutoRepository.Alterar(tipoProduto);

                @TempData["mensagem"] = "Tipo alterado com sucesso!";
                return RedirectToAction("Index", "TipoProduto");
            }
            else
            {
                return View(tipoProduto);
            }

        }


        [HttpGet]
        public ActionResult Consultar(int Id)
        {
            var tipoProduto = tipoProdutoRepository.Consultar(Id);
            return View(tipoProduto);
        }

        [HttpGet]
        public ActionResult Excluir(int Id)
        {
            tipoProdutoRepository.Excluir(Id);

            @TempData["mensagem"] = "Tipo removido com sucesso!";

            return RedirectToAction("Index", "TipoProduto");
        }

        [HttpGet]
        public IList<Produto> ListarProdutosPorTipo(int id)
        {
            var listaProdutos = tipoProdutoRepository.ConsultarProdutosPorTipo(id);
            return listaProdutos;
        }

        [HttpGet]
        public Produto BuscaProdutoId(int id)
        {
            var listaProdutos = produtoRepository.Consultar(id);
            return listaProdutos;
        }
    }
}