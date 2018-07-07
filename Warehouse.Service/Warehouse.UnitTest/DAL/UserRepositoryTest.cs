
namespace Warehouse.UnitTest.DAL
{
    using System.Linq;

    using NUnit.Framework;

    using Warehouse.Common.Container;
    using Warehouse.DAL.Contract;
    using Warehouse.Domain;

    /// <summary>
    /// The user repository test.
    /// </summary>
    [TestFixture]
    public class UserRepositoryTest
    {
        /// <summary>
        /// The use repository.
        /// </summary>
        private IRepository<User> useRepository;

        /// <summary>
        /// The set up.
        /// </summary>
        [SetUp]
        public void SetUp()
        {
            this.useRepository = DIContainer.Resolve<IRepository<User>>("User");
        }

        /// <summary>
        /// The get all user test.
        /// </summary>
        [Test]
        public void GetAllUserTest()
        {
            var users = this.useRepository.SelectAll();
            var user = new User(1, "admin", "admin", "admin", "admin");
            Assert.AreEqual(user.Login, users.First().Login);
        }
    }
}
