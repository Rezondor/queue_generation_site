using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace SFQG.Controllers
{
    [Route("api/users")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        [HttpGet]
        public IActionResult GetUsers()
        {
            var users = new[]
            {
                new {Name = "Nikita"},
                new {Name = "Evgeni"}
            };

            return Ok(users);
        }
    }
}
