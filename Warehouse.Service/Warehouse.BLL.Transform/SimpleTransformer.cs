// --------------------------------------------------------------------------------------------------------------------
// <copyright file="SimpleTransformer.cs" company="DNU">
//   DNU
// </copyright>
// <summary>
//   Defines the Transformer type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Warehouse.BLL.Transform
{
    using AutoMapper;

    /// <summary>
    /// The transformer.
    /// </summary>
    public static class SimpleTransformer
    {
        /// <summary>
        /// The transform.
        /// </summary>
        /// <param name="source">
        /// The source.
        /// </param>
        /// <typeparam name="TSource">
        /// TSource - source type
        /// </typeparam>
        /// <typeparam name="TResult">
        /// TResult - result
        /// </typeparam>
        /// <returns>
        /// The <see cref="TResult"/>.
        /// </returns>
        public static TResult Transform<TSource, TResult>(TSource source) where TSource : new() where TResult : new()
        {
            Mapper.Reset();
            Mapper.Initialize(cfg => cfg.CreateMap<TSource, TResult>());
            return Mapper.Map<TSource, TResult>(source);
        }
    }
}