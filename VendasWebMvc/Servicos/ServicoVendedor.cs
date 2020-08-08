using System;
using System.Collections.Generic;
using System.Linq;
using VendasWebMvc.Models;
using Microsoft.EntityFrameworkCore;
using VendasWebMvc.Servicos.Excecoes;

namespace VendasWebMvc.Servicos
{
    public class ServicoVendedor
    {
        private readonly VendasWebMvcContext _context;

        public ServicoVendedor(VendasWebMvcContext context)
        {
            _context = context;
        }

        public List<Vendedor> TodosVendedores() 
        {
            return _context.Vendedor.ToList();
        }

        public void Inserir(Vendedor obj)
        {            
            _context.Add(obj);
            _context.SaveChanges();
        }

        public Vendedor EncontrarId(int id) 
        {
            return _context.Vendedor.Include(obj => obj.Departamento).FirstOrDefault(obj => obj.Id == id);
        }

        public void Remover(int id) 
        {
            var obj = _context.Vendedor.Find(id);
            _context.Vendedor.Remove(obj);
            _context.SaveChanges();
        }

        public void Atualizar(Vendedor obj) 
        {
            //Any serve para verificar se existe algum registro do banco de dados com a condicao que for colocado como parametro
            if (!_context.Vendedor.Any(x => x.Id == obj.Id))
            {
                throw new NaoEncontrouExcecao("Id nao Encontrado");
            }
            
            try
            {
                _context.Update(obj);
                _context.SaveChanges();
            }
            // intercepta uma excecao do nivel de acesso a dados.
            catch (DbExcecaoSimultaniedade e)
            {
                /*relanca a excecao usando(DbExcecaoSimultaniedade) em nivel de servico. Importante pra segrega as camadas a camada de servico ela nao 
                 * propaga uma execao de acesso a dados, se uma excecao de nivel de acesso a dados acontece a camada de servico vai lanca uma excecao da 
                 * camada dela(DbExcecaoSimultaniedade) e ai o controlador no caso o VendedorController ele vai ter que lidar somente com excecoes da 
                 * camada de servico.*/
                throw new DbExcecaoSimultaniedade(e.Message);
            }
        }
    }
}
