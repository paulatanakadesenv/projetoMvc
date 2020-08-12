using System;

namespace VendasWebMvc.Servicos.Excecoes
{
    public class DbExcecaoSimultaniedade : ApplicationException
    {
        public DbExcecaoSimultaniedade(string mensagem) : base(mensagem) 
        {
        }
    }
}