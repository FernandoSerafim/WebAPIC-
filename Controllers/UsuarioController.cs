using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SistemaDeTarefas.Models;
using SistemaDeTarefas.Repositorios.Interfaces;

namespace SistemaDeTarefas.Controllers
{
    //Isso quer dizer que para acessar a minha API, 
    // Porta e IP do servidor/api/Usuario (substituindo onome da controller)
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        private readonly IUsuarioRepositorio _usuarioRepositorio;
        public UsuarioController(IUsuarioRepositorio usuarioRep)
        {
            _usuarioRepositorio = usuarioRep;
        }
        //Configurando meu primeiro EndPoint
        [HttpGet]
        public async Task<ActionResult<List<UsuarioModel>>> BuscarTodosUsuarios()
        {
            List<UsuarioModel> usuarios = await _usuarioRepositorio.BuscarTodosUsuarios();
            return Ok(usuarios); //Retorna o status 200 OK
        }

        //Personalizando a minha rota
        //Bate em api/Usuario/id
        //Se eu fizer api/Usuario, ele busca todos na rota de cima
        [HttpGet("{id}")]
        public async Task<ActionResult<List<UsuarioModel>>> BuscarPorId(int IdUser)
        {
            UsuarioModel usuario = await _usuarioRepositorio.BuscarPorId(IdUser);
            return Ok(usuario); //Retorna o status 200 OK
        }

        [HttpPost]
        public async Task<ActionResult<UsuarioModel>> Cadastrar([FromBody] UsuarioModel usuario)
        {
            UsuarioModel usuarioModel = await _usuarioRepositorio.AdicionarUsuario(usuario);
            return Ok(usuarioModel);
        }


        [HttpPut("{Id}")]
        public async Task<ActionResult<UsuarioModel>> Atualizar([FromBody] UsuarioModel usuario, int IdUser)
        {
            usuario.IdUsuario = IdUser;
            UsuarioModel usuarioAtualizado = await _usuarioRepositorio.AtualizarUsuario(usuario, IdUser);
            return Ok(usuarioAtualizado);
        }

        [HttpDelete("{Id}")]
        public async Task<ActionResult<UsuarioModel>> Apagar(int IdUser)
        {
            var resp = await _usuarioRepositorio.ApagarUsuario(IdUser);
            return Ok(resp);
        }

    }
}
