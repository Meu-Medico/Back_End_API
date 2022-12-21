﻿using Data.Entidade;

namespace Data.Interface
{
    public interface IAgendamentoRepository
    {
        List<Dto.AgendamentoDto> Listar();

        Dto.AgendamentoDto Consultar(int id);

        int Cadastrar(Dto.AgendamentoDto cadastrarDto);

        int Atualizar(Dto.AgendamentoDto cadastrarDto);

        int Excluir(int Id);
    }
}