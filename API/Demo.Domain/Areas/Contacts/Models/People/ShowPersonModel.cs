using Demo.Data.Objects;
using System;

namespace Demo.Domain.Areas.Contacts.Models.People
{
    public class ShowPersonModel
    {
        public long PersonId { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string DisplayName { get; set; }

        public DateTime? BirthDate { get; set; }

        public string Email { get; set; }

        public string MobileNumber { get; set; }

        public string TelephoneNumber { get; set; }

        public DateTime CreatedDate { get; set; }

        public DateTime? ModifiedDate { get; set; }

        public ShowPersonModel(Person dbEntity)
        {
            PersonId = dbEntity.PersonId;
            FirstName = dbEntity.FirstName;
            LastName = dbEntity.LastName;
            DisplayName = dbEntity.DisplayName;
            BirthDate = dbEntity.BirthDate;
            Email = dbEntity.Email;
            MobileNumber = dbEntity.MobileNumber;
            TelephoneNumber = dbEntity.TelephoneNumber;
            CreatedDate = dbEntity.CreatedDate;
            ModifiedDate = dbEntity.ModifiedDate;
        }
    }
}
