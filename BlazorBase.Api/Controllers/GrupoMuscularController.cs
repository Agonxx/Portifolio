using BlazorBase.Api.Repositories;
using BlazorBase.Shared.Models;
using Microsoft.AspNetCore.Mvc;

namespace BlazorBase.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class GrupoMuscularController
    {
        private readonly GrupoMuscularRepository _grupoMuscularRepository;
        private readonly ILogger _logger;

        public GrupoMuscularController(GrupoMuscularRepository grupoMuscularRepository, ILogger<GrupoMuscular> logger)
        {
            _grupoMuscularRepository = grupoMuscularRepository;
            _logger = logger;
        }

        [HttpPost(GrupoMuscularAPI.AddGrupoMuscular)]
        public async Task<GrupoMuscular> AddGrupoMuscular(GrupoMuscular grupoMuscular)
        {
            grupoMuscular = await _grupoMuscularRepository.AddGrupoMuscular(grupoMuscular);
            return grupoMuscular;
        }

        [HttpGet(GrupoMuscularAPI.BuscarGrupoMusculares)]
        public async Task<List<GrupoMuscular>> BuscarGrupoMusculares()
        {
            var grupoMusculares = await _grupoMuscularRepository.BuscarGrupoMusculares();
            return grupoMusculares;
        }
    }
}
