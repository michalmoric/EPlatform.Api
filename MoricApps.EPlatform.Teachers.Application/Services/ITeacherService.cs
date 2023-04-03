using MoricApps.EPlatform.Teachers.Domain.Models;

namespace MoricApps.EPlatform.Teachers.Application.Services
{
    public interface ITeacherService
    {
        Task<Teacher> AddTeacher(Teacher teacher);
        Task<Teacher> DeactivateTeacher(int id);
        Task<Teacher> DeleteTeacher(int id);
        Task<Teacher> GetTeacher(int id);
        Task<List<Teacher>> GetTeachers(int pageSize, int pageNo);
        Task<Teacher> UpdateTeacher(int id, Teacher teacher);
        Task<Teacher> ReactivateTeacher(int id);
    }
}