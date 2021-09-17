using Demo.Domain.Areas.Stock.Models.StockItems;
using System.Collections.Generic;

namespace Demo.Domain.Areas.Stock.Services.Interfaces
{
    public interface IStockItemsService
    {
        public IEnumerable<ShowStockItemModel> GetIndexModel(StockItemSearchModel search);

        public ShowStockItemModel GetShowModel(long id);

        public UpdateStockItemModel GetUpdateModel(long id);

        public void SaveUpdateModel(long id, UpdateStockItemModel model);

        public CreateStockItemModel GetCreateModel();

        public ShowStockItemModel SaveCreateModel(CreateStockItemModel model);

        public void Delete(long id);
    }
}
