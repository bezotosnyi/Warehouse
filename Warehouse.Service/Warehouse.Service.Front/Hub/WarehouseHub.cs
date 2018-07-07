// --------------------------------------------------------------------------------------------------------------------
// <copyright file="WarehouseHub.cs" company="DNU">
//   DNU
// </copyright>
// <summary>
//   Defines the MainHub type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Warehouse.Service.Front.Hub
{
    using System;
    using System.Threading.Tasks;

    using Microsoft.AspNet.SignalR;
    using Microsoft.AspNet.SignalR.Hubs;

    using Warehouse.Common.Container;
    using Warehouse.Common.Logger;
    using Warehouse.DTO;
    using Warehouse.Service.Common;
    using Warehouse.Service.Contract;

    /// <inheritdoc cref="Hub"/>
    /// <summary>
    /// The remote notepad hub.
    /// </summary>
    [HubName("WarehouseHub")]
    public class WarehouseHub : Hub
    {
        /// <summary>
        /// The system enter.
        /// </summary>
        /// <param name="userLogin">
        /// The user login.
        /// </param>
        /// <returns>
        /// The <see cref="T:System.Threading.Tasks.Task" />.
        /// </returns>
        public async Task<OperationStatusInfo> SystemEnter(UserLogin userLogin)
        {
            var serviceController = DIContainer.Resolve<IController>();
            return await Task.Run(() => serviceController.SystemEnter(userLogin));
        }

        /// <summary>
        /// The hello.
        /// </summary>
        /// <param name="name">
        /// The name.
        /// </param>
        /// <returns>
        /// The <see cref="Task"/>.
        /// </returns>
        public async Task<string> Hello(string name)
        {
            return await Task.Run(() => name);
        }

        #region Override Method

        /// <inheritdoc />
        /// <summary>
        /// The on connected.
        /// </summary>
        /// <returns>
        /// The <see cref="T:System.Threading.Tasks.Task" />.
        /// </returns>
        public override Task OnConnected()
        {
            Logger.Log("Client connected: " + this.Context.ConnectionId, LogMessageLevel.Info);
            return base.OnConnected();
        }

        /// <inheritdoc />
        /// <summary>
        /// The on disconnected.
        /// </summary>
        /// <param name="isDisconnected">
        /// The is disconnected.
        /// </param>
        /// <returns>
        /// The <see cref="T:System.Threading.Tasks.Task" />.
        /// </returns>
        public override Task OnDisconnected(bool isDisconnected)
        {
            Logger.Log("Client disconnected: " + this.Context.ConnectionId, LogMessageLevel.Info);
            return base.OnDisconnected(true);
        }

        #endregion
    }
}