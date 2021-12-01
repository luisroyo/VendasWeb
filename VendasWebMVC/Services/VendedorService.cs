using System.Collections.Generic;
using System.Linq;
using VendasWebMVC.Models;
using Microsoft.EntityFrameworkCore;
using VendasWebMVC.Services.Exceptions;

namespace VendasWebMVC.Services
{
    public class VendedorService
    {
        private readonly VendasWebMVCContext _context;

        public VendedorService(VendasWebMVCContext context)
        {
            _context = context;
        }

        public List<Vendedor> BuscarTodos()
        {
            return _context.Vendedor.ToList();
        }
        public void Inserir(Vendedor obj)
        {
            _context.Add(obj);
            _context.SaveChanges();
        }
        public Vendedor BuscarId(int id)
        {
            return _context.Vendedor.Include(obj => obj.Departamento).FirstOrDefault(obj => obj.ID == id);
        }

        public void Remover(int id)
        {
            var obj = _context.Vendedor.Find(id);
            _context.Vendedor.Remove(obj);
            _context.SaveChanges();
        }
        public void Update(Vendedor obj)
        {
            if(!_context.Vendedor.Any(x=> x.ID == obj.ID))
            {
                throw new NotFoundException("Id Não Encontrado!");
            }
            try
            {
                _context.Update(obj);
                _context.SaveChanges();
            }
            catch (DbConcurrencyException e)
            {
                throw new DbConcurrencyException(e.Message);
            }
            
        }
    }
}