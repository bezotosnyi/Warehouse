// --------------------------------------------------------------------------------------------------------------------
// <copyright file="UserRepository.cs" company="DNU">
//   DNU
// </copyright>
// <summary>
//   Defines the UserRepository type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Warehouse.DAL.SqlServer
{
    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.Data.Common;
    using System.Data.SqlClient;
    using System.Linq;

    using Warehouse.DAL.Contract;
    using Warehouse.Domain;

    /// <inheritdoc />
    /// <summary>
    /// The user repository.
    /// </summary>
    public class UserRepository : SqlServerRepositoryBase, IRepository<User>
    {
        /// <inheritdoc />
        /// <summary>
        /// The insert.
        /// </summary>
        /// <param name="item">
        /// The item.
        /// </param>
        /// <returns>
        /// The <see cref="T:System.Int32" />.
        /// </returns>
        public int Insert(User item)
        {
            var sqlParameters = new DbParameter[4];
            sqlParameters[0] = new SqlParameter("@Name", SqlDbType.VarChar) { Value = item.Name };
            sqlParameters[1] = new SqlParameter("@LastName", SqlDbType.VarChar) { Value = item.LastName };
            sqlParameters[2] = new SqlParameter("@Login", SqlDbType.VarChar) { Value = item.Login };
            sqlParameters[3] = new SqlParameter("@Password", SqlDbType.VarChar) { Value = item.Password };

            var id = this.dalManager.InsertProcedureWithOutputInsertedId(new SqlCommand("CreateUser"), sqlParameters);

            return id;
        }

        /// <inheritdoc />
        /// <summary>
        /// The insert by id.
        /// </summary>
        /// <param name="item">
        /// The item.
        /// </param>
        /// <exception cref="T:System.NotImplementedException">
        /// </exception>
        public void InsertById(User item)
        {
            throw new System.NotImplementedException();
        }

        /// <inheritdoc />
        /// <summary>
        /// The update.
        /// </summary>
        /// <param name="item">
        /// The item.
        /// </param>
        /// <exception cref="T:System.NotImplementedException">
        /// </exception>
        public void Update(User item)
        {
            throw new System.NotImplementedException();
        }

        /// <inheritdoc />
        /// <summary>
        /// The delete.
        /// </summary>
        /// <param name="id">
        /// The id.
        /// </param>
        /// <exception cref="T:System.NotImplementedException">
        /// </exception>
        public void Delete(int id)
        {
            throw new System.NotImplementedException();
        }

        /// <inheritdoc />
        /// <summary>
        /// The select by id.
        /// </summary>
        /// <param name="id">
        /// The id.
        /// </param>
        /// <returns>
        /// The <see cref="T:Warehouse.Domain.User" />.
        /// </returns>
        /// <exception cref="T:System.NotImplementedException">
        /// </exception>
        public User SelectById(int id)
        {
            throw new System.NotImplementedException();
        }

        /// <inheritdoc />
        /// <summary>
        /// The select all.
        /// </summary>
        /// <returns>
        /// The <see cref="T:System.Collections.Generic.IEnumerable`1" />.
        /// </returns>
        public IEnumerable<User> SelectAll()
        {
            var users = new List<User>();
            var command = new SqlCommand("GetAllUser");
            var dataTable = this.dalManager.SelectAllProcedure(command, new SqlDataAdapter(command));

            if (dataTable.Rows.Count > 0)
            {
                users.AddRange(
                    from DataRow dataRow in dataTable.Rows
                    select new User
                               {
                                   UserId = int.Parse(dataRow["UserId"].ToString()),
                                   Name = dataRow["Name"].ToString(),
                                   LastName = dataRow["LastName"].ToString(),
                                   Login = dataRow["Login"].ToString(),
                                   Password = dataRow["Password"].ToString()
                    });
            }
            else
            {
                return null;
            }

            return users;
        }
    }
}