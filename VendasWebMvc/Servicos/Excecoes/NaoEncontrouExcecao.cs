using System;

namespace VendasWebMvc.Servicos.Excecoes
{
    public class NaoEncontrouExcecao : ApplicationException
    {
        public NaoEncontrouExcecao(string mensagem) : base(mensagem) 
        {
        }
    }
}