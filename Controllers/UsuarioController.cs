using Microsoft.AspNetCore.Mvc;
using usuario.Model;

namespace usuario.Controllers
{
    [ApiController]
    [Route("api/[controller]")]

    public class UsuarioController : ControllerBase
    {

        private static List<Usuario> Usuarios()
        {
            return new List<Usuario>{
        new Usuario { Id = 1, Nome = "João Silva" },
        new Usuario { Id = 2, Nome = "Maria Souza" },
        // Adicione mais objetos Usuario conforme necessário
    };
        }
    }
}