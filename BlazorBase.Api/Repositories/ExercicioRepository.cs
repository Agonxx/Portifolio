using BlazorBase.Api.Data;
using BlazorBase.Shared.Models;
using Microsoft.EntityFrameworkCore;

namespace BlazorBase.Api.Repositories
{
    public class ExercicioRepository
    {
        private DataContext _database;

        public ExercicioRepository(DataContext context)
        {
            _database = context;
        }

        public async Task<Exercicio> AddExercicio(Exercicio exercicio)
        {
            await _database.Exercicios.AddAsync(exercicio);
            await _database.SaveChangesAsync();
            return exercicio;
        }

        public async Task<List<Exercicio>> BuscarExercicios()
        {
            var exercicios = await _database.Exercicios.ToListAsync();
            return exercicios;
        }
    }
}
