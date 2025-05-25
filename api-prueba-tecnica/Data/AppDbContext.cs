using Microsoft.EntityFrameworkCore;

namespace api_prueba_tecnica.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }
        public DbSet<Models.Clientes> Clientes { get; set; }
        public DbSet<Models.Pedidos> Pedidos { get; set; }
        public DbSet<Models.Productos> Productos { get; set; }
        public DbSet<Models.DetallePedido> DetallePedidos { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Models.Pedidos>()
                .HasOne<Models.Clientes>(c => c.Cliente)
                .WithMany();

            modelBuilder.Entity<Models.DetallePedido>()
               .HasOne<Models.Productos>(c => c.Producto)
               .WithMany();

            modelBuilder.Entity<Models.DetallePedido>()
               .HasOne<Models.Pedidos>(c => c.Pedido)
               .WithMany();
        }
    }
}
