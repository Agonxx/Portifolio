using BlazorBase.Api.Repositories;
using BlazorBase.Shared.Models;
using Microsoft.AspNetCore.Mvc;

namespace BlazorBase.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ExercicioController
    {
        private readonly ExercicioRepository _exercicioRepository;
        private readonly ILogger _logger;

        public ExercicioController(ExercicioRepository usuarioRepository, ILogger<Exercicio> logger)
        {
            _exercicioRepository = usuarioRepository;
            _logger = logger;
        }

        [HttpPost(ExercicioAPI.AddExercicio)]
        public async Task<Exercicio> AddExercicio(Exercicio exercicio)
        {
            exercicio = await _exercicioRepository.AddExercicio(exercicio);
            return exercicio;
        }

        [HttpGet(ExercicioAPI.BuscarExercicios)]
        public async Task<List<Exercicio>> BuscarExercicios()
        {
            var exercicios = await _exercicioRepository.BuscarExercicios();
            return exercicios;
        }
    }
}
