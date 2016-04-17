using StockMarket.Watch.ViewModels;
using System.Windows.Controls;

namespace StockMarket.Watch.Views
{
    /// <summary>
    /// Interaction logic for StockWatchView.xaml
    /// </summary>
    public partial class StockWatchView : UserControl
    {
        public StockWatchView(FileExplorerViewModel vm)
        {
            InitializeComponent();
            this.DataContext = vm;
        }
    }
}