using System.ComponentModel.DataAnnotations;

namespace AspnetCoreCrud.Models.ViewModel.Produtos
{
    public class IdProdutoViewModel
    {
        [Required(ErrorMessage="Produto deve ser informado.")]
        public int Id { get; set; }
    }
}