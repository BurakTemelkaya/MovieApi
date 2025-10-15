using Microsoft.AspNetCore.Identity;
using MovieApi.Application.Features.CQRSDesingPatterns.Commands.UserRegisterCommands;
using MovieApi.Persistence.Context;
using MovieApi.Persistence.Identity;

namespace MovieApi.Application.Features.CQRSDesingPatterns.Handlers.UserRegisterHandlers;

public class CreateUserRegisterCommandHandler
{
    private readonly MovieContext _context;
    private readonly UserManager<AppUser> _userManager;

    public CreateUserRegisterCommandHandler(MovieContext context, UserManager<AppUser> signInManager)
    {
        _context = context;
        _userManager = signInManager;
    }

    public async Task Handle(CreateUserRegisterCommand command)
    {
        AppUser user = new()
        {
            FirstName = command.FirstName,
            LastName = command.Surname,
            UserName = command.UserName,
            Email = command.Email
        };

        IdentityResult result = await _userManager.CreateAsync(user, command.Password);
    }
}