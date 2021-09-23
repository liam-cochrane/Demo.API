using Demo.Data.Objects;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Demo.Domain.Areas.Users.Models.Employees
{
    public class UpdateEmployeeModel : IValidatableObject
    {
        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }

        public DateTime? BirthDate { get; set; }

        [EmailAddress]
        public string Email { get; set; }

        [Phone]
        public string MobileNumber { get; set; }

        [Phone]
        public string TelephoneNumber { get; set; }

        public UpdateEmployeeModel(Employee dbEntity) : base()
        {
            FirstName = dbEntity.FirstName;
            LastName = dbEntity.LastName;
            BirthDate = dbEntity.BirthDate;
            Email = dbEntity.Email;
            MobileNumber = dbEntity.MobileNumber;
            TelephoneNumber = dbEntity.TelephoneNumber;
        }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (BirthDate > DateTime.Today)
            {
                yield return new ValidationResult($"{nameof(BirthDate)} must be in the past", new List<string> { nameof(BirthDate) });
            }
        }
    }
}
