using Demo.Data;
using Demo.Data.Objects;
using Demo.Domain.Areas.Stock.Models.Units;
using System.Collections.Generic;
using System.Linq;

namespace Demo.Domain.Areas.Stock.Services
{
    public class UnitsService : IUnitsService
    {
        private readonly DataContext _dc;

        public UnitsService(DataContext context)
        {
            _dc = context;
        }

        public IEnumerable<ShowUnitModel> GetIndexModel(UnitSearchModel search)
        {
            var dbEntities = _dc.Units.AsQueryable();

            if (search != null)
            {
                if (!string.IsNullOrEmpty(search.Term))
                {
                    var words = search.Term.ToUpper().Split(' ');
                    foreach (var word in words)
                    {
                        dbEntities = dbEntities.Where(x => x.Name.ToUpper().Contains(word));
                    }
                }
                if (search.StockItemId.HasValue)
                {
                    dbEntities = dbEntities.Where(x => x.StockItemUnits.Any(y => y.StockItem.StockItemId == search.StockItemId));
                }
            }

            var model = new List<ShowUnitModel>();

            foreach (var dbEntity in dbEntities)
            {
                model.Add(new ShowUnitModel(dbEntity));
            }

            return model;
        }

        public ShowUnitModel GetShowModel(long id)
        {
            var dbEntity = _dc.Units.Find(id);
            if (dbEntity == null)
            {
                return null;
            }
            else
            {
                return new ShowUnitModel(dbEntity);
            }
        }

        public UpdateUnitModel GetUpdateModel(long id)
        {
            var dbEntity = _dc.Units.Find(id);
            if (dbEntity == null)
            {
                return null;
            }
            else
            {
                return new UpdateUnitModel(dbEntity);
            }
        }

        public void SaveUpdateModel(long id, UpdateUnitModel model)
        {
            var dbEntity = _dc.Units.Find(id);
            dbEntity.Name = model.Name;
            dbEntity.MultipleOfBaseUnit = model.MultipleOfBaseUnit;
            _dc.SaveChanges();
        }

        public CreateUnitModel GetCreateModel()
        {
            return new CreateUnitModel();
        }

        public ShowUnitModel SaveCreateModel(CreateUnitModel model)
        {
            var dbEntity = new Unit();
            dbEntity.Name = model.Name;
            dbEntity.MultipleOfBaseUnit = model.MultipleOfBaseUnit;
            _dc.Units.Add(dbEntity);
            _dc.SaveChanges();

            return new ShowUnitModel(dbEntity);
        }

        public void Delete(long id)
        {
            var dbEntity = _dc.Units.Find(id);
            _dc.Remove(dbEntity);
            _dc.SaveChanges();
        }
    }
}
