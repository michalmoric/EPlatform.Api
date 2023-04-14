using MoricApps.EPlatform.Teachers.Contract;
using MoricApps.EPlatform.Teachers.Domain.Models;

namespace MoricApps.EPlatform.Teachers.Api.Mapper
{
    public static class TeacherContractDtoToModelMapper
    {
        public static Teacher? MapToModel(this TeacherInputDto dto)
        {
            List<TeacherAssigment> teacherAssigments = new List<TeacherAssigment>();
            if(dto == null)
            {
                return null;
            }
            foreach(var assigment in dto.Assigments)
            {
                teacherAssigments.Add(new TeacherAssigment(assigment.Id,assigment.BeginDate,assigment.EndDate));
            }
            return new Teacher(dto.FirstName,dto.LastName,dto.Email,dto.PhoneNumber,teacherAssigments);
        }
        public static TeacherReturnDto? MapToDto(this Teacher model) 
        {
            if(model == null)
            {
                return null;
            }
            List<AssigmentDto> assigmentDtos = new List<AssigmentDto>();
            foreach(var assigment in model.Assigments)
            {
                assigmentDtos.Add(new AssigmentDto()
                {
                    BeginDate = assigment.BeginDate,
                    EndDate = assigment.EndDate
                });
            }
            return new TeacherReturnDto
            {
                Id = model.Id,
                FirstName = model.FirstName,
                LastName = model.LastName,
                Email = model.Email,
                PhoneNumber = model.PhoneNumber,
                Status = model.Status,
                Assigments = assigmentDtos
 

            };
        }
    }
}
