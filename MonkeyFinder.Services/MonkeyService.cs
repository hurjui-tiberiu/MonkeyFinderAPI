using MonkeyFinder.Core.Interfaces;
using MonkeyFinder.Core.Entities;
using MonkeyFinder.Services.Dtos;
using MonkeyFinder.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MonkeyFinder.Services
{
    public class MonkeyService : IMonkeyService
    {
        private readonly IMonkeyRepository _monkeyRepository;

        public MonkeyService(IMonkeyRepository monkeyRepository)
        {
            _monkeyRepository = monkeyRepository;
        }

        public async Task<IEnumerable<MonkeyDto>> GetMonkeysAsync()
        {
            var monkeys = await _monkeyRepository.GetMonkeysAsync();

            var monkeyDtos = monkeys.Select(m => new MonkeyDto
            {
                Name = m.Name,
                Details = m.Details,
                Image = m.ImageUri,
                Latitude = m.Latitude,
                Location = m.Location,
                Longitude = m.Longitude,
                Population = m.Population
            });

            return monkeyDtos;
        }

        public async Task<IEnumerable<MonkeyDto>> SearchMonkeyByIdAsync(int id)
        {
            var monkeys = await _monkeyRepository.SearchMonkeyByIdAsync(id);

            var monkeyDtos = monkeys.Select(m => new MonkeyDto
            {
                Name = m.Name,
                Details = m.Details,
                Image = m.ImageUri,
                Latitude = m.Latitude,
                Location = m.Location,
                Longitude = m.Longitude,
                Population = m.Population
            });

            return monkeyDtos;
        }

        public async Task AddMonkey(MonkeyDto _monkey)
        {
            var monkey = new Monkey
            {
                Name = _monkey.Name,
                Details = _monkey.Details,
                Latitude = _monkey.Latitude,
                Location = _monkey.Location,
                Longitude = _monkey.Longitude,
                Population = _monkey.Population,
                Image = _monkey.Image.OriginalString
            };

            await _monkeyRepository.AddMonkey(monkey);
        }

        public async Task DeleteMonkey(string Name)
        {
            await _monkeyRepository.DeleteMonkey(Name);
        }

        public async Task UpdateMonkey(string Name,MonkeyDto _monkey)
        {
            var monkey = new Monkey
            {
                Name = _monkey.Name,
                Details = _monkey.Details,
                Latitude = _monkey.Latitude,
                Location = _monkey.Location,
                Longitude = _monkey.Longitude,
                Population = _monkey.Population,
                Image = _monkey.Image.OriginalString
            };

            await _monkeyRepository.UpdateMonkey( Name, monkey);
        }
    }
}
