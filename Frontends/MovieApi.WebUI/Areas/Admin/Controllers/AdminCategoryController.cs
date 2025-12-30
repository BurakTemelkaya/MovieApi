using Microsoft.AspNetCore.Mvc;
using MovieApi.Dto.Dtos.AdminMovieDtos;

namespace MovieApi.WebUI.Areas.Admin.Controllers;

public class AdminCategoryController : Controller
{
    private readonly IHttpClientFactory _httpClientFactory;

    public AdminCategoryController(IHttpClientFactory httpClientFactory)
    {
        _httpClientFactory = httpClientFactory;
    }

    public async Task<IActionResult> CategoryList()
    {
        var client = _httpClientFactory.CreateClient();

        var responseMessage = await client.GetAsync("https://localhost:7031/api/Categories");

        if (responseMessage.IsSuccessStatusCode)
        {
            List<AdminResultMovieDto>? values = await responseMessage.Content.ReadFromJsonAsync<List<AdminResultMovieDto>>();

            return View(values);
        }

        return View();
    }
}
