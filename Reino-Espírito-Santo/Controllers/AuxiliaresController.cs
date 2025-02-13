using System.Security.Cryptography.X509Certificates;
using Microsoft.AspNetCore.Mvc;
using Reino_Espírito_Santo.Models.Auxiliares;

namespace Reino_Espírito_Santo.Controllers
{
    public class AuxiliaresController : Controller
    {

        public IActionResult Index()
        {
            var model = new AuxiliaresModel() { Auxiliares = new AuxiliarModel().GetAll() };
            return View(model);
        }
        public IActionResult Record(long id)
        {
            // var auxiliaratual = auxiliares.FirstOrDefault(auxiliar => auxiliar.Id == id);
            // return View(auxiliaratual);
            throw new NotImplementedException();
        }
        [HttpPost]
        public IActionResult Save(AuxiliarModel model)
        {
            // var auxiliar = auxiliares.FirstOrDefault(i => i.ID == model.ID);

            // auxiliar.Nome = model.Nome;
            // auxiliar.Funcao = model.Funcao;
            // auxiliar.Telefone = model.Telefone;

            // return RedirectToAction("Index");
            throw new NotImplementedException();
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
                // model.ID = auxiliares.Max(a => a.Id) + 1;

                // auxiliares.Add(model);

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

                [HttpGet("api/v1/Auxiliares")]
        public IActionResult Get()
        {
            var auxiliar = new AuxiliarModel().GetAll();
            return Ok(auxiliar);
        }
        [HttpPost("api/v1/Auxiliar")]
        public IActionResult Post([FromBody] AuxiliarModel auxiliar)
        {
            auxiliar.Create();
            return Ok("Auxiliar Cadastrado");
        }
        [HttpPut("api/v1/Auxiliar/{id}")]
        public IActionResult Put(long id, [FromBody] AuxiliarModel auxiliar)
        {

            var auxiliarEntidade = new AuxiliarModel().Get(id);
            auxiliarEntidade.Update(id);

            return Ok("Auxiliar atualizado!");
        }
        [HttpDelete("api/v1/Auxiliares/{id}")]
        public IActionResult Delete(long id) 
        {
            var auxiliar = new AuxiliarModel().Get(id);
            auxiliar.Delete(id);

            return Ok("Auxiliar Deletado");
        }
    }
}


