// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IManager.cs" company="DNU">
//   DNU
// </copyright>
// <summary>
//   Defines the IManager type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Warehouse.BLL.Contract
{
    using System;
    using System.Collections.Generic;

    using Warehouse.DTO;

    /// <summary>
    /// The Manager interface.
    /// </summary>
    public interface IManager
    {
        /// <summary>
        /// The system enter.
        /// </summary>
        /// <param name="userLogin">
        /// The user login.
        /// </param>
        /// <returns>
        /// The <see cref="int"/>.
        /// </returns>
        int SystemEnter(UserLogin userLogin);

        /// <summary>
        /// The registration.
        /// </summary>
        /// <param name="userRegistration">
        /// The user registration.
        /// </param>
        void Registration(UserRegistration userRegistration);

        /// <summary>
        /// The get all warehouse goods.
        /// </summary>
        /// <returns>
        /// The <see cref="IEnumerable{WarehouseGoods}"/>.
        /// </returns>
        IEnumerable<WarehouseGoods> GetAllWarehouseGoods();

        /// <summary>
        /// The get all provider.
        /// </summary>
        /// <returns>
        /// The <see cref="IEnumerable{ProviderDto}"/>.
        /// </returns>
        IEnumerable<ProviderDto> GetAllProvider();

        /// <summary>
        /// The get goods by provider id.
        /// </summary>
        /// <param name="providerId">
        /// The provider id.
        /// </param>
        /// <returns>
        /// The <see cref="IEnumerable{WarehouseGoods}"/>.
        /// </returns>
        IEnumerable<WarehouseGoods> GetWarehouseGoodsByProviderId(int providerId);

        /// <summary>
        /// The get all goods class.
        /// </summary>
        /// <returns>
        /// The <see cref="IEnumerable{GoodsClassDto}"/>.
        /// </returns>
        IEnumerable<GoodsClassDto> GetAllGoodsClass();

        /// <summary>
        /// The get all goods category.
        /// </summary>
        /// <returns>
        /// The <see cref="IEnumerable{GoodsCategoryDto}"/>.
        /// </returns>
        IEnumerable<GoodsCategoryDto> GetAllGoodsCategory();

        /// <summary>
        /// The get goods by provider id.
        /// </summary>
        /// <param name="providerId">
        /// The provider id.
        /// </param>
        /// <returns>
        /// The <see cref="IEnumerable{GoodsDto}"/>.
        /// </returns>
        IEnumerable<GoodsDto> GetGoodsByProviderId(int providerId);

        /// <summary>
        /// The get goods by class id.
        /// </summary>
        /// <param name="classId">
        /// The class id.
        /// </param>
        /// <returns>
        /// The <see cref="IEnumerable{GoodsDto}"/>.
        /// </returns>
        IEnumerable<GoodsDto> GetGoodsByClassId(int classId);

        /// <summary>
        /// The get goods by category id.
        /// </summary>
        /// <param name="categoryId">
        /// The category id.
        /// </param>
        /// <returns>
        /// The <see cref="IEnumerable{GoodsDto}"/>.
        /// </returns>
        IEnumerable<GoodsDto> GetGoodsByCategoryId(int categoryId);

        /// <summary>
        /// The add warehouse goods.
        /// </summary>
        /// <param name="warehouseGoods">
        /// The warehouse goods.
        /// </param>
        void AddWarehouseGoods(IEnumerable<WarehouseGoods> warehouseGoods);

        /// <summary>
        /// The add goods of provider.
        /// </summary>
        /// <param name="goods">
        /// The goods.
        /// </param>
        void AddGoodsOfProvider(GoodsDto goods);

        /// <summary>
        /// The get all goods.
        /// </summary>
        /// <returns>
        /// The <see cref="IEnumerable{GoodsDto}"/>.
        /// </returns>
        IEnumerable<GoodsDto> GetAllGoods();

        /// <summary>
        /// The update goods.
        /// </summary>
        /// <param name="goods">
        /// The goods.
        /// </param>
        void UpdateGoods(GoodsDto goods);

        /// <summary>
        /// The update provider.
        /// </summary>
        /// <param name="provider">
        /// The provider.
        /// </param>
        void UpdateProvider(ProviderDto provider);

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
        /// The <see cref="IEnumerable{WarehouseGoods}"/>.
        /// </returns>
        IEnumerable<WarehouseGoods> GetGoodsByClassAndPeriod(int classId, DateTime startDate, DateTime endDate);

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
        /// The <see cref="ReportDto"/>.
        /// </returns>
        IEnumerable<ReportDto> GetReportByPeriodAndType(DateTime startDate, DateTime endDate);

        /// <summary>
        /// The sale.
        /// </summary>
        /// <param name="warehouseGoods">
        /// The warehouse goods.
        /// </param>
        /// <param name="amount">
        /// The amount.
        /// </param>
        void Sale(WarehouseGoods warehouseGoods, int amount);
    }
}