using System.ComponentModel.DataAnnotations;

namespace GerenciadorDeEmprestimoDeJogos.Aplicacao.Services.Jogos
{

    public class DadosDoJogo 
    {
        [Required]
        [StringLength(100)]
        public string Nome {get; set;}

        [Required]
        [Range(1970, 3000)]
       public int Ano {get; set;}

        [Required]
        [StringLength(100)]
       public string Sistema {get; set;}

    }
}