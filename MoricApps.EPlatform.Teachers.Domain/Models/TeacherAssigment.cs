

namespace MoricApps.EPlatform.Teachers.Domain.Models
{
    public class TeacherAssigment
    {
        public int Id { get;}
        public DateTime BeginDate { get;}

        public DateTime EndDate { get;}

        public TeacherAssigment(int id,DateTime begin,DateTime end) 
        {
            Id = id;
            BeginDate = begin;
            EndDate = end;
        }
    }
}
