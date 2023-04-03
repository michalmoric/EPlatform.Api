﻿using MoricApps.EPlatform.Teachers.Domain.Models;

namespace MoricApps.EPlatform.Teachers.Api.Repositories
{
    public interface ITeacherRepository
    {
        Task<Teacher> AddTeacherAsync(Teacher teacher);

        Task<List<Teacher>> GetTeachersAsync(int pageSize, int pageNo);

        Task<Teacher?> GetTeacherAsync(int Id);

        Task<Teacher> UpdateTeacherAsync(int Id, Teacher teacher);

        //Task<Teacher> DisactivateTeacherAsync(int Id);

        //Task<Teacher> ReactivateTeacherAsync(int Id);

        //Task<Teacher> DeleteTeacherAsync(int Id);
        //Task<IEnumerable<TeacherAssigment>?> GetAssigmentsAsync(int Id);
    }
}