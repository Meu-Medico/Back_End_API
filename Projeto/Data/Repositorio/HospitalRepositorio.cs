using Data.Contexto;
using Data.Dto;
using Data.Entidade;
using Data.Interface;

namespace Data.Repositorio
{
    public class HospitalRepositorio : IHospitalRepositorio
    {
        private readonly ProjetoContext _context;
        //injeçao de dados
        public HospitalRepositorio(ProjetoContext context) 
        {
            _context = context;
        }
       /* public int Cadastrar(HospitalDto hospital)
        {
            Hospital hospitalEntidade = new Hospital()
            {
                Nome = hospital.Nome,
                Cnpj = hospital.Cnpj,
                Endereço = hospital.Endereco,
                Telefone = hospital.Telefone,
                Cnes = hospital.Cnes,
                Ativo = hospital.Ativo,
            };

            _context.ChangeTracker.Clear();
            _context.Hospitals.Add(hospitalEntidade);
            return _context.SaveChanges();
        }*/
        public List<HospitalDto> ListarTodos()
        {
            return (from h in _context.Hospitals
                    select new Dto.HospitalDto()
                    {
                        Id = h.IdHospital,
                        Nome = h.Nome
                    }).ToList();
        }

        /*public List<Dto.HospitalDto> Hospital(int id)
{
   return _context.Hospitals
       .Where(h=>h.IdHospital == id)
       .Select(s=> new Dto.HospitalDto()
       {
           Id = s.IdHospital,
           Nome = s.Nome
       })
       .ToList();
}
public List<HospitalDto> ListarTodos(int id)
{
   return (from h in _context.Hospitals
           where h.IdHospital == id
           select new Dto.HospitalDto()
           {
               Id = h.IdHospital,
               Nome = h.Nome
           })
       .ToList();
}*/
    }
}
