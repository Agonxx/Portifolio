using BlazorBase.Api.Data;
using BlazorBase.Shared.Models;
using Microsoft.EntityFrameworkCore;

namespace BlazorBase.Api.Repositories
{
    public class SubDivisaoRepository
    {
        private DataContext _database;

        public SubDivisaoRepository(DataContext context)
        {
            _database = context;
        }

        public async Task<SubDivisao> AddSubDivisao(SubDivisao subDivisao)
        {
            await _database.SubDivisoes.AddAsync(subDivisao);
            await _database.SaveChangesAsync();
            return subDivisao;
        }

        public async Task<List<SubDivisao>> BuscarSubDivisoes()
        {
            var subDivisoes = await _database.SubDivisoes.ToListAsync();
            return subDivisoes;
        }
    }
}
