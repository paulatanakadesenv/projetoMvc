using System;
using System.Collections.Generic;
using System.Linq;
using VendasWebMvc.Models;
using Microsoft.EntityFrameworkCore;

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
    }
}
