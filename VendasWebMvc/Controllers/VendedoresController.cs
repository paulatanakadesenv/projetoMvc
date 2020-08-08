using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
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

        public IActionResult Index()
        {
            var list = _servicoVendedor.TodosVendedores();
            return View(list);
        }

        public IActionResult Create()
        {
            var departamentos = _servicoDepartamento.TodosDepartamentos();
            var viewModel = new ModeloExibicaoFormularioVendedor { Departamentos = departamentos };
            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Vendedor vendedor)
        {
            _servicoVendedor.Inserir(vendedor);
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return RedirectToAction(nameof(Error), new { mensagem = "Id nao fornecido"});
            }

            var obj = _servicoVendedor.EncontrarId(id.Value);
            if (obj == null)
            {
                return RedirectToAction(nameof(Error), new { mensagem = "Id nao existe" });
            }

            return View(obj);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(int id) 
        {
            _servicoVendedor.Remover(id);
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Details(int? id) 
        {
            if (id == null)
            {
                return RedirectToAction(nameof(Error), new { mensagem = "Id nao fornecido" });
            }

            var obj = _servicoVendedor.EncontrarId(id.Value);
            if (obj == null)
            {
                return RedirectToAction(nameof(Error), new { mensagem = "Id nao existe" });
            }

            return View(obj);
        }

        public IActionResult Edit(int? id) 
        {
            if (id == null)
            {
                return RedirectToAction(nameof(Error), new { mensagem = "Id nao fornecido" });
            }

            var obj = _servicoVendedor.EncontrarId(id.Value);
            if (obj == null)
            {
                return RedirectToAction(nameof(Error), new { mensagem = "Id nao existe" });
            }

            List<Departamento> departamentos = _servicoDepartamento.TodosDepartamentos();
            ModeloExibicaoFormularioVendedor modeloExibicao = new ModeloExibicaoFormularioVendedor { Vendedor = obj, Departamentos = departamentos};
            return View(modeloExibicao);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, Vendedor vendedor) 
        {
            //verifica se o id e o mesmo id do usuario que esta sendo editado.
            if (id != vendedor.Id)
            {
                return RedirectToAction(nameof(Error), new { mensagem = "Id nao corresponde" });
            }
            try
            {
                _servicoVendedor.Atualizar(vendedor);
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