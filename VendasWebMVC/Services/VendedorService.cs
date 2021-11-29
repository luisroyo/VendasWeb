using System.Collections.Generic;
using System.Linq;
using VendasWebMVC.Models;
using Microsoft.EntityFrameworkCore;

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
            _contex.Add(obj);
            _contex.SaveChanges();
        }
        public Vendedor BuscarId(int id)
        {
            return _contex.Vendedor.Include(obj=> obj.Departamento).FirstOrDefault(obj => obj.ID == id);
        }

        public void Remover(int id)
        {
            var obj = _contex.Vendedor.Find(id);
            _contex.Vendedor.Remove(obj);
            _contex.SaveChanges();
        }        
    }
}
