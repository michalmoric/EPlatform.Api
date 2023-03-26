using MoricApps.EPlatform.Domain.Models;

namespace MoricApps.EPlatform.Contexts
{
    public interface ITeacherRepository
    {
        Task AddTeacherAsync(Teacher teacher);
    }
}