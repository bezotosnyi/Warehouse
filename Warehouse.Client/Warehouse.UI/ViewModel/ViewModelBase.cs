// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ViewModelBase.cs" company="DNU">
//   DNU
// </copyright>
// <summary>
//   Defines the ViewModelBase type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Warehouse.UI.ViewModel
{
    using System.Windows;

    /// <inheritdoc cref="DependencyObject" />
    /// <summary>
    /// The view model base.
    /// </summary>
    public abstract class ViewModelBase : DependencyObject
    {
        /// <summary>
        /// The close.
        /// </summary>
        /// <param name="modelName">
        /// The model name.
        /// </param>
        protected void Close(string modelName)
        {
            var model = modelName.Replace("Window", string.Empty);
            foreach (Window window in Application.Current.Windows)
            {
                if (window.Name == model)
                {
                    window.Close();
                }
            }
        }
    }
}