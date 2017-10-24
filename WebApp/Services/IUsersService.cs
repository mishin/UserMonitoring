using System.Collections.Generic;
using System.Threading.Tasks;
using WebApp.Models;

namespace WebApp.Services
{
    /// <summary>
    /// Интерфейс для работы с данными клиентов
    /// </summary>
    public interface IUsersService
    {
        /// <summary>
        /// Добавить данные пользователей
        /// </summary>
        /// <param name="users"> Данные пользователей для добавления </param>
        /// <returns> Задача с контекстом выполнения </returns>
        Task Add(IEnumerable<User> users);

        /// <summary>
        /// Получение текущего расположения клиентов
        /// </summary>
        /// <returns> Список клиентов с данными об их координатах и времени посещения </returns>
        Task<IEnumerable<User>> Get();
    }
}