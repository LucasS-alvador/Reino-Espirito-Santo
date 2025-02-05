using System.Security.Cryptography.X509Certificates;
using Microsoft.AspNetCore.Mvc;
using Reino_Espírito_Santo.Models.Auxiliares;

namespace Reino_Espírito_Santo.Controllers
{
    public class AuxiliaresController : Controller
    {
        public static List<AuxiliarModel> auxiliares = new List<AuxiliarModel>()
        {
            new AuxiliarModel() {Id = 1, Nome = "Test", Funcao = "presbitero" , Telefone = "47 9982-3883"},
            new AuxiliarModel() { Id = 1, Nome = "Test", Funcao = "presbitero", Telefone = "47 9982-3883" },
            new AuxiliarModel() { Id = 2, Nome = "Ana Souza", Funcao = "diaconisa", Telefone = "47 9876-5432" },
            new AuxiliarModel() { Id = 3, Nome = "Carlos Pereira", Funcao = "pastor", Telefone = "47 9678-1122" },
            new AuxiliarModel() { Id = 4, Nome = "Maria Oliveira", Funcao = "auxiliar", Telefone = "47 9988-1122" },
            new AuxiliarModel() { Id = 5, Nome = "João Silva", Funcao = "presbitero", Telefone = "47 9678-2233" },
            new AuxiliarModel() { Id = 6, Nome = "Luciana Martins", Funcao = "diaconisa", Telefone = "47 9555-3344" },
            new AuxiliarModel() { Id = 7, Nome = "Paulo Santos", Funcao = "pastor", Telefone = "47 9444-5566" },
            new AuxiliarModel() { Id = 8, Nome = "Fernanda Costa", Funcao = "auxiliar", Telefone = "47 9222-7788" },
            new AuxiliarModel() { Id = 9, Nome = "Ricardo Almeida", Funcao = "presbitero", Telefone = "47 9333-8899" },
            new AuxiliarModel() { Id = 10, Nome = "Patrícia Lima", Funcao = "diaconisa", Telefone = "47 9111-1000" },

        };

        public IActionResult Index()
        {
            var model = new AuxiliaresModel() { Auxiliares = new AuxiliarModel().GetAll() };
            return View(model);
        }
        public IActionResult Record(long id)
        {
            var auxiliaratual = auxiliares.FirstOrDefault(auxiliar => auxiliar.Id == id);
            return View(auxiliaratual);
        }
        [HttpPost]
        public IActionResult Save(AuxiliarModel model)
        {
            var auxiliar = auxiliares.FirstOrDefault(i => i.Id == model.Id);

            auxiliar.Nome = model.Nome;
            auxiliar.Funcao = model.Funcao;
            auxiliar.Telefone = model.Telefone;

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
                model.Id = auxiliares.Max(a => a.Id) + 1;

                auxiliares.Add(model);

                return RedirectToAction("Index");
            }

            return View(model);
        }
        [HttpPost]
        public IActionResult Create(AuxiliarModel auxiliar)
        {
            auxiliar.Create();
            return RedirectToAction("Index");
        }
        public IActionResult Delete(int id)
        {
            new AuxiliarModel().Delete(id);
            return RedirectToAction("Index");
        }

        
    }
}


