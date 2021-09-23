using Demo.Domain.Areas.Core.Models;
using Demo.Domain.Areas.Stock.Models.StockItemUnits;
using System.Collections.Generic;

namespace Demo.Domain.Areas.Stock.Services
{
    public interface IStockItemUnitsService
    {
        public IEnumerable<ShowStockItemUnitModel> GetIndexModel(StockItemUnitSearchModel search, PagingModel paging);

        public ShowStockItemUnitModel GetShowModel(long id);

        public UpdateStockItemUnitModel GetUpdateModel(long id);

        public void SaveUpdateModel(long id, UpdateStockItemUnitModel model);

        public CreateStockItemUnitModel GetCreateModel();

        public ShowStockItemUnitModel SaveCreateModel(CreateStockItemUnitModel model);

        public void Delete(long id);
    }
}
