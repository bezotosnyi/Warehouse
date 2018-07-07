// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ReportDto.cs" company="DNU">
//   DNU
// </copyright>
// <summary>
//   Defines the ReportDto type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Warehouse.DTO
{
    using System;

    /// <summary>
    /// The report dto.
    /// </summary>
    [Serializable]
    public class ReportDto
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ReportDto"/> class.
        /// </summary>
        public ReportDto()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ReportDto"/> class.
        /// </summary>
        /// <param name="goodsClass">
        /// The goods class.
        /// </param>
        /// <param name="amountAccruedGoods">
        /// The amount accrued goods.
        /// </param>
        /// <param name="amountSalesGoods">
        /// The amount sales goods.
        /// </param>
        /// <param name="amountReturnedGoods">
        /// The amount returned goods.
        /// </param>
        /// <param name="sumFromSales">
        /// The sum from sales.
        /// </param>
        /// <param name="salesRenuve">
        /// The sales renuve.
        /// </param>
        public ReportDto(GoodsClassDto goodsClass, int amountAccruedGoods, int amountSalesGoods, int amountReturnedGoods, decimal sumFromSales, decimal salesRenuve)
        {
            this.GoodsClass = goodsClass;
            this.AmountAccruedGoods = amountAccruedGoods;
            this.AmountSalesGoods = amountSalesGoods;
            this.AmountReturnedGoods = amountReturnedGoods;
            this.SumFromSales = sumFromSales;
            this.SalesRenuve = salesRenuve;
        }

        /// <summary>
        /// Gets or sets the goods class.
        /// </summary>
        public GoodsClassDto GoodsClass { get; set; }

        /// <summary>
        /// Gets or sets the amount accrued goods.
        /// </summary>
        public int AmountAccruedGoods { get; set; }

        /// <summary>
        /// Gets or sets the amount sales goods.
        /// </summary>
        public int AmountSalesGoods { get; set; }

        /// <summary>
        /// Gets or sets the amount returned goods.
        /// </summary>
        public int AmountReturnedGoods { get; set; }

        /// <summary>
        /// Gets or sets the sum from sales.
        /// </summary>
        public decimal SumFromSales { get; set; }

        /// <summary>
        /// Gets or sets the sales renuve.
        /// </summary>
        public decimal SalesRenuve { get; set; }
    }
}