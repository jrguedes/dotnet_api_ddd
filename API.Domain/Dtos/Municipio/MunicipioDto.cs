using System;
using System.ComponentModel.DataAnnotations;
using API.Domain.Dtos.UF;

namespace API.Domain.Dtos.Municipio
{
    public class MunicipioDto
    {
        public Guid Id { get; set; }

        [Required(ErrorMessage = "Nome é obrigatorio")]
        [StringLength(60,ErrorMessage = "Maximo de 60 caracteres")]
        public string Nome { get; set; }

        [Range(0, int.MaxValue, ErrorMessage = "Codigo IBGE invalido")]
        public int CodIBGE { get; set; }

        [Required]
        public Guid UFId { get; set; }

        public UFDto UF { get; set; }

        public DateTime CreatedAt { get; set; }
    }
}
