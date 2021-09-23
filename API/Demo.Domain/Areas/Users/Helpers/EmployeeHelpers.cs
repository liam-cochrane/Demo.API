using Demo.Data.Objects;
using Demo.Domain.Areas.Users.Models.Employees;
using System.Linq;

namespace Demo.Domain.Areas.Users.Helpers
{
    public static class EmployeeHelpers
    {
        public static IQueryable<Employee> ApplySearch(this IQueryable<Employee> dbEntities, EmployeeSearchModel search)
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
