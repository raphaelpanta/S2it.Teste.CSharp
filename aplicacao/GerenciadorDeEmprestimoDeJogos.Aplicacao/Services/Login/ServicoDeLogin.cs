
using System;
using GerenciadoDeEmprestimoDeJogos.Dominio.Api;
using GerenciadoDeEmprestimoDeJogos.Dominio.Entidades;

namespace GerenciadorDeEmprestimoDeJogos.Aplicacao.Services.Login
{
    public class ServicoDeLogin : IServicoDeLogin
    {
        private IRepositorioDeUsuario _repositorio;
        public ServicoDeLogin(IRepositorioDeUsuario repositorio) {
            _repositorio = repositorio;
        }

        public void Cadastrar(DadosDoUsuario usuario)
        {
           _repositorio.Cadastrar(new Usuario {
               Nome = usuario.Nome,
                Credenciais = Credenciais.Nova(usuario.Email, usuario.Senha, _repositorio.NewSalt().ToString()),
                DataDeNascimento = usuario.DataDeNascimento,
                Endereco = new Endereco {
                    Logradouro = usuario.Endereco,
                    Numero = usuario.Numero,
                    Complemento = usuario.Complemento,
                    Cep = usuario.Cep,
                    Cidade = usuario.Cep,
                    UnidadeFederativa = usuario.UnidadeFederativa
                }
           });
        }

        public bool Validar(CredenciaisDoUsuario credenciais)
        {
            var credenciasOriginais = _repositorio.Por(credenciais.Email);
            var fornecidas = Credenciais.Nova(credenciais.Email, credenciais.Senha, credenciasOriginais.Salt);
            return credenciasOriginais.CompararCom(fornecidas);
        }
    }
}