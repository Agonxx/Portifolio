using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BlazorBase.Api.Migrations
{
    /// <inheritdoc />
    public partial class Ini2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Exercicio_SubDivisao_SubDivisaoId",
                table: "Exercicio");

            migrationBuilder.DropPrimaryKey(
                name: "PK_SubDivisao",
                table: "SubDivisao");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Exercicio",
                table: "Exercicio");

            migrationBuilder.RenameTable(
                name: "SubDivisao",
                newName: "SubDivisoes");

            migrationBuilder.RenameTable(
                name: "Exercicio",
                newName: "Exercicios");

            migrationBuilder.RenameIndex(
                name: "IX_Exercicio_SubDivisaoId",
                table: "Exercicios",
                newName: "IX_Exercicios_SubDivisaoId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_SubDivisoes",
                table: "SubDivisoes",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Exercicios",
                table: "Exercicios",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "GruposMusculares",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GruposMusculares", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_SubDivisoes_GrupoMuscularID",
                table: "SubDivisoes",
                column: "GrupoMuscularID");

            migrationBuilder.AddForeignKey(
                name: "FK_Exercicios_SubDivisoes_SubDivisaoId",
                table: "Exercicios",
                column: "SubDivisaoId",
                principalTable: "SubDivisoes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_SubDivisoes_GruposMusculares_GrupoMuscularID",
                table: "SubDivisoes",
                column: "GrupoMuscularID",
                principalTable: "GruposMusculares",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Exercicios_SubDivisoes_SubDivisaoId",
                table: "Exercicios");

            migrationBuilder.DropForeignKey(
                name: "FK_SubDivisoes_GruposMusculares_GrupoMuscularID",
                table: "SubDivisoes");

            migrationBuilder.DropTable(
                name: "GruposMusculares");

            migrationBuilder.DropPrimaryKey(
                name: "PK_SubDivisoes",
                table: "SubDivisoes");

            migrationBuilder.DropIndex(
                name: "IX_SubDivisoes_GrupoMuscularID",
                table: "SubDivisoes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Exercicios",
                table: "Exercicios");

            migrationBuilder.RenameTable(
                name: "SubDivisoes",
                newName: "SubDivisao");

            migrationBuilder.RenameTable(
                name: "Exercicios",
                newName: "Exercicio");

            migrationBuilder.RenameIndex(
                name: "IX_Exercicios_SubDivisaoId",
                table: "Exercicio",
                newName: "IX_Exercicio_SubDivisaoId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_SubDivisao",
                table: "SubDivisao",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Exercicio",
                table: "Exercicio",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Exercicio_SubDivisao_SubDivisaoId",
                table: "Exercicio",
                column: "SubDivisaoId",
                principalTable: "SubDivisao",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
