using MoricApps.EPlatform.Domain.Models;

namespace MoricApps.EPlatform.Contexts
{
    public interface ITeacherRepository
    {
        Task<Teacher> AddTeacherAsync(Teacher teacher);
    }
}