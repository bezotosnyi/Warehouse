// --------------------------------------------------------------------------------------------------------------------
// <copyright file="GoodsClass.cs" company="DNU">
//   DNU
// </copyright>
// <summary>
//   Defines the GoodsClass type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Warehouse.Domain
{
    /// <summary>
    /// The goods class.
    /// </summary>
    public class GoodsClass
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="GoodsClass"/> class.
        /// </summary>
        public GoodsClass()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="GoodsClass"/> class.
        /// </summary>
        /// <param name="goodsClassId">
        /// The goods class id.
        /// </param>
        /// <param name="title">
        /// The title.
        /// </param>
        public GoodsClass(int goodsClassId, string title)
        {
            this.GoodsClassId = goodsClassId;
            this.Title = title;
        }

        /// <summary>
        /// Gets or sets the goods class id.
        /// </summary>
        public int GoodsClassId { get; set; }

        /// <summary>
        /// Gets or sets the title.
        /// </summary>
        public string Title { get; set; }
    }
}