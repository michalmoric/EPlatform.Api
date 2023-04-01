namespace MoricApps.EPlatform.Teachers.Domain.Models
{
    public class Teacher
    {
        public int Id { get;}

        public string FirstName { get;}

        public string LastName { get;}

        public string Email { get;}
        public string PhoneNumber { get;}

        public TeacherStatus Status { get; private set; } = TeacherStatus.Active;

        public virtual ICollection<TeacherAssigment> Assigments { get;} = new List<TeacherAssigment>();

        public Teacher(string firstName, string lastName, string email, string phoneNumber,ICollection<TeacherAssigment> assigments)
        {
            FirstName = firstName;
            LastName = lastName;
            Email = email;
            PhoneNumber = phoneNumber;
            Assigments = assigments;

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
