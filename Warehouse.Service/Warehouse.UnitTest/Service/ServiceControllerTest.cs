// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ServiceControllerTest.cs" company="DNU">
//   DNU
// </copyright>
// <summary>
//   Defines the ServiceControllerTest type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Warehouse.UnitTest.Service
{
    using NUnit.Framework;

    using Warehouse.Common.Container;
    using Warehouse.DTO;
    using Warehouse.Service.Contract;

    /// <summary>
    /// The service controller test.
    /// </summary>
    [TestFixture]
    public class ServiceControllerTest
    {
        /// <summary>
        /// The service controller.
        /// </summary>
        private IController serviceController;

        /// <summary>
        /// The set up.
        /// </summary>
        [SetUp]
        public void SetUp()
        {
            this.serviceController = DIContainer.Resolve<IController>();
        }

        /// <summary>
        /// The system enter test.
        /// </summary>
        [Test]
        public void SystemEnterTest()
        {
            var userLogin = new UserLogin("administrator", "admin123^&");
            var result = this.serviceController.SystemEnter(userLogin);
            var expectedId = 2;
            Assert.AreEqual(expectedId, result.AttachedObject);
        }
    }
}