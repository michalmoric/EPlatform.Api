using MoricApps.EPlatform.Teachers.Contract;
using MoricApps.EPlatform.Teachers.Domain.Models;

namespace MoricApps.EPlatform.Teachers.Application.Mapper
{
    public static class TeacherContractDtoToModelMapper
    {
        public static Teacher MapToModel(this TeacherInputDto dto)
        {
            List<TeacherAssigment> temp = new List<TeacherAssigment>();
            foreach(var assigment in dto.Assigments)
            {
                temp.Add(new TeacherAssigment(assigment.Id,assigment.BeginDate,assigment.EndDate));
            }
            return new Teacher(dto.FirstName,dto.LastName,dto.Email,dto.PhoneNumber,temp);
        }
        public static TeacherReturnDto MapToDto(this Teacher model) 
        {
            List<AssigmentDto> temp = new List<AssigmentDto>();
            foreach(var assigment in model.Assigments)
            {
                temp.Add(new AssigmentDto()
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
                Assigments = temp
 

            };
        }
    }
}
