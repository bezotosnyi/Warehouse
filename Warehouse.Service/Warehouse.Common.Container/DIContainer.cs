// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Container.cs" company="DNU">
//   DNU
// </copyright>
// <summary>
//   The container.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Warehouse.Common.Container
{
    using System.Configuration;

    using Microsoft.Practices.Unity.Configuration;

    using Unity;

    /// <summary>
    /// The container.
    /// </summary>
    public static class DIContainer
    {
        /// <summary>
        /// The unity container.
        /// </summary>
        private static readonly UnityContainer UContainer;

        /// <summary>
        /// Initializes static members of the <see cref="DIContainer"/> class.
        /// </summary>
        static DIContainer()
        {
            UContainer = new UnityContainer();
            var configurationSection = (UnityConfigurationSection)ConfigurationManager.GetSection("unity");
            configurationSection.Configure(UContainer);
        }

        /// <summary>
        /// The resolve.
        /// </summary>
        /// <typeparam name="T">
        /// T - resolution type
        /// </typeparam>
        /// <returns>
        /// The <see cref="T"/>.
        /// </returns>
        public static T Resolve<T>() where T : class
        {
            return UContainer.Resolve<T>();
        }

        /// <summary>
        /// The resolve.
        /// </summary>
        /// <param name="name">
        /// The name.
        /// </param>
        /// <typeparam name="T">
        /// T - resolution type
        /// </typeparam>
        /// <returns>
        /// The <see cref="T"/>.
        /// </returns>
        public static T Resolve<T>(string name) where T : class
        {
            return UContainer.Resolve<T>(name);
        }
    }
}