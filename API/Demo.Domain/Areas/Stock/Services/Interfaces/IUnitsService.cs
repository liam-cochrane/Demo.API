using Demo.Domain.Areas.Stock.Models.Units;
using System.Collections.Generic;

namespace Demo.Domain.Areas.Stock.Services
{
    public interface IUnitsService
    {
        public IEnumerable<ShowUnitModel> GetIndexModel(UnitSearchModel search);

        public ShowUnitModel GetShowModel(long id);

        public UpdateUnitModel GetUpdateModel(long id);

        public void SaveUpdateModel(long id, UpdateUnitModel model);

        public CreateUnitModel GetCreateModel();

        public ShowUnitModel SaveCreateModel(CreateUnitModel model);

        public void Delete(long id);
    }
}
