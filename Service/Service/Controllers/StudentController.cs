using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Service.Model;
using Service.Services;

namespace Service.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {

        private readonly IStudentService _studentService;

        public StudentController(IStudentService studentService)
        {
            _studentService = studentService;
        }

        // GET student
        /// <summary>
        /// Para retornar un estado de la peticion 
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> Get()
        {

            return Ok(
                await _studentService.GetAllAsync()
            );
        }

        // GET student/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            return Ok(
               await _studentService.GetAsync(id)
           );
        }

        // POST student
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Student model)
        {
            return Ok(
              await _studentService.AddAsync(model)
          );
        }

        // PUT student/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] Student model)
        {
            return Ok(
                 await _studentService.UpdateAsync(model)
            );
        }

        // DELETE student/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            return Ok(
               await _studentService.DeleteAsync(id)
            );
        }
    }
}
