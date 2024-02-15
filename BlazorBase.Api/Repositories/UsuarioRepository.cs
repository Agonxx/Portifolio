using BlazorBase.Api.Data;
using BlazorBase.Shared.Enums;
using BlazorBase.Shared.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.EntityFrameworkCore;

namespace BlazorBase.Api.Repositories
{
    public class UsuarioRepository
    {
        private DataContext _database;

        public UsuarioRepository(DataContext context)
        {
            _database = context;
        }

        public async Task<Usuario> CadastrarUsuario(Usuario usuarioObj)
        {
            usuarioObj.Email = usuarioObj.Email;
            await _database.Usuarios.AddAsync(usuarioObj);
            await _database.SaveChangesAsync();
            return usuarioObj;
        }

        public async Task<Usuario> AddUsuario()
        {
            var user = new Usuario
            {
                Nome = "Rafael",
                Email = "Rafhita1@gmail.com",
                Genero = EGenero.Masculino
            };

            await _database.Usuarios.AddAsync(user);
            await _database.SaveChangesAsync();
            return user;
        }

        public async Task<List<Usuario>> BuscarUsuarios()
        {
            var usuarios = await _database.Usuarios.ToListAsync();
            return usuarios;
        }
    }
}
