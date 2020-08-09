using System;
using System.Collections.Generic;
using System.Linq;
using VendasWebMvc.Models;
using Microsoft.EntityFrameworkCore;
using VendasWebMvc.Servicos.Excecoes;
using System.Threading.Tasks;

namespace VendasWebMvc.Servicos
{
    public class ServicoVendedor
    {
        private readonly VendasWebMvcContext _context;

        public ServicoVendedor(VendasWebMvcContext context)
        {
            _context = context;
        }

        public async Task<List<Vendedor>> TodosVendedoresAsync() 
        {
            return await _context.Vendedor.ToListAsync();
        }

        public async Task InserirAsync(Vendedor obj)
        {            
            _context.Add(obj);
            await _context.SaveChangesAsync();
        }

        public async Task<Vendedor> EncontrarIdAsync(int id) 
        {
            return await _context.Vendedor.Include(obj => obj.Departamento).FirstOrDefaultAsync(obj => obj.Id == id);
        }

        public async Task RemoverAsync(int id) 
        {
            var obj = await _context.Vendedor.FindAsync(id);
            _context.Vendedor.Remove(obj);
            await _context.SaveChangesAsync();
        }

        public async Task AtualizarAsync(Vendedor obj) 
        {
            //Any serve para verificar se existe algum registro do banco de dados com a condicao que for colocado como parametro
            bool temAlgum = await _context.Vendedor.AnyAsync(x => x.Id == obj.Id);
            
            if (!temAlgum)
            {
                throw new NaoEncontrouExcecao("Id nao Encontrado");
            }
            
            try
            {
                _context.Update(obj);
                await _context.SaveChangesAsync();
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
