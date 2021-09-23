using Demo.Domain.Areas.Core.Models;
using Demo.Domain.Areas.Users.Models.Employees;
using System.Collections.Generic;

namespace Demo.Domain.Areas.Users.Services.Interfaces
{
    public interface IEmployeesService
    {
        IEnumerable<ShowEmployeeModel> GetIndexModel(EmployeeSearchModel search, PagingModel paging);

        int GetCount(EmployeeSearchModel search);

        ShowEmployeeModel GetShowModel(long id);

        ShowEmployeeModel GetShowModelByEmail(string email);

        UpdateEmployeeModel GetUpdateModel(long id);

        void SaveUpdateModel(long id, UpdateEmployeeModel model);

        CreateEmployeeModel GetCreateModel();

        ShowEmployeeModel SaveCreateModel(CreateEmployeeModel model);

        void Delete(long id);
    }
}
