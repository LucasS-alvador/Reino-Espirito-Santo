using Microsoft.AspNetCore.Mvc;
using MySql.Data.MySqlClient;
using Reino_Espírito_Santo.Models.Dizimo;
using System.Data;

namespace Reino_Espírito_Santo.Controllers
{
    public class DizimosController : Controller
    {
        public static decimal _Total = 0;
        public static decimal _UltimaContribuicao = 0;
        public static decimal _AntigoAdd1 = 0;
        public static decimal _AntigoAdd2 = 0;
        public static decimal _AntigoAdd3 = 0;

        private const int MaxContribuicoes = 4;

        public IActionResult Index()
        {
            var model = new DizimoModel()
            {
                Total = _Total,
                Adicionado = _UltimaContribuicao,
                AntigoAdd1 = _AntigoAdd1,
                AntigoAdd2 = _AntigoAdd2,
                AntigoAdd3 = _AntigoAdd3
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
            _UltimaContribuicao = model.Adicionado;
            _Total += model.Adicionado;

            _AntigoAdd3 = _AntigoAdd2;
            _AntigoAdd2 = _AntigoAdd1;
            _AntigoAdd1 = model.Adicionado;

            var novoDizimo = new DizimoModel()
            {
                Total = _Total,
                Adicionado = model.Adicionado,
                AntigoAdd1 = _AntigoAdd1,
                AntigoAdd2 = _AntigoAdd2,
                AntigoAdd3 = _AntigoAdd3
            };

            novoDizimo.Create();

            return RedirectToAction("Index");
        }
    }
}
