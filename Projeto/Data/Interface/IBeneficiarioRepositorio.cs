using Data.Entidade;
using Data.Dto.Beneficiario;
using Projeto.Entidade;

namespace Data.Interface
{
    public interface IBeneficiarioRepositorio
           {
            List<BeneficiarioDto> ListarTodos();
            BeneficiarioDto ListarPorId(int id);
            Beneficiario Criar(BeneficiarioCriarDto beneficiario);
            int Excluir(int Id);
            int Editar(BeneficiarioEditarDto beneficiario);
    }
}

