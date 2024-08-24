using System;

namespace test_dotnet_app.DTO;

public class BaseDto
{
    public DateTime CreatedAt { get; set; } = DateTime.Now;
    public DateTime UpdatedAt { get; set; } = DateTime.Now;

    public BaseDto(DateTime createdAt, DateTime updatedAt)
    {
        CreatedAt = createdAt;
        UpdatedAt = updatedAt;
    }
}
