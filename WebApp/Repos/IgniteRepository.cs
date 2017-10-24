using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Apache.Ignite.Core;
using Apache.Ignite.Core.Cache;
using Apache.Ignite.Linq;
using Ninject.Infrastructure.Language;
using WebApp.Models;

namespace WebApp.Repos
{
    /// <summary>
    /// Репозиторий для работы с Apache Ignite
    /// </summary>
    public class IgniteRepository : IRepository
    {
        private const string CacheName = "test";

        private readonly IIgnite ignite;

        private readonly ICache<string, User> cache;

        public IgniteRepository(IIgnite ignite)
        {
            this.ignite = ignite;
            this.cache = ignite.GetOrCreateCache<string, User>(CacheName);
        }

        /// <inheritdoc />
        public async Task Add(User user)
        {
            await this.cache.PutAsync(user.Id, user);
        }

        /// <inheritdoc />
        public async Task<IEnumerable<User>> Get()
        {
            var users = cache.AsCacheQueryable();

            var query = users
                    .Where(y => y.Value.ExitTime == null && y.Value.EnterTime != null)
                    .Select(x => x.Value);

            return await Task.FromResult(query.ToEnumerable());
        }
    }
}