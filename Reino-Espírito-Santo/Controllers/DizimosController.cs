using Microsoft.AspNetCore.Mvc;
using Reino_Espírito_Santo.Models.Dizimo;
using System.Linq;

namespace Reino_Espírito_Santo.Controllers
{
    public class DizimosController : Controller
    {
        private readonly DizimoModel _dizimoModel;

        public DizimosController()
        {
            _dizimoModel = new DizimoModel();
        }

        public IActionResult Index()
        {
            var contribuições = _dizimoModel.GetAll();
            var ultimoDizimo = contribuições.LastOrDefault();

            var model = new DizimoModel()
            {
                Total = ultimoDizimo?.Total ?? 0,
                Adicionado = ultimoDizimo?.Adicionado ?? 0,
                AntigoAdd1 = ultimoDizimo?.AntigoAdd1 ?? 0,
                AntigoAdd2 = ultimoDizimo?.AntigoAdd2 ?? 0,
                AntigoAdd3 = ultimoDizimo?.AntigoAdd3 ?? 0
            };

            return View(model);
        }

        public IActionResult Contribuir()
        {
            return View(new DizimoModel() { Adicionado = 0 });
        }

        [HttpPost]
        public IActionResult Contribuir(DizimoModel model)
        {
            var contribuições = _dizimoModel.GetAll();
            var ultimoDizimo = contribuições.LastOrDefault();

            var novoDizimo = new DizimoModel()
            {
                Total = (ultimoDizimo?.Total ?? 0) + model.Adicionado,
                Adicionado = model.Adicionado,
                AntigoAdd1 = ultimoDizimo?.AntigoAdd1 ?? 0,
                AntigoAdd2 = ultimoDizimo?.AntigoAdd2 ?? 0,
                AntigoAdd3 = ultimoDizimo?.AntigoAdd3 ?? 0
            };

            if (novoDizimo.AntigoAdd1 == 0)
                novoDizimo.AntigoAdd1 = model.Adicionado;
            else if (novoDizimo.AntigoAdd2 == 0)
                novoDizimo.AntigoAdd2 = model.Adicionado;
            else if (novoDizimo.AntigoAdd3 == 0)
                novoDizimo.AntigoAdd3 = model.Adicionado;

            novoDizimo.Create();

            return RedirectToAction("Index");
        }
    }
}
