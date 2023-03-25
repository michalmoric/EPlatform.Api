using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoricApps.EPlatform.Domain.Models
{
    public class TeacherAssigment
    {
        public int AssessmentId { get; set; }

        public Teacher Teacher { get; set; }

        public DateTime BeginDate { get; set; }

        public DateTime EndDate { get; set; }
    }
}
