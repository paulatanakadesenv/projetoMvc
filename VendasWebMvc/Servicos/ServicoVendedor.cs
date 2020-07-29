using System;
using System.Collections.Generic;
using System.Linq;
using VendasWebMvc.Models;

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


    }
}
