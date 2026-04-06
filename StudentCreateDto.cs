using System.ComponentModel.DataAnnotations;

namespace StudentManagementAPI.DTOs;

public class StudentCreateDto
{
    [Required]
    public string Name { get; set; } = "";

    [EmailAddress]
    public string Email { get; set; } = "";

    [Range(1,100)]
    public int Age { get; set; }

    public string Course { get; set; } = "";
}
