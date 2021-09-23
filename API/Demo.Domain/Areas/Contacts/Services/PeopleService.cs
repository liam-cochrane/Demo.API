using Demo.Data;
using Demo.Data.Objects;
using Demo.Domain.Areas.Contacts.Helpers;
using Demo.Domain.Areas.Contacts.Models.People;
using Demo.Domain.Areas.Contacts.Services.Interfaces;
using Demo.Domain.Areas.Core.Helpers;
using Demo.Domain.Areas.Core.Models;
using System.Collections.Generic;
using System.Linq;

namespace Demo.Domain.Areas.Contacts.Services
{
    public class PeopleService : IPeopleService
    {
        private readonly DataContext _dc;

        public PeopleService(DataContext context)
        {
            _dc = context;
        }

        public IEnumerable<ShowPersonModel> GetIndexModel(PersonSearchModel search, PagingModel paging)
        {
            var dbEntities = _dc.People.AsQueryable();

            dbEntities = dbEntities.ApplySearch(search);
            dbEntities = dbEntities.ApplyPaging(paging);

            var model = new List<ShowPersonModel>();

            foreach (var dbEntity in dbEntities)
            {
                model.Add(new ShowPersonModel(dbEntity));
            }

            return model;
        }

        public int GetCount(PersonSearchModel search)
        {
            var dbEntities = _dc.People.AsQueryable();
            dbEntities = dbEntities.ApplySearch(search);

            return dbEntities.Count();
        }

        public ShowPersonModel GetShowModel(long id)
        {
            var dbEntity = _dc.People.Find(id);
            if (dbEntity == null)
            {
                return null;
            }
            else
            {
                return new ShowPersonModel(dbEntity);
            }
        }

        public ShowPersonModel GetShowModelByEmail(string email)
        {
            var dbEntity = _dc.People.FirstOrDefault(x => x.Email == email);
            if (dbEntity == null)
            {
                return null;
            }
            else
            {
                return new ShowPersonModel(dbEntity);
            }
        }

        public UpdatePersonModel GetUpdateModel(long id)
        {
            var dbEntity = _dc.People.Find(id);
            if (dbEntity == null)
            {
                return null;
            }
            else
            {
                return new UpdatePersonModel(dbEntity);
            }
        }

        public void SaveUpdateModel(long id, UpdatePersonModel model)
        {
            var dbEntity = _dc.People.Find(id);
            dbEntity.FirstName = model.FirstName;
            dbEntity.LastName = model.LastName;
            dbEntity.BirthDate = model.BirthDate;
            dbEntity.Email = model.Email;
            dbEntity.MobileNumber = model.MobileNumber;
            dbEntity.TelephoneNumber = model.TelephoneNumber;
            _dc.SaveChanges();
        }

        public CreatePersonModel GetCreateModel()
        {
            return new CreatePersonModel();
        }

        public ShowPersonModel SaveCreateModel(CreatePersonModel model)
        {
            var dbEntity = new Person();
            dbEntity.FirstName = model.FirstName;
            dbEntity.LastName = model.LastName;
            dbEntity.BirthDate = model.BirthDate;
            dbEntity.Email = model.Email;
            dbEntity.MobileNumber = model.MobileNumber;
            dbEntity.TelephoneNumber = model.TelephoneNumber;
            _dc.People.Add(dbEntity);
            _dc.SaveChanges();

            return new ShowPersonModel(dbEntity);
        }

        public void Delete(long id)
        {
            var dbEntity = _dc.People.Find(id);
            _dc.Remove(dbEntity);
            _dc.SaveChanges();
        }
    }
}
