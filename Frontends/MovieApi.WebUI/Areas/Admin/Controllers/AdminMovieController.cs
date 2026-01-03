using Microsoft.AspNetCore.Mvc;
using MovieApi.Dto.Dtos.AdminMovieDtos;

namespace MovieApi.WebUI.Areas.Admin.Controllers;

[Area("Admin")]
public class AdminMovieController : Controller
{
    private readonly IHttpClientFactory _httpClientFactory;

    public AdminMovieController(IHttpClientFactory httpClientFactory)
    {
        _httpClientFactory = httpClientFactory;
    }

    public async Task<IActionResult> MovieList(CancellationToken cancellationToken)
    {
        var client = _httpClientFactory.CreateClient();

        var responseMessage = await client.GetAsync("https://localhost:7031/api/Movies/GetMoviesWithCategory", cancellationToken);

        if (responseMessage.IsSuccessStatusCode)
        {
            List<AdminResultMovieDto>? values = await responseMessage.Content.ReadFromJsonAsync<List<AdminResultMovieDto>>(cancellationToken);

            return View(values);
        }

        return View();
    }

    [HttpGet]
    public IActionResult CreateMovie()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> CreateMovie(AdminCreateMovieDto createMovieDto, CancellationToken cancellationToken)
    {
        var client = _httpClientFactory.CreateClient();
        var responseMessage = await client.PostAsJsonAsync("https://localhost:7031/api/Movies", createMovieDto, cancellationToken);
        if (!responseMessage.IsSuccessStatusCode)
        {
            return View(createMovieDto);
        }
        return RedirectToAction(nameof(MovieList), new { area = "Admin" });
    }
}