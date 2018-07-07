// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Program.cs" company="DNU">
//   DNU
// </copyright>
// <summary>
//   Defines the Program type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Warehouse.Service.Front.Console
{
    using System;

    using Warehouse.Common.Logger;

    /// <summary>
    /// The program.
    /// </summary>
    public class Program
    {
        /// <summary>
        /// The main.
        /// </summary>
        /// <param name="args">
        /// The args.
        /// </param>
        public static void Main(string[] args)
        {
            try
            {
                Startup.StartServer();
            }
            catch (Exception ex)
            {
                Logger.Log("Server exception", ex, LogMessageLevel.Error);
            }
            finally
            {
                Startup.StopServer();
                Console.ReadKey();
            }
        }
    }
}
