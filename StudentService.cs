using StudentManagementAPI.DTOs;
using StudentManagementAPI.Models;
using StudentManagementAPI.Repositories;

namespace StudentManagementAPI.Services;

public class StudentService : IStudentService
{
    private readonly IStudentRepository _repo;
    public StudentService(IStudentRepository repo) { _repo = repo; }

    public async Task<IEnumerable<StudentResponseDto>> GetAllAsync()
    {
        var data = await _repo.GetAllAsync();
        return data.Select(s => new StudentResponseDto
        {
            Id = s.Id,
            Name = s.Name,
            Email = s.Email,
            Age = s.Age,
            Course = s.Course
        });
    }

    public async Task AddAsync(StudentCreateDto dto)
    {
        var s = new Student
        {
            Name = dto.Name,
            Email = dto.Email,
            Age = dto.Age,
            Course = dto.Course
        };
        await _repo.AddAsync(s);
    }

    public async Task UpdateAsync(int id, StudentCreateDto dto)
    {
        var s = await _repo.GetByIdAsync(id);
        if (s == null) throw new Exception("Student not found");

        s.Name = dto.Name;
        s.Email = dto.Email;
        s.Age = dto.Age;
        s.Course = dto.Course;

        await _repo.UpdateAsync(s);
    }

    public async Task DeleteAsync(int id)
    {
        await _repo.DeleteAsync(id);
    }
}
