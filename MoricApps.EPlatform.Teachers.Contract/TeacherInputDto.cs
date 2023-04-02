
namespace MoricApps.EPlatform.Teachers.Contract
{
    public class TeacherInputDto
    {
        public string FirstName { get; set; } = null!;

        public string LastName { get; set; } = null!;

        public string Email { get; set; } = null!;
        public string PhoneNumber { get; set; } = null!;

        public ICollection<AssigmentDto> Assigments { get; set; } = null!;
    }
}
