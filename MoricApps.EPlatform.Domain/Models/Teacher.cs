using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoricApps.EPlatform.Domain.Models
{
    public class Teacher
    {
        public Teacher(string firstName, string lastName, string email, string phoneNumber)
        {
            FirstName = firstName;
            LastName = lastName;
            Email = email;
            PhoneNumber = phoneNumber;
            Status = TeacherStatus.Active;
        }
        public int Id { get;}

        public string FirstName { get;}

        public string LastName { get;}

        public string Email { get;}

        public string PhoneNumber { get;}

        public TeacherStatus Status { get; private set; }

        public void Disactivate() 
        { 
            Status = TeacherStatus.Inactive;
        }


    }
}
