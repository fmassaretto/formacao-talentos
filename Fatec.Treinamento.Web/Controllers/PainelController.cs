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

            CursoRepository repoTodos;

            using (repoTodos = new CursoRepository())
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

                var treinamento = repoTrein.ListarTodosTreinamentos(idUsuario);

                foreach (var item in treinamento)
                {
                    if (treinamento != null)
                    {
                        /* 
                         * Se DataInicio for não nulo e DataConclusao for nulo então 
                         * o curso está em andamento, se os dois forem não nulo então
                         * o curso está concluido
                         */
                        if (item.DataInicio.ToString() != "01/01/0001 00:00:00" & 
                            item.DataConclusao.ToString() == "01/01/0001 00:00:00")
                        {
                            foreach (var curso in listar.Acu)
                            {
                                if (item.IdCurso == curso.IdCurso)
                                {
                                    listar.CursosAndamento.Add(curso.IdCurso);
                                }                            
                            }
                        }
                        else if (item.DataInicio.ToString() != "01/01/0001 00:00:00" &
                            item.DataConclusao.ToString() != "01/01/0001 00:00:00")
                        {
                            foreach (var curso in listar.Acu)
                            {
                                if (item.IdCurso == curso.IdCurso)
                                {
                                    listar.CursosFinalizado.Add(curso.IdCurso);
                                }
                            }
                        }
                    }

                }
     
            }



            return View(listar);
        }
    }
}