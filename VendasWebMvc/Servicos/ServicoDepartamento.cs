using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VendasWebMvc.Models;
using Microsoft.EntityFrameworkCore;

namespace VendasWebMvc.Servicos
{
    public class ServicoDepartamento
    {
        private readonly VendasWebMvcContext _context;

        public ServicoDepartamento(VendasWebMvcContext context)
        {
            _context = context;
        }

        /*implementacao sincrona
        public List<Departamento> TodosDepartamentos() 
        {
            return _context.Departamento.OrderBy(x => x.Nome).ToList();
        }*/

        //implementacao assincrona (Async) suficso e uma recomendacao da plataforma c# nao obrigatorio, mas e um padrao adotado na linguagem.
        // async mostra que e uma implementacao assincrona retornando um Task<List<Departamento>> e dentro dela temos uma outra chamada assincrona
        public async Task<List<Departamento>> TodosDepartamentosAsync()
        {
            // await avisa ao compilador que essa e uma chama assincrona./ nao bloqueia a aplicacao
            return await _context.Departamento.OrderBy(x => x.Nome).ToListAsync();
        }
    }
}