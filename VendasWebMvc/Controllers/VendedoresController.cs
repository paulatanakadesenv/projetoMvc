using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using VendasWebMvc.Models;
using VendasWebMvc.Models.ViewModels;
using VendasWebMvc.Servicos;
using VendasWebMvc.Servicos.Excecoes;

namespace VendasWebMvc.Controllers
{
    public class VendedoresController : Controller
    {
        private readonly ServicoVendedor _servicoVendedor;
        private readonly ServicoDepartamento _servicoDepartamento;
        public VendedoresController(ServicoVendedor servicoVendedor, ServicoDepartamento servicoDepartamento)
        {
            _servicoVendedor = servicoVendedor;
            _servicoDepartamento = servicoDepartamento;
        }

        public async Task<IActionResult> Index()
        {
            var list = await _servicoVendedor.TodosVendedoresAsync();
            return View(list);
        }

        public async Task<IActionResult> Create()
        {
            var departamentos = await _servicoDepartamento.TodosDepartamentosAsync();
            var viewModel = new ModeloExibicaoFormularioVendedor { Departamentos = departamentos };
            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Vendedor vendedor)
        {
            // verifica se p vendedor e valido ou nao
            if (!ModelState.IsValid)
            {
                var departamentos = await _servicoDepartamento.TodosDepartamentosAsync();
                var modeloExibicao = new ModeloExibicaoFormularioVendedor { Vendedor = vendedor, Departamentos = departamentos };
                return View(modeloExibicao);
            }
            await _servicoVendedor.InserirAsync(vendedor);
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return RedirectToAction(nameof(Error), new { mensagem = "Id nao fornecido"});
            }

            var obj = await _servicoVendedor.EncontrarIdAsync(id.Value);
            if (obj == null)
            {
                return RedirectToAction(nameof(Error), new { mensagem = "Id nao existe" });
            }

            return View(obj);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id) 
        {
            await _servicoVendedor.RemoverAsync(id);
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Details(int? id) 
        {
            if (id == null)
            {
                return RedirectToAction(nameof(Error), new { mensagem = "Id nao fornecido" });
            }

            var obj = await _servicoVendedor.EncontrarIdAsync(id.Value);
            if (obj == null)
            {
                return RedirectToAction(nameof(Error), new { mensagem = "Id nao existe" });
            }

            return View(obj);
        }

        public async Task<IActionResult> Edit(int? id) 
        {
            if (id == null)
            {
                return RedirectToAction(nameof(Error), new { mensagem = "Id nao fornecido" });
            }

            var obj = await _servicoVendedor.EncontrarIdAsync(id.Value);
            if (obj == null)
            {
                return RedirectToAction(nameof(Error), new { mensagem = "Id nao existe" });
            }

            List<Departamento> departamentos = await _servicoDepartamento.TodosDepartamentosAsync();
            ModeloExibicaoFormularioVendedor modeloExibicao = new ModeloExibicaoFormularioVendedor { Vendedor = obj, Departamentos = departamentos};
            return View(modeloExibicao);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Vendedor vendedor) 
        {
            if (!ModelState.IsValid)
            {
                var departamentos = await _servicoDepartamento.TodosDepartamentosAsync();
                var modeloExibicao = new ModeloExibicaoFormularioVendedor { Vendedor = vendedor, Departamentos = departamentos };
                return View(modeloExibicao);
            }
            //verifica se o id e o mesmo id do usuario que esta sendo editado.
            if (id != vendedor.Id)
            {
                return RedirectToAction(nameof(Error), new { mensagem = "Id nao corresponde" });
            }
            try
            {
                await _servicoVendedor.AtualizarAsync(vendedor);
                return RedirectToAction(nameof(Index));
            }
            catch (ApplicationException e)
            {
                return RedirectToAction(nameof(Error), new { mensagem = e.Message });
            }    
        }

        public IActionResult Error(string mensagem) 
        {
            var modeloExibicao = new ErrorViewModel
            {
                Message = mensagem,
                RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier
            };
            return View(modeloExibicao);
        }
    }   
}