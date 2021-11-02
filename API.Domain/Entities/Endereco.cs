using System;
using System.ComponentModel.DataAnnotations;

namespace API.Domain.Entities
{
    public class Endereco : BaseEntity
    {
        [Required]
        [MaxLength(10)]
        public string CEP { get; set; }

        [Required]
        [MaxLength(60)]
        public string Logradouro { get; set; }

        [MaxLength(10)]
        public string Numero { get; set; }

        public Guid MunicipioId { get; set; }

        public Municipio Municipio { get; set; }
    }
}
