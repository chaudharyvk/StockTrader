using System;

using System.Windows;

namespace StockMarket.Interfaces
{
    public interface IApplicationCommands
    {
        void CloseView(object view);

        void OpenView(string title, Type viewType);

        void OpenView(string title, UIElement viewToOpen);
    }
}