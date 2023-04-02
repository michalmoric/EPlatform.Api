using MoricApps.EPlatform.Teachers.Domain.Models;

namespace MoricApps.EPlatform.Teachers.Contract
{
    public class TeacherReturnDto
    {
        public int Id { get; set; }
        public string FirstName { get; set; } = null!;

        public string LastName { get; set; } = null!;

        public string Email { get; set; } = null!;
        public string PhoneNumber { get; set; } = null!;

        public ICollection<AssigmentDto> Assigments { get; set; } = null!;

        public TeacherStatus Status { get; set; }
    }
}
