using Data.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Interface
{
    public interface IProfissionalRepositorio
    {
        public List<ProfissionalDto> ListarTodos();
        public List<ProfissionalDto> ListarPorId(int id);
        public List<ProfissionalDto> ListarPorNome(string nome);
        public int Cadastrar(ProfissionalDto profissional);
        public int Atualizar(ProfissionalDto profissional);
        public int Excluir(int id);
    }
}
