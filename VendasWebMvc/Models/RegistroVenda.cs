using System;
using System.ComponentModel.DataAnnotations;
using VendasWebMvc.Models.Enums;

namespace VendasWebMvc.Models
{
    public class RegistroVenda
    {
        public int Id { get; set; }

        [DisplayFormat(DataFormatString ="{0:dd/MM/yyyy}")]
        public DateTime Data { get; set; }

        [DisplayFormat(DataFormatString ="{0:F2}")]
        public double Quantia { get; set; }
        public StatusVenda Status { get; set; }
        public Vendedor Vendedor { get; set; }

        public RegistroVenda()
        {                
        }

        public RegistroVenda(int id, DateTime data, double quantia, StatusVenda status, Vendedor vendedor)
        {
            Id = id;
            Data = data;
            Quantia = quantia;
            Status = status;
            Vendedor = vendedor;
        }
    }
}