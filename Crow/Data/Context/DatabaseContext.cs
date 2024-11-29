using Crow.Models;
using Microsoft.EntityFrameworkCore;

namespace Crow.Data.Context
{
    public class DatabaseContext : DbContext
    {
        public required virtual DbSet<ClienteModel> Cliente { get; set; }
        public required virtual DbSet<RoupaModel> Roupa { get; set; }
        public DatabaseContext(DbContextOptions options) : base(options) { }
        protected DatabaseContext() { }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ClienteModel>(entity =>
            {
                entity.ToTable("tabela_cliente");
                entity.HasKey(c => c.ClienteId);
                entity.Property(c => c.Nome).IsRequired();
                entity.Property(c => c.SenhaHash).IsRequired();
                entity.Property(c => c.Email).IsRequired();
                entity.Property(c => c.Role);
                entity.Property(c => c.DataCadastro).IsRequired().HasColumnType("date");
            });

            modelBuilder.Entity<RoupaModel>(entity =>
            {
                entity.ToTable("tabela_roupa");
                entity.HasKey(r => r.RoupaId);
                entity.Property(r => r.Nome).IsRequired();
                entity.Property(r => r.Cor).IsRequired();
                entity.Property(r => r.Preco).IsRequired();
                entity.Property(r => r.Estoque).IsRequired();
                entity.Property(r => r.Descricao).IsRequired();
            });

            base.OnModelCreating(modelBuilder);
        }
    }
}
