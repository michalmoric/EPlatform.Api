using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MoricApps.EPlatform.Teachers.Storage;
using MoricApps.EPlatform.Teachers.Domain.Models;
using MoricApps.EPlatform.Teachers.Contract;

namespace MoricApps.EPlatform.Teachers.Api.Controllers
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
        public async Task<ActionResult<List<TeacherReturnDto>>> GetTeachersAction([FromQuery] int pageSize, [FromQuery] int pageNo)
        {
            if (pageSize <= 0 && pageNo <= 0)
            {
                return BadRequest();
            }

            return Ok(await _teacherService.GetTeachers(pageSize, pageNo));
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<TeacherReturnDto>> GetTeacherAction(int id)
        {
            var result = await _teacherService.GetTeacher(id);
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }
        [HttpPost("add")]
        public async Task<ActionResult<TeacherReturnDto>> AddTeacherAction(TeacherInputDto teacher)
        {
            return Ok(await _teacherService.AddTeacher(teacher));
        }
        [HttpPut("{id}")]
        public async Task<ActionResult<TeacherReturnDto>> ModyfyTeacherAction(int id, TeacherInputDto teacher)
        {
            var result = await _teacherService.ModifyTeacher(id, teacher);
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }
        [HttpPatch("{id}/deactivate")]
        public async Task<ActionResult<TeacherReturnDto>> DeactivateTeacher(int id)
        {
            var result = await _teacherService.DeactivateTeacher(id);
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }
    }
}
