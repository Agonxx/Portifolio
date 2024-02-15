using Microsoft.EntityFrameworkCore;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace BlazorBase.Shared.Models
{
    public class GrupoMuscular
    {
        [Key]
        public int Id { get; set; }

        [DisplayName("Nome")]
        public string Nome { get; set; } = "";

    }

    public static class GrupoMuscularAPI
    {
        public const string BuscarGrupoMusculares = "BuscarGrupoMusculares";
        public const string AddGrupoMuscular = "AddGrupoMuscular";
    }

    public static class DBContextGrupoMuscular
    {
        public static void SetarConfigGrupoMuscular(this ModelBuilder modelBuilder)
        {
            //modelBuilder.Entity<GrupoMuscular>(
            //    r =>
            //    {
            //        r.HasOne<GrupoMuscular>()
            //        .WithMany()
            //        .HasForeignKey(x => x.GrupoMuscularID)
            //        .OnDelete(DeleteBehavior.Cascade);
            //    });
        }
    }
}
