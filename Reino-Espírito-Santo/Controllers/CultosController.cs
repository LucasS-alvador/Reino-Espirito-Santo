﻿using Microsoft.AspNetCore.Mvc;
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
            listaDeCultos.cultos = standardCultos;
            var pastores = new List<AuxiliarModel>();
            foreach (var a in AuxiliaresController.auxiliares)
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
            var highestId = standardCultos.LastOrDefault().Id;
            Culto c = new Culto(highestId + 1, new DateTime(2000, 1, 1, 1, 1, 1), 3, "placeholder");
            return View(c);
        }

        [HttpPost] public IActionResult Criar(Culto culto)
        {
            standardCultos.Add(culto);
            return RedirectToAction("Index");
        }

        public IActionResult Deletar(int id)
        {
            var culto = standardCultos.FirstOrDefault(a => a.Id == id);
            if (culto != null)
            {
                standardCultos.Remove(culto);
            }
            return RedirectToAction("Index");
        }
    }
}
