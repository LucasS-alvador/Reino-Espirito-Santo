using Microsoft.AspNetCore.Mvc;
using Reino_Espírito_Santo.Models;
using Reino_Espírito_Santo.Models.Auxiliares;
using System;
using static System.Net.WebRequestMethods;

namespace Reino_Espírito_Santo.Controllers
{
    public class CultosController : Controller
    {
        public static List<Culto> standardCultos = new List<Culto>() {
            new Culto(1, new DateTime(2025, 1, 5, 10, 0, 0), 7, "youtu.be/dQw4w9WgXcQ"),
            new Culto(2, new DateTime(2025, 1, 6, 10, 0, 0), 2, "youtu.be/eAj4kjK7dXI"),
        };
        public IActionResult Index()
        {
            var listaDeCultos = new ListaDeCultosEAuxiliares();
            listaDeCultos.cultos = new Culto().GetAll();
            var pastores = new List<AuxiliarModel>();
            foreach (var a in new AuxiliarModel().GetAll())
            {
                if (a.Funcao == null)
                {
                    continue;
                }
                var func = a.Funcao.ToUpper();
                
                if(func == "PASTOR")
                {
                    pastores.Add(a);
                }
            }
            listaDeCultos.auxiliares = pastores;
            return View(listaDeCultos);
        }

        public IActionResult Criacao()
        {
            Culto c = new Culto(-1, new DateTime(2000, 1, 1, 1, 1, 1), 3, "placeholder");
            return View(c);
        }

        [HttpPost] public IActionResult Criar(Culto culto)
        {
            culto.Create();
            return RedirectToAction("Index");
        }

        public IActionResult Deletar(int id)
        {
            new Culto().Delete(id);
            return RedirectToAction("Index");
        }

        [HttpGet("api/v1/Cultos")]
        public IActionResult Get()
        {
            var cultos = new Culto().GetAll();
            return Ok(cultos);
        }

        [HttpPost("api/v1/Culto")]
        public IActionResult Post(Culto culto)
        {
            culto.Create();
            return Ok("Culto cadastrado!");
        }

        [HttpPut("api/v1/Culto/{id}")]
        public IActionResult Put(long id, [FromBody] Culto culto)
        {
            culto.Update(id);
            return Ok("Culto atualizado");
        }
        [HttpDelete("api/v1/Cultos/{id}")]
        public IActionResult Delete(long id)
        {
            new Culto().Delete(id);

            return Ok("Culto deletado!");
        }
    }
}
