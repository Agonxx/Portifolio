using BlazorBase.Api.Repositories;
using BlazorBase.Shared.Models;
using Microsoft.AspNetCore.Mvc;

namespace BlazorBase.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SubDivisaoController
    {
        private readonly SubDivisaoRepository _subDivisaoRepository;
        private readonly ILogger _logger;

        public SubDivisaoController(SubDivisaoRepository subDivisaoRepository, ILogger<SubDivisao> logger)
        {
            _subDivisaoRepository = subDivisaoRepository;
            _logger = logger;
        }

        [HttpPost(SubDivisaoAPI.AddSubDivisao)]
        public async Task<SubDivisao> AddSubDivisao(SubDivisao subDivisao)
        {
            subDivisao = await _subDivisaoRepository.AddSubDivisao(subDivisao);
            return subDivisao;
        }

        [HttpGet(SubDivisaoAPI.BuscarSubDivisoes)]
        public async Task<List<SubDivisao>> BuscarSubDivisoes()
        {
            var subDivisoes = await _subDivisaoRepository.BuscarSubDivisoes();
            return subDivisoes;
        }
    }
}
