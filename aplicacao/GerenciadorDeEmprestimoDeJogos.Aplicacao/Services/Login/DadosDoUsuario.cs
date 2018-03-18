using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace GerenciadorDeEmprestimoDeJogos.Aplicacao.Services.Login
{
    public class DadosDoUsuario : IValidatableObject
    {
        [Required]
        [StringLength(100)]
        [Display(Name = "Nome:")]
        public string Nome {get; set;}

        [Required]
        [StringLength(100)]
        [EmailAddress]
        [Display(Name = "Endereço de E-mail:")]
        public string Email {get;set;}

        [Required]
        [EmailAddress]
        [Display(Name = "Repita seu e-mail:")]
        [Compare(nameof(Email))]
        public string RepetirEmail{get; set;}

        [Required]
        [Display(Name = "Senha (Mínimo de 6 caracteres, máximo 20):")]
        [StringLength(20, MinimumLength = 6)]
        public string Senha {get; set;}

        [Required]
        [Display(Name = "Repita sua senha: ")]
        [StringLength(20, MinimumLength = 6)]
        [Compare(nameof(Senha))]
        public string RepetirSenha {get; set;}

        [Required]
        [DataType(DataType.Date)]
        [Display(Name = "Data de Nascimento: ")]
        public DateTime DataDeNascimento {get;set;}

        [Required]
        [StringLength(100)]
        [Display(Name = "Endereço")]
        public string Endereco {get;set; }

        [Display(Name = "Número de sua residência")]
        [Range(0,9999)]
        public int? Numero {get;set;}

        [Display(Name = "Complemento:")]
        public string Complemento {get; set;}

        [Required]
        [Display(Name = "CEP:")]
        [RegularExpression("[0-9]{8}")]
        public string Cep {get; set;}
        
        [Required]
        [StringLength(100)]
        [Display(Name = "Cidade:")]
        public string Cidade {get; set; }

        [Required]
        [StringLength(2, MinimumLength = 2)]
        [Display(Name = "Estado/UF:")]
        public string UnidadeFederativa {get; set;}

        private static IEnumerable<string> UnidadesFederativas => new [] {
            "AC", "AL", "AM", "AP", "BA", "CE", "DF", "ES", "GO", "MA", "MG", "MS", "MT", "PA", "PB", "PE", "PI", "PR",
            "RJ", "RN", "RO", "RR", "RS", "SC", "SE", "SP", "TO"
        };


        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if(!UnidadesFederativas.Contains(UnidadeFederativa))
            {
                yield return new ValidationResult("Unidade federativa não reconhecida");
            }      
        }
    }
}