﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using VendasWebMVC.Models;

namespace VendasWebMVC.Models
{
    public class VendasWebMVCContext : DbContext
    {
        public VendasWebMVCContext (DbContextOptions<VendasWebMVCContext> options)
            : base(options)
        {
        }

        public DbSet<Departamento> Departamento { get; set; }
        public DbSet<Vendedor>Vendedor { get; set; }
        public DbSet<VendaRegistrada> VendaRegistrada { get; set; }
    }
}
