using System.ComponentModel;

namespace BlazorBase.Shared.Enums
{
    public enum EGenero : sbyte
    {
        [Description("Masculino")]
        Masculino = 1,

        [Description("Feminino")]
        Feminino = 2,

        [Description("Outro")]
        Outro = 3,
    }
}
