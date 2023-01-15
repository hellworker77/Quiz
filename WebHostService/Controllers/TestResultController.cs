using Core.Abstraction.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Models.Implementation;

namespace WebHostService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestResultController : ControllerBase
    {
        private readonly ITestResultService _testResultService;
        private readonly IIdentityService _identityService;

        public TestResultController(ITestResultService testResultService,
            IIdentityService identityService)
        {
            _testResultService = testResultService;
            _identityService = identityService;
        }

        [Authorize]
        [HttpGet("id")]
        public async Task<TestResultDto?> GetByIdAsync(Guid id)
        {
            var userId = _identityService.GetUserIdentity();
            if (userId != string.Empty)
            {
                return await _testResultService.GetTestResultsAsync(Guid.Parse(userId), id);
            }

            return null;
        }

        [Authorize(Roles = "admin")]
        [HttpGet("userTestResult")]
        public async Task<TestResultDto> GetByIdAsync(Guid userId, Guid id)
        {
            return await _testResultService.GetTestResultsAsync(userId, id);
        }

        [Authorize]
        [HttpGet("chunk")]
        public async Task<List<TestResultDto>?> GetChunkAsync(int size, int number)
        {
            var userId = _identityService.GetUserIdentity();
            if (userId != string.Empty)
            {
                return await _testResultService.GetChunkAsync(Guid.Parse(userId), size, number);
            }

            return null;
        }

        [Authorize]
        [HttpGet("count")]
        public async Task<int> GetCountAsync()
        {
            var userId = _identityService.GetUserIdentity();
            if (userId != string.Empty)
            {
                return await _testResultService.GetCountAsync(Guid.Parse(userId));
            }

            return 0;
        }

        [Authorize(Roles = "admin")]
        [HttpGet("userTestResults")]
        public async Task<List<TestResultDto>> GetChunkAsync(Guid userId, int size, int number)
        {
            return await _testResultService.GetChunkAsync(userId, size, number);
        }

        [Authorize(Roles = "admin")]
        [HttpGet("userCount")]
        public async Task<int> GetUserCountAsync(Guid userId)
        {
            return await _testResultService.GetCountAsync(userId);
        }

        [Authorize]
        [HttpPost("reply")]
        public async Task ReplyAsync(AnswerTest answerTest)
        {
            var userId = _identityService.GetUserIdentity();
            if (userId != string.Empty)
            {
                await _testResultService.ReplyAsync(answerTest, Guid.Parse(userId));
            }
        }
        
    }
}
