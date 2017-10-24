using System.Collections.Generic;
using System.Linq;
using Moq;
using NUnit.Framework;
using WebApp.Models;
using WebApp.Repos;
using WebApp.Services;

namespace WebApp.Tests.Services
{
    [TestFixture]
    internal class UsersServiceFixture
    {
        [Test]
        public void TestAddToDatabaseCorrectAmount()
        {
            var service = new Mock<UpdatesHub>();
            var repo = new Mock<IRepository>();
            var sut = new UsersService(repo.Object, service.Object);
            var users = GetUsersData();

            sut.Add(users).Wait();

            repo.Verify(x => 
                x.Add(It.IsAny<User>()), Times.Exactly(users.Count),
                $"Должно быть записано в базу {users.Count} обновлений данных пользователей");
;       }

        [Test]
        public void TestSenduserNotificationsCorrectTimes()
        {
            var service = new Mock<UpdatesHub>();
            var repo = new Mock<IRepository>();
            var sut = new UsersService(repo.Object, service.Object);
            var users = GetUsersData();

            sut.Add(users).Wait();

            service.Verify(x =>
                x.SendNotifications(It.IsAny<string>()), Times.Exactly(users.Count),
                $"Должно быть отправлено {users.Count} обновлений пользователям");
        }

        [Test]
        public void TestGetUserData()
        {
            var users = GetUsersData();
            var service = new Mock<UpdatesHub>();
            var repo = new Mock<IRepository>();
            repo.Setup(x => x.Get()).ReturnsAsync(users);
            var sut = new UsersService(repo.Object, service.Object);

            var result = sut.Get().Result.ToList();

            Assert.That(result.SequenceEqual(users), "Полученные данные не соответствуют тем, которые ожидаются");
        }

        private static List<User> GetUsersData()
        {
            return new List<User>
            {
                new User(),
                new User(),
                new User()
            };
        }
    }
}