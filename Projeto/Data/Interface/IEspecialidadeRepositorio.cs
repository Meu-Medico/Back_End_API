using Data.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Interface
{
    public interface IEspecialidadeRepositorio
    {
        public List<Dto.EspecialidadeDto> ListarTodos();
        public List<Dto.EspecialidadeDto> ListarPorNome(string nome);
        public List<Dto.EspecialidadeDto> ListarPorId(int id);
        public int Cadastrar(EspecialidadeDto especialidadeDto);
        public int Atualizar(EspecialidadeDto especialidadeDto);
        public int Excluir(int id);

    }
}
