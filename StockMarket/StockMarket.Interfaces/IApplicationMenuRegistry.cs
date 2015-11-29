using System;

namespace StockMarket.Interfaces
{
    public interface IApplicationMenuRegistry
    {
        void RegisterMenuItem(string menuItemName, string description, Type viewType);
    }
}