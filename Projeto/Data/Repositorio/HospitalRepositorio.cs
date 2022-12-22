using Data.Contexto;
using Data.Dto;
using Data.Entidade;
using Data.Interface;

namespace Data.Repositorio
{
    public class HospitalRepositorio : IHospitalRepositorio
    {
        private readonly ProjetoContext _context;
        public HospitalRepositorio(ProjetoContext context)
        {
            _context = context;
        }
        public int Cadastrar(HospitalDto hospital)
        {
            Hospital hospitalEntidade = new Hospital()
            {
                Nome = hospital.Nome,
                Cnpj = hospital.Cnpj,
                Endereco = hospital.Endereco,
                Telefone = hospital.Telefone,
                Cnes = hospital.Cnes,
                Ativo = hospital.Ativo,
            };

            _context.ChangeTracker.Clear();
            _context.Hospitals.Add(hospitalEntidade);
            return _context.SaveChanges();
        }
        public List<HospitalDto> ListarTodos()
        {
            return (from h in _context.Hospitals
                    select new Dto.HospitalDto()
                    {
                        Id = h.IdHospital,
                        Nome = h.Nome
                    }).ToList();
        }
        public List<HospitalDto> ListarPorId(int id)
        {
            return (from h in _context.Hospitals
                    where h.IdHospital == id
                    select new Dto.HospitalDto()
                    {
                        Id = h.IdHospital,
                        Nome = h.Nome
                    }).ToList();
        }
        public List<HospitalDto> ListarPorNome(string nome)
        {
            return (from h in _context.Hospitals
                    where h.Nome == nome
                    select new Dto.HospitalDto()
                    {
                        Id = h.IdHospital,
                        Nome = h.Nome
                    }).ToList();
        }

        public int Atualizar(HospitalDto hospitalDto)
        {
            Hospital hospital = (from h in _context.Hospitals
                                       where h.IdHospital == hospitalDto.Id
                                       select h)
                                       ?.FirstOrDefault()
                                       ?? new Hospital();

            if (hospitalDto == null || DBNull.Value.Equals(hospitalDto.Id) || hospitalDto.Id == 0)
            {
                return 0;
            }

            hospital.Nome = hospitalDto.Nome;
            hospital.Cnpj = hospitalDto.Cnpj;
            hospital.Endereco = hospitalDto.Endereco;
            hospital.Telefone = hospitalDto.Telefone;
            hospital.Cnes = hospitalDto.Cnes;
            hospital.Ativo = hospitalDto.Ativo;
        
            _context.ChangeTracker.Clear();
            _context.Hospitals.Update(hospital);
            return _context.SaveChanges();
        }
        public int Excluir(int id)
        {

            Hospital hospital = (from h in _context.Hospitals
                                       where h.IdHospital == id
                                       select h).FirstOrDefault();

            if (hospital == null || DBNull.Value.Equals(hospital.IdHospital) || hospital.IdHospital == 0)
            {
                return 0;
            }

            _context.ChangeTracker.Clear();
            _context.Hospitals.Remove(hospital);
            return _context.SaveChanges();
        }
    }
}
