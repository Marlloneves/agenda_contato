using AgendaContato.Mvc.Models;
using AgendaContatos.Data.Entities;
using AgendaContatos.Data.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace AgendaContato.Mvc.Controllers
{
    public class ContatosController : Controller
    {
        //Rota
        public IActionResult Cadastro()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Cadastro(ContatosCadastroModel model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var contato = new Contato();
                    contato.IdContato = Guid.NewGuid();
                    contato.Nome = model.Nome;
                    contato.Email = model.Email;
                    var date = DateTime.Parse(model.DataNascimento);
                    contato.DataNascimento = date;
                    contato.Telefone = model.Telefone;
                    var contatosRepository = new ContatoRepository();
                    contatosRepository.Create(contato);

                    TempData["Mensagem"] = $"Contato cadastrado com sucesso.";
                }catch (Exception e)
                {
                    TempData["Mensagem"] = $"Falha ao cadastrar: {e.Message}";
                }
            }
            return View();
        }

        //Rota
        public IActionResult Consulta()
        {
            return View();
        }
        //Rota
        public IActionResult Edicao()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Edicao(ContatosEdicaoModel model)
        {
            if (ModelState.IsValid)
            {
                try
                {

                }
                catch (Exception e)
                {
                    TempData["Mensagem"] = $"Falha ao editar: {e.Message}";
                }
            }
            return View();
        }
    }
}
