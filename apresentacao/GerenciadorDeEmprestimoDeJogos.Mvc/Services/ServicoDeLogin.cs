using GerenciadorDeEmprestimoDeJogos.Mvc.Models.Cadastro;

namespace GerenciadorDeEmprestimoDeJogos.Mvc.Services
{
    public class ServicoDeLogin : IServicoDeLogin
    {
        public bool Validar(CredenciaisDoUsuario credenciais)
        {
            return true;
        }
    }
}