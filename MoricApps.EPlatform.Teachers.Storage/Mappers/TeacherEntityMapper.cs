using MoricApps.EPlatform.Teachers.Domain.Models;
using MoricApps.EPlatform.Teachers.Storage.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoricApps.EPlatform.Teachers.Storage.Mappers
{
    public static class TeacherEntityMapper
    {
        public static Teacher MapToModel(this TeacherEntity entity)
        {
            List<TeacherAssigment> coll = new List<TeacherAssigment>();
            foreach (var assigment in entity.Assigments)
            {
                coll.Add(assigment.MapToModel());
            }
            return new Teacher(entity.FirstName, entity.LastName,entity.Email,entity.PhoneNumber,coll);
        }
        public static TeacherEntity MapToEntity(this Teacher entity) 
        {
            List<TeacherAssigmentEntity> coll = new List<TeacherAssigmentEntity>();
            foreach (var assigment in entity.Assigments)
            {
                coll.Add(assigment.MapToEntity());
            }
            return new TeacherEntity(entity.FirstName, entity.LastName, entity.Email, entity.PhoneNumber);// coll);
        }
    }
}
