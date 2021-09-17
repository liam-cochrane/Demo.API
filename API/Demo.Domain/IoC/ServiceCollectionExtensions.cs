using Demo.Data;
using Demo.Domain.Areas.Stock.Services;
using Demo.Domain.Areas.Stock.Services.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace Demo.Domain.IoC
{
    public static class ServiceCollectionExtensions
    {
        public static void RegisterStockServices(this IServiceCollection collection)
        {
            collection.AddScoped<IStockItemsService, StockItemsService>();
            collection.AddScoped<IStockItemUnitsService, StockItemUnitsService>();
            collection.AddScoped<IUnitsService, UnitsService>();
        }

        public static void AddDataContext(this IServiceCollection collection)
        {
            collection.AddDbContext<DataContext>();
        }
    }
}
