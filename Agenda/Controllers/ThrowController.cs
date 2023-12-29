using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;

namespace Agenda.Controllers
{
    [ApiExplorerSettings(IgnoreApi = true)]
    public class ThrowController : Controller
    {
        [Route("/error")]
        public IActionResult HandlerError() => Problem();

        [Route("/error-desenvolvedor")]
        public IActionResult HandleErrorDesenvolvedor([FromServices] IHostEnvironment hostEnvironment)
        { 
            if (!hostEnvironment.IsDevelopment())
            {
                return NotFound();
            }   

            var exceptionHandlerFeature = 
                HttpContext.Features.Get<IExceptionHandlerPathFeature>()!;

            return Problem(
                detail: exceptionHandlerFeature.Error.StackTrace,
                title: exceptionHandlerFeature.Error.Message);
        }
    }
}
