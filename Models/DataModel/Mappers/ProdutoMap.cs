using AspnetCoreCrud.Models.DomainModel;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AspnetCoreCrud.Models.DataModel.Mappers
{
    public static class ProdutoMap
    {
        public static void Map(this EntityTypeBuilder<Produto> entity)
        {
            entity.ToTable(nameof(Produto));

            entity.HasKey(p => p.Id);

            entity.Property(p => p.Id).ValueGeneratedOnAdd();
            entity.Property(p => p.Nome).HasMaxLength(150).IsRequired();
            entity.Property(p => p.Valor).IsRequired();
        }
    }
}