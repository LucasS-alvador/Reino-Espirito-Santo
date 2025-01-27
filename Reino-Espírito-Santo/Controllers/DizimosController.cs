using Microsoft.AspNetCore.Mvc;
using Reino_Espírito_Santo.Models.Dizimo;

namespace Reino_Espírito_Santo.Controllers
{
    public class DizimosController : Controller
    {
        public static decimal _Total = 0;
        public static decimal _UltimaContribuicao = 0;
        public static List<decimal> _AdicionadosAntigos = new List<decimal> {};  
        private const int MaxContribuicoes = 3;  

        public IActionResult Index()
        {
            var model = new DizimoModel()
            {
                Total = _Total,
                Adicionado = _UltimaContribuicao,
                AdicionadosAntigos = _AdicionadosAntigos.Take(MaxContribuicoes).ToList()
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

            if (_AdicionadosAntigos.Count >= MaxContribuicoes)
            {
                _AdicionadosAntigos.RemoveAt(_AdicionadosAntigos.Count - 1);
            }

            // Adiciona o novo valor no topo da lista
            _AdicionadosAntigos.Insert(0, model.Adicionado);

            return RedirectToAction("Index");
        }
    }
}
