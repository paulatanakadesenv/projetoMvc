using System;
using System.Collections.Generic;
using System.Linq;

namespace VendasWebMvc.Servicos.Excecoes
{
    public class NaoEncontrouExcecao : ApplicationException
    {
        public NaoEncontrouExcecao(string mensagem) : base(mensagem) 
        {
        }
    }
}
