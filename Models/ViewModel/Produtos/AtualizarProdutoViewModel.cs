using System.ComponentModel.DataAnnotations;

namespace AspnetCoreCrud.Models.ViewModel.Produtos
{
    public class AtualizarProdutoViewModel
    {
        [Required(ErrorMessage="Produto deve ser informado.")]
        public int Id { get; set; }

        [Required, StringLength(150, ErrorMessage = "Campo 'Nome' deve conter no máximo {0} caracteres.")]
        public string Nome { get; set; }

        [Required, RegularExpression(@"\d+(\.\d{1,2})?", ErrorMessage = "Campo 'Nome' é invalido.")]
        public string Valor { get; set; }
    }
}