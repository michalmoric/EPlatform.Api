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
        [HttpGet]
        public async Task<ActionResult<List<TeacherGetDto>>> GetTeachersAction([FromQuery] int pageSize, [FromQuery] int pageNo)
        {
            if (pageSize <= 0 && pageNo <= 0) 
            {
                return BadRequest();
            }
            
            return Ok(await _teacherService.GetTeachers(pageSize,pageNo));
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<TeacherGetDto>> GetTeacherAction(int id)
        {
            var result = await _teacherService.GetTeacher(id);
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }
        [HttpPost("add")]
        public async Task<ActionResult<TeacherAddDto>> AddTeacherAction(Teacher teacher)
        {
            return Ok(await _teacherService.AddTeacher(teacher));
        }
    }
}
