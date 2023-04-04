using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoricApps.EPlatform.Teachers.Domain.Exeptions
{
    public class TeacherDeactivateExeption : Exception
    {
        public TeacherDeactivateExeption() : base("Teacher cannot be deactivated because of an assigment") { }
        public TeacherDeactivateExeption(string message) : base(message)
        {

        }
    }
}
