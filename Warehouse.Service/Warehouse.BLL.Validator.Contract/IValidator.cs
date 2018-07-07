// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IValidator.cs" company="DNU">
//   DNU
// </copyright>
// <summary>
//   Defines the IValidator type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Warehouse.BLL.Validator.Contract
{
    using Warehouse.BLL.Validator.Common;

    /// <summary>
    /// The Validator interface.
    /// </summary>
    /// <typeparam name="TModel">
    /// DTO class
    /// </typeparam>
    public interface IValidator<in TModel> where TModel : class
    {
            /// <summary>
            /// The validate.
            /// </summary>
            /// <param name="model">
            /// The model.
            /// </param>
            /// <returns>
            /// The <see cref="ValidationStatusInfo"/>.
            /// </returns>
            ValidationStatusInfo Validate(TModel model);
    }
}