
namespace Warehouse.UnitTest.Container
{
    using NUnit.Framework;

    using Warehouse.Common.Container;
    using Warehouse.DAL.Contract;
    using Warehouse.DAL.SqlServer;
    using Warehouse.Domain;

    /// <summary>
    /// The dal factory test.
    /// </summary>
    [TestFixture]
    public class RepositoryContainerTest
    {
        /// <summary>
        /// The factory test.
        /// </summary>
        [Test]
        public void UserRepositoryResolveTest()
        {
            var resolve = DIContainer.Resolve<IRepository<User>>("User");
            Assert.IsInstanceOf(typeof(UserRepository), resolve);
        }
    }
}
