// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ServiceConnectionTest.cs" company="DNU">
//   DNU
// </copyright>
// <summary>
//   Defines the ServiceConnectionTest type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Warehouse.Client.Test
{
    using System;
    using System.Configuration;

    using Microsoft.AspNet.SignalR.Client;

    using NUnit.Framework;

    using Warehouse.DTO;
    using Warehouse.Service.Common;

    /// <summary>
    /// The service connection test.
    /// </summary>
    [TestFixture]
    public class ServiceConnectionTest
    {
        /// <summary>
        /// The service url.
        /// </summary>
        private string serviceUrl;

        /// <summary>
        /// The hub name.
        /// </summary>
        private string hubName;

        /// <summary>
        /// The hub connection.
        /// </summary>
        private HubConnection hubConnection;

        /// <summary>
        /// The hub proxy.
        /// </summary>
        private IHubProxy hubProxy;

        /// <summary>
        /// The system enter.
        /// </summary>
        [Test]
        public void SystemEnter()
        {
            var result = this.hubProxy.Invoke<OperationStatusInfo>("SystemEnter", new UserLogin("administrator", "admin123^&"));
            result.Wait();
            Console.WriteLine((int)result.Result.AttachedObject);
            // Assert.AreEqual("Hello, Dima", result.Result);
        }

        /// <summary>
        /// The strart connection async.
        /// </summary>
        [SetUp]
        public void StrartConnectionAsync()
        {
            this.serviceUrl = ConfigurationManager.AppSettings["ServiceUrl"];
            this.hubName = ConfigurationManager.AppSettings["HubName"];
            this.hubConnection = new HubConnection(this.serviceUrl);
            this.hubProxy = this.hubConnection.CreateHubProxy(this.hubName);
            this.hubConnection.Start().Wait();
        }

        /// <summary>
        /// The stop connection.
        /// </summary>
        [TearDown]
        public void StopConnection()
        {
            if (this.hubConnection.State == ConnectionState.Connected)
                this.hubConnection.Stop();
        }
    }
}