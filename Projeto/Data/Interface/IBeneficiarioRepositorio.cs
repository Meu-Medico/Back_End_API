using Data.Entidade;
using Data.Dto.Beneficiario;
using Projeto.Entidade;

namespace Data.Interface
{
    public interface IBeneficiarioRepositorio
    {
        Beneficiario Criar(BeneficiarioCriarDto beneficiario);
        int Excluir(int Id);
        int Editar(BeneficiarioEditarDto beneficiario);
        List<BeneficiarioDto> ListarTodos();
        List<BeneficiarioDto> ListarPorId(int id);
    }
}

