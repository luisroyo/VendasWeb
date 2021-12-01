using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace VendasWebMVC.Models
{
    public class Vendedor
    {
        public int ID { get; set; }

        [Required(ErrorMessage = "{0} Obrigatório")]
        [StringLength(60, MinimumLength = 3, ErrorMessage ="{0} deve ser entre {2} e {1}")]
        [Display(Name = "Nome")]
        public string Name { get; set; }

        [Required(ErrorMessage = "{0} Obrigatório")]
        [DataType(DataType.EmailAddress)]
        [EmailAddress(ErrorMessage ="Entre com email valido!")]
        public string Email { get; set; }

        [Required(ErrorMessage = "{0} Obrigatório")]
        [Display(Name = " Nascimento ")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString ="{0:dd/MM/yyyy}")]
        public DateTime Nascimento { get; set; }

        [Required(ErrorMessage = "{0} Obrigatório")]
        [Display(Name= "Salário Base")]
        [Range(100.0, 50000.0, ErrorMessage = "{0} must be from {1} to {2}")]
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
