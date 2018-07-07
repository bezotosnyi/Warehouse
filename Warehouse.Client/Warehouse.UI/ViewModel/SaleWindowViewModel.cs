// --------------------------------------------------------------------------------------------------------------------
// <copyright file="SaleWindowViewModel.cs" company="DNU">
//   DNU
// </copyright>
// <summary>
//   Defines the SaleWindowViewModel type.
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
    /// The sale window view model.
    /// </summary>
    public class SaleWindowViewModel : ViewModelBase
    {
        /// <summary>
        /// The warehouse goods property.
        /// </summary>
        public static readonly DependencyProperty WarehouseGoodsProperty = DependencyProperty.Register(
            "WarehouseGoodsCollection",
            typeof(ObservableCollection<WarehouseGoods>),
            typeof(WarehouseWindowViewModel),
            new PropertyMetadata(default(ObservableCollection<WarehouseGoods>)));

        /// <summary>
        /// The selected index property.
        /// </summary>
        public static readonly DependencyProperty SelectedIndexProperty = DependencyProperty.Register("SelectedIndex", typeof(int), typeof(SaleWindowViewModel), new PropertyMetadata(default(int)));

        /// <summary>
        /// The amount property.
        /// </summary>
        public static readonly DependencyProperty AmountProperty = DependencyProperty.Register("Amount", typeof(string), typeof(SaleWindowViewModel), new PropertyMetadata(default(string)));

        /// <summary>
        /// The front service client.
        /// </summary>
        private readonly IFrontServiceClient frontServiceClient;

        /// <summary>
        /// Initializes a new instance of the <see cref="SaleWindowViewModel"/> class.
        /// </summary>
        public SaleWindowViewModel()
        {
            this.frontServiceClient = FrontServiceDIContainer.Resolve<IFrontServiceClient>();
            this.SaleCommand = new RelayCommand(cmd => this.Sale(), cmd => this.CanSale());
            this.WarehouseGoodsCollection = this.frontServiceClient.GetAllWarehouseGoods().ToObservableCollection();
            this.SelectedIndex = -1;
        }

        /// <summary>
        /// Gets or sets the property type.
        /// </summary>
        public ObservableCollection<WarehouseGoods> WarehouseGoodsCollection
        {
            get
            {
                return (ObservableCollection<WarehouseGoods>)this.GetValue(WarehouseGoodsProperty);
            }

            set
            {
                this.SetValue(WarehouseGoodsProperty, value);
            }
        }

        /// <summary>
        /// Gets or sets the selected index.
        /// </summary>
        public int SelectedIndex
        {
            get
            {
                return (int)this.GetValue(SelectedIndexProperty);
            }

            set
            {
                this.SetValue(SelectedIndexProperty, value);
            }
        }

        /// <summary>
        /// Gets or sets the amount.
        /// </summary>
        public string Amount
        {
            get
            {
                return (string)this.GetValue(AmountProperty);
            }

            set
            {
                this.SetValue(AmountProperty, value);
            }
        }

        /// <summary>
        /// Gets or sets the sale command.
        /// </summary>
        public ICommand SaleCommand { get; set; }

        /// <summary>
        /// The sale.
        /// </summary>
        private void Sale()
        {
            this.frontServiceClient.Sale(this.WarehouseGoodsCollection[this.SelectedIndex], int.Parse(this.Amount));
            this.Close("SaleWindow");
        }

        /// <summary>
        /// The can sale.
        /// </summary>
        /// <returns>
        /// The <see cref="bool"/>.
        /// </returns>
        private bool CanSale()
        {
            return this.SelectedIndex != -1 && !string.IsNullOrEmpty(this.Amount)
                   && this.WarehouseGoodsCollection[this.SelectedIndex].Amount <= int.Parse(this.Amount);
        }
    }
}