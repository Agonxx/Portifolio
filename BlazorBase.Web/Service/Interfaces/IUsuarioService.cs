using BlazorBase.Shared.Models;

namespace BlazorBase.Web.Service.Interfaces
{
    public interface IUsuarioService : IBaseService<Usuario>
    {
        public Task<Usuario> AddUsuario();
        public Task<Usuario> CadastrarUsuario(Usuario usuaroObj);
        public Task<List<Usuario>> BuscarUsuarios();
    }
}
