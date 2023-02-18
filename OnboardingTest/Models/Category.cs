using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace OnboardingTest.Models;

public class Category
{
    public int Id { get; set; }
    
    [Required]
    public string Name { get; set; }

    [JsonIgnore]
    public List<Article> Articles { get; set; } = new();
}