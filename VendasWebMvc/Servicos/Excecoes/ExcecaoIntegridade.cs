using System;

namespace VendasWebMvc.Servicos.Excecoes
{
    public class ExcecaoIntegridade : ApplicationException
    {
        public ExcecaoIntegridade(string message) : base(message)
        { 
        }               
    }
}
