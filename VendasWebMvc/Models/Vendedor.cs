using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace VendasWebMvc.Models
{
    public class Vendedor
    {
        public int Id { get; set; }

        // torna obrigatorio o nome/ {0} parametriza pegando o nome do atributo ou seja nesta caso (Nome).
        [Required(ErrorMessage = "{0} obrigatorio")]
        // StringLength determina a quantidade minima e maxima de caracter/ErrorMessage mensagem de erro personalizado.
        [StringLength(60,MinimumLength = 3, ErrorMessage = "O tamanho do {0} deve ter em {2} e {1} caracter")]
        public string Nome { get; set; }

        // torna obrigatorio o nome/ {0} parametriza pegando o nome do atributo ou seja nesta caso (Email).
        [Required(ErrorMessage = "{0} obrigatorio")]
        [EmailAddress(ErrorMessage = "Entre com um email valido")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        // torna obrigatorio o nome/ {0} parametriza pegando o nome do atributo ou seja nesta caso (DataNascimento).
        [Required(ErrorMessage = "{0} obrigatorio")]
        // separa os nomes das labels.
        [Display(Name = "Data Nascimento")]
        // exibe somente a date sem o horario.
        [DataType(DataType.Date)]
        // formata a exibicao de data da forma que quiser.
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime DataNascimento { get; set; }

        // torna obrigatorio o nome/ {0} parametriza pegando o nome do atributo ou seja nesta caso (Salario).
        [Required(ErrorMessage = "{0} obrigatorio")]
        // deternima a quantidade minima de salario e maxima.
        [Range(100.0, 50000.0, ErrorMessage = "{0} deve ser de {1} para {2}")]
        // exibi duas casas decimais apos o valor so salario.
        [DisplayFormat(DataFormatString = "{0:F2}")]
        public double Salario { get; set; }
        public Departamento Departamento { get; set; }
        public int DepartamentoId { get; set; }
        public ICollection<RegistroVenda> Vendas { get; set; } = new List<RegistroVenda>();

        public Vendedor()
        {               
        }

        public Vendedor(int id, string nome, string email, DateTime dataNascimento, double salario, Departamento departamento)
        {
            Id = id;
            Nome = nome;
            Email = email;
            DataNascimento = dataNascimento;
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
