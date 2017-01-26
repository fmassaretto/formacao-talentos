using Fatec.Treinamento.Data.Repositories;
using Fatec.Treinamento.Model;
using Fatec.Treinamento.Model.Enum;
using Fatec.Treinamento.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Fatec.Treinamento.Web.Controllers
{
    public class UsuarioController : Controller
    {
        
        [AllowAnonymous]
        [HttpGet]
        public ActionResult Registrar()
        {
            return View();
        }

        
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public ActionResult Registrar(RegistroUsuarioViewModel model)
        {
            if (ModelState.IsValid)
            {
                var usuario = new Usuario
                {
                    Nome = model.Nome,
                    Email = model.Email,
                    Senha = model.Senha,
                    Ativo = true,
                    Perfil = new Perfil { Id = (int)TipoPerfil.Usuario } // Por padrão todos que se registram são usuarios.
                };
                
                using(UsuarioRepository repo = new UsuarioRepository())
                {
                    usuario = repo.Inserir(usuario);
                }
                    
                if (usuario.Id > 0)
                {
                    //TODO: logar o usuario
                    return RedirectToAction("Index", "Home");
                }
                
            }

            // Se chegou aqui, temos um problema. Devolvo o model para o form novamente.
            return View(model);
        }
        
    }
}