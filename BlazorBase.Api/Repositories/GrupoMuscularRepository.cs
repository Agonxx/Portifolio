using BlazorBase.Api.Data;
using BlazorBase.Shared.Models;
using Microsoft.EntityFrameworkCore;

namespace BlazorBase.Api.Repositories
{
    public class GrupoMuscularRepository
    {
        private DataContext _database;

        public GrupoMuscularRepository(DataContext context)
        {
            _database = context;
        }

        public async Task<GrupoMuscular> AddGrupoMuscular(GrupoMuscular grupoMuscular)
        {
            await _database.GruposMusculares.AddAsync(grupoMuscular);
            await _database.SaveChangesAsync();
            return grupoMuscular;
        }

        public async Task<List<GrupoMuscular>> BuscarGrupoMusculares()
        {
            var grupoMusculares = await _database.GruposMusculares.ToListAsync();
            return grupoMusculares;
        }
    }
}
