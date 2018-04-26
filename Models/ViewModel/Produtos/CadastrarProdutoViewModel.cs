using System.ComponentModel.DataAnnotations;

namespace AspnetCoreCrud.Models.ViewModel.Produtos
{
    public class CadastrarProdutoViewModel
    {

        [Required(ErrorMessage= "Campo 'Nome' é obrigatorio"), StringLength(150, ErrorMessage = "Campo 'Nome' deve conter no máximo {0} caracteres.")]
        public string Nome { get; set; }

        [Required(ErrorMessage= "Campo 'Valor' é obrigatorio"), RegularExpression(@"\d+(\.\d{1,2})?", ErrorMessage = "Campo 'Valor' é invalido.")]
        public decimal Valor { get; set; }
    }
}