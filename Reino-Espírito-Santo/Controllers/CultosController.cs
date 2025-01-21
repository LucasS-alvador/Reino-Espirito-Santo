﻿using Microsoft.AspNetCore.Mvc;
using Reino_Espírito_Santo.Models;
using System;
using static System.Net.WebRequestMethods;

namespace Reino_Espírito_Santo.Controllers
{
    public class CultosController : Controller
    {
        public static List<Culto> standardCultos = new List<Culto>() {
            new Culto(1, new DateTime(2025, 1, 5, 10, 0, 0), 1, "youtu.be/dQw4w9WgXcQ"),
            new Culto(2, new DateTime(2025, 1, 6, 10, 0, 0), 2, "youtu.be/eAj4kjK7dXI"),
        };
        public IActionResult Index()
        {
            ListaDeCultos listaDeCultos = new ListaDeCultos();
            listaDeCultos.cultos = standardCultos;
            return View(listaDeCultos);
        }
    }
}
