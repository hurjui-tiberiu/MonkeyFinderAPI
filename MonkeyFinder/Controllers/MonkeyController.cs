using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MonkeyFinder.Services.Dtos;
using MonkeyFinder.Services.Interfaces;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MonkeyFinder.Api.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class MonkeyController : ControllerBase
    {
        private readonly IMonkeyService _monkeyService;
        private readonly ILogger<MonkeyController> _logger;

        public MonkeyController(IMonkeyService monkeyService, ILogger<MonkeyController> logger)
        {
            _monkeyService = monkeyService;
            _logger = logger;
        }

        [HttpGet]
        public async Task<ActionResult<IReadOnlyList<MonkeyDto>>> GetMonkeysAsync()
        {
            var result = await _monkeyService.GetMonkeysAsync();
            _logger.LogInformation("Monkeys were retrieved with success. Monkeys count : {count}", result.Count());

            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<IReadOnlyList<MonkeyDto>>> SearchMonkeyById(int id)
        {
            var result = await _monkeyService.SearchMonkeyByIdAsync(id);
            _logger.LogInformation("Monkey was retrieved with success");

            return Ok(result);
        }

        [HttpPost]
        public async Task AddMonkey([FromBody]MonkeyDto Monkey)
        {
                await _monkeyService.AddMonkey(Monkey);
            _logger.LogInformation("Monkey added succesfuly.");
        }

        [HttpDelete]
        public async Task Delete(string Name)
        {
             await _monkeyService.DeleteMonkey (Name);
            _logger.LogInformation("Monkey deleted succesfuly.");
        }

        [HttpPut]
        public async Task UpdateMonkey(string Name, [FromBody] MonkeyDto Monkey)
        {
            await _monkeyService.UpdateMonkey(Name, Monkey);
            _logger.LogInformation("Monkey updated succesfuly.");
        }


    }
}
