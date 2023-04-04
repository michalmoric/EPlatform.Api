using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoricApps.EPlatform.Teachers.Domain.Exeptions
{
    public class TeacherDeleteExeption : Exception
    {
        public TeacherDeleteExeption() : base("Teacher cannot be deleted because of an assigment") { }
        public TeacherDeleteExeption(string message) : base(message)
        {
            
        }
    }
}
