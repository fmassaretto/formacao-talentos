using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using Fatec.Treinamento.Data.Repositories;
using Fatec.Treinamento.Model;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Fatec.Treinamento.Testes.Data.Tests
{
    [TestClass]
    public class PerfilRepositoryTests
    {
        
        [TestMethod]
        public void TestarCrudPerfil()
        {
            var id = InserirPerfil();
            var perfil = ObterPerfil(id);
            perfil = AtualizarPerfil(perfil);
            
            InserirPermissoes(id);

            Excluir(perfil);
        }

        private void InserirPermissoes(int id)
        {
            var funcionalidades = new List<Funcionalidade>()
            {
                new Funcionalidade { Id=1, Nome="" },
                new Funcionalidade {Id=2, Nome="" }
            };

            using (PerfilRepository repo = new PerfilRepository())
            {
                repo.InserirPermissoes(id, funcionalidades);

                // Obtem os dados para validar se foi inserido certo:

                var permissoes = repo.ObterPermissoes(id);

                Assert.AreEqual(2, permissoes.Count());
                
            }
            
        }

        private int InserirPerfil()
        {
            using (PerfilRepository repo = new PerfilRepository())
            {
                var perfil = new Perfil
                {
                    Id=99,
                    Nome = "Demo teste 1"
                };

                int id = repo.Inserir(perfil).Id ;

                Assert.IsTrue(id > 0);
                return id;
            }
        }
        
        public Perfil ObterPerfil(int id)
        {
            using (PerfilRepository repo = new PerfilRepository())
            {
               
                var perfil = repo.Obter(id);
                
                Assert.AreEqual("Demo teste 1", perfil.Nome);
                
                return perfil;

            }
        }


        private Perfil AtualizarPerfil(Perfil perfil)
        {
            using (PerfilRepository repo = new PerfilRepository())
            {

                perfil.Nome = "Nome Atualizado";
                repo.Atualizar(perfil);

                var perfilAtualizado = repo.Obter(perfil.Id);

                Assert.AreEqual("Nome Atualizado", perfilAtualizado.Nome);
                
                return perfilAtualizado;
            }
        }
                
        private void Excluir(Perfil perfil)
        {
            using (PerfilRepository repo = new PerfilRepository())
            {
                repo.Excluir(perfil);
                var perfilRet = repo.Obter(perfil.Id);
                Assert.IsTrue(perfilRet == null);
            }
        }
    }
}
