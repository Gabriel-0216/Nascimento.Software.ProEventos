﻿using ProEventos.Domain.Models;

namespace Infra.Repository.Eventos;

public interface IEventoRepository : IRepository<Evento>
{
    Task<IEnumerable<Evento>> GetAll(int skip, int take);
    Task<Evento?> GetById(int id, bool asNoTracking);
}