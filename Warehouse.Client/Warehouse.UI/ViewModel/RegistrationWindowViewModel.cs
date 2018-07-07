// --------------------------------------------------------------------------------------------------------------------
// <copyright file="RegistrationWindowViewModel.cs" company="DNU">
//   DNU
// </copyright>
// <summary>
//   Defines the RegistrationViewModel type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Warehouse.UI.ViewModel
{
    using System.Configuration;
    using System.Windows;
    using System.Windows.Input;

    using Microsoft.Practices.Unity.Configuration;

    using Unity;

    using Warehouse.DTO;
    using Warehouse.Front.Service.Client.Contract;
    using Warehouse.UI.Helper;
    using Warehouse.UI.View;

    /// <inheritdoc />
    /// <summary>
    /// The registration view model.
    /// </summary>
    public class RegistrationWindowViewModel : ViewModelBase
    {
        #region Create DependencyProperty section

        /// <summary>
        /// The name property.
        /// </summary>
        public static readonly DependencyProperty NameProperty = DependencyProperty.Register(
            "Name",
            typeof(string),
            typeof(RegistrationWindowViewModel),
            new PropertyMetadata(default(string)));

        /// <summary>
        /// The last name property.
        /// </summary>
        public static readonly DependencyProperty LastNameProperty = DependencyProperty.Register(
            "LastName",
            typeof(string),
            typeof(RegistrationWindowViewModel),
            new PropertyMetadata(default(string)));

        /// <summary>
        /// The login property.
        /// </summary>
        public static readonly DependencyProperty LoginProperty = DependencyProperty.Register(
            "Login",
            typeof(string),
            typeof(RegistrationWindowViewModel),
            new PropertyMetadata(default(string)));

        /// <summary>
        /// The password property.
        /// </summary>
        public static readonly DependencyProperty PasswordProperty = DependencyProperty.Register(
            "Password",
            typeof(string),
            typeof(RegistrationWindowViewModel),
            new PropertyMetadata(default(string)));

        #endregion

        /// <summary>
        /// The front service client.
        /// </summary>
        private readonly IFrontServiceClient frontServiceClient;

        /// <summary>
        /// Initializes a new instance of the <see cref="RegistrationWindowViewModel"/> class.
        /// </summary>
        public RegistrationWindowViewModel()
        {
            this.RegistrateCommand = new RelayCommand(cmd => this.Registrate(), cmd => this.CanRegistrate());
            this.CancleCommand = new RelayCommand(cmd => this.Cancle());

            this.frontServiceClient = FrontServiceDIContainer.Resolve<IFrontServiceClient>();
        }

        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        public string Name
        {
            get
            {
                return (string)this.GetValue(NameProperty);
            }

            set
            {
                this.SetValue(NameProperty, value);
            }
        }

        /// <summary>
        /// Gets or sets the last name.
        /// </summary>
        public string LastName
        {
            get
            {
                return (string)this.GetValue(LastNameProperty);
            }

            set
            {
                this.SetValue(LastNameProperty, value);
            }
        }

        /// <summary>
        /// Gets or sets the login.
        /// </summary>
        public string Login
        {
            get
            {
                return (string)this.GetValue(LoginProperty);
            }

            set
            {
                this.SetValue(LoginProperty, value);
            }
        }

        /// <summary>
        /// Gets or sets the password.
        /// </summary>
        public string Password
        {
            get
            {
                return (string)this.GetValue(PasswordProperty);
            }

            set
            {
                this.SetValue(PasswordProperty, value);
            }
        }

        /// <summary>
        /// Gets the registrate command.
        /// </summary>
        public ICommand RegistrateCommand { get; }

        /// <summary>
        /// Gets the cancle command.
        /// </summary>
        public ICommand CancleCommand { get; }

        /// <summary>
        /// The registrate.
        /// </summary>
        private void Registrate()
        {
            this.frontServiceClient.Registration(new UserRegistration(this.Name, this.LastName, this.Login, this.Password));
            this.Cancle();
        }

        /// <summary>
        /// The cancle.
        /// </summary>
        private void Cancle()
        {
            var loginWindow = new LoginWindow();
            loginWindow.Show();
            this.Close("RegistrationWindow");
        }

        /// <summary>
        /// The can registrate.
        /// </summary>
        /// <returns>
        /// The <see cref="bool"/>.
        /// </returns>
        private bool CanRegistrate()
        {
            return !string.IsNullOrEmpty(this.Name) && !string.IsNullOrEmpty(this.LastName)
                   && !string.IsNullOrEmpty(this.Login) && !string.IsNullOrEmpty(this.Password);
        }
    }
}