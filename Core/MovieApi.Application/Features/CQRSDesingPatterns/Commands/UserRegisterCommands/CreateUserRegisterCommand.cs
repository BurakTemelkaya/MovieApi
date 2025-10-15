namespace MovieApi.Application.Features.CQRSDesingPatterns.Commands.UserRegisterCommands;

public class CreateUserRegisterCommand
{
    public string FirstName { get; set; }
    public string Surname { get; set; }
    public string UserName { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
}