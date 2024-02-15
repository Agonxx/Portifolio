using Microsoft.EntityFrameworkCore;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace BlazorBase.Shared.Models
{
    public class Exercicio
    {
        [Key]
        public int Id { get; set; }

        public int SubDivisaoId { get; set; }

        [DisplayName("Nome")]
        public string Nome { get; set; } = "";

    }

    public static class ExercicioAPI
    {
        public const string BuscarExercicios = "BuscarExercicios";
        public const string AddExercicio = "AddExercicio";
    }

    public static class DBContextExercicio
    {
        public static void SetarConfigExercicio(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Exercicio>(
                r =>
                {
                    r.HasOne<SubDivisao>()
                    .WithMany()
                    .HasForeignKey(x => x.SubDivisaoId)
                    .OnDelete(DeleteBehavior.Cascade);
                });
        }
    }
}
