using Core.Abstraction.Interfaces;
using Entities.Entity;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Models.Implementation;

namespace WebHostService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestController : ControllerBase
    {
        private readonly ITestService _testService;

        public TestController(ITestService testService)
        {
            _testService = testService;
        }

        [HttpGet("chunk")]
        public async Task<List<TestDto>> GetChunkAsync(int size, int number)
        {
            return await _testService.GetChunkAsync(size, number);
        }
        [HttpGet("id")]
        public async Task<TestDto> GetByIdAsync(Guid id)
        {
            return await _testService.GetByIdAsync(id);
        }
        [HttpPost("create")]
        public async Task CreateAsync(TestDto testDto)
        {
            await _testService.CreateAsync(testDto);
        }
        [HttpPut("update")]
        public async Task UpdateAsync(TestDto testDto)
        {
            await _testService.UpdateAsync(testDto);
        }
        [HttpDelete("delete")]
        public async Task DeleteAsync(Guid id)
        {
            await _testService.DeleteAsync(id);
        }
    }
}
