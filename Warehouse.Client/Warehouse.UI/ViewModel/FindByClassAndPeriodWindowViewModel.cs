// --------------------------------------------------------------------------------------------------------------------
// <copyright file="FindByClassAndPeriodWindowViewModel.cs" company="DNU">
//   DNU
// </copyright>
// <summary>
//   Defines the FindByClassAndPeriodWindowViewModel type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Warehouse.UI.ViewModel
{
    using System;
    using System.Collections.ObjectModel;
    using System.Linq;
    using System.Windows;
    using System.Windows.Input;

    using Warehouse.DTO;
    using Warehouse.Front.Service.Client.Contract;
    using Warehouse.UI.Extension;
    using Warehouse.UI.Helper;

    /// <inheritdoc />
    /// <summary>
    /// The find by class and period window view model.
    /// </summary>
    public class FindByClassAndPeriodWindowViewModel : ViewModelBase
    {
        /// <summary>
        /// The goods class collection property.
        /// </summary>
        public static readonly DependencyProperty GoodsClassCollectionProperty = DependencyProperty.Register("GoodsClassCollection", typeof(ObservableCollection<GoodsClassDto>), typeof(FindByClassAndPeriodWindowViewModel), new PropertyMetadata(default(ObservableCollection<GoodsClassDto>)));

        /// <summary>
        /// The selected class index property.
        /// </summary>
        public static readonly DependencyProperty SelectedClassIndexProperty = DependencyProperty.Register("SelectedClassIndex", typeof(int), typeof(FindByClassAndPeriodWindowViewModel), new PropertyMetadata(default(int)));

        /// <summary>
        /// The selected start date property.
        /// </summary>
        public static readonly DependencyProperty SelectedStartDateProperty = DependencyProperty.Register("SelectedStartDate", typeof(DateTime), typeof(FindByClassAndPeriodWindowViewModel), new PropertyMetadata(default(DateTime)));

        /// <summary>
        /// The selected end date property.
        /// </summary>
        public static readonly DependencyProperty SelectedEndDateProperty = DependencyProperty.Register("SelectedEndDate", typeof(DateTime), typeof(FindByClassAndPeriodWindowViewModel), new PropertyMetadata(default(DateTime)));

        /// <summary>
        /// The warehouse window view model.
        /// </summary>
        private readonly WarehouseWindowViewModel warehouseWindowViewModel;

        /// <summary>
        /// The front service client.
        /// </summary>
        private readonly IFrontServiceClient frontServiceClient;

        /// <inheritdoc />
        /// <summary>
        /// Initializes a new instance of the <see cref="T:Warehouse.UI.ViewModel.FindByClassAndPeriodWindowViewModel" /> class.
        /// </summary>
        public FindByClassAndPeriodWindowViewModel() : this(null)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="FindByClassAndPeriodWindowViewModel"/> class.
        /// </summary>
        /// <param name="warehouseWindowViewModel">
        /// The warehouse window view model.
        /// </param>
        public FindByClassAndPeriodWindowViewModel(WarehouseWindowViewModel warehouseWindowViewModel)
        {
            this.warehouseWindowViewModel = warehouseWindowViewModel;
            this.frontServiceClient = FrontServiceDIContainer.Resolve<IFrontServiceClient>();
            this.GoodsClassCollection = this.frontServiceClient.GetAllGoodsClass().ToObservableCollection();
            this.FindCommand = new RelayCommand(cmd => this.Find());

            this.SelectedClassIndex = -1;
        }

        /// <summary>
        /// Gets or sets the selected end date.
        /// </summary>
        public DateTime SelectedEndDate
        {
            get
            {
                return (DateTime)this.GetValue(SelectedEndDateProperty);
            }

            set
            {
                this.SetValue(SelectedEndDateProperty, value);
            }
        }

        /// <summary>
        /// Gets or sets the selected start date.
        /// </summary>
        public DateTime SelectedStartDate
        {
            get
            {
                return (DateTime)this.GetValue(SelectedStartDateProperty);
            }

            set
            {
                this.SetValue(SelectedStartDateProperty, value);
            }
        }

        /// <summary>
        /// Gets or sets the selected class index.
        /// </summary>
        public int SelectedClassIndex
        {
            get
            {
                return (int)this.GetValue(SelectedClassIndexProperty);
            }

            set
            {
                this.SetValue(SelectedClassIndexProperty, value);
            }
        }

        /// <summary>
        /// Gets or sets the goods class collection.
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
        /// Gets or sets the find command.
        /// </summary>
        public ICommand FindCommand { get; set; }

        /// <summary>
        /// The find.
        /// </summary>
        private void Find()
        {
            if (this.SelectedClassIndex == -1) return;

            this.warehouseWindowViewModel.GoodsClass = this.GoodsClassCollection[this.SelectedClassIndex];
            this.warehouseWindowViewModel.StartDate = this.SelectedStartDate;
            this.warehouseWindowViewModel.EndDate = this.SelectedEndDate;
            this.Close("FindByClassAndPeriodWindow");
        }
    }
}