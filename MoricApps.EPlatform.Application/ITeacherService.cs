using MoricApps.EPlatform.Domain.Models;
using MoricApps.EPlatform.Dtos;

namespace MoricApps.EPlatform.Application
{
    public interface ITeacherService
    {
        Task<TeacherAddDto> AddTeacher(Teacher teacher);
        Task DeactivateTeacher(int id);
        Task DeleteTeacher(int id);
        Task<TeacherGetDto> GetTeacher(int id);
        Task<List<TeacherGetDto>> GetTeachers(int pageSize, int pageNo);
        Task ModifyTeacher(int id);
        Task ReactivateTeacher(int id);
    }
}