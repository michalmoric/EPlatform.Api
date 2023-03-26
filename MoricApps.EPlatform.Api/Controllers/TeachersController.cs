using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MoricApps.EPlatform.Application;
using MoricApps.EPlatform.Domain.Models;
using MoricApps.EPlatform.Dtos;

namespace MoricApps.EPlatform.Api.Controllers
{
    // Tutaj zwracam dane na zewnątrz
    [Route("api/teachers")]
    [ApiController]
    public class TeachersController : ControllerBase
    {
        private readonly ITeacherService _teacherService;
        public TeachersController(ITeacherService teacherService)
        {
            _teacherService = teacherService;
        }
        [HttpPost("/add")]
        public async Task<ActionResult<TeacherAddDto>> AddTeacherAction(Teacher teacher)
        {
            return Ok(await _teacherService.AddTeacher(teacher));
        }
    }
}
