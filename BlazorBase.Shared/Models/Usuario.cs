
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using BlazorBase.Shared.Enums;

namespace BlazorBase.Shared.Models
{
    public class Usuario
    {
        [Key]
        public int Id { get; set; }

        [DisplayName("Nome")]
        public string Nome { get; set; } = "";

        [DisplayName("E-mail")]
        public string Email { get; set; } = "";

        [DisplayName("Genero")]
        public EGenero Genero { get; set; } = EGenero.Outro;
    }

    public static class UsuarioAPI
    {
        public const string CadastrarUsuario = "CadastrarUsuario";
        public const string BuscarUsuarios = "BuscarUsuarios";
        public const string AddUsuario = "AddUsuario";
    }
}
