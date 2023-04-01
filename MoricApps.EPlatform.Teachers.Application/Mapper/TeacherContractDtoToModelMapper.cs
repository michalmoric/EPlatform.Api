using MoricApps.EPlatform.Teachers.Contract;
using MoricApps.EPlatform.Teachers.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace MoricApps.EPlatform.Teachers.Application.Mapper
{
    public static class TeacherContractDtoToModelMapper
    {
        public static Teacher MapToModel(this TeacherInputDto dto)
        {
            return new Teacher(dto.FirstName,dto.LastName,dto.Email,dto.PhoneNumber,dto.Assigments);
        }
        public static TeacherReturnDto MapToDto(this Teacher model) 
        {
            return new TeacherReturnDto
            {
                Id = model.Id,
                FirstName = model.FirstName,
                LastName = model.LastName,
                Email = model.Email,
                PhoneNumber = model.PhoneNumber,
                Status = model.Status
            };
        }
    }
}
