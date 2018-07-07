// --------------------------------------------------------------------------------------------------------------------
// <copyright file="LoginWindowViewModel.cs" company="DNU">
//   DNU
// </copyright>
// <summary>
//   Defines the LoginWindowViewModel type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Warehouse.UI.ViewModel
{
    using System;
    using System.Windows;
    using System.Windows.Input;

    using Warehouse.DTO;
    using Warehouse.Front.Service.Client.Contract;
    using Warehouse.UI.Helper;
    using Warehouse.UI.View;

    /// <inheritdoc />
    /// <summary>
    /// The login window view model.
    /// </summary>
    public class LoginWindowViewModel : ViewModelBase
    {
        #region Create DependencyProperty section

        /// <summary>
        /// The login name property.
        /// </summary>
        public static readonly DependencyProperty LoginNameProperty = DependencyProperty.Register(
            "LoginText",
            typeof(string),
            typeof(LoginWindowViewModel),
            new PropertyMetadata(default(string)));

        /// <summary>
        /// The password property.
        /// </summary>
        public static readonly DependencyProperty PasswordProperty = DependencyProperty.Register(
            "PasswordText",
            typeof(string),
            typeof(LoginWindowViewModel),
            new PropertyMetadata(default(string)));

        #endregion

        /// <summary>
        /// The front service client.
        /// </summary>
        private readonly IFrontServiceClient frontServiceClient;

        /// <summary>
        /// Initializes a new instance of the <see cref="LoginWindowViewModel"/> class.
        /// </summary>
        public LoginWindowViewModel()
        {
            this.frontServiceClient = FrontServiceDIContainer.Resolve<IFrontServiceClient>();

            this.LoginCommand = new RelayCommand(cmd => this.Login(), can => this.CanLogin());
            this.RegistrationCommand = new RelayCommand(cmd => this.Registration());
        }

        /// <summary>
        /// Gets the login command.
        /// </summary>
        public ICommand LoginCommand { get; }

        /// <summary>
        /// Gets the registration command.
        /// </summary>
        public ICommand RegistrationCommand { get; }

        /// <summary>
        /// Gets or sets the login.
        /// </summary>
        public string LoginText
        {
            get
            {
                return (string)this.GetValue(LoginNameProperty);
            }

            set
            {
                this.SetValue(LoginNameProperty, value); 
            }
        }

        /// <summary>
        /// Gets or sets the password text.
        /// </summary>
        public string PasswordText
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
        /// The login.
        /// </summary>
        private void Login()
        {
            try
            {
                int userId = this.frontServiceClient.SystemEnter(new UserLogin(this.LoginText, this.PasswordText));
                if (userId != -1)
                {
                    var mainWindow = new WarehouseWindow
                                         {
                                             DataContext = new WarehouseWindowViewModel(userId)
                                         };
                    mainWindow.Show();
                    this.Close("LoginWindow");
                }
                else
                {
                    MessageBox.Show("Incorrect login or password", "Stop message", MessageBoxButton.OK, MessageBoxImage.Stop);
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.StackTrace, "Error message", MessageBoxButton.OK, MessageBoxImage.Error);
            }      
        }   

        /// <summary>
        /// The registration.
        /// </summary>
        private void Registration()
        {
            var registrationWindow = new RegistrationWindow();
            registrationWindow.Show();
            this.Close("LoginWindow");
        }

        /// <summary>
        /// The can login.
        /// </summary>
        /// <returns>
        /// The <see cref="bool"/>.
        /// </returns>
        private bool CanLogin()
        {
            return !string.IsNullOrWhiteSpace(this.LoginText) && !string.IsNullOrWhiteSpace(this.PasswordText);
        }
    }
}