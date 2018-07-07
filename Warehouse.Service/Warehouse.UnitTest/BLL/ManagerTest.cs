// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ManagerTest.cs" company="DNU">
//   DNU
// </copyright>
// <summary>
//   Defines the ManagerTest type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Warehouse.UnitTest.BLL
{
    using System;
    using System.Linq;

    using NUnit.Framework;

    using Warehouse.BLL.Contract;
    using Warehouse.Common.Container;
    using Warehouse.DTO;

    /// <summary>
    /// The manager test.
    /// </summary>
    [TestFixture]
    public class ManagerTest
    {
        /// <summary>
        /// The manager.
        /// </summary>
        private IManager manager;

        /// <summary>
        /// The set up.
        /// </summary>
        [SetUp]
        public void SetUp()
        {
            this.manager = DIContainer.Resolve<IManager>();
        }

        /// <summary>
        /// The system enter test.
        /// </summary>
        [Test]
        public void SystemEnterTest()
        {
            var userLogin = new UserLogin("administrator", "admin123^&");
            var result = this.manager.SystemEnter(userLogin);
            var expectedId = 2;
            Assert.AreEqual(expectedId, result);
        }

        /// <summary>
        /// The get all warehouse goods test.
        /// </summary>
        [Test]
        public void GetAllWarehouseGoodsTest()
        {
            var warehouseGoods = this.manager.GetAllWarehouseGoods();
            var firstExpectedWarehouseGoodsTitle = "Cholate";                
            Assert.AreNotEqual(firstExpectedWarehouseGoodsTitle, warehouseGoods.First().Title);
        }
    }
}
