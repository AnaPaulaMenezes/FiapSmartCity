using FiapSmartCityClient.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;

namespace FiapSmartCityClient
{
    class Program
    {
        static void Main(string[] args)
        {
            get();

            post();

            get();

            Console.Read();
        }

        static void post()
        {
            
            System.Net.Http.HttpClient client = new System.Net.Http.HttpClient();

            
            TipoProduto tipo = new TipoProduto();
            tipo.IdTipo = 101;
            tipo.DescricaoTipo = "Grid de Energia Solar";
            tipo.Comercializado = true;

            var json = JsonConvert.SerializeObject(tipo);

            StringContent conteudo = new StringContent(json.ToString(), Encoding.UTF8, "application/json");

            System.Net.Http.HttpResponseMessage resposta =
                client.PostAsync("https://localhost:44385/api/TipoProduto", conteudo).Result;

           
            if (resposta.IsSuccessStatusCode)
            {
                Console.WriteLine("Tipo do produto criado com sucesso");
                Console.Write("Link para consulta: " + resposta.Headers.Location);
            }
        }

        static void get()
        {
            
            System.Net.Http.HttpClient client = new System.Net.Http.HttpClient();
            System.Net.Http.HttpResponseMessage resposta =
                client.GetAsync("https://localhost:44385/api/TipoProduto").Result;

            if (resposta.IsSuccessStatusCode)
            {
                string conteudo = resposta.Content.ReadAsStringAsync().Result;              
                List<TipoProduto> lista =
                    JsonConvert.DeserializeObject<List<TipoProduto>>(conteudo);
                foreach (var item in lista)
                {
                    Console.WriteLine("Descrição:" + item.DescricaoTipo);
                    Console.WriteLine("Comercializado:" + item.Comercializado);
                    Console.WriteLine(" ========== ");
                    Console.WriteLine("");
                }

            }

        }
    }
}