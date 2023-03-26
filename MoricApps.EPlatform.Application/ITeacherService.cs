using MoricApps.EPlatform.Domain.Models;

namespace MoricApps.EPlatform.Application
{
    public interface ITeacherService
    {
        Task AddTeacher(Teacher teacher);
        Task DeactivateTeacher(int id);
        Task DeleteTeacher(int id);
        Task GetTeacher(int id);
        Task GetTeachers();
        Task ModifyTeacher(int id);
        Task ReactivateTeacher(int id);
    }
}