// --------------------------------------------------------------------------------------------------------------------
// <copyright file="AddOrModifyProviderWindowViewModel.cs" company="DNU">
//   DNU
// </copyright>
// <summary>
//   Defines the AddOrModifyProviderWindowViewModel type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Warehouse.UI.ViewModel
{
    using System.Collections.ObjectModel;
    using System.Globalization;
    using System.Windows;
    using System.Windows.Input;

    using Warehouse.DTO;
    using Warehouse.Front.Service.Client.Contract;
    using Warehouse.UI.Extension;
    using Warehouse.UI.Helper;

    /// <inheritdoc />
    /// <summary>
    /// The add or modify provider window view model.
    /// </summary>
    public class AddOrModifyProviderWindowViewModel : ViewModelBase
    {
        /// <summary>
        /// The provider name property.
        /// </summary>
        public static readonly DependencyProperty ProviderNameProperty = DependencyProperty.Register("ProviderName", typeof(string), typeof(AddOrModifyProviderWindowViewModel), new PropertyMetadata(default(string)));

        /// <summary>
        /// The provider address property.
        /// </summary>
        public static readonly DependencyProperty ProviderAddressProperty = DependencyProperty.Register("ProviderAddress", typeof(string), typeof(AddOrModifyProviderWindowViewModel), new PropertyMetadata(default(string)));

        /// <summary>
        /// The provider phone property.
        /// </summary>
        public static readonly DependencyProperty ProviderPhoneProperty = DependencyProperty.Register("ProviderPhone", typeof(string), typeof(AddOrModifyProviderWindowViewModel), new PropertyMetadata(default(string)));

        /// <summary>
        /// The goods title property.
        /// </summary>
        public static readonly DependencyProperty GoodsTitleProperty = DependencyProperty.Register("GoodsTitle", typeof(string), typeof(AddOrModifyProviderWindowViewModel), new PropertyMetadata(default(string)));

        /// <summary>
        /// The goods price property.
        /// </summary>
        public static readonly DependencyProperty GoodsPriceProperty = DependencyProperty.Register("GoodsPrice", typeof(string), typeof(AddOrModifyProviderWindowViewModel), new PropertyMetadata(default(string)));

        /// <summary>
        /// The goods category property.
        /// </summary>
        public static readonly DependencyProperty GoodsCategoryCollectionProperty = DependencyProperty.Register("GoodsCategoryCollection", typeof(ObservableCollection<GoodsCategoryDto>), typeof(AddOrModifyProviderWindowViewModel), new PropertyMetadata(default(ObservableCollection<GoodsCategoryDto>)));

        /// <summary>
        /// The goods class property.
        /// </summary>
        public static readonly DependencyProperty GoodsClassCollectionProperty = DependencyProperty.Register("PropertyType", typeof(ObservableCollection<GoodsClassDto>), typeof(AddOrModifyProviderWindowViewModel), new PropertyMetadata(default(ObservableCollection<GoodsClassDto>)));

        /// <summary>
        /// The goods collection property.
        /// </summary>
        public static readonly DependencyProperty GoodsCollectionProperty = DependencyProperty.Register("GoodsCollection", typeof(ObservableCollection<GoodsDto>), typeof(AddOrModifyProviderWindowViewModel), new PropertyMetadata(default(ObservableCollection<GoodsDto>)));

        /// <summary>
        /// The goods category text property.
        /// </summary>
        public static readonly DependencyProperty GoodsCategoryTextProperty = DependencyProperty.Register("GoodsCategoryText", typeof(string), typeof(AddOrModifyProviderWindowViewModel), new PropertyMetadata(default(string)));

        /// <summary>
        /// The goods class text property.
        /// </summary>
        public static readonly DependencyProperty GoodsClassTextProperty = DependencyProperty.Register("GoodsClassText", typeof(string), typeof(AddOrModifyProviderWindowViewModel), new PropertyMetadata(default(string)));

        /// <summary>
        /// The provider collection property.
        /// </summary>
        public static readonly DependencyProperty ProviderCollectionProperty = DependencyProperty.Register("ProviderCollection", typeof(ObservableCollection<ProviderDto>), typeof(AddOrModifyProviderWindowViewModel), new PropertyMetadata(default(ObservableCollection<ProviderDto>)));

        /// <summary>
        /// The provider collection selected index property.
        /// </summary>
        public static readonly DependencyProperty ProviderCollectionSelectedIndexProperty = DependencyProperty.Register("ProviderCollectionSelectedIndex", typeof(int), typeof(AddOrModifyProviderWindowViewModel), new PropertyMetadata(default(int)));

        /// <summary>
        /// The goods collection selection index property.
        /// </summary>
        public static readonly DependencyProperty GoodsCollectionSelectionIndexProperty = DependencyProperty.Register("GoodsCollectionSelectionIndex", typeof(int), typeof(AddOrModifyProviderWindowViewModel), new PropertyMetadata(default(int)));

        /// <summary>
        /// The goods category selected item property.
        /// </summary>
        public static readonly DependencyProperty GoodsCategorySelectedItemProperty = DependencyProperty.Register("GoodsCategorySelectedItem", typeof(GoodsCategoryDto), typeof(AddOrModifyProviderWindowViewModel), new PropertyMetadata(default(GoodsCategoryDto)));

        /// <summary>
        /// The goods class selected item property.
        /// </summary>
        public static readonly DependencyProperty GoodsClassSelectedItemProperty = DependencyProperty.Register("GoodsClassSelectedItem", typeof(GoodsClassDto), typeof(AddOrModifyProviderWindowViewModel), new PropertyMetadata(default(GoodsClassDto)));

        /// <summary>
        /// The front service client.
        /// </summary>
        private readonly IFrontServiceClient frontServiceClient;

        /// <summary>
        /// Initializes a new instance of the <see cref="AddOrModifyProviderWindowViewModel"/> class.
        /// </summary>
        public AddOrModifyProviderWindowViewModel()
        {
            this.frontServiceClient = FrontServiceDIContainer.Resolve<IFrontServiceClient>();
            this.AddGoodsCommand = new RelayCommand(cmd => this.AddGoods(), cmd => this.CanAddGoods());
            this.AddProviderCommand = new RelayCommand(cmd => this.AddProvider());
            this.ProviderIndeSelectedSelectedChangedCommand = new RelayCommand(cmd => this.ProviderIndeSelectedSelected());
            this.GoodsSelectedChangedCommand = new RelayCommand(cmd => this.GoodsSelectedChanged());
            this.UpdateCommand = new RelayCommand(cmd => this.Update(), cmd => this.CanUpdate());

            this.ProviderCollectionSelectedIndex = -1;
            this.GoodsCollectionSelectionIndex = -1;

            this.ProviderCollection = this.frontServiceClient.GetAllProvider().ToObservableCollection();
            this.GoodsClassCollection = this.frontServiceClient.GetAllGoodsClass().ToObservableCollection();
            this.GoodsCategoryCollection = this.frontServiceClient.GetAllGoodsCategory().ToObservableCollection();           
        }

        #region Dependency fields

        /// <summary>
        /// Gets or sets the goods class selected item.
        /// </summary>
        public GoodsClassDto GoodsClassSelectedItem
        {
            get
            {
                return (GoodsClassDto)this.GetValue(GoodsClassSelectedItemProperty);
            }

            set
            {
                this.SetValue(GoodsClassSelectedItemProperty, value);
            }
        }

        /// <summary>
        /// Gets or sets the goods category selected item.
        /// </summary>
        public GoodsCategoryDto GoodsCategorySelectedItem
        {
            get
            {
                return (GoodsCategoryDto)this.GetValue(GoodsCategorySelectedItemProperty);
            }

            set
            {
                this.SetValue(GoodsCategorySelectedItemProperty, value);
            }
        }

        /// <summary>
        /// Gets or sets the goods collection selection index.
        /// </summary>
        public int GoodsCollectionSelectionIndex
        {
            get
            {
                return (int)this.GetValue(GoodsCollectionSelectionIndexProperty);
            }

            set
            {
                this.SetValue(GoodsCollectionSelectionIndexProperty, value);
            }
        }

        /// <summary>
        /// Gets or sets the provider collection selected index.
        /// </summary>
        public int ProviderCollectionSelectedIndex
        {
            get
            {
                return (int)this.GetValue(ProviderCollectionSelectedIndexProperty);
            }

            set
            {
                this.SetValue(ProviderCollectionSelectedIndexProperty, value);
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

        /// <summary>
        /// Gets or sets the goods class text.
        /// </summary>
        public string GoodsClassText
        {
            get
            {
                return (string)this.GetValue(GoodsClassTextProperty);
            }

            set
            {
                this.SetValue(GoodsClassTextProperty, value);
            }
        }

        /// <summary>
        /// Gets or sets the goods category text.
        /// </summary>
        public string GoodsCategoryText
        {
            get
            {
                return (string)this.GetValue(GoodsCategoryTextProperty);
            }

            set
            {
                this.SetValue(GoodsCategoryTextProperty, value);
            }
        }

        /// <summary>
        /// Gets or sets the goods collection.
        /// </summary>
        public ObservableCollection<GoodsDto> GoodsCollection
        {
            get
            {
                return (ObservableCollection<GoodsDto>)this.GetValue(GoodsCollectionProperty);
            }

            set
            {
                this.SetValue(GoodsCollectionProperty, value);
            }
        }

        /// <summary>
        /// Gets or sets the goods class.
        /// </summary>
        public ObservableCollection<GoodsClassDto> GoodsClassCollection
        {
            get
            {
                return (ObservableCollection<GoodsClassDto>)this.GetValue(GoodsClassCollectionProperty);
            }

            set
            {
                this.SetValue(GoodsClassCollectionProperty, value);
            }
        }

        /// <summary>
        /// Gets or sets the goods category.
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
        /// Gets or sets the goods price.
        /// </summary>
        public string GoodsPrice
        {
            get
            {
                return (string)this.GetValue(GoodsPriceProperty);
            }

            set
            {
                this.SetValue(GoodsPriceProperty, value);
            }
        }

        /// <summary>
        /// Gets or sets the goods title.
        /// </summary>
        public string GoodsTitle
        {
            get
            {
                return (string)this.GetValue(GoodsTitleProperty);
            }

            set
            {
                this.SetValue(GoodsTitleProperty, value);
            }
        }

        /// <summary>
        /// Gets or sets the provider phone.
        /// </summary>
        public string ProviderPhone
        {
            get
            {
                return (string)this.GetValue(ProviderPhoneProperty);
            }

            set
            {
                this.SetValue(ProviderPhoneProperty, value);
            }
        }

        /// <summary>
        /// Gets or sets the provider address.
        /// </summary>
        public string ProviderAddress
        {
            get
            {
                return (string)this.GetValue(ProviderAddressProperty);
            }

            set
            {
                this.SetValue(ProviderAddressProperty, value);
            }
        }

        /// <summary>
        /// Gets or sets the provider name.
        /// </summary>
        public string ProviderName
        {
            get
            {
                return (string)this.GetValue(ProviderNameProperty);
            }

            set
            {
                this.SetValue(ProviderNameProperty, value);
            }
        }

        #endregion

        /// <summary>
        /// Gets or sets the add goods command.
        /// </summary>
        public ICommand AddGoodsCommand { get; set; }

        /// <summary>
        /// Gets or sets the add provider command.
        /// </summary>
        public ICommand AddProviderCommand { get; set; }

        /// <summary>
        /// Gets or sets the provider inde selected selected changed command.
        /// </summary>
        public ICommand ProviderIndeSelectedSelectedChangedCommand { get; set; }

        /// <summary>
        /// Gets or sets the goods inde selected selected changed command.
        /// </summary>
        public ICommand GoodsSelectedChangedCommand { get; set; }

        /// <summary>
        /// Gets or sets the update command.
        /// </summary>
        public ICommand UpdateCommand { get; set; }

        /// <summary>
        /// The update.
        /// </summary>
        private void Update()
        {
            this.frontServiceClient.UpdateGoods(new GoodsDto
                                                    {
                                                        GoodsCategory = new GoodsCategoryDto(0, this.GoodsCategoryText),
                                                        GoodsClass = new GoodsClassDto(0, this.GoodsClassText),
                                                        GoodsId = 0,
                                                        Price = decimal.Parse(this.GoodsPrice),
                                                        Provider = new ProviderDto(0, this.ProviderName, this.ProviderAddress, this.ProviderPhone),
                                                        Title = this.GoodsTitle,
                                                    });
            this.frontServiceClient.UpdateProvider(new ProviderDto
                                                       {
                                                           ProviderId = 0,
                                                           Address = this.ProviderAddress,
                                                           Name = this.ProviderName,
                                                           Phone = this.ProviderPhone
                                                       });
            this.ProviderCollection = this.frontServiceClient.GetAllProvider().ToObservableCollection();
        }

        /// <summary>
        /// The can update.
        /// </summary>
        /// <returns>
        /// The <see cref="bool"/>.
        /// </returns>
        private bool CanUpdate()
        {
            return this.CanAddGoods();
        }

        /// <summary>
        /// The add goods.
        /// </summary>
        private void AddGoods()
        {
            this.frontServiceClient.AddGoodsOfProvider(new GoodsDto
                                                           {
                                                               GoodsCategory = new GoodsCategoryDto(0, this.GoodsCategoryText),
                                                               GoodsClass = new GoodsClassDto(0, this.GoodsClassText),
                                                               GoodsId = 0,
                                                               Price = decimal.Parse(this.GoodsPrice, CultureInfo.InvariantCulture),
                                                               Provider = new ProviderDto(0, this.ProviderName, this.ProviderAddress, this.ProviderPhone),
                                                               Title = this.GoodsTitle,
                                                           });
            this.GoodsCollection = this.frontServiceClient.GetGoodsByProviderId(
                this.ProviderCollection[this.ProviderCollectionSelectedIndex].ProviderId).ToObservableCollection();
        }

        /// <summary>
        /// The goods inde selected selected changed.
        /// </summary>
        private void GoodsSelectedChanged()
        {
            if (this.GoodsCollectionSelectionIndex == -1) return;

            var goods = this.GoodsCollection[this.GoodsCollectionSelectionIndex];
            this.GoodsClassText = goods.GoodsClass.Title;
            this.GoodsCategoryText = goods.GoodsCategory.Title;
            this.GoodsTitle = goods.Title;
            this.GoodsPrice = goods.Price.ToString(CultureInfo.InvariantCulture);
        }

        /// <summary>
        /// The provider inde selected selected.
        /// </summary>
        private void ProviderIndeSelectedSelected()
        {
            if (this.ProviderCollectionSelectedIndex == -1) return;
            var provider = this.ProviderCollection[this.ProviderCollectionSelectedIndex];
            this.ProviderName = provider.Name;
            this.ProviderAddress = provider.Address;
            this.ProviderPhone = provider.Phone;
            this.GoodsClassText = string.Empty;
            this.GoodsCategoryText = string.Empty;
            this.GoodsTitle = string.Empty;
            this.GoodsPrice = string.Empty;

            this.GoodsCollection = this.frontServiceClient.GetGoodsByProviderId(provider.ProviderId).ToObservableCollection();
        }

        /// <summary>
        /// The add provider.
        /// </summary>
        private void AddProvider()
        {
            this.ProviderName = string.Empty;
            this.ProviderAddress = string.Empty;
            this.ProviderPhone = string.Empty;
            this.GoodsClassText = string.Empty;
            this.GoodsCategoryText = string.Empty;
            this.GoodsTitle = string.Empty;
            this.GoodsPrice = string.Empty;

            this.ProviderCollectionSelectedIndex = -1;
            this.GoodsCollectionSelectionIndex = -1;

            this.GoodsCollection = null;
        }

        /// <summary>
        /// The can add goods.
        /// </summary>
        /// <returns>
        /// The <see cref="bool"/>.
        /// </returns>
        private bool CanAddGoods()
        {
            return !string.IsNullOrEmpty(this.ProviderName) && !string.IsNullOrEmpty(this.ProviderAddress)
                   && !string.IsNullOrEmpty(this.ProviderPhone) && !string.IsNullOrEmpty(this.GoodsClassText)
                   && !string.IsNullOrEmpty(this.GoodsCategoryText) && !string.IsNullOrEmpty(this.GoodsTitle)
                   && !string.IsNullOrEmpty(this.GoodsPrice);
        }
    }
}