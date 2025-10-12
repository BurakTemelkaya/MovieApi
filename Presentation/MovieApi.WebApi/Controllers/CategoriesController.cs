using Microsoft.AspNetCore.Mvc;
using MovieApi.Application.Features.CQRSDesingPatterns.Commands.CategoryCommands;
using MovieApi.Application.Features.CQRSDesingPatterns.Handlers.CategoryHandlers;
using MovieApi.Application.Features.CQRSDesingPatterns.Queries.CategoryQueries;
using MovieApi.Application.Features.CQRSDesingPatterns.Result.CategoryResults;

namespace MovieApi.WebApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CategoriesController : ControllerBase
{
    private readonly GetCategoryQueryHandler _getCategoryQueryHandler;
    private readonly GetCategoryByIdQueryHandler _getCategoryByIdQueryHandler;
    private readonly CreateCategoryCommandHandler _createCategoryCommandHandler;
    private readonly UpdateCategoryCommandHandler _updateCategoryCommandHandler;
    private readonly RemoveCategoryCommandHandler _removeCategoryCommandHandler;

    public CategoriesController(GetCategoryQueryHandler getCategoryQueryHandler, GetCategoryByIdQueryHandler getCategoryByIdQueryHandler, CreateCategoryCommandHandler createCategoryCommandHandler, UpdateCategoryCommandHandler updateCategoryCommandHandler, RemoveCategoryCommandHandler removeCategoryCommandHandler)
    {
        _getCategoryQueryHandler = getCategoryQueryHandler;
        _getCategoryByIdQueryHandler = getCategoryByIdQueryHandler;
        _createCategoryCommandHandler = createCategoryCommandHandler;
        _updateCategoryCommandHandler = updateCategoryCommandHandler;
        _removeCategoryCommandHandler = removeCategoryCommandHandler;
    }

    [HttpGet]

    public async Task<IActionResult> CategoryList(CancellationToken cancellationToken = default)
    {
        List<GetCategoryQueryResult> value = await _getCategoryQueryHandler.Handle(cancellationToken);

        return Ok(value);
    }

    [HttpPost]
    public async Task<IActionResult> CreateCategory([FromBody] CreateCategoryCommand command, CancellationToken cancellationToken = default)
    {
        await _createCategoryCommandHandler.Handle(command, cancellationToken);
        return Ok("Kategori ekleme işlemi başarılı.");
    }

    [HttpDelete]
    public async Task<IActionResult> DeleteCategory(int categoryId, CancellationToken cancellationToken = default)
    {
        await _removeCategoryCommandHandler.Handle(new RemoveCategoryCommand(categoryId), cancellationToken);
        return Ok("Kategori silme işlemi başarılı.");
    }

    [HttpPut]
    public async Task<IActionResult> UpdateCategory([FromBody] UpdateCategoryCommand command, CancellationToken cancellationToken = default)
    {
        await _updateCategoryCommandHandler.Handle(command, cancellationToken);
        return Ok("Kategori güncelleme işlemi başarılı.");
    }

    [HttpGet("GetCategoryById")]
    public async Task<IActionResult> GetCategoryById(int categoryId, CancellationToken cancellationToken = default)
    {
        GetCategoryQueryResult value = await _getCategoryByIdQueryHandler.Handle(new GetCategoryByIdQuery(categoryId), cancellationToken);
        return Ok(value);
    }
}