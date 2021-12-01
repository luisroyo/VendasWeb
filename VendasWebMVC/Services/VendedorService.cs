using System.Collections.Generic;
using System.Linq;
using VendasWebMVC.Models;
using Microsoft.EntityFrameworkCore;

namespace VendasWebMVC.Services
{
    public class VendedorService
    {
<<<<<<< HEAD
        private readonly VendasWebMVCContext _context;

        public VendedorService(VendasWebMVCContext context)
        {
            _context = context;
=======
        private readonly VendasWebMVCContext _contex;

        public VendedorService(VendasWebMVCContext context)
        {
            _contex = context;
>>>>>>> aac1a996cf27aaff57e41c16a07fc619bc675f3e
        }

        public List<Vendedor> BuscarTodos()
        {
<<<<<<< HEAD
            return _context.Vendedor.ToList();
        }
        public void Inserir(Vendedor obj)
        {            
            _context.Add(obj);
            _context.SaveChanges();
        }
        public Vendedor BuscarId(int id)
        {
            return _context.Vendedor.Include(obj=> obj.Departamento).FirstOrDefault(obj => obj.ID == id);
=======
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
>>>>>>> aac1a996cf27aaff57e41c16a07fc619bc675f3e
        }

        public void Remover(int id)
        {
<<<<<<< HEAD
            var obj = _context.Vendedor.Find(id);
            _context.Vendedor.Remove(obj);
            _context.SaveChanges();
        }

        
=======
            var obj = _contex.Vendedor.Find(id);
            _contex.Vendedor.Remove(obj);
            _contex.SaveChanges();
        }        
>>>>>>> aac1a996cf27aaff57e41c16a07fc619bc675f3e
    }
}
