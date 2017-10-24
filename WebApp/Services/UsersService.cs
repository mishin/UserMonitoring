using System.Collections.Generic;
using System.Threading.Tasks;
using Newtonsoft.Json;
using WebApp.Models;
using WebApp.Repos;

namespace WebApp.Services
{
    /// <summary>
    /// Класс для работы с данными пользователей
    /// </summary>
    public class UsersService : IUsersService
    {
        private readonly IRepository repo;

        private readonly UpdatesHub hub;

        /// <summary>
        /// Конструктор для создания класса <see cref="UsersService" />
        /// </summary>
        /// <param name="repo"> Репозиторий для работы с базой данных </param>
        /// <param name="hub"> Хаб, для отправки уведомлений об обновлениях на клиент </param>
        public UsersService(IRepository repo, UpdatesHub hub)
        {
            this.repo = repo;
            this.hub = hub;
        }

        /// <inheritdoc />
        public async Task Add(IEnumerable<User> users)
        {
            foreach (var user in users)
            {
                await repo.Add(user);
                hub.SendNotifications(JsonConvert.SerializeObject(user));
            }
        }

        /// <inheritdoc />
        public async Task<IEnumerable<User>> Get()
        {
            return await this.repo.Get();
        }
    }
}