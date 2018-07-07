// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Extension.cs" company="DNU">
//   DNU
// </copyright>
// <summary>
//   Defines the Extension type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Warehouse.UI.Extension
{
    using System.Collections.Generic;
    using System.Collections.ObjectModel;

    using Warehouse.DTO;

    /// <summary>
    /// The extension.
    /// </summary>
    public static class Extension
    {
        /// <summary>
        /// The to observable collection.
        /// </summary>
        /// <param name="collection">
        /// The collection.
        /// </param>
        /// <typeparam name="T">
        /// T - any class
        /// </typeparam>
        /// <returns>
        /// The <see cref="ObservableCollection{T}"/>.
        /// </returns>
        public static ObservableCollection<T> ToObservableCollection<T>(this IEnumerable<T> collection)
        {
            return new ObservableCollection<T>(collection);
        }
    }
}