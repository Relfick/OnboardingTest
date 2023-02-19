using Microsoft.AspNetCore.Mvc;

namespace OnboardingTest.Models;

public class TelegramCredentials
{
    [FromHeader]
    public long Id { get; set; }
    
    [FromHeader]
    public string Username { get; set; }
}