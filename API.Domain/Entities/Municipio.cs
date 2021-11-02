using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace API.Domain.Entities
{
    public class Municipio : BaseEntity
    {
        [Required]
        [MaxLength(60)]
        public string Nome { get; set; }
        public int CodIBGE { get; set; }
        
        [Required]
        public Guid UFId { get; set; }

        public UF UF { get; set; }

        public IEnumerable<Endereco> Enderecos { get; set; }

    }
}
