using MoricApps.EPlatform.Teachers.Contract;
using MoricApps.EPlatform.Teachers.Domain.Models;

namespace MoricApps.EPlatform.Teachers.Storage
{
    public interface ITeacherService
    {
        Task<TeacherReturnDto> AddTeacher(TeacherInputDto teacher);
        Task<TeacherReturnDto> DeactivateTeacher(int id);
        Task<TeacherReturnDto> DeleteTeacher(int id);
        Task<TeacherReturnDto> GetTeacher(int id);
        Task<List<TeacherReturnDto>> GetTeachers(int pageSize, int pageNo);
        Task<TeacherReturnDto> ModifyTeacher(int id, TeacherInputDto teacher);
        Task<TeacherReturnDto> ReactivateTeacher(int id);
    }
}