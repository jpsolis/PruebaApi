using Microsoft.EntityFrameworkCore;

namespace PruebaApi.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        { }

        public DbSet<Producto>? Productos => Set<Producto>();

        public DbSet<Usuario>? Usuarios { get; set; }

        public DbSet<Rol>? Roles { get; set; }

        public DbSet<CarroCompra>? CarroCompras { get; set; }

        public DbSet<Stock>? Stocks { get; set; }

        public DbSet<DetalleCarro>? DetalleCarros { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CarroCompra>()
                .HasOne(e => e.DetalleCarro)
                .WithOne(e => e.CarroCompra)
                .HasForeignKey<DetalleCarro>(e => e.CarroCompraId)
                .IsRequired();
        }
    }
}
