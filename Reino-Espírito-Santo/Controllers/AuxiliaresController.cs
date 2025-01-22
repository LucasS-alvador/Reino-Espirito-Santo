using System.Security.Cryptography.X509Certificates;
using Microsoft.AspNetCore.Mvc;
using Reino_Espírito_Santo.Models.Auxiliares;

namespace Reino_Espírito_Santo.Controllers
{
    public class AuxiliaresController : Controller
    {
        static List<AuxiliarModel> _auxiliares = new List<AuxiliarModel>()
        {
            new AuxiliarModel() {Id = 1, Nome = "Test", Funcao = "presbitero"},
            new AuxiliarModel() {Id = 2, Nome = "Ana", Funcao = "diaconisa"},
            new AuxiliarModel() {Id = 3, Nome = "João", Funcao = "mestre"},
            new AuxiliarModel() {Id = 4, Nome = "Carlos", Funcao = "pastor"},
            new AuxiliarModel() {Id = 5, Nome = "Maria", Funcao = "evangelista"},
            new AuxiliarModel() {Id = 6, Nome = "Roberto", Funcao = "presbitero"},
            new AuxiliarModel() {Id = 7, Nome = "Patricia", Funcao = "diaconisa"},
            new AuxiliarModel() {Id = 8, Nome = "Eduardo", Funcao = "mestre"},
            new AuxiliarModel() {Id = 9, Nome = "Juliana", Funcao = "pastor"},
            new AuxiliarModel() {Id = 10, Nome = "Felipe", Funcao = "evangelista"}
        };

        public IActionResult Index()
        {
            var model = new AuxiliaresModel() { Auxiliares = _auxiliares };
            return View(model);
        }
        public IActionResult Record(long id)
        {
            var auxiliaratual = _auxiliares.FirstOrDefault(auxiliar => auxiliar.Id == id);
            return View(auxiliaratual);
        }
        [HttpPost]
        public IActionResult Save(AuxiliarModel model)
        {
            var auxiliar = _auxiliares.FirstOrDefault(i => i.Id == model.Id);

            auxiliar.Nome = model.Nome;
            auxiliar.Funcao = model.Funcao;

            return RedirectToAction("Index");
        }
        public IActionResult Add()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Add(AuxiliarModel model)
        {
            if (ModelState.IsValid)
            {
                model.Id = _auxiliares.Max(a => a.Id) + 1;

                _auxiliares.Add(model);

                return RedirectToAction("Index");
            }

            return View(model);
        }

    }
}


