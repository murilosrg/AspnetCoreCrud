using Microsoft.AspNetCore.Mvc;
using AspnetCoreCrud.Models.DataModel;
using System.Threading.Tasks;
using System.Linq;
using AspnetCoreCrud.Models.DomainModel;
using AspnetCoreCrud.Models.ViewModel.Produtos;
using AspnetCoreCrud.Models.DataModel.Queries;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace AspnetCoreCrud.Controllers
{
    [Route("produtos")]
    public class ProdutosController : Controller
    {
        private DbApplication dbApplication;

        public ProdutosController(DbApplication dbApplication)
        {
            this.dbApplication = dbApplication;
        }

        [HttpPost, Route("atualizar")]
        public async Task<IActionResult> Atualizar(AtualizarProdutoViewModel viewModel)
        {

            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            Produto produto = await dbApplication
                .Produtos
                .ComId(viewModel.Id)
                .SingleOrDefaultAsync();

            if(produto == null)
                 return Json("Produto não encontrado.");

            produto.Nome = viewModel.Nome;
            produto.Valor = viewModel.Valor;

            dbApplication.Update(produto);
            dbApplication.SaveChanges();
           
            return Json("Produto atualizado com sucesso");
        }
        
        [HttpPost, Route("consultar")]
        public async Task<IActionResult> Consultar(ConsultarProdutosViewModel viewModel)
        {
            ICollection<dynamic> produtosJson = await dbApplication
                .Produtos
                .OrdenadosPorNome()
                .OndeNomeContem(viewModel.Nome)
                .Select(p => new
                {
                    id = p.Id,
                    nome = p.Nome,
                    valor = p.Valor
                })
                .ToListAsync<dynamic>();

            return Json(new
            {
                produtos = produtosJson
            });
        }

        [HttpPost, Route("cadastrar")]
        public ActionResult Cadastrar(CadastrarProdutoViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            Produto produto = new Produto()
            {
                Nome = viewModel.Nome,
                Valor = viewModel.Valor
            };

            dbApplication.Add(produto);
            dbApplication.SaveChanges();


            return Json("Produto cadastrado com sucesso");
        }

        [HttpPost, Route("remover")]
        public async Task<IActionResult> Remover(IdProdutoViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            Produto produto = await dbApplication
                .Produtos
                .ComId(viewModel.Id)
                .SingleOrDefaultAsync();

            if(produto == null)
                 return Json("Produto não encontrado.");
            
            dbApplication.Remove(produto);
            dbApplication.SaveChanges();


            return Json("Produto removido com sucesso");
        }
    }
}