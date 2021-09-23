using Demo.Data.Objects;
using Demo.Domain.Areas.Contacts.Models.People;
using System.Linq;

namespace Demo.Domain.Areas.Contacts.Helpers
{
    public static class PersonHelpers
    {
        public static IQueryable<Person> ApplySearch(this IQueryable<Person> dbEntities, PersonSearchModel search)
        {
            if (search != null)
            {
                if (!string.IsNullOrEmpty(search.Term))
                {
                    var words = search.Term.ToUpper().Split(' ');
                    foreach (var word in words)
                    {
                        dbEntities = dbEntities.Where(x => x.FirstName.ToUpper().Contains(word) ||
                            x.LastName.ToUpper().Contains(word) ||
                            x.Email.ToUpper().Contains(word));
                    }
                }
            }

            return dbEntities;
        }
    }
}
