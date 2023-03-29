using MoricApps.EPlatform.Domain.Models;

namespace MoricApps.EPlatform.Contexts
{
    public interface ITeacherRepository
    {
        Task<Teacher> AddTeacherAsync(Teacher teacher);

        Task<List<Teacher>> GetTeachersAsync(int pageSize, int pageNo);

        Task<Teacher?> GetTeacherAsync(int Id);

        Task<Teacher> ModyfyTeacherAsync(int Id, Teacher teacher);

        Task<Teacher> DisactivateTeacherAsync(int Id);
        Task<IEnumerable<TeacherAssigment>?> GetAssigmentsAsync(int Id);
    }
}