using MediatR;
using MovieApi.Application.Features.MediatorDesignPatterns.Results.TagResults;

namespace MovieApi.Application.Features.MediatorDesignPatterns.Queries.TagQueries;

public class GetTagQuery : IRequest<List<GetTagQueryResult>>
{
}