using System;
using System.Collections.Generic;
using VendasWebMVC.Models;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace VendasWebMVC.Services
{
    public class VendaRegistradaService
    {
        private readonly VendasWebMVCContext _context;
        public VendaRegistradaService(VendasWebMVCContext context)
        {
            _context = context;
        }

        public async Task<List<VendaRegistrada>> BuscarDataAsync(DateTime? minDate , DateTime? maxDate )
        {
            var resultado = from obj in _context.VendaRegistrada select obj;
            if (minDate.HasValue)
            {
                resultado = resultado.Where(x => x.Data >= minDate.Value);
            }
            if (maxDate.HasValue)
            {
                resultado = resultado.Where(x => x.Data <= maxDate.Value);
            }
            return await resultado
                .Include(x=> x.Vendedor)
                .Include(x=> x.Vendedor.Departamento)
                .OrderByDescending(x=> x.Data)
                .ToListAsync();
        }
        public async Task<List<IGrouping<Departamento, VendaRegistrada>>> BuscarDataGrupoAsync(DateTime? minDate, DateTime? maxDate)
        {
            var resultado = from obj in _context.VendaRegistrada select obj;
            if (minDate.HasValue)
            {
                resultado = resultado.Where(x => x.Data >= minDate.Value);
            }
            if (maxDate.HasValue)
            {
                resultado = resultado.Where(x => x.Data <= maxDate.Value);
            }
            return await resultado
                .Include(x => x.Vendedor)
                .Include(x => x.Vendedor.Departamento)
                .OrderByDescending(x => x.Data)
                .GroupBy(x=> x.Vendedor.Departamento)
                .ToListAsync();
        }
    }
}
