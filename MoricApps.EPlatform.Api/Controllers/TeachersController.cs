using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MoricApps.EPlatform.Application;
using MoricApps.EPlatform.Domain.Models;

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
        public async Task<ActionResult<Teacher>> AddTeacherAction(Teacher teacher)
        {
            await _teacherService.AddTeacher(teacher);
            return Ok(teacher);
        }
    }
}
