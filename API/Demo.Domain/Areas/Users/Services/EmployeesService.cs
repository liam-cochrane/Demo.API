using Demo.Data;
using Demo.Data.Objects;
using Demo.Domain.Areas.Users.Helpers;
using Demo.Domain.Areas.Core.Helpers;
using Demo.Domain.Areas.Core.Models;
using Demo.Domain.Areas.Users.Models.Employees;
using System.Collections.Generic;
using System.Linq;
using Demo.Domain.Areas.Users.Services.Interfaces;

namespace Demo.Domain.Areas.Users.Services
{
    public class EmployeesService : IEmployeesService
    {
        private readonly DataContext _dc;

        public EmployeesService(DataContext context)
        {
            _dc = context;
        }

        public IEnumerable<ShowEmployeeModel> GetIndexModel(EmployeeSearchModel search, PagingModel paging)
        {
            var dbEntities = _dc.Employees.AsQueryable();

            dbEntities = dbEntities.ApplySearch(search);
            dbEntities = dbEntities.ApplyPaging(paging);

            var model = new List<ShowEmployeeModel>();

            foreach (var dbEntity in dbEntities)
            {
                model.Add(new ShowEmployeeModel(dbEntity));
            }

            return model;
        }

        public int GetCount(EmployeeSearchModel search)
        {
            var dbEntities = _dc.Employees.AsQueryable();
            dbEntities = dbEntities.ApplySearch(search);

            return dbEntities.Count();
        }

        public ShowEmployeeModel GetShowModel(long id)
        {
            var dbEntity = _dc.Employees.Find(id);
            if (dbEntity == null)
            {
                return null;
            }
            else
            {
                return new ShowEmployeeModel(dbEntity);
            }
        }

        public ShowEmployeeModel GetShowModelByEmail(string email)
        {
            var dbEntity = _dc.Employees.FirstOrDefault(x => x.Email == email);
            if (dbEntity == null)
            {
                return null;
            }
            else
            {
                return new ShowEmployeeModel(dbEntity);
            }
        }

        public UpdateEmployeeModel GetUpdateModel(long id)
        {
            var dbEntity = _dc.Employees.Find(id);
            if (dbEntity == null)
            {
                return null;
            }
            else
            {
                return new UpdateEmployeeModel(dbEntity);
            }
        }

        public void SaveUpdateModel(long id, UpdateEmployeeModel model)
        {
            var dbEntity = _dc.Employees.Find(id);
            dbEntity.FirstName = model.FirstName;
            dbEntity.LastName = model.LastName;
            dbEntity.BirthDate = model.BirthDate;
            dbEntity.Email = model.Email;
            dbEntity.MobileNumber = model.MobileNumber;
            dbEntity.TelephoneNumber = model.TelephoneNumber;
            _dc.SaveChanges();
        }

        public CreateEmployeeModel GetCreateModel()
        {
            return new CreateEmployeeModel();
        }

        public ShowEmployeeModel SaveCreateModel(CreateEmployeeModel model)
        {
            var dbEntity = new Employee();
            dbEntity.FirstName = model.FirstName;
            dbEntity.LastName = model.LastName;
            dbEntity.BirthDate = model.BirthDate;
            dbEntity.Email = model.Email;
            dbEntity.MobileNumber = model.MobileNumber;
            dbEntity.TelephoneNumber = model.TelephoneNumber;
            _dc.Employees.Add(dbEntity);
            _dc.SaveChanges();

            return new ShowEmployeeModel(dbEntity);
        }

        public void Delete(long id)
        {
            var dbEntity = _dc.People.Find(id);
            _dc.Remove(dbEntity);
            _dc.SaveChanges();
        }
    }
}
