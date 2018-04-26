using System.Linq;
using AspnetCoreCrud.Models.DomainModel;

namespace AspnetCoreCrud.Models.DataModel.Queries
{
    public static class ProdutosQuery
    {
        public static IQueryable<Produto> ComId(this IQueryable<Produto> produtos, int id)
        {
            return produtos.Where(p => p.Id == id);
        }
        
        public static IQueryable<Produto> OrdenadosPorNome(this IQueryable<Produto> produtos)
        {
            return produtos.OrderBy(p => p.Nome);
        }

        public static IQueryable<Produto> OndeNomeContem(this IQueryable<Produto> produtos, string nome)
        {
             if (string.IsNullOrWhiteSpace(nome))
            return produtos;
                return produtos.Where(p => p.Nome.Contains(nome));
        }  
    }
}