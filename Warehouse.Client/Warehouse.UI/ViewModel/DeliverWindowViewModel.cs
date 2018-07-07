// --------------------------------------------------------------------------------------------------------------------
// <copyright file="DeliverWindowViewModel.cs" company="DNU">
//   DNU
// </copyright>
// <summary>
//   Defines the DeliverWindowViewModel type.
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
    /// The deliver window view model.
    /// </summary>
    public class DeliverWindowViewModel : ViewModelBase
    {
        #region Dependency property

        /// <summary>
        /// The provider collection property.
        /// </summary>
        public static readonly DependencyProperty ProviderCollectionProperty = DependencyProperty.Register(
            "ProviderCollection",
            typeof(ObservableCollection<ProviderDto>),
            typeof(DeliverWindowViewModel),
            new PropertyMetadata(default(ObservableCollection<ProviderDto>)));

        /// <summary>
        /// The property type property.
        /// </summary>
        public static readonly DependencyProperty ProviderListBoxSelectedIndexProperty = DependencyProperty.Register(
            "ProviderListBoxSelectedIndex",
            typeof(int),
            typeof(DeliverWindowViewModel),
            new PropertyMetadata(default(int)));

        /// <summary>
        /// The goods category collection property.
        /// </summary>
        public static readonly DependencyProperty GoodsCategoryCollectionProperty = DependencyProperty.Register(
            "GoodsCategoryCollection",
            typeof(ObservableCollection<GoodsCategoryDto>),
            typeof(DeliverWindowViewModel),
            new PropertyMetadata(default(ObservableCollection<GoodsCategoryDto>)));

        /// <summary>
        /// The property type property.
        /// </summary>
        public static readonly DependencyProperty GoodsCategoryListBoxSelectedIndexProperty = DependencyProperty.Register(
            "GoodsCategoryListBoxSelectedIndex",
            typeof(int),
            typeof(DeliverWindowViewModel),
            new PropertyMetadata(default(int)));

        /// <summary>
        /// The property type property.
        /// </summary>
        public static readonly DependencyProperty GoodsClassCollectionTypeProperty = DependencyProperty.Register(
            "GoodsClassCollection",
            typeof(ObservableCollection<GoodsClassDto>),
            typeof(DeliverWindowViewModel),
            new PropertyMetadata(default(ObservableCollection<GoodsClassDto>)));

        /// <summary>
        /// The goods class list box selected index property.
        /// </summary>
        public static readonly DependencyProperty GoodsClassListBoxSelectedIndexProperty = DependencyProperty.Register(
            "GoodsClassListBoxSelectedIndex",
            typeof(int),
            typeof(DeliverWindowViewModel),
            new PropertyMetadata(default(int)));

        /// <summary>
        /// The provider goods collection property.
        /// </summary>
        public static readonly DependencyProperty ProviderGoodsCollectionProperty = DependencyProperty.Register(
            "ProviderGoodsCollection",
            typeof(ObservableCollection<GoodsDto>),
            typeof(DeliverWindowViewModel),
            new PropertyMetadata(default(ObservableCollection<GoodsDto>)));

        /// <summary>
        /// The provider goods grid selected index property.
        /// </summary>
        public static readonly DependencyProperty ProviderGoodsGridSelectedIndexProperty = DependencyProperty.Register(
            "ProviderGoodsGridSelectedIndex",
            typeof(int),
            typeof(DeliverWindowViewModel),
            new PropertyMetadata(default(int)));

        /// <summary>
        /// The selected goods property.
        /// </summary>
        public static readonly DependencyProperty SelectedGoodsNameProperty = DependencyProperty.Register(
            "SelectedGoodsName",
            typeof(string),
            typeof(DeliverWindowViewModel),
            new PropertyMetadata(default(string)));

        /// <summary>
        /// The amount goods type property.
        /// </summary>
        public static readonly DependencyProperty AmountGoodsTypeProperty = DependencyProperty.Register(
            "AmountGoods",
            typeof(string),
            typeof(DeliverWindowViewModel),
            new PropertyMetadata(default(string)));

        /// <summary>
        /// The unit price goods property.
        /// </summary>
        public static readonly DependencyProperty UnitPriceGoodsProperty = DependencyProperty.Register(
            "UnitPriceGoods",
            typeof(string),
            typeof(DeliverWindowViewModel),
            new PropertyMetadata(default(string)));

        /// <summary>
        /// The warehouse goodses property.
        /// </summary>
        public static readonly DependencyProperty WarehouseGoodsProperty = DependencyProperty.Register(
            "WarehouseGoodsCollection",
            typeof(ObservableCollection<WarehouseGoods>),
            typeof(DeliverWindowViewModel),
            new PropertyMetadata(default(ObservableCollection<WarehouseGoods>)));

        /// <summary>
        /// The warehouse goods grid selected index property.
        /// </summary>
        public static readonly DependencyProperty WarehouseGoodsGridSelectedIndexProperty = DependencyProperty.Register(
            "WarehouseGoodsGridSelectedIndex",
            typeof(int),
            typeof(DeliverWindowViewModel),
            new PropertyMetadata(default(int)));
        
        #endregion

        /// <summary>
        /// The front service client.
        /// </summary>
        private readonly IFrontServiceClient frontServiceClient;

        /// <summary>
        /// Initializes a new instance of the <see cref="DeliverWindowViewModel"/> class.
        /// </summary>
        public DeliverWindowViewModel()
        {
            this.frontServiceClient = FrontServiceDIContainer.Resolve<IFrontServiceClient>();

            this.ProviderSelectionChangedCommand = new RelayCommand(cmd => this.ProviderSelectionChanged());
            this.GoodsClassSelectionChangedCommand = new RelayCommand(cmd => this.GoodsClassSelectionChanged());
            this.GoodsCategorySelectionChangedCommand = new RelayCommand(cmd => this.GoodsCategorySelectionChanged());
            this.GoodsProviderGridSelectedChangedCommand = new RelayCommand(cmd => this.GoodsProviderGridSelectedChanged());
            this.AddGoodsToDeliveryCommand = new RelayCommand(cmd => this.AddGoodsToDelivery(), cmd => this.CanAddGoodsToDelivery());
            this.DeleteGoodsFromDeviveryCommand = new RelayCommand(cmd => this.DeleteGoodsFromDevivery(), cmd => this.CanDeleteGoodsFromDevivery());
            this.DeliverCommand = new RelayCommand(cmd => this.Deliver(), cmd => this.CanDeliver());
            this.NewDeliverCommand = new RelayCommand(cmd => this.NewDeliver());
            this.AddOrModifyProviderCommand = new RelayCommand(cmd => this.AddOrModifyProvider());

            this.ProviderCollection = this.frontServiceClient.GetAllProvider().ToObservableCollection();
            this.GoodsCategoryCollection = this.frontServiceClient.GetAllGoodsCategory().ToObservableCollection();
            this.GoodsClassCollection = this.frontServiceClient.GetAllGoodsClass().ToObservableCollection();

            this.WarehouseGoodsGridSelectedIndex = -1;
            this.ProviderListBoxSelectedIndex = -1;
            this.GoodsClassListBoxSelectedIndex = -1;
            this.GoodsCategoryListBoxSelectedIndex = -1;
        }

        #region Dependency fields

        /// <summary>
        /// Gets or sets the warehouse goods grid selected index.
        /// </summary>
        public int WarehouseGoodsGridSelectedIndex
        {
            get
            {
                return (int)this.GetValue(WarehouseGoodsGridSelectedIndexProperty);
            }

            set
            {
                this.SetValue(WarehouseGoodsGridSelectedIndexProperty, value);
            }
        }

        /// <summary>
        /// Gets or sets the warehouse goodse collection.
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
        /// Gets or sets the unit price goods.
        /// </summary>
        public string UnitPriceGoods
        {
            get
            {
                return (string)this.GetValue(UnitPriceGoodsProperty);
            }

            set
            {
                this.SetValue(UnitPriceGoodsProperty, value);
            }
        }

        /// <summary>
        /// Gets or sets the amount goods.
        /// </summary>
        public string AmountGoods
        {
            get
            {
                return (string)this.GetValue(AmountGoodsTypeProperty);
            }

            set
            {
                this.SetValue(AmountGoodsTypeProperty, value);
            }
        }

        /// <summary>
        /// Gets or sets the selected goods.
        /// </summary>
        public string SelectedGoodsName
        {
            get
            {
                return (string)this.GetValue(SelectedGoodsNameProperty);
            }

            set
            {
                this.SetValue(SelectedGoodsNameProperty, value);
            }
        }

        /// <summary>
        /// Gets or sets the provider goods grid selected index.
        /// </summary>
        public int ProviderGoodsGridSelectedIndex
        {
            get
            {
                return (int)this.GetValue(ProviderGoodsGridSelectedIndexProperty);
            }

            set
            {
                this.SetValue(ProviderGoodsGridSelectedIndexProperty, value);
            }
        }

        /// <summary>
        /// Gets or sets the provider goods collection.
        /// </summary>
        public ObservableCollection<GoodsDto> ProviderGoodsCollection
        {
            get
            {
                return (ObservableCollection<GoodsDto>)this.GetValue(ProviderGoodsCollectionProperty);
            }

            set
            {
                this.SetValue(ProviderGoodsCollectionProperty, value);
            }
        }

        /// <summary>
        /// Gets or sets the goods class list box selected index.
        /// </summary>
        public int GoodsClassListBoxSelectedIndex
        {
            get
            {
                return (int)this.GetValue(GoodsClassListBoxSelectedIndexProperty);
            }

            set
            {
                this.SetValue(GoodsClassListBoxSelectedIndexProperty, value);
            }
        }

        /// <summary>
        /// Gets or sets the goods class collection.
        /// </summary>
        public ObservableCollection<GoodsClassDto> GoodsClassCollection
        {
            get
            {
                return (ObservableCollection<GoodsClassDto>)this.GetValue(GoodsClassCollectionTypeProperty);
            }

            set
            {
                this.SetValue(GoodsClassCollectionTypeProperty, value);
            }
        }

        /// <summary>
        /// Gets or sets the goods category list box selected index.
        /// </summary>
        public int GoodsCategoryListBoxSelectedIndex
        {
            get
            {
                return (int)this.GetValue(GoodsCategoryListBoxSelectedIndexProperty);
            }

            set
            {
                this.SetValue(GoodsCategoryListBoxSelectedIndexProperty, value);
            }
        }

        /// <summary>
        /// Gets or sets the goods category collection.
        /// </summary>
        public ObservableCollection<GoodsCategoryDto> GoodsCategoryCollection
        {
            get
            {
                return (ObservableCollection<GoodsCategoryDto>)this.GetValue(GoodsCategoryCollectionProperty);
            }

            set
            {
                this.SetValue(GoodsCategoryCollectionProperty, value);
            }
        }

        /// <summary>
        /// Gets or sets the provider list box selected index.
        /// </summary>
        public int ProviderListBoxSelectedIndex
        {
            get
            {
                return (int)this.GetValue(ProviderListBoxSelectedIndexProperty);
            }

            set
            {
                this.SetValue(ProviderListBoxSelectedIndexProperty, value);
            }
        }

        /// <summary>
        /// Gets or sets the provider collection.
        /// </summary>
        public ObservableCollection<ProviderDto> ProviderCollection
        {
            get
            {
                return (ObservableCollection<ProviderDto>)this.GetValue(ProviderCollectionProperty);
            }

            set
            {
                this.SetValue(ProviderCollectionProperty, value);
            }
        }

        #endregion

        #region ICommand members 

        /// <summary>
        /// Gets or sets the provider selection changed command.
        /// </summary>
        public ICommand ProviderSelectionChangedCommand { get; set; }

        /// <summary>
        /// Gets or sets the goods class selection changed command.
        /// </summary>
        public ICommand GoodsClassSelectionChangedCommand { get; set; }

        /// <summary>
        /// Gets or sets the goods category selection changed command.
        /// </summary>
        public ICommand GoodsCategorySelectionChangedCommand { get; set; }

        /// <summary>
        /// Gets or sets the goods provider grid selected changed command.
        /// </summary>
        public ICommand GoodsProviderGridSelectedChangedCommand { get; set; }

        /// <summary>
        /// Gets or sets the add goods to delivery command.
        /// </summary>
        public ICommand AddGoodsToDeliveryCommand { get; set; }

        /// <summary>
        /// Gets or sets the delete goods from devivery command.
        /// </summary>
        public ICommand DeleteGoodsFromDeviveryCommand { get; set; }

        /// <summary>
        /// Gets or sets the deliver command.
        /// </summary>
        public ICommand DeliverCommand { get; set; }

        /// <summary>
        /// Gets or sets the new deliver command.
        /// </summary>
        public ICommand NewDeliverCommand { get; set; }

        /// <summary>
        /// Gets or sets the add or modify provider command.
        /// </summary>
        public ICommand AddOrModifyProviderCommand { get; set; }

        #endregion

        /// <summary>
        /// The provider selection changed.
        /// </summary>
        private void ProviderSelectionChanged()
        {
            if (this.ProviderListBoxSelectedIndex == -1) return;
            this.ProviderGoodsCollection =
                this.frontServiceClient.GetGoodsByProviderId(
                    this.ProviderCollection[this.ProviderListBoxSelectedIndex].ProviderId).ToObservableCollection();
        }

        /// <summary>
        /// The goods class selection changed.
        /// </summary>
        private void GoodsClassSelectionChanged()
        {
            if (this.GoodsClassListBoxSelectedIndex == -1) return;
            this.ProviderGoodsCollection =
                this.frontServiceClient.GetGoodsByClassId(
                    this.GoodsClassCollection[this.GoodsClassListBoxSelectedIndex].GoodsClassId).ToObservableCollection();
        }

        /// <summary>
        /// The goods category selection changed.
        /// </summary>
        private void GoodsCategorySelectionChanged()
        {
            if (this.GoodsCategoryListBoxSelectedIndex == -1) return;
            this.ProviderGoodsCollection =
                this.frontServiceClient.GetGoodsByCategoryId(
                    this.GoodsCategoryCollection[this.GoodsCategoryListBoxSelectedIndex].GoodsCategoryId).ToObservableCollection();
        }

        /// <summary>
        /// The goods provider grid selected changed.
        /// </summary>
        private void GoodsProviderGridSelectedChanged()
        {
            if (this.ProviderGoodsGridSelectedIndex == -1) return;
            this.SelectedGoodsName = this.ProviderGoodsCollection[this.ProviderGoodsGridSelectedIndex].Title;
        }

        /// <summary>
        /// The add goods to delivery.
        /// </summary>
        private void AddGoodsToDelivery()
        {
            if (this.WarehouseGoodsCollection == null) this.WarehouseGoodsCollection = new ObservableCollection<WarehouseGoods>();
            this.WarehouseGoodsCollection.Add(new WarehouseGoods
                                                  {
                                                      GoodsId = this.WarehouseGoodsCollection.Count + 1,
                                                      Amount = int.Parse(this.AmountGoods),
                                                      DateTimeDelivery = DateTime.Now,
                                                      GoodsCategory = this.ProviderGoodsCollection[this.ProviderGoodsGridSelectedIndex].GoodsCategory,
                                                      GoodsClass = this.ProviderGoodsCollection[this.ProviderGoodsGridSelectedIndex].GoodsClass,
                                                      Provider = this.ProviderGoodsCollection[this.ProviderGoodsGridSelectedIndex].Provider,
                                                      Title = this.SelectedGoodsName,
                                                      State = "Accrued",
                                                      UnitPrice = decimal.Parse(this.UnitPriceGoods)
                                                   });
        }

        /// <summary>
        /// The can add goods to delivery.
        /// </summary>
        /// <returns>
        /// The <see cref="bool"/>.
        /// </returns>
        private bool CanAddGoodsToDelivery()
        {
            return this.ProviderGoodsGridSelectedIndex != -1 && !string.IsNullOrEmpty(this.SelectedGoodsName) 
                && !string.IsNullOrEmpty(this.UnitPriceGoods) && !string.IsNullOrEmpty(this.AmountGoods);
        }

        /// <summary>
        /// The delete goods from devivery.
        /// </summary>
        private void DeleteGoodsFromDevivery()
        {
            this.WarehouseGoodsCollection.RemoveAt(this.WarehouseGoodsGridSelectedIndex);
        }

        /// <summary>
        /// The can delete goods from devivery.
        /// </summary>
        /// <returns>
        /// The <see cref="bool"/>.
        /// </returns>
        private bool CanDeleteGoodsFromDevivery()
        {
            return this.WarehouseGoodsGridSelectedIndex != -1;
        }

        /// <summary>
        /// The deliver.
        /// </summary>
        private void Deliver()
        {
            this.frontServiceClient.AddWarehouseGoods(this.WarehouseGoodsCollection);
            this.Close("DeliverWindow");
        }

        /// <summary>
        /// The can deliver.
        /// </summary>
        /// <returns>
        /// The <see cref="bool"/>.
        /// </returns>
        private bool CanDeliver()
        {
            return this.WarehouseGoodsCollection != null && this.WarehouseGoodsCollection.Count > 0;
        }

        /// <summary>
        /// The new deliver.
        /// </summary>
        private void NewDeliver()
        {
            this.ProviderListBoxSelectedIndex = -1;
            this.GoodsCategoryListBoxSelectedIndex = -1;
            this.GoodsClassListBoxSelectedIndex = -1;

            this.WarehouseGoodsGridSelectedIndex = -1;
            this.ProviderListBoxSelectedIndex = -1;
            this.WarehouseGoodsCollection = null;
            this.ProviderGoodsCollection = null;

            this.SelectedGoodsName = string.Empty;
            this.AmountGoods = string.Empty;
            this.UnitPriceGoods = string.Empty;
        }

        /// <summary>
        /// The add or modify provider.
        /// </summary>
        private void AddOrModifyProvider()
        {
            var window = new AddOrModifyProviderWindow();
            window.Show();
            this.Close("DeliverWindow");
        }
    }
}