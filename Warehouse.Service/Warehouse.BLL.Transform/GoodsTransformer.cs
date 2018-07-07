// --------------------------------------------------------------------------------------------------------------------
// <copyright file="GoodsTransformer.cs" company="DNU">
//   DNU
// </copyright>
// <summary>
//   Defines the GoodsTransformer type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Warehouse.BLL.Transform
{
    using AutoMapper;

    using Warehouse.Domain;
    using Warehouse.DTO;

    /// <summary>
    /// The goods transformer.
    /// </summary>
    public static class GoodsTransformer
    {
        /// <summary>
        /// The from goods dto to goods.
        /// </summary>
        /// <param name="goodsDto">
        /// The goods dto.
        /// </param>
        /// <returns>
        /// The <see cref="Goods"/>.
        /// </returns>
        public static Goods FromGoodsDtoToGoods(GoodsDto goodsDto)
        {
            Mapper.Reset();
            Mapper.Initialize(cfg => cfg.CreateMap<GoodsDto, Goods>()
                .ForMember("ProviderId", map => map.MapFrom(g => g.Provider.ProviderId))
                .ForMember("GoodsCategoryId", map => map.MapFrom(g => g.GoodsCategory.GoodsCategoryId))
                .ForMember("GoodsClassId", map => map.MapFrom(g => g.GoodsClass.GoodsClassId)));
            return Mapper.Map<GoodsDto, Goods>(goodsDto);
        }

        /// <summary>
        /// The from goods to goods dto.
        /// </summary>
        /// <param name="goods">
        /// The goods.
        /// </param>
        /// <param name="provider">
        /// The provider.
        /// </param>
        /// <param name="goodsCategory">
        /// The goods category.
        /// </param>
        /// <param name="goodsClass">
        /// The goods class.
        /// </param>
        /// <returns>
        /// The <see cref="GoodsDto"/>.
        /// </returns>
        public static GoodsDto FromGoodsToGoodsDto(
            Goods goods,
            ProviderDto provider,
            GoodsCategoryDto goodsCategory,
            GoodsClassDto goodsClass)
        {
            Mapper.Reset();
            Mapper.Initialize(cfg => cfg.CreateMap<Goods, GoodsDto>()
                .ForMember("Provider", map => map.UseValue(provider))
                .ForMember("GoodsCategory", map => map.UseValue(goodsCategory))
                .ForMember("GoodsClass", map => map.UseValue(goodsClass)));
            return Mapper.Map<Goods, GoodsDto>(goods);
        }
    }
}