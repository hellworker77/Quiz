using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebHostService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    
    public class Test : ControllerBase
    {
        [Authorize(Roles = "admin")]
        [HttpGet("admin")]
        public async Task<int> GetByAdminAsync()
        {
            return await Task.FromResult(1);
        }
        [Authorize]
        [HttpGet("any auth")]
        public async Task<int> GetByUserAsync()
        {
            return await Task.FromResult(0);
        }
    }
}
