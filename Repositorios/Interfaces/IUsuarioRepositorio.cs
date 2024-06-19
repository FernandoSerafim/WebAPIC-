using SistemaDeTarefas.Models;

namespace SistemaDeTarefas.Repositorios.Interfaces
{
    public interface IUsuarioRepositorio
    {
        //Como as operações são assíncronas, precisam ser to tipo Task
        Task<List<UsuarioModel>> BuscarTodosUsuarios();
        Task<UsuarioModel> BuscarPorId(int idUsuario);
        Task<UsuarioModel> AdicionarUsuario(UsuarioModel usuario);
        Task<UsuarioModel> AtualizarUsuario(UsuarioModel usuario, int IdUsuario);
        Task<bool> ApagarUsuario(int IdUsuario);
    }
}
