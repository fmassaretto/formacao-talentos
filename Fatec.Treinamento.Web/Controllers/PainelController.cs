using Fatec.Treinamento.Data;
using Fatec.Treinamento.Data.Repositories;
using Fatec.Treinamento.Model;
using Fatec.Treinamento.Model.DTO;
using Fatec.Treinamento.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Fatec.Treinamento.Web.Controllers
{
    public class PainelController : Controller
    {
        // GET: Painel
        public ActionResult Index()
        {
            //IEnumerable<AssuntoCursoUsuario> listaTodos = new List<AssuntoCursoUsuario>();
            UsuarioPainelViewModel listar = new UsuarioPainelViewModel();

            int idUsuario = 0;
            using (UsuarioRepository usuario = new UsuarioRepository())
            {
                var listaUsuario = usuario.ListarPorNome(User.Identity.Name);

                foreach (var item in listaUsuario)
                {
                    idUsuario = item.Id;
                }
            }

            using (CursoRepository repoTodos = new CursoRepository())
            {
                listar.Acu = repoTodos.ListarTodosCursos();
            }

            using (TreinamentoRepository repoTrein = new TreinamentoRepository())
            {
                try
                {
                    listar.PontosUsuario = repoTrein.PontosUsuario(idUsuario);

                }
                catch (Exception)
                {
                    listar.PontosUsuario = 0;
                   
                }
     
            }

            return View(listar);
        }
    }
}