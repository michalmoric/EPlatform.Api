using MoricApps.EPlatform.Teachers.Domain.Models;
using MoricApps.EPlatform.Teachers.Storage.Entities;

namespace MoricApps.EPlatform.Teachers.Storage.Mappers
{
    public static class AssigmentMapper
    {
        public static TeacherAssigmentEntity? MapToEntity(this TeacherAssigment model)
        {
            if (model == null) return null;
            TeacherAssigmentEntity entity = new TeacherAssigmentEntity();
            entity.BeginDate = model.BeginDate;
            entity.EndDate = model.EndDate;
            return entity;
        }
        public static TeacherAssigment? MapToModel(this TeacherAssigmentEntity entity) 
        {
            if (entity == null) return null;
            TeacherAssigment model = new TeacherAssigment(entity.Id,entity.BeginDate, entity.EndDate);
            return model;
        }
    }
}
