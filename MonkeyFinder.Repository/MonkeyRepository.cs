using Dapper;
using MonkeyFinder.Core.Entities;
using MonkeyFinder.Core.Interfaces;
using MonkeyFinder.DataAccess;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MonkeyFinder.Repository
{
    public class MonkeyRepository : IMonkeyRepository
    {
        private readonly IDbConnectionFactory _connectionFactory;

        public MonkeyRepository(IDbConnectionFactory connectionFactory)
        {
            _connectionFactory = connectionFactory;
        }

        public async Task<IEnumerable<Monkey>> GetMonkeysAsync()
        {
            const string query = "SELECT * FROM Monkey";

            var result = await _connectionFactory.GetConnection().QueryAsync<Monkey>(query);

            return result;
        }

        public async Task<IEnumerable<Monkey>> AddMonkeysAsync(Monkey monkey)
        {
            const string query = "SELECT * FROM Monkey";

            var result = await _connectionFactory.GetConnection().QueryAsync<Monkey>(query);

            return result;
        }

        public async Task<IEnumerable<Monkey>> SearchMonkeyByIdAsync(int id)
        {
            string query = $"SELECT * FROM Monkey WHERE ID = {0}" + id.ToString();

            var result = await _connectionFactory.GetConnection().QueryAsync<Monkey>(query);

            return result;
        }

        public async Task AddMonkey(Monkey monkey)
        {
            string query = string.Format("INSERT INTO Monkey (Name, Location, Details, Image, Population, Latitude, Longitude) VALUES ('{0}', '{1}', '{2}', '{3}', {4}, {5}, {6})",
                monkey.Name,
                monkey.Location,
                monkey.Details,
                monkey.ImageUri.OriginalString,
                monkey.Population,
                monkey.Latitude,
                monkey.Longitude);

            await _connectionFactory.GetConnection().QueryAsync<Monkey>(query);
        }


        public async Task DeleteMonkey(string Name)
        {
            string query = string.Format("DELETE FROM Monkey WHERE Name='{0}'",
                Name);

            await _connectionFactory.GetConnection().QueryAsync<Monkey>(query);
        }


        public async Task UpdateMonkey(string Name, Monkey monkey)
        {
          string query = string.Format("UPDATE Monkey SET Name='{0}', Location='{1}', Details='{2}', Image='{3}', Population={4}, Latitude={5}, Longitude={6} WHERE NAME='{7}'",
              monkey.Name,
              monkey.Location,
              monkey.Details,
              monkey.ImageUri.OriginalString,
              monkey.Population,
              monkey.Latitude,
              monkey.Longitude,
              Name);
          
          await _connectionFactory.GetConnection().QueryAsync<Monkey>(query);
        }



    }
}
