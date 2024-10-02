using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;


namespace taller_evaluativo_poo.AccesoDatos
{
    public class Datos : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // Construir la configuración a partir del appsettings.json
            IConfigurationRoot configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

            // Usar la cadena de conexión
            var connectionString = configuration.GetConnectionString("DefaultConnection");
            optionsBuilder.UseSqlServer(connectionString);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Configura TPT para cada tipo derivado, para que las tablas herencia se creen en la BD
            modelBuilder.Entity<dtosCliente>().ToTable("Clientes");
            modelBuilder.Entity<dtosVendedor>().ToTable("Vendedores");
        }

        // Define los DbSets aquí para las operaciones CRUD sobre las entidades
        public DbSet<dtosPersona> Personas { get; set; }
        public DbSet<dtosCliente> Clientes { get; set; }
        public DbSet<dtosVendedor> Vendedores { get; set; }
        public DbSet<dtosEmpresa> Empresas { get; set; }
        public DbSet<dtosFactura> Facturas { get; set; }
        public DbSet<dtosProducto> Productos { get; set; }
        public DbSet<dtosProductosPorFactura> ProductosPorFactura { get; set; }
    }
}