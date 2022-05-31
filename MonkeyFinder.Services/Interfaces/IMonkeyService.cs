using MonkeyFinder.Services.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonkeyFinder.Services.Interfaces
{
    public interface IMonkeyService
    {
        Task<IEnumerable<MonkeyDto>> GetMonkeysAsync();
        Task<IEnumerable<MonkeyDto>>SearchMonkeyByIdAsync(int id);
        Task AddMonkey(MonkeyDto monkey);
        Task DeleteMonkey(string Name);
        Task UpdateMonkey(string Name, MonkeyDto monkey);
    }
}
