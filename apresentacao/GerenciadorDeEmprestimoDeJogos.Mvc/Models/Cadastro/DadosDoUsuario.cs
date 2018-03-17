using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace GerenciadorDeEmprestimoDeJogos.Mvc.Models.Cadastro
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

        public List<SelectListItem> Unidades {get;} = new List<SelectListItem> {
            new SelectListItem {Value = null, Text = "Selecione"},
            new SelectListItem { Value = "AC", Text = "Acre" },
            new SelectListItem { Value = "SP", Text = "São Paulo" },
            new SelectListItem { Value = "SE", Text = "Sergipe" }
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