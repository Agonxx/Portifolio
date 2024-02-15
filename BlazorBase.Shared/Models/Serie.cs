using Microsoft.EntityFrameworkCore;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace BlazorBase.Shared.Models
{
    public class Serie
    {
        [Key]
        public int Id { get; set; }

        public int ExercicioId { get; set; }

        [DisplayName("Nome")]
        public string Nome { get; set; } = "";

        [DisplayName("Repetições")]
        public int Repeticoes { get; set; }

        [DisplayName("Carga")]
        public decimal Carga { get; set; }

    }

    public static class SerieAPI
    {
        public const string BuscarSeries = "BuscarSeries";
        public const string AddSerie = "AddSerie";
    }

    public static class DBContextSerie
    {
        public static void SetarConfigSerie(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Serie>(
                r =>
                {
                    r.HasOne<Exercicio>()
                    .WithMany()
                    .HasForeignKey(x => x.ExercicioId)
                    .OnDelete(DeleteBehavior.Cascade);
                });
        }
    }
}
