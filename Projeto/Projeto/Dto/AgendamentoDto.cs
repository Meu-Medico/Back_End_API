﻿using Projeto.Entidade;

namespace Projeto.Dto
{
    public class AgendamentoDto
    {
        public int IdAgendamento { get; set; }
        public int IdHospital { get; set; }

        public int IdEspecialidade { get; set; }

        public int IdProfissional { get; set; }

        public DateTime DataHoraAgendamento { get; set; }

        public int IdBeneficiario { get; set; }

        public bool Ativo { get; set; }

    }
}
