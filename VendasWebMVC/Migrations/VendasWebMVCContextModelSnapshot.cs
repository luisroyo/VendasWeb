﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using VendasWebMVC.Models;

namespace VendasWebMVC.Migrations
{
    [DbContext(typeof(VendasWebMVCContext))]
    partial class VendasWebMVCContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.14-servicing-32113")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("VendasWebMVC.Models.Departamento", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Nome");

                    b.HasKey("Id");

                    b.ToTable("Departamento");
                });

            modelBuilder.Entity("VendasWebMVC.Models.VendaRegistrada", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("Data");

                    b.Property<double>("Quantia");

                    b.Property<int>("Status");

                    b.Property<int?>("VendedorID");

                    b.HasKey("Id");

                    b.HasIndex("VendedorID");

                    b.ToTable("VendaRegistrada");
                });

            modelBuilder.Entity("VendasWebMVC.Models.Vendedor", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<int?>("DepartamentoId");

                    b.Property<string>("Email");

                    b.Property<string>("Name");

                    b.Property<DateTime>("Nascimento");

                    b.Property<double>("SalarioBase");

                    b.HasKey("ID");

                    b.HasIndex("DepartamentoId");

                    b.ToTable("Vendedor");
                });

            modelBuilder.Entity("VendasWebMVC.Models.VendaRegistrada", b =>
                {
                    b.HasOne("VendasWebMVC.Models.Vendedor", "Vendedor")
                        .WithMany("Vendas")
                        .HasForeignKey("VendedorID");
                });

            modelBuilder.Entity("VendasWebMVC.Models.Vendedor", b =>
                {
                    b.HasOne("VendasWebMVC.Models.Departamento", "Departamento")
                        .WithMany("Vendedores")
                        .HasForeignKey("DepartamentoId");
                });
#pragma warning restore 612, 618
        }
    }
}
