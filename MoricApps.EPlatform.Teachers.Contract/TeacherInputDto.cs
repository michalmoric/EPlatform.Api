using MoricApps.EPlatform.Teachers.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoricApps.EPlatform.Teachers.Contract
{
    public class TeacherInputDto
    {
        public string FirstName { get; set; } = null!;

        public string LastName { get; set; } = null!;

        public string Email { get; set; } = null!;
        public string PhoneNumber { get; set; } = null!;

        public ICollection<TeacherAssigment> Assigments { get; set; } = null!;
    }
}
