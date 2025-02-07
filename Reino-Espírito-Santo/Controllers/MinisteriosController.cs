using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Reino_Espírito_Santo.DataBase.Entidades;
using Reino_Espírito_Santo.Models.Auxiliares;
using Reino_Espírito_Santo.Models.Ministerios;

namespace Reino_Espírito_Santo.Controllers
{
    public class MinisteriosController : Controller
    {
        public IActionResult Index()
        {
            var model = new MinisteriosModel() // Ajustando a estrutura do retorno
            { Ministerio = new MinisterioModel().GetAll()
            };

            return View(model);
        }

        public IActionResult Record(long? id)
        {
            var model = id.HasValue ? new MinisterioModel().Get(id.Value) : new MinisterioModel();
            return View(model);
        }

        [HttpPost]
        public IActionResult Record(MinisterioModel model, string type)
        {
            if (!ModelState.IsValid)
                return View(model);

            if (type == "save")
            {
                if (model.Id > 0)
                    model.Update(model.Id);
                else
                    model.Create();
            }
            else if (type == "delete")
            {
                model.Delete(model.Id);
            }
            else
            {
                return BadRequest("Requisição inválida!");
            }

            return RedirectToAction("Index");
        }

        public IActionResult Adicionar()
        {
            var auxiliares = new AuxiliarModel().GetAll()
                .Select(a => new SelectListItem
                {
                    Value = a.ID.ToString(),
                    Text = a.Nome
                })
                .ToList();

            ViewBag.Auxiliares = auxiliares;
            return View(new MinisterioModel());
        }

        [HttpPost]
        public IActionResult Adicionar(MinisterioModel model)
        {
            if (!ModelState.IsValid)
                return View(model);

            model.Create();
            return RedirectToAction("Index");
        }
    }
}
