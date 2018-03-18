namespace GerenciadorDeEmprestimoDeJogos.Aplicacao.Services.Login
{
    public interface IServicoDeLogin
    {
         bool Validar(CredenciaisDoUsuario credenciais);

         void Cadastrar(DadosDoUsuario usuario);
    }
}