using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MoricApps.EPlatform.Teachers.Storage;
using MoricApps.EPlatform.Teachers.Domain.Models;
using MoricApps.EPlatform.Teachers.Contract;
using MoricApps.EPlatform.Teachers.Application.Mapper;

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
        public async Task<ActionResult<List<TeacherReturnDto>>> GetTeachers([FromQuery] int pageSize, [FromQuery] int pageNo)
        {
            if (pageSize <= 0 && pageNo <= 0)
            {
                return BadRequest();
            }

            return Ok(await _teacherService.GetTeachers(pageSize, pageNo));
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<TeacherReturnDto>> GetTeacher(int id)
        {
            var result = await _teacherService.GetTeacher(id);
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }
        [HttpPost]
        public async Task<ActionResult<TeacherReturnDto>> AddTeacher(TeacherInputDto teacher)
        {
            
            return Ok(await _teacherService.AddTeacher(teacher.MapToModel()));
        }
        [HttpPut("{id}")]
        public async Task<ActionResult<TeacherReturnDto>> ModyfyTeacher(int id, TeacherInputDto teacher)
        {
            var result = await _teacherService.ModifyTeacher(id, teacher.MapToModel());
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
        [HttpPatch("{id}/reactivate")]
        public async Task<ActionResult<TeacherReturnDto>> ReactivateTeacher(int id)
        {
            var result = await _teacherService.ReactivateTeacher(id);
            if(result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteTeacher(int id)
        {
            var result = await _teacherService.DeleteTeacher(id);
            if(result == null)
            {
                return NotFound();
            }
            return NoContent();
        }
    }
}
