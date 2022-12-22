using Data.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Interface
{
    public interface IHospitalRepositorio
    {
        List<HospitalDto> ListarTodos();
        List<HospitalDto> ListarPorId(int id);
        List<HospitalDto> ListarPorNome(string nome);
        public int Cadastrar(HospitalDto hospital);
        public int Atualizar(HospitalDto hospital);
        public int Excluir(int id);
    }
}
