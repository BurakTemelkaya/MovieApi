using Microsoft.Extensions.DependencyInjection;
using MovieApi.Application.Features.MediatorDesignPatterns.Handlers.TagHandlers;

namespace MovieApi.Application.Extensions;

public static class MediatRExtensions
{
    public static IServiceCollection AddMediatorServices(this IServiceCollection services)
    {
        services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(GetTagQueryHandler).Assembly));

        return services;
    }
}