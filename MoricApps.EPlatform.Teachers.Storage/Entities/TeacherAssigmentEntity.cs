
namespace MoricApps.EPlatform.Teachers.Storage.Entities
{
    public class TeacherAssigmentEntity
    {
        public int Id { get; set; }

        public virtual TeacherEntity Teacher { get; set; }

        public DateTime BeginDate { get; set; }

        public DateTime EndDate { get; set; }
    }
}
