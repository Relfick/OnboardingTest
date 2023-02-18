using System.Runtime.Serialization;

namespace OnboardingTest.Models;

public class Article
{
    public int Id { get; set; }
    
    public string Title { get; set; }

    public string Text { get; set; }
    
    // public virtual int CategoryId { get; set; }
    public virtual Category Category { get; set; }
}