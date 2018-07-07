// --------------------------------------------------------------------------------------------------------------------
// <copyright file="FindByProviderWindowViewModel.cs" company="DNU">
//   DNU
// </copyright>
// <summary>
//   Defines the FindByProviderWindowViewModel type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Warehouse.UI.ViewModel
{
    using System.Collections.ObjectModel;
    using System.Windows;
    using System.Windows.Input;

    using Warehouse.DTO;
    using Warehouse.Front.Service.Client.Contract;
    using Warehouse.UI.Extension;
    using Warehouse.UI.Helper;

    /// <inheritdoc />
    /// <summary>
    /// The find by provider window view model.
    /// </summary>
    public class FindByProviderWindowViewModel : ViewModelBase
    {
        /// <summary>
        /// The provider property.
        /// </summary>
        public static readonly DependencyProperty ProviderProperty = DependencyProperty.Register(
            "ProviderCollection",
            typeof(ObservableCollection<ProviderDto>),
            typeof(FindByProviderWindowViewModel),
            new PropertyMetadata(default(ObservableCollection<ProviderDto>)));

        /// <summary>
        /// The selected provider index property.
        /// </summary>
        public static readonly DependencyProperty SelectedProviderIndexProperty = DependencyProperty.Register(
            "PropertyType",
            typeof(int),
            typeof(FindByProviderWindowViewModel),
            new PropertyMetadata(default(int)));

        /// <summary>
        /// The provider name.
        /// </summary>
        private readonly WarehouseWindowViewModel viewModel;

        /// <summary>
        /// Initializes a new instance of the <see cref="FindByProviderWindowViewModel"/> class.
        /// </summary>
        public FindByProviderWindowViewModel()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="FindByProviderWindowViewModel"/> class.
        /// </summary>
        /// <param name="viewModel">
        /// The view Model.
        /// </param>
        public FindByProviderWindowViewModel(WarehouseWindowViewModel viewModel)
        {
            var frontServiceClient = FrontServiceDIContainer.Resolve<IFrontServiceClient>();

            this.ProviderCollection = frontServiceClient.GetAllProvider().ToObservableCollection();

            this.FindCommand = new RelayCommand(cmd => this.Find(), cmd => this.CanFind());

            this.SelectedProviderIndex = -1;

            this.viewModel = viewModel;
        }

        /// <summary>
        /// Gets or sets the property type.
        /// </summary>
        public ObservableCollection<ProviderDto> ProviderCollection
        {
            get
            {
                return (ObservableCollection<ProviderDto>)this.GetValue(ProviderProperty);
            }

            set
            {
                this.SetValue(ProviderProperty, value);
            }
        }

        /// <summary>
        /// Gets or sets the selected provider index.
        /// </summary>
        public int SelectedProviderIndex
        {
            get
            {
                return (int)this.GetValue(SelectedProviderIndexProperty);
            }

            set
            {
                this.SetValue(SelectedProviderIndexProperty, value);
            }
        }

        /// <summary>
        /// Gets or sets the find command.
        /// </summary>
        public ICommand FindCommand { get; set; }

        /// <summary>
        /// The find.
        /// </summary>
        public void Find()
        {
            this.viewModel.Provider = this.ProviderCollection[this.SelectedProviderIndex];
            this.Close("FindByProviderWindow");
        }

        /// <summary>
        /// The can find.
        /// </summary>
        /// <returns>
        /// The <see cref="bool"/>.
        /// </returns>
        public bool CanFind()
        {
            return this.SelectedProviderIndex != -1;
        }
    }
}