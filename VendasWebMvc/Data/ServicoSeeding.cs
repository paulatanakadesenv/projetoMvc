using System;
using System.Collections.Generic;
using System.Linq;
using VendasWebMvc.Models;
using VendasWebMvc.Models.Enums;

namespace VendasWebMvc.Data
{
    public class ServicoSeeding
    {
        private VendasWebMvcContext _context;

        public ServicoSeeding(VendasWebMvcContext context) 
        {
            _context = context;
        }

        public void PopularBaseDados() 
        {
            if (_context.Departamento.Any() || _context.Vendedor.Any() || _context.RegistroVenda.Any())
            {
                return;// banco de dados ja foi populado.
            }

            Departamento departamento1 = new Departamento(1, "Computadores");
            Departamento departamento2 = new Departamento(2, "Eletronicos");
            Departamento departamento3 = new Departamento(3, "Moda");
            Departamento departamento4 = new Departamento(4, "Livros");

            Vendedor vendedor1 = new Vendedor(1, "Bob Brown", "bob@gmail.com", new DateTime(1998, 4, 21), 1000.0, departamento1 );
            Vendedor vendedor2 = new Vendedor(2 , "Maria Green", "maria@gmail.com", new DateTime(1979, 12, 31), 3500.0, departamento2);
            Vendedor vendedor3 = new Vendedor(3, "Alex Grey", "alex@gmail.com", new DateTime(1988, 1, 15), 2200.0, departamento1);
            Vendedor vendedor4 = new Vendedor(4, "Martha Red", "martha@gmail.com", new DateTime(1993, 11, 30), 3000.0, departamento4);
            Vendedor vendedor5 = new Vendedor(5, "Donald Blue", "donald@gmail.com", new DateTime(2000, 1, 9), 4000.0, departamento3);
            Vendedor vendedor6 = new Vendedor(6, "Alex Pink", "alexP@gmail.com", new DateTime(1997, 3, 4), 3000.0, departamento2);

            
            RegistroVenda registroVenda1 = new RegistroVenda(1, new DateTime(2018, 09, 25), 11000.0, StatusVenda.Faturado, vendedor1);
            RegistroVenda registroVenda2 = new RegistroVenda(2, new DateTime(2018, 09, 4), 7000.0, StatusVenda.Faturado, vendedor5);
            RegistroVenda registroVenda3 = new RegistroVenda(3, new DateTime(2018, 09, 13), 4000.0, StatusVenda.Cancelado, vendedor4);
            RegistroVenda registroVenda4 = new RegistroVenda(4, new DateTime(2018, 09, 1), 8000.0, StatusVenda.Faturado, vendedor1);
            RegistroVenda registroVenda5 = new RegistroVenda(5, new DateTime(2018, 09, 21), 3000.0, StatusVenda.Faturado, vendedor3);
            RegistroVenda registroVenda6 = new RegistroVenda(6, new DateTime(2018, 09, 15), 2000.0, StatusVenda.Faturado, vendedor1);
            RegistroVenda registroVenda7 = new RegistroVenda(7, new DateTime(2018, 09, 28), 13000.0, StatusVenda.Faturado, vendedor2);
            RegistroVenda registroVenda8 = new RegistroVenda(8, new DateTime(2018, 09, 11), 4000.0, StatusVenda.Faturado, vendedor4);
            RegistroVenda registroVenda9 = new RegistroVenda(9, new DateTime(2018, 09, 14), 11000.0, StatusVenda.Pendente, vendedor6);
            RegistroVenda registroVenda10 = new RegistroVenda(10, new DateTime(2018, 09, 7), 9000.0, StatusVenda.Faturado, vendedor6);
            RegistroVenda registroVenda11 = new RegistroVenda(11, new DateTime(2018, 09, 13), 6000.0, StatusVenda.Faturado, vendedor2);
            RegistroVenda registroVenda12 = new RegistroVenda(12, new DateTime(2018, 09, 25), 7000.0, StatusVenda.Pendente, vendedor3);
            RegistroVenda registroVenda13 = new RegistroVenda(13, new DateTime(2018, 09, 29), 10000.0, StatusVenda.Faturado, vendedor4);
            RegistroVenda registroVenda14 = new RegistroVenda(14, new DateTime(2018, 09, 4), 3000.0, StatusVenda.Faturado, vendedor5);
            RegistroVenda registroVenda15 = new RegistroVenda(15, new DateTime(2018, 09, 12), 4000.0, StatusVenda.Faturado, vendedor1);
            RegistroVenda registroVenda16 = new RegistroVenda(16, new DateTime(2018, 10, 5), 2000.0, StatusVenda.Faturado, vendedor4);
            RegistroVenda registroVenda17 = new RegistroVenda(17, new DateTime(2018, 10, 1), 12000.0, StatusVenda.Faturado, vendedor1);
            RegistroVenda registroVenda18 = new RegistroVenda(18, new DateTime(2018, 10, 24), 6000.0, StatusVenda.Faturado, vendedor3);
            RegistroVenda registroVenda19 = new RegistroVenda(19, new DateTime(2018, 10, 22), 8000.0, StatusVenda.Faturado, vendedor5);
            RegistroVenda registroVenda20 = new RegistroVenda(20, new DateTime(2018, 10, 15), 8000.0, StatusVenda.Faturado, vendedor6);
            RegistroVenda registroVenda21 = new RegistroVenda(21, new DateTime(2018, 10, 17), 9000.0, StatusVenda.Faturado, vendedor2);
            RegistroVenda registroVenda22 = new RegistroVenda(22, new DateTime(2018, 10, 24), 4000.0, StatusVenda.Faturado, vendedor4);
            RegistroVenda registroVenda23 = new RegistroVenda(23, new DateTime(2018, 10, 19), 11000.0, StatusVenda.Cancelado, vendedor2);
            RegistroVenda registroVenda24 = new RegistroVenda(24, new DateTime(2018, 10, 12), 8000.0, StatusVenda.Faturado, vendedor5);
            RegistroVenda registroVenda25 = new RegistroVenda(25, new DateTime(2018, 10, 31), 7000.0, StatusVenda.Faturado, vendedor3);
            RegistroVenda registroVenda26 = new RegistroVenda(26, new DateTime(2018, 10, 6), 5000.0, StatusVenda.Faturado, vendedor4);
            RegistroVenda registroVenda27 = new RegistroVenda(27, new DateTime(2018, 10, 13), 9000.0, StatusVenda.Pendente, vendedor1);
            RegistroVenda registroVenda28 = new RegistroVenda(28, new DateTime(2018, 10, 7), 4000.0, StatusVenda.Faturado, vendedor3);
            RegistroVenda registroVenda29 = new RegistroVenda(29, new DateTime(2018, 10, 23), 12000.0, StatusVenda.Faturado, vendedor5);
            RegistroVenda registroVenda30 = new RegistroVenda(30, new DateTime(2018, 10, 12), 5000.0, StatusVenda.Faturado, vendedor2);

            //add o departamentos
            _context.Departamento.AddRange(departamento1, departamento2, departamento3, departamento4);
            //add os vendedores
            _context.Vendedor.AddRange(vendedor1, vendedor2, vendedor3, vendedor4, vendedor5, vendedor6);
            //add os resgistros de vendas
            _context.RegistroVenda.AddRange(
                registroVenda1, registroVenda2, registroVenda3, registroVenda4, registroVenda5, registroVenda6, registroVenda7, registroVenda8, 
                registroVenda9, registroVenda10, registroVenda11, registroVenda12, registroVenda13, registroVenda14, registroVenda15, registroVenda16,
                registroVenda17, registroVenda18, registroVenda19, registroVenda20, registroVenda21, registroVenda22, registroVenda23, registroVenda24, 
                registroVenda25, registroVenda26, registroVenda27, registroVenda28, registroVenda29, registroVenda30
            );
            //salva e confirma as alteracaoes nao banco de dados
            _context.SaveChanges();
        }
    }
}
