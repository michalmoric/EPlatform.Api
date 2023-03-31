using MoricApps.EPlatform.Teachers.Domain.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoricApps.EPlatform.Teachers.Storage.Entities
{
    public class TeacherEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        [EmailAddress]
        public string Email { get; set; }
        [Phone]
        public string PhoneNumber { get; set; }

        public TeacherStatus Status { get; set; } = TeacherStatus.Active;

        public bool IsDeleted { get; set; } = false;

        public virtual ICollection<TeacherAssigment> Assigments { get; set; } = new List<TeacherAssigment>();

        public TeacherEntity(string firstName, string lastName, string email, string phoneNumber)
        {
            FirstName = firstName;
            LastName = lastName;
            Email = email;
            PhoneNumber = phoneNumber;

        }
        public void Disactivate()
        {
            Status = TeacherStatus.Inactive;
        }
        public void Reactivate()
        {
            Status = TeacherStatus.Active;
        }
    }
}
