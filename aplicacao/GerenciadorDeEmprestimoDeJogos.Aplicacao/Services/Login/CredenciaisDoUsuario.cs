using System.ComponentModel.DataAnnotations;

namespace GerenciadorDeEmprestimoDeJogos.Aplicacao.Services.Login
{
    public class CredenciaisDoUsuario
    {
        [Required]
        [EmailAddress]
        [StringLength(100)]
        [Display(Name = "Email: ")]
        public string Email{ get; set;}

        [Required]
        [StringLength(20, MinimumLength = 6)]
        [DataType(DataType.Password)]
        public string Senha {get;set;}
    }
}