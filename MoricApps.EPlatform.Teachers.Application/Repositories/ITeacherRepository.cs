using MoricApps.EPlatform.Teachers.Domain.Models;

namespace MoricApps.EPlatform.Teachers.Api.Repositories
{
    public interface ITeacherRepository
    {
        Task<Teacher?> AddTeacherAsync(Teacher teacher);

        Task<List<Teacher>> GetTeachersAsync(int pageSize, int pageNo);

        Task<Teacher?> GetTeacherAsync(int Id);

        Task<Teacher?> UpdateTeacherAsync(int Id, Teacher teacher);

    }
}