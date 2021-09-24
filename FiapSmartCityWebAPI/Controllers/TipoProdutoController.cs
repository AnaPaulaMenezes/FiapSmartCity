using FiapSmartCityWebAPI.DAL;
using FiapSmartCityWebAPI.Models;
using System;
using System.Collections.Generic;
using System.Web.Http;

namespace FiapSmartCityWebAPI.Controllers
{
    public class TipoProdutoController : ApiController
    {
        public IHttpActionResult Get()
        {
            return Ok(new TipoProdutoDAL().Listar());
        }

        public IHttpActionResult Get(int id)
        {
            try
            {
                TipoProdutoDAL dal = new TipoProdutoDAL();
                TipoProduto TipoProduto = dal.Consultar(id);
                return Ok(TipoProduto);
            }
            catch (KeyNotFoundException)
            {
                return NotFound();
            }
        }

        public IHttpActionResult Post([FromBody] TipoProduto TipoProduto)
        {
            try
            {
             
                TipoProdutoDAL dal = new TipoProdutoDAL();
                
                dal.Inserir(TipoProduto);

                string location =
                    Url.Link("DefaultApi",
                    new { controller = "tipoproduto", id = TipoProduto.IdTipo });

                return Created(new Uri(location), TipoProduto);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }
        public IHttpActionResult Delete(int id)
        {
            try
            {
                TipoProdutoDAL dal = new TipoProdutoDAL();
                dal.Excluir(id);
                return Ok();
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        public IHttpActionResult Put([FromBody] TipoProduto tipoProduto)
        {
            try
            {
                TipoProdutoDAL dal = new TipoProdutoDAL();
                dal.Alterar(tipoProduto);
                return Ok();
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }
    }
}