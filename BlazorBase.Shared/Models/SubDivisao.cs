using Microsoft.EntityFrameworkCore;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace BlazorBase.Shared.Models
{
    public class SubDivisao
    {
        [Key]
        public int Id { get; set; }

        public int GrupoMuscularID { get; set; }

        [DisplayName("Nome")]
        public string Nome { get; set; } = "";

    }

    public static class SubDivisaoAPI
    {
        public const string BuscarSubDivisoes = "BuscarSubDivisoes";
        public const string AddSubDivisao = "AddSubDivisao";
    }

    public static class DBContextSubDivisao
    {
        public static void SetarConfigSubDivisao(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<SubDivisao>(
                r =>
                {
                    r.HasOne<GrupoMuscular>()
                    .WithMany()
                    .HasForeignKey(x => x.GrupoMuscularID)
                    .OnDelete(DeleteBehavior.Cascade);
                });
        }
    }
}
