using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Http;
using WebApp.Models;
using WebApp.Services;

namespace WebApp.Controllers
{
    /// <summary>
    /// Контроллер для работы с пользовательскими данными
    /// </summary>
    [RoutePrefix("users")]
    public class UsersController : ApiController
    {
        private readonly IUsersService usersService;

        /// <summary>
        /// Конструктор для создания класса <see cref="UsersController" />
        /// </summary>
        /// <param name="usersService"> Сервис для работы с данными пользователей </param>
        public UsersController(IUsersService usersService)
        {
            this.usersService = usersService;
        }

        /// <summary>
        /// Добавление данных пользователей
        /// </summary>
        /// <param name="users"> Данные пользователя </param>
        /// <returns> Задача с контекстом выполнения </returns>
        [HttpPost]
        [Route("add")]
        public async Task Add(List<User> users)
        {
            await this.usersService.Add(users);
        }

        /// <summary>
        /// Получение данных пользователей
        /// </summary>
        /// <returns> Данные пользователя </returns>
        [HttpGet]
        [Route("get")]
        public async Task<IEnumerable<User>> Get()
        {
            return await this.usersService.Get();
        }
    }
}
