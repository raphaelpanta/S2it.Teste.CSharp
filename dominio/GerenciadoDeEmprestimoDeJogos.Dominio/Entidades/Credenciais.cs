using System.Security.Cryptography;
using System.Text;

namespace GerenciadoDeEmprestimoDeJogos.Dominio.Entidades
{
    public class Credenciais
    {
        public string Email { get; set; }

        public string Senha { get; set; }

        public string Salt { get; set; }

        public bool CompararCom(Credenciais fornecidas) {
          return Email.Equals(fornecidas.Email) && Senha.Equals(fornecidas.Senha);
        }

        public static Credenciais Nova(string email, string senha, string salt) {
            var crypt = new SHA256Managed();
            var hash = new StringBuilder();
            byte[] crypto = crypt.ComputeHash(Encoding.UTF8.GetBytes(senha + salt));

            foreach(var vbyte in crypto) {
                hash.Append(vbyte.ToString("x2"));
            }

            return new Credenciais { Email = email, Senha =  hash.ToString(), Salt = salt };
        }


    }
}