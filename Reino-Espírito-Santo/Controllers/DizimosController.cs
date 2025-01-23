using Microsoft.AspNetCore.Mvc;
using Reino_Espírito_Santo.Models.Dizimo;

namespace Reino_Espírito_Santo.Controllers
{
    public class DizimosController : Controller
    {
        public static decimal _Total = 100;
        public static decimal _UltimaContribuicao = 20;

        public IActionResult Index()
        {
            var model = new DizimoModel () { Total = _Total, Adicionado = _UltimaContribuicao };
            return View(model);
        }
        public IActionResult Contribuir()
        {
            return View(new DizimoModel () { Adicionado = 0});
        }
        [HttpPost]
        public IActionResult Contribuir(DizimoModel model)
        {
            _UltimaContribuicao = model.Adicionado;
            _Total += model.Adicionado;

            var updatedModel = new DizimoModel() { Total = _Total, Adicionado = model.Adicionado };
            return RedirectToAction("Index");


        }
    }
}
