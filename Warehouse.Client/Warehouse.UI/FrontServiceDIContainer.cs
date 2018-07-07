// --------------------------------------------------------------------------------------------------------------------
// <copyright file="FrontServiceDIContainer.cs" company="DNU">
//   DNU
// </copyright>
// <summary>
//   Defines the FrontServiceUnityFactory type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Warehouse.UI
{
    using System.Configuration;

    using Microsoft.Practices.Unity.Configuration;

    using Unity;

    /// <summary>
    /// The front service unity factory.
    /// </summary>
    public static class FrontServiceDIContainer
    {
        /// <summary>
        /// The unity container.
        /// </summary>
        private static readonly UnityContainer Container;

        /// <summary>
        /// Initializes static members of the <see cref="FrontServiceDIContainer"/> class.
        /// </summary>
        static FrontServiceDIContainer()
        {
            Container = new UnityContainer();
            var configurationSection = (UnityConfigurationSection)ConfigurationManager.GetSection("unity");
            configurationSection.Configure(Container);
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
            return Container.Resolve<T>();
        }
    }
}