using GerenciadorDeEmprestimoDeJogos.Mvc.Models.Cadastro;

namespace GerenciadorDeEmprestimoDeJogos.Mvc.Services
{
    public interface IServicoDeLogin
    {
         bool Validar(CredenciaisDoUsuario credenciais);
    }
}