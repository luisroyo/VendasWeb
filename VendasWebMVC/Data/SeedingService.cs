using System;
using System.Linq;
using VendasWebMVC.Models;
using VendasWebMVC.Models.Enums;

namespace VendasWebMVC.Data
    
{
    public class SeedingService
    {
        private VendasWebMVCContext _context;

        public SeedingService(VendasWebMVCContext context)
        {
            _context = context;
        }

        public void Seed()
        {
            if (_context.Departamento.Any() ||
                _context.Vendedor.Any() ||
                _context.VendaRegistrada.Any())
            {
                return; // BD ja foi populado
            }

            Departamento d1 = new Departamento(1, "Computadores");
            Departamento d2 = new Departamento(2, "Eletrônicos"); 
            Departamento d3 = new Departamento(3, "Eletromésticos");
            Departamento d4 = new Departamento(4, "Livros");

            Vendedor v1 = new Vendedor(1, "Luis Eduardo", "luis@gmail",new DateTime(1987,4,30),2000.0,d1);
            Vendedor v2 = new Vendedor(2, "Luis Miguel ", "miguel@gmail", new DateTime(2001, 2, 01), 1000.0, d2);
            Vendedor v3 = new Vendedor(3, "Cris Royo", "cris@gmail", new DateTime(1990, 3, 27), 1500.0, d3);
            Vendedor v4 = new Vendedor(4, "João Gabriel", "joao@gmail", new DateTime(1999, 5, 12), 3000.0, d3);
            Vendedor v5 = new Vendedor(5, "Royo Eduardo", "Royo@gmail", new DateTime(1986, 1, 01), 5000.0, d4);

            VendaRegistrada vr1 = new VendaRegistrada(1,new DateTime(2021/11/29), 10000.0,StatusVenda.Faturado,v1);
            VendaRegistrada vr2 = new VendaRegistrada(31, new DateTime(2021, 09, 25), 11000.0, StatusVenda.Faturado, v1);
            VendaRegistrada vr3 = new VendaRegistrada(2, new DateTime(2021, 09, 4), 7000.0, StatusVenda.Faturado, v5);
            VendaRegistrada vr4 = new VendaRegistrada(3, new DateTime(2021, 09, 13), 4000.0, StatusVenda.Cancelado, v4);
            VendaRegistrada vr5 = new VendaRegistrada(4, new DateTime(2021, 09, 1), 8000.0, StatusVenda.Faturado, v1);
            VendaRegistrada vr6 = new VendaRegistrada(5, new DateTime(2021, 09, 21), 3000.0, StatusVenda.Faturado, v3);
            VendaRegistrada vr7 = new VendaRegistrada(6, new DateTime(2021, 09, 15), 2000.0, StatusVenda.Faturado, v1);
            VendaRegistrada vr8 = new VendaRegistrada(7, new DateTime(2021, 09, 28), 13000.0, StatusVenda.Faturado, v2);
            VendaRegistrada vr9 = new VendaRegistrada(8, new DateTime(2021, 09, 11), 4000.0, StatusVenda.Faturado, v4);
            VendaRegistrada vr10 = new VendaRegistrada(9, new DateTime(2021, 09, 14), 11000.0, StatusVenda.Pendente, v4);
            VendaRegistrada vr11 = new VendaRegistrada(10, new DateTime(2021, 09, 7), 9000.0, StatusVenda.Faturado, v5);
            VendaRegistrada vr12 = new VendaRegistrada(11, new DateTime(2021, 09, 13), 6000.0, StatusVenda.Faturado, v2);
            VendaRegistrada vr13= new VendaRegistrada(12, new DateTime(2021, 09, 25), 7000.0, StatusVenda.Pendente, v3);
            VendaRegistrada vr14= new VendaRegistrada(13, new DateTime(2021, 09, 29), 10000.0, StatusVenda.Faturado, v4);
            VendaRegistrada vr15= new VendaRegistrada(14, new DateTime(2021, 09, 4), 3000.0, StatusVenda.Faturado, v5);
            VendaRegistrada vr16= new VendaRegistrada(15, new DateTime(2021, 09, 12), 4000.0, StatusVenda.Faturado, v1);
            VendaRegistrada vr17= new VendaRegistrada(16, new DateTime(2021, 10, 5), 2000.0, StatusVenda.Faturado, v4);
            VendaRegistrada vr18= new VendaRegistrada(17, new DateTime(2021, 10, 1), 12000.0, StatusVenda.Faturado, v1);
            VendaRegistrada vr19= new VendaRegistrada(18, new DateTime(2021, 10, 24), 6000.0, StatusVenda.Faturado, v3);
            VendaRegistrada vr20= new VendaRegistrada(19, new DateTime(2021, 10, 22), 8000.0, StatusVenda.Faturado, v5);
            VendaRegistrada vr21 = new VendaRegistrada(20, new DateTime(2021, 10, 15), 8000.0, StatusVenda.Faturado, v5);
            VendaRegistrada vr22= new VendaRegistrada(21, new DateTime(2021, 10, 17), 9000.0, StatusVenda.Faturado, v2);
            VendaRegistrada vr23= new VendaRegistrada(22, new DateTime(2021, 10, 24), 4000.0, StatusVenda.Faturado, v4);
            VendaRegistrada vr24= new VendaRegistrada(23, new DateTime(2021, 10, 19), 11000.0, StatusVenda.Cancelado, v2);
            VendaRegistrada vr25= new VendaRegistrada(24, new DateTime(2021, 10, 12), 8000.0, StatusVenda.Faturado, v5);
            VendaRegistrada vr26= new VendaRegistrada(25, new DateTime(2021, 10, 31), 7000.0, StatusVenda.Faturado, v3);
            VendaRegistrada vr27= new VendaRegistrada(26, new DateTime(2021, 10, 6), 5000.0, StatusVenda.Faturado, v4);
            VendaRegistrada vr28= new VendaRegistrada(27, new DateTime(2021, 10, 13), 9000.0, StatusVenda.Pendente, v1);
            VendaRegistrada vr29= new VendaRegistrada(28, new DateTime(2021, 10, 7), 4000.0, StatusVenda.Faturado, v3);
            VendaRegistrada vr30 = new VendaRegistrada(29, new DateTime(2021, 10, 23), 12000.0, StatusVenda.Faturado, v5);
            VendaRegistrada vr31= new VendaRegistrada(30, new DateTime(2021, 10, 12), 5000.0, StatusVenda.Faturado, v2);

            _context.Departamento.AddRange(d1, d2, d3, d4);

            _context.Vendedor.AddRange(v1, v2, v3, v4, v5);

            _context.VendaRegistrada.AddRange(vr1, vr2, vr3, vr4, vr5, vr6, vr7, vr8, vr9, vr10, vr11, vr12, vr13, vr14, vr15
                , vr16, vr17, vr18, vr19, vr20, vr21, vr22, vr23, vr24, vr25, vr26, vr27, vr28, vr29, vr30, vr31);

            _context.SaveChanges();
        }
    }
}
