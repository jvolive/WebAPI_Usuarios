using Microsoft.AspNetCore.Mvc;
using usuario.Model;
using usuario.Repository;

namespace usuario.Controllers
{
    [ApiController]
    [Route("api/[controller]")]

    public class UsuarioController : ControllerBase
    {
        private readonly IUsuarioRepository _repository;

        public UsuarioController(IUsuarioRepository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var usuarios = await _repository.BuscaUsuario();
            return usuarios.Any()
                    ? Ok(usuarios)
                    : NoContent();
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var usuarios = await _repository.BuscaUsuario(id);
            return usuarios != null
                    ? Ok(usuarios)
                    : NotFound("Usuario não encontrado");
        }

        [HttpPost]
        public async Task<IActionResult> Post(Usuario usuario)
        {
            _repository.AdicionaUsuario(usuario);
            return await _repository.SaveChangeAsync()
            ? Ok("Usuario adicionado com sucesso")
            : BadRequest("Erro");
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, Usuario usuario)
        {
            var usuarioBanco = await _repository.BuscaUsuario(id);
            if (usuarioBanco == null) return NotFound("Usuario não encontrado");

            usuarioBanco.Nome = usuario.Nome ?? usuarioBanco.Nome;
            usuarioBanco.DataNacimento = usuario.DataNacimento != new DateTime()
            ? usuario.DataNacimento : usuarioBanco.DataNacimento;

            _repository.AtualizarUsuario(usuarioBanco);

            return await _repository.SaveChangeAsync()
            ? Ok("Usuario adicionado com sucesso")
            : BadRequest("Erro ao atualizar o usuario");

        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var usuarioBanco = await _repository.BuscaUsuario(id);
            if (usuarioBanco == null) return NotFound("Usuario não encontrado");

            _repository.DeletaUsuario(usuarioBanco);

            return await _repository.SaveChangeAsync()
            ? Ok("Usuario deletado com sucesso")
            : BadRequest("Erro ao deletar o usuario");


        }


    }


}