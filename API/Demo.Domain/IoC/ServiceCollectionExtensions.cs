using Demo.Data;
using Demo.Domain.Areas.Contacts.Services;
using Demo.Domain.Areas.Contacts.Services.Interfaces;
using Demo.Domain.Areas.Stock.Services;
using Demo.Domain.Areas.Stock.Services.Interfaces;
using Demo.Domain.Areas.Users.Services;
using Demo.Domain.Areas.Users.Services.Interfaces;
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

        public static void RegisterContactServices(this IServiceCollection collection)
        {
            collection.AddScoped<IPeopleService, PeopleService>();
        }

        public static void RegisterUserServices(this IServiceCollection collection)
        {
            collection.AddScoped<IEmployeesService, EmployeesService>();
        }

        public static void AddDataContext(this IServiceCollection collection)
        {
            collection.AddDbContext<DataContext>();
        }
    }
}
