// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ReportByPeriodAndTypeWindowViewModel.cs" company="DNU">
//   DNU
// </copyright>
// <summary>
//   Defines the ReportByPeriodAndTypeWindowViewModel type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Warehouse.UI.ViewModel
{
    using System;
    using System.Text;
    using System.Windows;
    using System.Windows.Input;
    
    using Warehouse.Front.Service.Client.Contract;
    using Warehouse.UI.Helper;

    /// <inheritdoc />
    /// <summary>
    /// The report by period and type window view model.
    /// </summary>
    public class ReportByPeriodAndTypeWindowViewModel : ViewModelBase 
    {
        /// <summary>
        /// The selected start date property.
        /// </summary>
        public static readonly DependencyProperty SelectedStartDateProperty = DependencyProperty.Register("SelectedStartDate", typeof(DateTime), typeof(FindByClassAndPeriodWindowViewModel), new PropertyMetadata(default(DateTime)));

        /// <summary>
        /// The selected end date property.
        /// </summary>
        public static readonly DependencyProperty SelectedEndDateProperty = DependencyProperty.Register("SelectedEndDate", typeof(DateTime), typeof(FindByClassAndPeriodWindowViewModel), new PropertyMetadata(default(DateTime)));

        /// <summary>
        /// The front service client.
        /// </summary>
        private readonly IFrontServiceClient frontServiceClient;

        /// <summary>
        /// Initializes a new instance of the <see cref="ReportByPeriodAndTypeWindowViewModel"/> class.
        /// </summary>
        public ReportByPeriodAndTypeWindowViewModel()
        {
            this.frontServiceClient = FrontServiceDIContainer.Resolve<IFrontServiceClient>();
            this.ReportCommand = new RelayCommand(cmd => this.Report());
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
        /// Gets or sets the find command.
        /// </summary>
        public ICommand ReportCommand { get; set; }

        /// <summary>
        /// The find.
        /// </summary>
        private void Report()
        {
            var report = this.frontServiceClient.GetReportByPeriodAndType(this.SelectedStartDate, this.SelectedEndDate);
            var str = new StringBuilder();
            foreach (var rep in report)
            {
                str.AppendLine($"Goods class: {rep.GoodsClass.Title}");
                str.AppendLine($"Accured: {rep.AmountAccruedGoods}");
                str.AppendLine($"Sales: {rep.AmountSalesGoods}");
                str.AppendLine($"Returned: {rep.AmountReturnedGoods}");
                str.AppendLine($"Sum from sales: {rep.SumFromSales}");
                str.AppendLine($"Renuve: {rep.SalesRenuve}");
                str.AppendLine("__________________________");
            }

            MessageBox.Show(str.ToString(), "Report", MessageBoxButton.OK);
            this.Close("ReportByPeriodAndTypeWindow");
        }
    }
}