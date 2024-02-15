using BlazorBase.Shared.Models;
using Microsoft.EntityFrameworkCore;

namespace BlazorBase.Api.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }

        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<GrupoMuscular> GruposMusculares { get; set; }
        public DbSet<SubDivisao> SubDivisoes{ get; set; }
        public DbSet<Exercicio> Exercicios{ get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.SetarConfigGrupoMuscular();
            modelBuilder.SetarConfigSubDivisao();
            modelBuilder.SetarConfigExercicio();
            modelBuilder.Seed();
        }
    }

    public static class ModelBuilderExtensions
    {
        public static void Seed(this ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<Usuario>().HasData(new Usuario[]
            {
                new Usuario {
                    Id = 1,
                    Email ="Rafael@gmail.com",
                    Nome = "Rafael",
                },
                new Usuario
                {
                    Id = 2,
                    Email ="Joao@gmail.com",
                    Nome = "João",
                }
            });
        }
    }
}
