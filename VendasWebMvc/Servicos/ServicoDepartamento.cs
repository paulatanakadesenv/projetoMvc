using System;
using System.Collections.Generic;
using System.Linq;
using VendasWebMvc.Models;

namespace VendasWebMvc.Servicos
{
    public class ServicoDepartamento
    {
        private readonly VendasWebMvcContext _context;

        public ServicoDepartamento(VendasWebMvcContext context)
        {
            _context = context;
        }

        public List<Departamento> TodosDepartamentos() 
        {
            return _context.Departamento.OrderBy(x => x.Nome).ToList();
        }
    }
}
