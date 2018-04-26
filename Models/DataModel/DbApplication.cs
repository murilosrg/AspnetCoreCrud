using AspnetCoreCrud.Models.DomainModel;
using AspnetCoreCrud.Models.DataModel.Mappers;
using Microsoft.EntityFrameworkCore;

namespace AspnetCoreCrud.Models.DataModel
{
    public class DbApplication : DbContext
    {
         public DbSet<Produto> Produtos { get; set; }

        public DbApplication(DbContextOptions<DbApplication> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Produto>().Map();
        }
    }
}