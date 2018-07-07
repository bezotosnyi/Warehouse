// --------------------------------------------------------------------------------------------------------------------
// <copyright file="UserLogin.cs" company="DNU">
//   DNU
// </copyright>
// <summary>
//   Defines the UserLogin type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Warehouse.DTO
{
    /// <summary>
    /// The user login.
    /// </summary>
    [System.Serializable]
    public class UserLogin
    {

        /// <summary>
        /// Initializes a new instance of the <see cref="UserLogin"/> class.
        /// </summary>
        public UserLogin()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="UserLogin"/> class.
        /// </summary>
        /// <param name="login">
        /// The login.
        /// </param>
        /// <param name="password">
        /// The password.
        /// </param>
        public UserLogin(string login, string password)
        {
            this.Login = login;
            this.Password = password;
        }


        /// <summary>
        /// Gets or sets the login.
        /// </summary>
        public string Login { get; set; }

        /// <summary>
        /// Gets or sets the password.
        /// </summary>
        public string Password { get; set; }
    }
}