using MediatR;
using MovieApi.Application.Features.MediatorDesignPatterns.Results.CastResults;

namespace MovieApi.Application.Features.MediatorDesignPatterns.Queries.CastQueries;

public class GetCastByIdQuery:IRequest<GetCastByIdQueryResult>
{
    public GetCastByIdQuery(int castId)
    {
        CastId = castId;
    }

    public int CastId { get; set; }
}