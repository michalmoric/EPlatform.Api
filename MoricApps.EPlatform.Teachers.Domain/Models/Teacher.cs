using Microsoft.IdentityModel.Tokens;

namespace MoricApps.EPlatform.Teachers.Domain.Models
{
    public class Teacher
    {
        public int Id { get;}

        public string FirstName { get;}

        public string LastName { get;}

        public string Email { get;}
        public string PhoneNumber { get;}

        public bool IsDeleted { get; private set; }

        public TeacherStatus Status { get; private set; } = TeacherStatus.Active;

        public virtual ICollection<TeacherAssigment> Assigments { get;} = new List<TeacherAssigment>();

        public Teacher(int id, string firstName, string lastName, string email, string phoneNumber,ICollection<TeacherAssigment> assigments, TeacherStatus status, bool isDeleted)
        {
            Id = id;
            FirstName = firstName;
            LastName = lastName;
            Email = email;
            PhoneNumber = phoneNumber;
            Assigments = assigments;
            Status = status;
            IsDeleted = isDeleted;
        }
        public Teacher(string firstName, string lastName, string email, string phoneNumber, ICollection<TeacherAssigment> assigments)
        {
            FirstName = firstName;
            LastName = lastName;
            Email = email;
            PhoneNumber = phoneNumber;
            Assigments = assigments;
        }
        public Teacher Disactivate()
        {
            if (!Assigments.IsNullOrEmpty())
            {
                foreach (var assigment in Assigments)
                {
                    if (assigment.EndDate > DateTime.Now)
                    {
                        return null;
                    }
                }
            }
            Status = TeacherStatus.Inactive;
            return this;
        }

        public Teacher Reactivate()
        {
            Status = TeacherStatus.Active;
            return this;
        }
        public Teacher Delete()
        {

            if (!Assigments.IsNullOrEmpty())
            {
                foreach (var assigment in Assigments)
                {
                    if (assigment.EndDate > DateTime.Now)
                    {
                        return null;
                    }
                }
            }
            IsDeleted = true;
            return this;

        }

    }
}
