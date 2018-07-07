// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ServiceController.cs" company="DNU">
//   DNU
// </copyright>
// <summary>
//   Defines the ServiceController type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Warehouse.Service
{
    using System;

    using Warehouse.BLL.Contract;
    using Warehouse.Common.Container;
    using Warehouse.Common.Logger;
    using Warehouse.DTO;
    using Warehouse.Service.Common;
    using Warehouse.Service.Contract;

    /// <inheritdoc />
    /// <summary>
    /// The service controller.
    /// </summary>
    public class ServiceController : IController
    {
        /// <summary>
        /// The manager.
        /// </summary>
        private readonly IManager manager;

        /// <summary>
        /// Initializes a new instance of the <see cref="ServiceController"/> class.
        /// </summary>
        public ServiceController()
        {
            this.manager = DIContainer.Resolve<IManager>();
        }

        /// <inheritdoc />
        /// <summary>
        /// The system enter.
        /// </summary>
        /// <param name="userLogin">
        /// The user login.
        /// </param>
        /// <returns>
        /// The <see cref="T:Warehouse.Service.Common.OperationStatusInfo" />.
        /// </returns>
        public OperationStatusInfo SystemEnter(UserLogin userLogin)
        {
            try
            {
                var result = this.manager.SystemEnter(userLogin);
                Logger.Log("Success enter system", LogMessageLevel.Info);
                return new OperationStatusInfo(OperationStatus.Success, "Success enter system", result);
            }
            catch (Exception e)
            {
                Logger.Log(e.StackTrace, LogMessageLevel.Error);
                return new OperationStatusInfo(OperationStatus.Fail, e.Message, -1);
            }
        }

        /// <inheritdoc />
        /// <summary>
        /// The registration.
        /// </summary>
        /// <param name="userRegistration">
        /// The user registration.
        /// </param>
        /// <returns>
        /// The <see cref="T:Warehouse.Service.Common.OperationStatusInfo" />.
        /// </returns>
        public OperationStatusInfo Registration(UserRegistration userRegistration)
        {
            try
            {
                this.manager.Registration(userRegistration);
                Logger.Log("Success registration", LogMessageLevel.Info);
                return new OperationStatusInfo(OperationStatus.Success, "Success registration", null);
            }
            catch (Exception e)
            {
                Logger.Log(e.StackTrace, LogMessageLevel.Error);
                return new OperationStatusInfo(OperationStatus.Fail, e.Message, null);
            }
        }

        /// <inheritdoc />
        /// <summary>
        /// The get all warehouse goods.
        /// </summary>
        /// <returns>
        /// The <see cref="T:Warehouse.Service.Common.OperationStatusInfo" />.
        /// </returns>
        public OperationStatusInfo GetAllWarehouseGoods()
        {
            try
            {
                var result = this.manager.GetAllWarehouseGoods();
                Logger.Log("Success get all warehouse goods", LogMessageLevel.Info);
                return new OperationStatusInfo(OperationStatus.Success, "Success get all warehouse goods", result);
            }
            catch (Exception e)
            {
                Logger.Log(e.StackTrace, LogMessageLevel.Error);
                return new OperationStatusInfo(OperationStatus.Fail, e.Message, false);
            }
        }
    }
}