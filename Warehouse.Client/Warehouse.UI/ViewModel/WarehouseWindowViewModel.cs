// --------------------------------------------------------------------------------------------------------------------
// <copyright file="WarehouseWindowViewModel.cs" company="DNU">
//   DNU
// </copyright>
// <summary>
//   Defines the MainWindowViewModel type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Warehouse.UI.ViewModel
{
    using System;
    using System.Collections.ObjectModel;
    using System.Windows;
    using System.Windows.Input;

    using Warehouse.DTO;
    using Warehouse.Front.Service.Client.Contract;
    using Warehouse.UI.Extension;
    using Warehouse.UI.Helper;
    using Warehouse.UI.View;

    /// <inheritdoc />
    /// <summary>
    /// The main window view model.
    /// </summary>
    public class WarehouseWindowViewModel : ViewModelBase
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
        /// The front service client.
        /// </summary>
        private readonly IFrontServiceClient frontServiceClient;

        /// <summary>
        /// The user id.
        /// </summary>
        private readonly int userId;

        /// <inheritdoc />
        /// <summary>
        /// Initializes a new instance of the <see cref="T:Warehouse.UI.ViewModel.WarehouseWindowViewModel" /> class.
        /// </summary>
        public WarehouseWindowViewModel() : this(-1)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="WarehouseWindowViewModel"/> class.
        /// </summary>
        /// <param name="userId">
        /// The user Id.
        /// </param>
        public WarehouseWindowViewModel(int userId)
        {
            this.userId = userId;

            this.frontServiceClient = FrontServiceDIContainer.Resolve<IFrontServiceClient>();

            this.WarehouseGoodsCollection = this.frontServiceClient.GetAllWarehouseGoods().ToObservableCollection();

            this.WindowCloseCommand = new RelayCommand(cmd => this.WindowClose());
            this.OnWarehouseCommand = new RelayCommand(cmd => this.OnWarehouse());
            this.DeliverCommand = new RelayCommand(cmd => this.Deliver());
            this.SaleCommand = new RelayCommand(cmd => this.Sale());
            this.FindByProviderCommand = new RelayCommand(cmd => this.FindByProvider());
            this.FindByClassAndPeriodCommand = new RelayCommand(cmd => this.FindByClassAndPeriod());
            this.ReportByPeriodAndTypeCommand = new RelayCommand(cmd => this.ReportByPeriodAndType());
            this.ReportSumFromSalesCommand = new RelayCommand(cmd => this.ReportSumFromSales());
            this.ReportSalesRevenueCommand = new RelayCommand(cmd => this.ReportSalesRevenue());
            this.ReportByCategoryAndPeriodCommand = new RelayCommand(cmd => this.ReportByCategoryAndPeriod());
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

        #region ICommand members

        /// <summary>
        /// Gets or sets the window close command.
        /// </summary>
        public ICommand WindowCloseCommand { get; set; }

        /// <summary>
        /// Gets or sets the on ware house command.
        /// </summary>
        public ICommand OnWarehouseCommand { get; set; }

        /// <summary>
        /// Gets or sets the deliver command.
        /// </summary>
        public ICommand DeliverCommand { get; set; }

        /// <summary>
        /// Gets or sets the sale command.
        /// </summary>
        public ICommand SaleCommand { get; set; }

        /// <summary>
        /// Gets or sets the find by provider command.
        /// </summary>
        public ICommand FindByProviderCommand { get; set; }

        /// <summary>
        /// Gets or sets the find by class and period command.
        /// </summary>
        public ICommand FindByClassAndPeriodCommand { get; set; }

        /// <summary>
        /// Gets or sets the report by period and type command.
        /// </summary>
        public ICommand ReportByPeriodAndTypeCommand { get; set; }

        /// <summary>
        /// Gets or sets the report sum from sales command.
        /// </summary>
        public ICommand ReportSumFromSalesCommand { get; set; }

        /// <summary>
        /// Gets or sets the report sales revenue command.
        /// </summary>
        public ICommand ReportSalesRevenueCommand { get; set; }

        /// <summary>
        /// Gets or sets the report by category and period command.
        /// </summary>
        public ICommand ReportByCategoryAndPeriodCommand { get; set; }

        #endregion

        /// <summary>
        /// Gets or sets the provider.
        /// </summary>
        public ProviderDto Provider { private get; set; }

        /// <summary>
        /// Gets or sets the goods class.
        /// </summary>
        public GoodsClassDto GoodsClass { private get; set; }

        /// <summary>
        /// Gets or sets the start date.
        /// </summary>
        public DateTime StartDate { private get; set; }

        /// <summary>
        /// Gets or sets the end date.
        /// </summary>
        public DateTime EndDate { private get; set; }

        /// <summary>
        /// The window close.
        /// </summary>
        private void WindowClose()
        {
            this.Close("WarehouseWindow");
        }

        /// <summary>
        /// The on warehouse.
        /// </summary>
        private void OnWarehouse()
        {
            this.WarehouseGoodsCollection = this.frontServiceClient.GetAllWarehouseGoods().ToObservableCollection();
        }

        /// <summary>
        /// The deliver.
        /// </summary>
        private void Deliver()
        {
            var deliverWindow = new DeliverWindow();
            deliverWindow.ShowDialog();
            this.WarehouseGoodsCollection = this.frontServiceClient.GetAllWarehouseGoods().ToObservableCollection();
        }

        /// <summary>
        /// The sale.
        /// </summary>
        private void Sale()
        {
        }

        /// <summary>
        /// The find by provider.
        /// </summary>
        private void FindByProvider()
        {
            var findWindow = new FindByProviderWindow
                                 {
                                     DataContext =
                                         new FindByProviderWindowViewModel(this)
                                 };
            findWindow.ShowDialog();
            if (this.Provider == null) return;
            this.WarehouseGoodsCollection =
                this.frontServiceClient.GetWarehouseGoodsByProviderId(this.Provider.ProviderId).ToObservableCollection();
            this.Provider = null;
        }

        /// <summary>
        /// The find by class and period.
        /// </summary>
        private void FindByClassAndPeriod()
        {
            var findByClassAndPeriodWindow = new FindByClassAndPeriodWindow { DataContext = new FindByClassAndPeriodWindowViewModel(this) };
            findByClassAndPeriodWindow.ShowDialog();
            this.WarehouseGoodsCollection =
                this.frontServiceClient.GetGoodsByClassAndPeriod(this.GoodsClass.GoodsClassId, this.StartDate, this.EndDate).ToObservableCollection();
        }

        /// <summary>
        /// The report by period and type.
        /// </summary>
        private void ReportByPeriodAndType()
        {
            var window = new ReportByPeriodAndTypeWindow();
            window.ShowDialog();
            this.WarehouseGoodsCollection = this.frontServiceClient.GetAllWarehouseGoods().ToObservableCollection();
        }

        /// <summary>
        /// The report sum from sales.
        /// </summary>
        private void ReportSumFromSales()
        {
        }

        /// <summary>
        /// The report sales revenue.
        /// </summary>
        private void ReportSalesRevenue()
        {
        }

        /// <summary>
        /// The report by category and period.
        /// </summary>
        private void ReportByCategoryAndPeriod()
        {
        }
    }
}