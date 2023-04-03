using MoricApps.EPlatform.Teachers.Domain.Models;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Microsoft.IdentityModel.Tokens;

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

        public virtual ICollection<TeacherAssigmentEntity> Assigments { get; set; } = new List<TeacherAssigmentEntity>();

        public TeacherEntity()
        {
            

        }

    }
}
