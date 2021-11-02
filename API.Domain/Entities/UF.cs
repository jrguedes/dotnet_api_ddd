using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace API.Domain.Entities
{
    public class UF : BaseEntity
    {
        [Required]
        [MaxLength(2)]
        public string Sigla { get; set; }

        [Required]
        [MaxLength(45)]
        public string Nome { get; set; }

        public IEnumerable<Municipio> Municipios { get; set; }

        
    }
}
