using System.Threading.Tasks;
using Infrastructure.Data;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IAuthRepository _authRepo;
        public UserController(IAuthRepository authRepo)
        {
            _authRepo = authRepo;
        }

        [HttpGet("GetAll")]
        public async Task<IActionResult> Get()
        {
            return Ok(await _authRepo.GetAllUsers());
        }



    }
}