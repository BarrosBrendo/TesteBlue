using Agenda.Application.Services;
using Agenda.Domain.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace Agenda.Controllers
{
    [ApiController]
    [Route("api/v1/auth")]
    public class AuthController : Controller
    {
        [HttpPost]
        public IActionResult Auth(string usuarionome, string senha)
        {
            if (usuarionome == "usuario01" && senha == "123456")
            {
                var token = TokenService.GenerateToken(new UsuarioModel());
                return Ok(token);
            }
        
            return BadRequest("Nome ou senha invalidos");
        }
    }
}
