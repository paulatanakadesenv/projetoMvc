using System;
using System.Collections.Generic;
using System.Linq;

namespace VendasWebMvc.Servicos.Excecoes
{
    public class DbExcecaoSimultaniedade : ApplicationException
    {
        public DbExcecaoSimultaniedade(string mensagem) : base(mensagem) 
        {
        }
    }
}
