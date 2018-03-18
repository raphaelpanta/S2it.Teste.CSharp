namespace GerenciadoDeEmprestimoDeJogos.Dominio.Entidades {
    public class Endereco {
        public string Logradouro { get; set; }

        public int? Numero { get; set; }

        public string Complemento { get; set; }

        public string Cep { get; set; }

        public string Cidade { get; set; }

        public string UnidadeFederativa { get; set; }
    }
}