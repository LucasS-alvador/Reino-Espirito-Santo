using Microsoft.AspNetCore.Mvc;
using Reino_Espírito_Santo.Models.Missionarios;

namespace Reino_Espírito_Santo.Controllers
{
    public class MissionariosController : Controller
    {

        static List<MissionarioModel> _Missionario = new List<MissionarioModel>()
        {   new MissionarioModel(){Id =1, Nome = "Tiago", Telefone = "4002-8922"},
            new MissionarioModel(){Id =2, Nome = "pedro", Telefone = "4002-8922"},
            new MissionarioModel(){Id =3, Nome = "joao", Telefone = "4002-8922"},

        };


        public IActionResult Index()
        {
            var model = new MissionariosModel() { Missionario = _Missionario };
            return View(model);
        }


        public IActionResult Record(long Id)
        {

            var MissionarioAtual =_Missionario.FirstOrDefault(missionario => missionario.Id == Id);

            return View(MissionarioAtual);
        }

        [HttpPost]
        public IActionResult Salvar(MissionarioModel model)
        {
            var missioanrio = _Missionario.FirstOrDefault(i => i.Id == model.Id);
            missioanrio.Nome = model.Nome;
            missioanrio.Telefone = model.Telefone;
            return RedirectToAction("Index");
        }

    }
}
