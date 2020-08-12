using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using VendasWebMvc.Servicos;

namespace VendasWebMvc.Controllers
{
    public class RegistroVendasController : Controller
    {
        private readonly ServicoRegistroVendas _servicoRegistroVendas;

        public RegistroVendasController(ServicoRegistroVendas servicoRegistroVendas)
        {
            _servicoRegistroVendas = servicoRegistroVendas;
        }

        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> BuscaSimples(DateTime? dataMinima, DateTime? dataMaxima)
        {
            if (!dataMinima.HasValue)
            {
                dataMinima = new DateTime(DateTime.Now.Year, 1, 1);
            }

            if (!dataMaxima.HasValue)
            {
                dataMaxima = DateTime.Now;
            }

            ViewData["dataMinima"] = dataMinima.Value.ToString("yyyy-MM-dd");
            ViewData["dataMaxima"] = dataMaxima.Value.ToString("yyyy-MM-dd");

            var resultado = await _servicoRegistroVendas.EncontrarDataAsync(dataMinima, dataMaxima);
            return View(resultado);
        }

        public IActionResult BuscaAgrupada()
        {
            return View();
        }
    }
}