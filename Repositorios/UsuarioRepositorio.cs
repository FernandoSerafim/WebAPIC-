using Microsoft.EntityFrameworkCore;
using SistemaDeTarefas.Data;
using SistemaDeTarefas.Models;
using SistemaDeTarefas.Repositorios.Interfaces;

namespace SistemaDeTarefas.Repositorios
{
    public class UsuarioRepositorio:IUsuarioRepositorio
    {
        private readonly SistemaTarefasDbContex _dbContext;
        public UsuarioRepositorio(SistemaTarefasDbContex sistemaTarefasDbContex)
        {
            _dbContext = sistemaTarefasDbContex;
        }


        //Operações envolvendo consumo de API devem ser do tipo assíncronas sempre
        public async Task<UsuarioModel> BuscarPorId(int idUsuario)
        {
            return await _dbContext.Usuarios.FirstOrDefaultAsync(x => x.IdUsuario == idUsuario); //Sem o await, a operação nem funciona
        }

        public async Task<List<UsuarioModel>> BuscarTodosUsuarios()
        {
            return await _dbContext.Usuarios.ToListAsync(); //Sem o await, a operação nem funciona
        }

        public async Task<UsuarioModel> AdicionarUsuario(UsuarioModel usuario)
        {
             await _dbContext.Usuarios.AddAsync(usuario);
             await _dbContext.SaveChangesAsync();
            return usuario;
        }

        public async Task<bool> ApagarUsuario(int IdUsuario)
        {

            UsuarioModel usuarioBuscado = await BuscarPorId(IdUsuario);

            if (usuarioBuscado == null)
            {
                throw new Exception($"O usuário para o Id: {IdUsuario} não foi encontrado no banco de dados! ");
            }

            _dbContext.Usuarios.Remove(usuarioBuscado);
            await _dbContext.SaveChangesAsync();

            return true;
        }

        public async Task<UsuarioModel> AtualizarUsuario(UsuarioModel usuario, int IdUsuario)
        {

            UsuarioModel usuarioBuscado = await BuscarPorId(IdUsuario);

            if (usuarioBuscado == null)
            {
                throw new Exception($"O usuário para o Id: {IdUsuario} não foi encontrado no banco de dados! ");
            }

            usuarioBuscado.NmUsuario = usuario.NmUsuario;
            usuarioBuscado.Email = usuario.Email;

            _dbContext.Usuarios.Update(usuarioBuscado);
            await _dbContext.SaveChangesAsync();

            return usuarioBuscado;
        }

    }
}
