using Microsoft.AspNet.SignalR;

namespace WebApp
{
    /// <summary>
    /// SignalR-хаб, посылающий обновления на клиенты
    /// </summary>
    public class UpdatesHub : Hub
    {
        private const string ServerName = "SERVER";

        /// <summary>
        /// Отправка сообщения на клиент
        /// </summary>
        /// <param name="message"> Передаваемое сообщение </param>
        public virtual void SendNotifications(string message)
        {
            var context = GlobalHost.ConnectionManager.GetHubContext<UpdatesHub>();
            context.Clients.All.receiveMessage(ServerName, message);
        }
    }
}