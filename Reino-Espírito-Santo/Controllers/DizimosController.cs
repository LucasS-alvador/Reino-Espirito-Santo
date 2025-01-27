using Microsoft.AspNetCore.Mvc;
using Reino_Espírito_Santo.Models.Dizimo;

namespace Reino_Espírito_Santo.Controllers
{
    public class DizimosController : Controller
    {
        public static decimal _Total = 0;
        public static decimal _UltimaContribuicao = 0;
        // Lista de contribuições antigas
        public static List<decimal> _AdicionadosAntigos = new List<decimal> {};

        public IActionResult Index()
        {
            var model = new DizimoModel()
            {
                Total = _Total,
                Adicionado = _UltimaContribuicao,
                AdicionadosAntigos = _AdicionadosAntigos // Passando a lista de antigos
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

            _AdicionadosAntigos.Add(model.Adicionado); // Adicionando o novo valor à lista de antigos

            return RedirectToAction("Index");
        }
    }
}
