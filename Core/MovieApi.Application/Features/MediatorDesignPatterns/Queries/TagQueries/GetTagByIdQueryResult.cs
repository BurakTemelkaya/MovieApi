using MediatR;
using MovieApi.Application.Features.MediatorDesignPatterns.Results.TagResults;

namespace MovieApi.Application.Features.MediatorDesignPatterns.Queries.TagQueries;

public class GetTagByIdQuery : IRequest<GetTagByIdQueryResult>
{
    public GetTagByIdQuery(int tagId)
    {
        TagId = tagId;
    }

    public int TagId { get; set; }
}