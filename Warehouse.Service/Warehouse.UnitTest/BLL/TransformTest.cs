
namespace Warehouse.UnitTest.BLL
{
    using System;

    using NUnit.Framework;

    using Warehouse.BLL.Transform;
    using Warehouse.Domain;
    using Warehouse.DTO;

    /// <summary>
    /// The transform test.
    /// </summary>
    [TestFixture]

    public class TransformTest
    {
        /// <summary>
        /// The user transformer test.
        /// </summary>
        [Test]
        public void SimleTransformerTest()
        {
            var userLogin = new UserLogin("admin", "admin");
            var result = SimpleTransformer.Transform<UserLogin, User>(userLogin);
            Assert.AreEqual(userLogin.Login, result.Login);
        }

        /// <summary>
        /// The goods transformer test.
        /// </summary>
        [Test]
        public void GoodsDomainTransformerTest()
        {
            var goodsDto = new GoodsDto(
                1,
                "title1",
                new ProviderDto(123, string.Empty, string.Empty, string.Empty),
                new GoodsCategoryDto(456, string.Empty),
                new GoodsClassDto(789, string.Empty),
                100m);
            var expectedDomain = new Goods(1, "title1", 123, 456, 789, 100m);
            var result = GoodsTransformer.FromGoodsDtoToGoods(goodsDto);
            Assert.AreEqual(expectedDomain.GoodsClassId, result.GoodsClassId);
        }

        /// <summary>
        /// The goods dto transformer test.
        /// </summary>
        [Test]
        public void GoodsDtoTransformerTest()
        {
            var domain = new Goods(1, "1", 2, 3, 4, 5m);
            var provider = new ProviderDto(12, "name", "adress", "phone");
            var category = new GoodsCategoryDto(54, "category");
            var gclass = new GoodsClassDto(76543, "class");
            var result = GoodsTransformer.FromGoodsToGoodsDto(domain, provider, category, gclass);
            Assert.AreEqual(category.Title, result.GoodsCategory.Title);
        }
    }
}
