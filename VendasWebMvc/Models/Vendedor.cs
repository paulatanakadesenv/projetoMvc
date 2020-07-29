﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VendasWebMvc.Models
{
    public class Vendedor
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public DateTime DatatNascimento { get; set; }
        public double Salario { get; set; }
        public Departamento Departamento { get; set; }
        public ICollection<RegistroVenda> Vendas { get; set; } = new List<RegistroVenda>();

        public Vendedor()
        {               
        }

        public Vendedor(int id, string nome, string email, DateTime datatNascimento, double salario, Departamento departamento)
        {
            Id = id;
            Nome = nome;
            Email = email;
            DatatNascimento = datatNascimento;
            Salario = salario;
            Departamento = departamento;
        }

        public void AddVendas(RegistroVenda sr) 
        {
            Vendas.Add(sr);
        }

        public void RemoverVendas(RegistroVenda sr) 
        {
            Vendas.Remove(sr);
        }

        public double TotalVendas(DateTime inicial, DateTime final) 
        {
            return Vendas.Where(sr => sr.Data >= inicial && sr.Data <= final).Sum(sr => sr.Quantia);
        }
    }
}