using System;
using Microsoft.EntityFrameworkCore;
using app.neptuno.models;

namespace app.neptuno.data
{
    public class DataContext : DbContext
    {
        // 3 minutos * 60 segundos/minuto = 180 segundos
        int tiempo_de_espera_en_segundos = 180;

        public DataContext()
        {
        }

        public DataContext(DbContextOptions<DataContext> options) : base(options) { }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlServer("server=localhost;database=neptuno;user=sa;password=M1n0T4ur0;TrustServerCertificate=true;Encrypt=True;", builder =>
                {
                    builder.EnableRetryOnFailure();
                    builder.CommandTimeout(tiempo_de_espera_en_segundos);
                });
        }


        // entidades
        public DbSet<CoEnte> Ente => Set<CoEnte>();
        public DbSet<InBodega> Bodega => Set<InBodega>();
        public DbSet<InItem> Item => Set<InItem>();
        public DbSet<InItemBodega> ItemBodega => Set<InItemBodega>();
        public DbSet<InGrupoBodega> GrupoBodega => Set<InGrupoBodega>();
        public DbSet<InVentaCab> VentaCab => Set<InVentaCab>();
        public DbSet<InVentaDet> VentaDet => Set<InVentaDet>();
        public DbSet<InNodoClasif1> NodoClasif1 => Set<InNodoClasif1>();
        public DbSet<PrProveedor> Proveedor => Set<PrProveedor>();


        internal Task FindAsync(int id)
        {
            throw new NotImplementedException();
        }
    }
}