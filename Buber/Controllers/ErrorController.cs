using Microsoft.AspNetCore.Mvc;

namespace Buber.Controllers
{
    public class ErrorController:ControllerBase
    {
        [Route("Error")]
        public IActionResult Error()
        {
            return Problem();
        }
    }
}
