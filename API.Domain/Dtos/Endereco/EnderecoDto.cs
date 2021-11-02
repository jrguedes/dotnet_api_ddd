using System;
using API.Domain.Dtos.Municipio;

namespace API.Domain.Dtos.Endereco
{
    public class EnderecoDto
    {
        public Guid Id { get; set; }
        public string CEP { get; set; }

        public string Logradouro { get; set; }

        public string Numero { get; set; }
        public Guid MunicipioId { get; set; }

        public MunicipioDto Municipio { get; set; }
    }
}
