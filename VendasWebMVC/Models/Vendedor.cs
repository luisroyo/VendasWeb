using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace VendasWebMVC.Models
{
    public class Vendedor
    {
        public int ID { get; set; }
        public string Name { get; set; }

        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Display(Name = " Nascimento ")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString ="{0:dd/MM/yyyy}")]
        public DateTime Nascimento { get; set; }

        [Display(Name= "Salário Base")]
        [DisplayFormat(DataFormatString ="{0:F2}")]
        public double SalarioBase { get; set; }
        public Departamento Departamento { get; set; }
        public int DepartamentoId { get; set; }
        public ICollection<VendaRegistrada> Vendas { get; set; } = new List<VendaRegistrada>();

        public Vendedor()
        {

        }

        public Vendedor(int iD, string name, string email, DateTime nascimento, double salarioBase, Departamento departamento)
        {
            ID = iD;
            Name = name;
            Email = email;
            Nascimento = nascimento;
            SalarioBase = salarioBase;
            Departamento = departamento;
        }

        public void AdicionarVenda(VendaRegistrada vr)
        {
            Vendas.Add(vr);
        }
        public void RemoveVenda(VendaRegistrada vr)
        {
            Vendas.Remove(vr);
        }
        public double TotalVendas(DateTime inicial, DateTime final)
        {
            return Vendas.Where(vr => vr.Data >= inicial && vr.Data <= final).Sum(vr => vr.Quantia);
        }

    }
}
