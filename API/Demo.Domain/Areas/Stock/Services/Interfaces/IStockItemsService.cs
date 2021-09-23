using Demo.Domain.Areas.Core.Models;
using Demo.Domain.Areas.Stock.Models.StockItems;
using System.Collections.Generic;

namespace Demo.Domain.Areas.Stock.Services.Interfaces
{
    public interface IStockItemsService
    {
        public IEnumerable<ShowStockItemModel> GetIndexModel(StockItemSearchModel search, PagingModel paging);

        public ShowStockItemModel GetShowModel(long id);

        public ShowStockItemModel GetShowModelByCode(string code);

        public UpdateStockItemModel GetUpdateModel(long id);

        public void SaveUpdateModel(long id, UpdateStockItemModel model);

        public CreateStockItemModel GetCreateModel();

        public ShowStockItemModel SaveCreateModel(CreateStockItemModel model);

        public void Delete(long id);
    }
}
