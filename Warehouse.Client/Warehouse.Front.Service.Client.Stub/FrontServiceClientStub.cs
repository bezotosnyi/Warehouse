// --------------------------------------------------------------------------------------------------------------------
// <copyright file="FrontServiceClientStub.cs" company="DNU">
//   DNU
// </copyright>
// <summary>
//   Defines the FontServiceClientStub type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Warehouse.Front.Service.Client.Stub
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using Warehouse.DTO;
    using Warehouse.Front.Service.Client.Contract;

    /// <inheritdoc />
    /// <summary>
    /// The font service client stub.
    /// </summary>
    public class FrontServiceClientStub : IFrontServiceClient
    {
        /// <summary>
        /// The user registration list.
        /// </summary>
        private readonly List<UserLogin> userLoginList;

        /// <summary>
        /// The warehouse goodse list.
        /// </summary>
        private readonly List<WarehouseGoods> warehouseGoodseList;

        /// <summary>
        /// The provider list.
        /// </summary>
        private readonly List<ProviderDto> providerList;

        /// <summary>
        /// The goods category list.
        /// </summary>
        private readonly List<GoodsCategoryDto> goodsCategoryList;

        /// <summary>
        /// The goods class list.
        /// </summary>
        private readonly List<GoodsClassDto> goodsClassList;

        /// <summary>
        /// The goods list.
        /// </summary>
        private readonly List<GoodsDto> goodsList;

        /// <summary>
        /// Initializes a new instance of the <see cref="FrontServiceClientStub"/> class.
        /// </summary>
        public FrontServiceClientStub()
        {
            this.userLoginList = new List<UserLogin>
                                            {
                                                new UserLogin
                                                    {
                                                        Login = "login",
                                                        Password = "password"
                                                    }
                                            };
            this.warehouseGoodseList = new List<WarehouseGoods>
                                           {
                                                new WarehouseGoods
                                                    {
                                                        GoodsId = 1,
                                                        Title = "Goods1",
                                                        Provider = new ProviderDto
                                                                       {
                                                                           ProviderId = 1,
                                                                           Name = "Provider1",
                                                                           Address = "address1",
                                                                           Phone = "1234567"
                                                                       },
                                                        GoodsCategory = new GoodsCategoryDto
                                                                            {
                                                                                GoodsCategoryId = 1,
                                                                                Title = "Category1"
                                                                            },
                                                        GoodsClass = new GoodsClassDto
                                                                         {
                                                                             GoodsClassId = 1,
                                                                             Title = "Class1"
                                                                         },
                                                        Amount = 1,
                                                        UnitPrice = 1.0m,
                                                        DateTimeDelivery = DateTime.Now,
                                                        State = "Accrued"
                                                    },
                                               new WarehouseGoods
                                                   {
                                                       GoodsId = 2,
                                                       Title = "Goods2",
                                                       Provider = new ProviderDto
                                                                      {
                                                                          ProviderId = 2,
                                                                          Name = "Provider2",
                                                                          Address = "address2",
                                                                          Phone = "1234567"
                                                                      },
                                                       GoodsCategory = new GoodsCategoryDto
                                                                           {
                                                                               GoodsCategoryId = 2,
                                                                               Title = "Category2"
                                                                           },
                                                       GoodsClass = new GoodsClassDto
                                                                        {
                                                                            GoodsClassId = 2,
                                                                            Title = "Class2"
                                                                        },
                                                       Amount = 2,
                                                       UnitPrice = 2.0m,
                                                       DateTimeDelivery = DateTime.Now,
                                                       State = "Accrued"
                                                   },
                                               new WarehouseGoods
                                                   {
                                                       GoodsId = 3,
                                                       Title = "Goods3",
                                                       Provider = new ProviderDto
                                                                      {
                                                                          ProviderId = 3,
                                                                          Name = "Provider3",
                                                                          Address = "address3",
                                                                          Phone = "1234567"
                                                                      },
                                                       GoodsCategory = new GoodsCategoryDto
                                                                           {
                                                                               GoodsCategoryId = 3,
                                                                               Title = "Category3"
                                                                           },
                                                       GoodsClass = new GoodsClassDto
                                                                        {
                                                                            GoodsClassId = 3,
                                                                            Title = "Class3"
                                                                        },
                                                       Amount = 3,
                                                       UnitPrice = 3.0m,
                                                       DateTimeDelivery = DateTime.Now,
                                                       State = "Accrued"
                                                   }
                                            };
            this.providerList = new List<ProviderDto>
                                    {
                                        new ProviderDto
                                            {
                                                ProviderId = 1,
                                                Name = "Provider1",
                                                Address = "address1",
                                                Phone = "1234567"
                                            },
                                        new ProviderDto
                                            {
                                                ProviderId = 2,
                                                Name = "Provider2",
                                                Address = "address2",
                                                Phone = "1234567"
                                            },
                                        new ProviderDto
                                            {
                                                ProviderId = 3,
                                                Name = "Provider3",
                                                Address = "address3",
                                                Phone = "1234567"
                                            }
                                    };
            this.goodsCategoryList = new List<GoodsCategoryDto>
                                         {
                                             new GoodsCategoryDto
                                                 {
                                                     GoodsCategoryId = 1,
                                                     Title = "Category1"
                                                 },
                                             new GoodsCategoryDto
                                                 {
                                                     GoodsCategoryId = 2,
                                                     Title = "Category2"
                                                 },
                                             new GoodsCategoryDto
                                                 {
                                                     GoodsCategoryId = 3,
                                                     Title = "Category3"
                                                 }
                                         };
            this.goodsClassList = new List<GoodsClassDto>
                                      {
                                          new GoodsClassDto
                                              {
                                                  GoodsClassId = 1,
                                                  Title = "Class1"
                                              },
                                          new GoodsClassDto
                                              {
                                                  GoodsClassId = 2,
                                                  Title = "Class2"
                                              },
                                          new GoodsClassDto
                                              {
                                                  GoodsClassId = 3,
                                                  Title = "Class3"
                                              }
                                      };
            this.goodsList = new List<GoodsDto>
                                 {
                                     new GoodsDto
                                         {
                                             GoodsCategory = this.goodsCategoryList[0],
                                             GoodsClass = this.goodsClassList[0],
                                             GoodsId = 1,
                                             Price = 1.0m,
                                             Provider = this.providerList[0],
                                             Title = "Goods1"
                                         },
                                     new GoodsDto
                                         {
                                             GoodsCategory = this.goodsCategoryList[1],
                                             GoodsClass = this.goodsClassList[1],
                                             GoodsId = 2,
                                             Price = 2.0m,
                                             Provider = this.providerList[1],
                                             Title = "Goods2"
                                         },
                                     new GoodsDto
                                         {
                                             GoodsCategory = this.goodsCategoryList[2],
                                             GoodsClass = this.goodsClassList[2],
                                             GoodsId = 3,
                                             Price = 3.0m,
                                             Provider = this.providerList[2],
                                             Title = "Goods3"
                                         }
                                 };
        }

        /// <inheritdoc />
        /// <summary>
        /// The system enter.
        /// </summary>
        /// <param name="userLogin">
        /// The user login.
        /// </param>
        /// <returns>
        /// The <see cref="T:System.Boolean" />.
        /// </returns>
        public int SystemEnter(UserLogin userLogin)
        {
            return this.userLoginList.Contains(userLogin) ? -1 : 1;
        }

        /// <inheritdoc />
        /// <summary>
        /// The registration.
        /// </summary>
        /// <param name="userRegistration">
        /// The user registration.
        /// </param>
        public void Registration(UserRegistration userRegistration)
        {
        }

        /// <inheritdoc />
        /// <summary>
        /// The get all warehouse goods.
        /// </summary>
        /// <returns>
        /// The <see cref="T:System.Collections.Generic.IEnumerable`1" />.
        /// </returns>
        public IEnumerable<WarehouseGoods> GetAllWarehouseGoods() => this.warehouseGoodseList;

        /// <inheritdoc />
        /// <summary>
        /// The get all provider.
        /// </summary>
        /// <returns>
        /// The <see cref="T:System.Collections.Generic.IEnumerable`1" />.
        /// </returns>
        public IEnumerable<ProviderDto> GetAllProvider() => this.providerList;

        /// <inheritdoc />
        /// <summary>
        /// The get goods by provider id.
        /// </summary>
        /// <param name="providerId">
        /// The provider id.
        /// </param>
        /// <returns>
        /// The <see cref="T:System.Collections.Generic.IEnumerable`1" />.
        /// </returns>
        public IEnumerable<WarehouseGoods> GetWarehouseGoodsByProviderId(int providerId) => this.warehouseGoodseList
                            .Where(x => x.Provider.ProviderId == providerId);

        /// <inheritdoc />
        /// <summary>
        /// The get all goods class.
        /// </summary>
        /// <returns>
        /// The <see cref="T:System.Collections.Generic.IEnumerable`1" />.
        /// </returns>
        public IEnumerable<GoodsClassDto> GetAllGoodsClass()
        {
            return this.goodsClassList;
        }

        /// <inheritdoc />
        /// <summary>
        /// The get all goods category.
        /// </summary>
        /// <returns>
        /// The <see cref="T:System.Collections.Generic.IEnumerable`1" />.
        /// </returns>
        public IEnumerable<GoodsCategoryDto> GetAllGoodsCategory()
        {
            return this.goodsCategoryList;
        }

        /// <inheritdoc />
        /// <summary>
        /// The get goods by provider id.
        /// </summary>
        /// <param name="providerId">
        /// The provider id.
        /// </param>
        /// <returns>
        /// The <see cref="T:System.Collections.Generic.IEnumerable`1" />.
        /// </returns>
        public IEnumerable<GoodsDto> GetGoodsByProviderId(int providerId)
        {
            return this.goodsList.Where(x => x.Provider.ProviderId == providerId);
        }

        /// <inheritdoc />
        /// <summary>
        /// The get goods by class id.
        /// </summary>
        /// <param name="classId">
        /// The class id.
        /// </param>
        /// <returns>
        /// The <see cref="T:System.Collections.Generic.IEnumerable`1" />.
        /// </returns>
        public IEnumerable<GoodsDto> GetGoodsByClassId(int classId)
        {
            return this.goodsList.Where(x => x.GoodsClass.GoodsClassId == classId);
        }

        /// <inheritdoc />
        /// <summary>
        /// The get goods by category id.
        /// </summary>
        /// <param name="categoryId">
        /// The category id.
        /// </param>
        /// <returns>
        /// The <see cref="T:System.Collections.Generic.IEnumerable`1" />.
        /// </returns>
        public IEnumerable<GoodsDto> GetGoodsByCategoryId(int categoryId)
        {
            return this.goodsList.Where(x => x.GoodsCategory.GoodsCategoryId == categoryId);
        }

        /// <inheritdoc />
        /// <summary>
        /// The add warehouse goods.
        /// </summary>
        /// <param name="warehouseGoods">
        /// The warehouse goods.
        /// </param>
        public void AddWarehouseGoods(IEnumerable<WarehouseGoods> warehouseGoods)
        {
        }

        /// <inheritdoc />
        /// <summary>
        /// The add goods of provider.
        /// </summary>
        /// <param name="goods">
        /// The goods.
        /// </param>
        public void AddGoodsOfProvider(GoodsDto goods)
        {
        }

        /// <inheritdoc />
        /// <summary>
        /// The get all goods.
        /// </summary>
        /// <returns>
        /// The <see cref="T:System.Collections.Generic.IEnumerable`1" />.
        /// </returns>
        public IEnumerable<GoodsDto> GetAllGoods()
        {
            return this.goodsList;
        }

        /// <inheritdoc />
        /// <summary>
        /// The update goods.
        /// </summary>
        /// <param name="goods">
        /// The goods.
        /// </param>
        public void UpdateGoods(GoodsDto goods)
        {
        }

        /// <inheritdoc />
        /// <summary>
        /// The update provider.
        /// </summary>
        /// <param name="provider">
        /// The provider.
        /// </param>
        public void UpdateProvider(ProviderDto provider)
        {
        }

        /// <inheritdoc />
        /// <summary>
        /// The get goods by class and period.
        /// </summary>
        /// <param name="classId">
        /// The class id.
        /// </param>
        /// <param name="startDate">
        /// The start date.
        /// </param>
        /// <param name="endDate">
        /// The end date.
        /// </param>
        /// <returns>
        /// The <see cref="T:System.Collections.Generic.IEnumerable`1" />.
        /// </returns>
        public IEnumerable<WarehouseGoods> GetGoodsByClassAndPeriod(int classId, DateTime startDate, DateTime endDate)
        {
            return this.warehouseGoodseList.Where(
                x => x.GoodsClass.GoodsClassId == classId && x.DateTimeDelivery >= startDate && x.DateTimeDelivery <= endDate);
        }

        /// <inheritdoc />
        /// <summary>
        /// The get report by period and type.
        /// </summary>
        /// <param name="startDate">
        /// The start date.
        /// </param>
        /// <param name="endDate">
        /// The end date.
        /// </param>
        /// <returns>
        /// The <see cref="T:System.Collections.Generic.IEnumerable`1" />.
        /// </returns>
        /// <exception cref="T:System.NotImplementedException">
        /// </exception>
        public IEnumerable<ReportDto> GetReportByPeriodAndType(DateTime startDate, DateTime endDate)
        {
            return new List<ReportDto>
                       {
                           new ReportDto
                               {
                                   AmountReturnedGoods = 1,
                                   AmountSalesGoods = 2,
                                   AmountAccruedGoods = 3,
                                   GoodsClass = new GoodsClassDto(1, "Class1"),
                                   SalesRenuve = 100m,
                                   SumFromSales = 200m
                               },
                           new ReportDto
                               {
                                   AmountReturnedGoods = 2,
                                   AmountSalesGoods = 2,
                                   AmountAccruedGoods = 3,
                                   GoodsClass = new GoodsClassDto(1, "Class1"),
                                   SalesRenuve = 500m,
                                   SumFromSales = 10000m
                               }
                       };
        }

        /// <inheritdoc />
        /// <summary>
        /// The sale.
        /// </summary>
        /// <param name="warehouseGoods">
        /// The warehouse goods.
        /// </param>
        /// <param name="amount">
        /// The amount.
        /// </param>
        public void Sale(WarehouseGoods warehouseGoods, int amount)
        {
        }
    }
}