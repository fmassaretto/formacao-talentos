using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Fatec.Treinamento.Model
{
    public class Usuario
    {
        public int Id { get; set; }

        public string Nome { get; set; }

        public string Email { get; set; }

        public string Senha { get; set; }

        public bool Ativo { get; set; }

        /// <summary>
        /// Retorna a senha criptografada.
        /// OBS: a propriedade SENHA deve ter sido informada.
        /// </summary>
        public string HashSenha
        {
            get
            {
                if(string.IsNullOrEmpty(Senha))
                    throw new InvalidOperationException("A senha deve ser informada!");

                var bytes = new UTF8Encoding().GetBytes(Senha);
                var hashBytes = MD5.Create().ComputeHash(bytes);
                return Convert.ToBase64String(hashBytes);
            }
        }
    }
}
