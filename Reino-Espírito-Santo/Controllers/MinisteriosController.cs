using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Reino_Espírito_Santo.DataBase.Entidades;
using Reino_Espírito_Santo.Models.Ministerios;
using Reino_Espírito_Santo.DataBase.Entidades;

namespace Reino_Espírito_Santo.Controllers
{
    public class MinisteriosController : Controller
    {
        public IActionResult Index()
        {
            var model = new MinisteriosModel();
            model.Ministerio = new List<MinisterioModel>();

            var ministerios = Ministerio.GetAll(); // Método estático para buscar todos os ministérios

            // A forma mais simples de mapear os dados
            model.Ministerio = ministerios.Select(ministerioEntidade => new MinisterioModel(ministerioEntidade)).ToList();

            return View(model);
        }

        public IActionResult Record(long? id)
        {
            var model = new MinisterioModel();

            if (id.HasValue)
            {
                // Aqui buscamos o ministério pelo ID
                model = new MinisterioModel(Ministerio.Get(id.Value));
            }

            return View(model);
        }

        [HttpPost]
        public IActionResult Record(MinisterioModel model, string type)
        {
            Ministerio ministerio = model.getEntidade();

            if (type == "save")
            {
                // Se o ID for maior que 0, significa que já existe no banco, então vamos atualizar
                if (ministerio.Id > 0)
                {
                    ministerio.Update(); // Atualiza o ministério no banco de dados
                }
                else
                {
                    ministerio.Create(); // Cria um novo ministério no banco de dados
                }
            }
            else if (type == "delete")
            {
                ministerio.Delete(); // Exclui o ministério
            }
            else
            {
                return BadRequest("Requisição inválida!"); // Retorna erro se o tipo de requisição for inválido
            }

            return RedirectToAction("Index"); // Redireciona para a lista de ministérios
        }

        public IActionResult Adicionar()
        {
            var auxiliares = AuxiliaresController.auxiliares
                .Select(a => new SelectListItem
                {
                    Value = a.Id.ToString(),
                    Text = a.Nome
                })
                .ToList();

            ViewBag.Auxiliares = auxiliares; // Passa os auxiliares para a view

            return View();
        }

        [HttpPost]
        public IActionResult Adicionar(MinisterioModel model)
        {
            if (ModelState.IsValid)
            {
                var ministerio = model.getEntidade(); // Converte o modelo para a entidade do banco

                ministerio.Create(); // Cria o novo ministério no banco

                return RedirectToAction("Index"); // Redireciona para a lista de ministérios
            }

            return View(model); // Retorna para a view caso a validação não passe
        }
    }
}
