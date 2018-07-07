// --------------------------------------------------------------------------------------------------------------------
// <copyright file="UserRegistration.cs" company="DNU">
//   DNU
// </copyright>
// <summary>
//   Defines the UserRegister type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Warehouse.DTO
{
    /// <summary>
    /// The user register.
    /// </summary>
    [System.Serializable]
    public class UserRegistration
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="UserRegistration"/> class.
        /// </summary>
        public UserRegistration()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="UserRegistration"/> class.
        /// </summary>
        /// <param name="name">
        /// The name.
        /// </param>
        /// <param name="lastName">
        /// The last name.
        /// </param>
        /// <param name="login">
        /// The login.
        /// </param>
        /// <param name="password">
        /// The password.
        /// </param>
        public UserRegistration(string name, string lastName, string login, string password)
        {
            this.Name = name;
            this.LastName = lastName;
            this.Login = login;
            this.Password = password;
        }

        #region Properties

        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the last name.
        /// </summary>
        public string LastName { get; set; }

        /// <summary>
        /// Gets or sets the login.
        /// </summary>
        public string Login { get; set; }

        /// <summary>
        /// Gets or sets the password.
        /// </summary>
        public string Password { get; set; }

        #endregion
    }
}