using Data.Entidade;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Dto
{
    public class HospitalDto
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Cnpj { get; set; }
        public string Endereco { get; set; }
        public string Telefone { get; set; }
        public string Cnes { get; set; }
        public bool Ativo { get; set; }

        public static implicit operator HospitalDto(Hospital v)
        {
            throw new NotImplementedException();
        }
    }
}
