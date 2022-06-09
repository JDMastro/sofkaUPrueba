using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace SofkaUPrueba.Api.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class HomeController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            var id = User.Claims.FirstOrDefault(x => x.Type.ToString().Equals("Id", StringComparison.InvariantCultureIgnoreCase));
            return Ok(id.Value);
        }
    }
}
