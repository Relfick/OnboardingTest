using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace OnboardingTest.Models;

public class City
{
    public int Id { get; set; }
    
    [Required]
    public string Name { get; set; }

    [JsonIgnore]
    public List<Employee> Employees { get; set; } = new();
}