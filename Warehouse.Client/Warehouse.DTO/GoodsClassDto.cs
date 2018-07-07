// --------------------------------------------------------------------------------------------------------------------
// <copyright file="GoodsClassDto.cs" company="DNU">
//   DNU
// </copyright>
// <summary>
//   Defines the GoodsClassDto type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Warehouse.DTO
{
    /// <summary>
    /// The goods class dto.
    /// </summary>
    public class GoodsClassDto
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="GoodsClassDto"/> class.
        /// </summary>
        public GoodsClassDto()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="GoodsClassDto"/> class.
        /// </summary>
        /// <param name="goodsClassId">
        /// The goods class id.
        /// </param>
        /// <param name="title">
        /// The title.
        /// </param>
        public GoodsClassDto(int goodsClassId, string title)
        {
            this.GoodsClassId = goodsClassId;
            this.Title = title;
        }

        /// <summary>
        /// Gets or sets the goods category id.
        /// </summary>
        public int GoodsClassId { get; set; }

        /// <summary>
        /// Gets or sets the title.
        /// </summary>
        public string Title { get; set; }

    }
}