// --------------------------------------------------------------------------------------------------------------------
// <copyright file="SqlServerRepositoryBase.cs" company="DNU">
//   DNU
// </copyright>
// <summary>
//   Defines the RepositoryBase type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Warehouse.DAL.SqlServer
{
    using System.Configuration;
    using System.Data.SqlClient;

    using Warehouse.DAL.Common;

    /// <summary>
    /// The repository base.
    /// </summary>
    public abstract class SqlServerRepositoryBase
    {
        /// <summary>
        /// The db dal manager.
        /// </summary>
        protected readonly CommonDalManager dalManager;

        /// <summary>
        /// Initializes a new instance of the <see cref="SqlServerRepositoryBase"/> class. 
        /// </summary>
        protected SqlServerRepositoryBase()
        {
            this.dalManager = new CommonDalManager(new SqlConnection(ConfigurationManager.ConnectionStrings["dbConnectionString"].ConnectionString));
        }
    }
}