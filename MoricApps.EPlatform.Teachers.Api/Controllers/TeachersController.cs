using Microsoft.AspNetCore.Mvc;
using MoricApps.EPlatform.Teachers.Contract;
using MoricApps.EPlatform.Teachers.Api.Mapper;
using MoricApps.EPlatform.Teachers.Api.Services;
using MoricApps.EPlatform.Teachers.Domain.Exeptions;

namespace MoricApps.EPlatform.Teachers.Api.Controllers
{
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
            

            var teachers = await _teacherService.GetTeachers(pageSize, pageNo);
            List<TeacherReturnDto> results = new List<TeacherReturnDto>();
            foreach( var teacher in teachers)
            {
                results.Add(teacher.MapToDto());
            }
            return Ok(results);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<TeacherReturnDto>> GetTeacher(int id)
        {
            var result = await _teacherService.GetTeacher(id);
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result.MapToDto());
        }

        [HttpPost]
        public async Task<ActionResult<TeacherReturnDto>> AddTeacher(TeacherInputDto teacher)
        {
            
            return Ok(await _teacherService.AddTeacher(teacher.MapToModel()));
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<TeacherReturnDto>> UpdateTeacher(int id, TeacherInputDto teacher)
        {
            var result = await _teacherService.UpdateTeacher(id, teacher.MapToModel());
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result.MapToDto());
        }

        [HttpPatch("{id}/deactivate")]
        public async Task<ActionResult<TeacherReturnDto>> DeactivateTeacher(int id)
        {
            try
            {
                var result = await _teacherService.DeactivateTeacher(id);
                if (result == null)
                {
                    return NotFound();
                }
                return Ok(result.MapToDto());
            }
            catch(TeacherDeactivateExeption ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPatch("{id}/reactivate")]
        public async Task<ActionResult<TeacherReturnDto>> ReactivateTeacher(int id)
        {
            var result = await _teacherService.ReactivateTeacher(id);
            if(result == null)
            {
                return NotFound();
            }
            return Ok(result.MapToDto());
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteTeacher(int id)
        {
            try
            {
                var result = await _teacherService.DeleteTeacher(id);
                if (result == null)
                {
                    return NotFound();
                }
                return NoContent();
            }
            catch(TeacherDeleteExeption ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
