// --------------------------------------------------------------------------------------------------------------------
// <copyright file="GoodsCategoryDto.cs" company="DNU">
//   DNU
// </copyright>
// <summary>
//   Defines the GoodsCategoryDto type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Warehouse.DTO
{
    /// <summary>
    /// The goods category dto.
    /// </summary>
    [System.Serializable]
    public class GoodsCategoryDto
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="GoodsCategoryDto"/> class.
        /// </summary>
        public GoodsCategoryDto()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="GoodsCategoryDto"/> class.
        /// </summary>
        /// <param name="goodsCategoryId">
        /// The goods category id.
        /// </param>
        /// <param name="title">
        /// The title.
        /// </param>
        public GoodsCategoryDto(int goodsCategoryId, string title)
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