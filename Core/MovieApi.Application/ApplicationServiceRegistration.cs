using Microsoft.Extensions.DependencyInjection;
using MovieApi.Application.Features.CQRSDesingPatterns.Handlers.CategoryHandlers;
using MovieApi.Application.Features.CQRSDesingPatterns.Handlers.MovieHandlers;
using MovieApi.Application.Features.CQRSDesingPatterns.Handlers.SeriesHandlers;
using MovieApi.Application.Features.CQRSDesingPatterns.Handlers.UserRegisterHandlers;

namespace MovieApi.Application;

public static class ApplicationServiceRegistration
{
    public static IServiceCollection AddApplicationServices(this IServiceCollection services)
    {
        services.AddScoped<GetCategoryQueryHandler>();
        services.AddScoped<GetCategoryByIdQueryHandler>();
        services.AddScoped<CreateCategoryCommandHandler>();
        services.AddScoped<UpdateCategoryCommandHandler>();
        services.AddScoped<RemoveCategoryCommandHandler>();

        services.AddScoped<GetMovieQueryHandler>();
        services.AddScoped<GetMovieByIdQueryHandler>();
        services.AddScoped<CreateMovieCommandHandler>();
        services.AddScoped<UpdateMovieCommandHandler>();
        services.AddScoped<RemoveMovieCommandHandler>();

        services.AddScoped<GetSeriesQueryHandler>();
        services.AddScoped<GetSeriesByIdQueryHandler>();
        services.AddScoped<CreateSeriesCommandHandler>();
        services.AddScoped<RemoveSeriesCommandHandler>();
        services.AddScoped<UpdateSeriesCommandHandler>();

        services.AddScoped<CreateUserRegisterCommandHandler>();

        return services;
    }
}
