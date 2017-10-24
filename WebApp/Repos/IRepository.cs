using System.Collections.Generic;
using System.Threading.Tasks;
using WebApp.Models;

namespace WebApp.Repos
{
    /// <summary>
    /// Интерфейс репозитория для работы с базой данных
    /// </summary>
    public interface IRepository
    {
        /// <summary>
        /// Добавление данных в базу
        /// </summary>
        /// <param name="user"> Пользователь, которого необходимо добавить </param>
        /// <returns> Задача с контекстом выполнения </returns>
        Task Add(User user);

        /// <summary>
        /// Получить данные из базы
        /// </summary>
        /// <returns> Список пользователей c данными  </returns>
        Task<IEnumerable<User>> Get();
    }
}