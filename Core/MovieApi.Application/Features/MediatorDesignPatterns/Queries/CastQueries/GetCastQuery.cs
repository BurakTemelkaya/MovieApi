using MediatR;
using MovieApi.Application.Features.MediatorDesignPatterns.Results.CastResults;

namespace MovieApi.Application.Features.MediatorDesignPatterns.Queries.CastQueries;

public class GetCastQuery : IRequest<List<GetCastQueryResult>>
{
}