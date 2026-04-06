using StudentManagementAPI.DTOs;

namespace StudentManagementAPI.Services;

public interface IStudentService
{
    Task<IEnumerable<StudentResponseDto>> GetAllAsync();
    Task AddAsync(StudentCreateDto dto);
    Task UpdateAsync(int id, StudentCreateDto dto);
    Task DeleteAsync(int id);
}
