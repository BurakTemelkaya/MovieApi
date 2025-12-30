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

    public async Task<IActionResult> MovieList()
    {
        var client = _httpClientFactory.CreateClient();

        var responseMessage = await client.GetAsync("https://localhost:7031/api/Movies");

        if (responseMessage.IsSuccessStatusCode)
        {
            List<AdminResultMovieDto>? values = await responseMessage.Content.ReadFromJsonAsync<List<AdminResultMovieDto>>();

            return View(values);
        }

        return View();
    }
}