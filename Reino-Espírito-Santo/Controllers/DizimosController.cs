using Microsoft.AspNetCore.Mvc;
using MySqlX.XDevAPI.Common;
using Reino_Espírito_Santo.Models.Auxiliares;
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
        [HttpGet("api/v1/Dizimos")]
        public IActionResult Get()
        {

            var contribuicoes = _dizimoModel.GetAll();
            var ultimoDizimo = contribuicoes.FirstOrDefault();

            if (ultimoDizimo == null)
            {
                return NotFound("Nada encontrado");
            }

            var result = new 
            { 
                Total = ultimoDizimo.Total,
                Adicionado = ultimoDizimo.Adicionado,
                AntigoAdd1 = ultimoDizimo.AntigoAdd1,
                AntigoAdd2 = ultimoDizimo.AntigoAdd2,
                AntigoAdd3 = ultimoDizimo.AntigoAdd3
            };


            return Ok(result);
        }
        [HttpPost("api/v1/Dizimos")]
        public IActionResult Post([FromBody] DizimoModel dizimo)
        {
            dizimo.Create();

            return Ok("Carro Cadastrado");
        }

        [HttpPut("api/v1/Dizimos/{id}")]
        public IActionResult Put(long id, [FromBody] DizimoModel dizimo)
        {
            var dizimoEntidade = new DizimoModel().Get(id);
            dizimoEntidade.Update(id);

            return Ok("Atualizado");
        }
        [HttpDelete("api/v1/Dizimos/{id}")]
        public IActionResult Delete(long id)
        {
            var dizimo = new DizimoModel().Get(id);
            dizimo.Delete(id);
            

            return Ok("Deletado");
        }
    }
}
