using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Fatec.Treinamento.Model.Extensoes
{
    public static class StringExtensions
    {
        public static string GerarHash(this string str)
        {
            if (string.IsNullOrEmpty(str))
                throw new InvalidOperationException("O valor não pode ser nulo.");

            var bytes = new UTF8Encoding().GetBytes(str);
            var hashBytes = MD5.Create().ComputeHash(bytes);
            return Convert.ToBase64String(hashBytes);
        }

    }
}
