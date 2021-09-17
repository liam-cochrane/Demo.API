using Demo.Data;
using Demo.Data.Objects;
using Demo.Domain.Areas.Stock.Models.StockItemUnits;
using System.Collections.Generic;

namespace Demo.Domain.Areas.Stock.Services
{
    public class StockItemUnitsService : IStockItemUnitsService
    {
        private readonly DataContext _dc;

        public StockItemUnitsService(DataContext context)
        {
            _dc = context;
        }

        public IEnumerable<ShowStockItemUnitModel> GetIndexModel(StockItemUnitSearchModel search)
        {
            var dbEntities = _dc.StockItemUnits.AsQueryable();

            if (search != null)
            {

            }

            var model = new List<ShowStockItemUnitModel>();

            foreach (var dbEntity in dbEntities)
            {
                model.Add(new ShowStockItemUnitModel(dbEntity));
            }

            return model;
        }

        public ShowStockItemUnitModel GetShowModel(long id)
        {
            var dbEntity = _dc.StockItemUnits.Find(id);
            if (dbEntity == null)
            {
                return null;
            }
            else
            {
                return new ShowStockItemUnitModel(dbEntity);
            }
        }

        public UpdateStockItemUnitModel GetUpdateModel(long id)
        {
            var dbEntity = _dc.StockItemUnits.Find(id);
            if (dbEntity == null)
            {
                return null;
            }
            else
            {
                return new UpdateStockItemUnitModel(dbEntity);
            }
        }

        public void SaveUpdateModel(long id, UpdateStockItemUnitModel model)
        {
            var dbEntity = _dc.StockItemUnits.Find(id);
            dbEntity.StockItem = _dc.StockItems.Find(model.StockItemId);
            dbEntity.Unit = _dc.Units.Find(model.UnitId);
            _dc.SaveChanges();
        }

        public CreateStockItemUnitModel GetCreateModel()
        {
            return new CreateStockItemUnitModel();
        }

        public ShowStockItemUnitModel SaveCreateModel(CreateStockItemUnitModel model)
        {
            var dbEntity = new StockItemUnit();
            dbEntity.StockItem = _dc.StockItems.Find(model.StockItemId);
            dbEntity.Unit = _dc.Units.Find(model.UnitId);
            _dc.StockItemUnits.Add(dbEntity);
            _dc.SaveChanges();

            return new ShowStockItemUnitModel(dbEntity);
        }

        public void Delete(long id)
        {
            var dbEntity = _dc.StockItemUnits.Find(id);
            _dc.Remove(dbEntity);
            _dc.SaveChanges();
        }
    }
}
