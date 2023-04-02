using MoricApps.EPlatform.Teachers.Domain.Models;
using MoricApps.EPlatform.Teachers.Storage.Entities;

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
            return new Teacher(entity.Id,entity.FirstName, entity.LastName,entity.Email,entity.PhoneNumber,coll,entity.Status);
        }
        public static TeacherEntity MapToEntity(this Teacher entity) 
        {
            List<TeacherAssigmentEntity> coll = new List<TeacherAssigmentEntity>();
            foreach (var assigment in entity.Assigments)
            {
                coll.Add(assigment.MapToEntity());
            }
            return new TeacherEntity()
            {
                Id= entity.Id,
                FirstName = entity.FirstName,
                LastName = entity.LastName,
                Email = entity.Email,
                PhoneNumber = entity.PhoneNumber,
                Assigments = coll
            };
        }
    }
}
