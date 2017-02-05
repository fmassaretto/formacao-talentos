using System;
using System.Diagnostics;
using System.Linq;
using Fatec.Treinamento.Data.Repositories;
using Fatec.Treinamento.Model;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Fatec.Treinamento.Model.DTO;

namespace Fatec.Treinamento.Testes.Data.Tests
{
    [TestClass]
    public class AssuntoRepositoryTests
    {
        
        [TestMethod]
        public void TestarCrudAssunto()
        {
            var id = InserirAssunto();
            var assunto = ObterAssunto(id);
            assunto = AtualizarAssunto(assunto);
            Excluir(assunto);
        }

        private int InserirAssunto()
        {
            using (AssuntoRepository repo = new AssuntoRepository())
            {
                var assunto = new AssuntoCursoUsuario
                {
                    Nome = "Demo teste 1"
                };

                int id = repo.Inserir(assunto).IdCurso ;

                Assert.IsTrue(id > 0);
                return id;
            }
        }
        
        public AssuntoCursoUsuario ObterAssunto(int id)
        {
            using (AssuntoRepository repo = new AssuntoRepository())
            {
               
                var assunto = repo.Obter(id);
                
                Assert.AreEqual("Demo teste 1", assunto.Nome);
                
                return assunto;

            }
        }


        private AssuntoCursoUsuario AtualizarAssunto(AssuntoCursoUsuario assunto)
        {
            using (AssuntoRepository repo = new AssuntoRepository())
            {

                assunto.Nome = "Nome Atualizado";
                repo.Atualizar(assunto);

                var assuntoAtualizado = repo.Obter(assunto.IdAssunto);

                Assert.AreEqual("Nome Atualizado", assuntoAtualizado.NomeAssunto);
                
                return assuntoAtualizado;
            }
        }
                
        private void Excluir(AssuntoCursoUsuario assunto)
        {
            using (AssuntoRepository repo = new AssuntoRepository())
            {
                repo.Excluir(assunto);
                var assuntoRet = repo.Obter(assunto.IdAssunto);
                Assert.IsTrue(assuntoRet == null);
            }
        }
    }
}
