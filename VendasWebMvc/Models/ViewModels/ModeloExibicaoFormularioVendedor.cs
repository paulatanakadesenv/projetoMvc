using System;
using System.Collections.Generic;
using System.Linq;

namespace VendasWebMvc.Models.ViewModels
{
    public class ModeloExibicaoFormularioVendedor
    {
        public Vendedor Vendedor { get; set; }
        public ICollection<Departamento> Departamentos { get; set; }
    }
}
