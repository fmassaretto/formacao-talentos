﻿using Fatec.Treinamento.Data.Repositories;
using Fatec.Treinamento.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Fatec.Treinamento.Web.Controllers
{
    // Obs: Colocando o atributo [Authorize] no controller, garante que todas as actions so podem ser
    // acessadas quando o usuário estiver autorizado a utilizar.
    // Quando informo o parametro "Roles", indico que só quem tiver o perfil administrador poderá acessar.

    //[Authorize(Roles = "Administrador")]
    public class TrilhaController : Controller
    {
        [HttpGet]
        public ActionResult Index()
        {
            var repo = new TrilhaRepository();

            var lista = repo.Listar();

            return View(lista);
        }

        [HttpPost]
        public ActionResult Criar(Trilha trilha)
        {
            var repo = new TrilhaRepository();
            var lista = repo.Inserir(trilha);

            if (lista.Id == 0)
            {
                ModelState.AddModelError("", "Erro");
            }

            return RedirectToAction("Index");
        }
    }
}