// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IController.cs" company="DNU">
//   DNU
// </copyright>
// <summary>
//   Defines the IController type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Warehouse.Service.Contract
{
    using Warehouse.DTO;
    using Warehouse.Service.Common;

    /// <summary>
    /// The Controller interface.
    /// </summary>
    public interface IController
    {
        /// <summary>
        /// The system enter.
        /// </summary>
        /// <param name="userLogin">
        /// The user login.
        /// </param>
        /// <returns>
        /// The <see cref="OperationStatusInfo"/>.
        /// </returns>
        OperationStatusInfo SystemEnter(UserLogin userLogin);

        /// <summary>
        /// The registration.
        /// </summary>
        /// <param name="userRegistration">
        /// The user registration.
        /// </param>
        /// <returns>
        /// The <see cref="OperationStatusInfo"/>.
        /// </returns>
        OperationStatusInfo Registration(UserRegistration userRegistration);

        /// <summary>
        /// The get all warehouse goods.
        /// </summary>
        /// <returns>
        /// The <see cref="OperationStatusInfo"/>.
        /// </returns>
        OperationStatusInfo GetAllWarehouseGoods();
    }
}