using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using StudentManagementAPI.DTOs;
using StudentManagementAPI.Services;

namespace StudentManagementAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
[Authorize]
public class StudentController : ControllerBase
{
    private readonly IStudentService _service;
    public StudentController(IStudentService service) { _service = service; }

    [HttpGet]
    public async Task<IActionResult> Get() => Ok(await _service.GetAllAsync());

    [HttpPost]
    public async Task<IActionResult> Post(StudentCreateDto dto)
    {
        await _service.AddAsync(dto);
        return Ok("Created");
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Put(int id, StudentCreateDto dto)
    {
        await _service.UpdateAsync(id, dto);
        return Ok("Updated");
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        await _service.DeleteAsync(id);
        return Ok("Deleted");
    }
}
