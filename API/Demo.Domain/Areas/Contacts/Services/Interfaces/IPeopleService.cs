using Demo.Domain.Areas.Contacts.Models.People;
using Demo.Domain.Areas.Core.Models;
using System.Collections.Generic;

namespace Demo.Domain.Areas.Contacts.Services.Interfaces
{
    public interface IPeopleService
    {
        IEnumerable<ShowPersonModel> GetIndexModel(PersonSearchModel search, PagingModel paging);

        int GetCount(PersonSearchModel search);

        ShowPersonModel GetShowModel(long id);

        ShowPersonModel GetShowModelByEmail(string email);

        UpdatePersonModel GetUpdateModel(long id);

        void SaveUpdateModel(long id, UpdatePersonModel model);

        CreatePersonModel GetCreateModel();

        ShowPersonModel SaveCreateModel(CreatePersonModel model);

        void Delete(long id);
    }
}
