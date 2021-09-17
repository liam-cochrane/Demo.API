using Demo.Data;
using Demo.Data.Objects;
using Demo.Domain.Areas.Stock.Models.StockItems;
using Demo.Domain.Areas.Stock.Services.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace Demo.Domain.Areas.Stock.Services
{
    public class StockItemsService : IStockItemsService
    {
        private readonly DataContext _dc;

        public StockItemsService(DataContext context)
        {
            _dc = context;
        }

        public IEnumerable<ShowStockItemModel> GetIndexModel(StockItemSearchModel search)
        {
            var dbEntities = _dc.StockItems.AsQueryable();

            if (search != null)
            {
                if (!string.IsNullOrEmpty(search.Term))
                {
                    var words = search.Term.ToUpper().Split(' ');
                    foreach (var word in words)
                    {
                        dbEntities = dbEntities.Where(x => x.Description.ToUpper().Contains(word) || x.ItemCode.ToUpper().Contains(word));
                    }
                }
            }

            var model = new List<ShowStockItemModel>();

            foreach (var dbEntity in dbEntities)
            {
                model.Add(new ShowStockItemModel(dbEntity));
            }

            return model;
        }

        public ShowStockItemModel GetShowModel(long id)
        {
            var dbEntity = _dc.StockItems.Find(id);
            if (dbEntity == null)
            {
                return null;
            }
            else
            {
                return new ShowStockItemModel(dbEntity);
            }
        }

        public ShowStockItemModel GetShowModelByCode(string code)
        {
            var dbEntity = _dc.StockItems.FirstOrDefault(x => x.ItemCode == code);
            if (dbEntity == null)
            {
                return null;
            }
            else
            {
                return new ShowStockItemModel(dbEntity);
            }
        }

        public UpdateStockItemModel GetUpdateModel(long id)
        {
            var dbEntity = _dc.StockItems.Find(id);
            if (dbEntity == null)
            {
                return null;
            }
            else
            {
                return new UpdateStockItemModel(dbEntity);
            }
        }

        public void SaveUpdateModel(long id, UpdateStockItemModel model)
        {
            var dbEntity = _dc.StockItems.Find(id);
            dbEntity.ItemCode = model.ItemCode;
            dbEntity.Description = model.Description;
            _dc.SaveChanges();
        }

        public CreateStockItemModel GetCreateModel()
        {
            return new CreateStockItemModel();
        }

        public ShowStockItemModel SaveCreateModel(CreateStockItemModel model)
        {
            var dbEntity = new StockItem();
            dbEntity.ItemCode = model.ItemCode;
            dbEntity.Description = model.Description;
            _dc.StockItems.Add(dbEntity);
            _dc.SaveChanges();

            return new ShowStockItemModel(dbEntity);
        }

        public void Delete(long id)
        {
            var dbEntity = _dc.StockItems.Find(id);
            _dc.Remove(dbEntity);
            _dc.SaveChanges();
        }
    }
}
