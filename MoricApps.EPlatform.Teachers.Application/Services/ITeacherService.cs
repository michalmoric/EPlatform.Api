using MoricApps.EPlatform.Teachers.Contract;
using MoricApps.EPlatform.Teachers.Domain.Models;

namespace MoricApps.EPlatform.Teachers.Application.Services
{
    public interface ITeacherService
    {
        Task<TeacherReturnDto> AddTeacher(Teacher teacher);
        Task<TeacherReturnDto> DeactivateTeacher(int id);
        Task<TeacherReturnDto> DeleteTeacher(int id);
        Task<TeacherReturnDto> GetTeacher(int id);
        Task<List<TeacherReturnDto>> GetTeachers(int pageSize, int pageNo);
        Task<TeacherReturnDto> ModifyTeacher(int id, Teacher teacher);
        Task<TeacherReturnDto> ReactivateTeacher(int id);
    }
}