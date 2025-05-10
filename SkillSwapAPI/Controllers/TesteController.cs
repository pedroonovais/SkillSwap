using Microsoft.AspNetCore.Mvc;

namespace SkillSwapAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TesteController : ControllerBase
    {
        [HttpGet("/")]
        public IActionResult Hello()
        {
            return Ok("Teste funcionando!");
        }
    }
}
