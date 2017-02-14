using Fatec.Treinamento.Data.Repositories;
using Fatec.Treinamento.Model;
using Fatec.Treinamento.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Fatec.Treinamento.Web.Controllers
{
    public class AdminUsuariosController : Controller
    {
        // GET: AdminUsuarios
        public ActionResult Index()
        {
            using (var repo = new UsuarioRepository())
            {
                var lista = repo.Listar();

                return View(lista);
            }
        }

        [HttpGet]
        public ActionResult Obter(int id)
        {
            using (var repo = new UsuarioRepository())
            {
                var lista = repo.Obter(id);
                return View(lista);
            }
        }

        [HttpGet]
        public ActionResult Criar()
        {
            var model = new RegistroUsuarioViewModel();

            using (var repoUser = new PerfilRepository())
            {
                var listaPerfil = repoUser.Listar();
                model.ListaPerfil = (from x in listaPerfil
                                     select new SelectListItem
                                     {
                                         Text = x.Nome,
                                         Value = x.Id.ToString()
                                     });
            }

            return View(model);
        }

        [HttpPost]
        public ActionResult Criar(RegistroUsuarioViewModel model)
        {
            var usuario = new Usuario
            {
                Nome = model.Nome,
                Email = model.Email,
                Senha = model.Senha,
                Ativo = true,
                Perfil = new Perfil { Id = model.IdPerfil }
            };

            using (UsuarioRepository repo = new UsuarioRepository())
            {
                usuario = repo.Inserir(usuario);

                if (usuario.Id == 0)
                {
                    ModelState.AddModelError("", "Erro");
                }
            }
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Editar(int id)
        {
            var model = new AdminUsuarioViewModel();

            using (var repoUser = new PerfilRepository())
            {
                var listaPerfil = repoUser.Listar();

                model.ListaPerfil = (from x in listaPerfil
                                     select new SelectListItem
                                       {
                                           Text = x.Nome,
                                           Value = x.Id.ToString()
                                       });
            }

            using (var repo = new UsuarioRepository())
            {
                model.Usuario = repo.Obter(id);
            }
            return View(model);
        }

        [HttpPost]
        public ActionResult Editar(Usuario usuario)
        {
            using (var repo = new AdminUsuarioRepository())
            {
                repo.Atualizar(usuario);

                return RedirectToAction("Index");
            }
        }

        [HttpGet]
        public ActionResult Deletar(int id)
        {
            using (var repo = new UsuarioRepository())
            {
                var curso = repo.Obter(id);

                return View(curso);
            }
        }

        [HttpPost]
        public ActionResult Deletar(Usuario usuario)
        {
            using (var repo = new AdminUsuarioRepository())
            {
                repo.Excluir(usuario);
            }
            return RedirectToAction("Index");
        }

    }
}