using StockMarket.Interfaces;
using System;

namespace StockMarket.Shell.ViewModels
{
    public class ApplicationCommands : IApplicationCommands
    {
        public void CloseView(object view)
        {
            // throw new NotImplementedException();
        }

        public void OpenView(string title, Type viewType)
        {
            //throw new NotImplementedException();
        }

        public void OpenView(string title, System.Windows.UIElement viewToOpen)
        {
            // throw new NotImplementedException();
        }
    }
}