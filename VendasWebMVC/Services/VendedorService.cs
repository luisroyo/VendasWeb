using System.Collections.Generic;
using System.Linq;
using VendasWebMVC.Models;

namespace VendasWebMVC.Services
{
    public class VendedorService
    {
        private readonly VendasWebMVCContext _contex;

        public VendedorService(VendasWebMVCContext context)
        {
            _contex = context;
        }

        public List<Vendedor> BuscarTodos()
        {
            return _contex.Vendedor.ToList();
        }
        public void Inserir(Vendedor obj)
        {
            obj.Departamento = _contex.Departamento.First();
            _contex.Add(obj);
            _contex.SaveChanges();
        }
    }
}
