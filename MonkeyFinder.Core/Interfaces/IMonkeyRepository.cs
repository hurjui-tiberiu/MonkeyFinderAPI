using MonkeyFinder.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonkeyFinder.Core.Interfaces
{
    public interface IMonkeyRepository
    {
        Task<IEnumerable<Monkey>> GetMonkeysAsync();
        Task<IEnumerable<Monkey>> SearchMonkeyByIdAsync(int id);
        Task AddMonkey(Monkey monkey);
        Task DeleteMonkey(string Name);
        Task UpdateMonkey(string Name, Monkey monkey);
    }
}
