using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Reino_Espírito_Santo.Models.Auxiliares;
using Reino_Espírito_Santo.Models.Ministerio;
using Reino_Espírito_Santo.Models.Ministerios;

namespace Reino_Espírito_Santo.Controllers
{
    public class MinisteriosController : Controller
    {
        static List<MinisterioModel> _Ministerio = new List<MinisterioModel>()
        {
            new MinisterioModel(){Id = 1, Nome = "ministerio1",  Descricao = "Ministério de Louvor", auxiliarId = 3, DataInicio = new DateTime(2020, 1, 1)},
            new MinisterioModel(){Id = 2, Nome = "ministerio2",   Descricao = "Ministério de Ensino", auxiliarId = 3, DataInicio = new DateTime(2019, 5, 15)},
            new MinisterioModel(){Id = 3, Nome = "ministerio3",  Descricao = "Ministério de Oração", auxiliarId = 3, DataInicio = new DateTime(2021, 8, 30)},
        };



        public IActionResult Index()
        {
            var model = new MinisteriosModel()
            {
                // Para cada ministério, adicione o nome do auxiliar, se existir.
                Ministerio = _Ministerio.Select(ministerio => new MinisterioModel
                {
                    Id = ministerio.Id,
                    Nome = ministerio.Nome,
                    Descricao = ministerio.Descricao,
                    auxiliarId = ministerio.auxiliarId,
                    DataInicio = ministerio.DataInicio,
                    // Aqui você atribui o nome do auxiliar com base no auxiliarId
                    AuxiliarNome = AuxiliaresController.auxiliares
                        .FirstOrDefault(a => a.Id == ministerio.auxiliarId)?.Nome ?? "Sem líder"
                }).ToList()
            };

            return View(model);
        }


        public IActionResult Record(long id)
        {
            var missionarioAtual = _Ministerio.FirstOrDefault(missionario => missionario.Id == id);
            return View(missionarioAtual);
        }

        public IActionResult Adicionar()
        {
            var auxiliares = AuxiliaresController.auxiliares
                .Select(a => new SelectListItem
                {
                    Value = a.Id.ToString(),
                    Text = a.Nome
                })
                .ToList();

            ViewBag.Auxiliares = auxiliares;

            return View();
        }


        [HttpPost]

        public IActionResult Adicionar(MinisterioModel model)
        {
            if (ModelState.IsValid)
            {
                model.Id = _Ministerio.Max(a => a.Id) + 1;

                _Ministerio.Add(model);

                return RedirectToAction("Index");
            }

            return View(model);
        }
        public IActionResult Salvar(MinisterioModel model)
        {
            var missionario = _Ministerio.FirstOrDefault(i => i.Id == model.Id);

            if (missionario != null) // Verifica se o missionário foi encontrado
            {
                missionario.Nome = model.Nome;
                missionario.Descricao = model.Descricao;
                missionario.auxiliarId = model.auxiliarId;
                missionario.DataInicio = model.DataInicio;
            }

            return RedirectToAction("Index");
        }
    }
}
