﻿// <auto-generated />
using BlazorBase.Api.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace BlazorBase.Api.Migrations
{
    [DbContext(typeof(DataContext))]
    partial class DataContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("BlazorBase.Shared.Models.Exercicio", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Nome")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("SubDivisaoId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("SubDivisaoId");

                    b.ToTable("Exercicios");
                });

            modelBuilder.Entity("BlazorBase.Shared.Models.GrupoMuscular", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Nome")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("GruposMusculares");
                });

            modelBuilder.Entity("BlazorBase.Shared.Models.SubDivisao", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("GrupoMuscularID")
                        .HasColumnType("int");

                    b.Property<string>("Nome")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("GrupoMuscularID");

                    b.ToTable("SubDivisoes");
                });

            modelBuilder.Entity("BlazorBase.Shared.Models.Usuario", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<short>("Genero")
                        .HasColumnType("smallint");

                    b.Property<string>("Nome")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Usuarios");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Email = "Rafael@gmail.com",
                            Genero = (short)3,
                            Nome = "Rafael"
                        },
                        new
                        {
                            Id = 2,
                            Email = "Joao@gmail.com",
                            Genero = (short)3,
                            Nome = "João"
                        });
                });

            modelBuilder.Entity("BlazorBase.Shared.Models.Exercicio", b =>
                {
                    b.HasOne("BlazorBase.Shared.Models.SubDivisao", null)
                        .WithMany()
                        .HasForeignKey("SubDivisaoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("BlazorBase.Shared.Models.SubDivisao", b =>
                {
                    b.HasOne("BlazorBase.Shared.Models.GrupoMuscular", null)
                        .WithMany()
                        .HasForeignKey("GrupoMuscularID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
