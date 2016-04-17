using Microsoft.Practices.Prism.Modularity;
using Microsoft.Practices.Prism.Regions;
using StockMarket.Watch.Views;

namespace StockMarket.Watch
{
    public class StockWatchModule : IModule
    {
        private readonly IRegionManager regionManager;

        public StockWatchModule(IRegionManager regionManager)
        {
            this.regionManager = regionManager;
        }

        public void Initialize()
        {
            regionManager.RegisterViewWithRegion("MainRegion", typeof(StockWatchView));
        }
    }
}