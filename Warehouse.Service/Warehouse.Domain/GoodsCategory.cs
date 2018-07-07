// --------------------------------------------------------------------------------------------------------------------
// <copyright file="GoodsCategory.cs" company="DNU">
//   DNU
// </copyright>
// <summary>
//   Defines the GoodsCategory type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Warehouse.Domain
{
    /// <summary>
    /// The goods category.
    /// </summary>
    public class GoodsCategory
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="GoodsCategory"/> class.
        /// </summary>
        public GoodsCategory()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="GoodsCategory"/> class.
        /// </summary>
        /// <param name="goodsCategoryId">
        /// The goods category id.
        /// </param>
        /// <param name="title">
        /// The title.
        /// </param>
        public GoodsCategory(int goodsCategoryId, string title)
        {
            this.GoodsCategoryId = goodsCategoryId;
            this.Title = title;
        }

        /// <summary>
        /// Gets or sets the goods category id.
        /// </summary>
        public int GoodsCategoryId { get; set; }

        /// <summary>
        /// Gets or sets the title.
        /// </summary>
        public string Title { get; set; }
    }
}