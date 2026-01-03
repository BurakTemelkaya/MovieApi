using Microsoft.AspNetCore.Mvc;
using MovieApi.Dto.Dtos.AdminDtos.AdminSeriesDtos;

namespace SeriesApi.WebUI.Areas.Admin.Controllers;

[Area("Admin")]
public class AdminSeriesController : Controller
{
    private readonly IHttpClientFactory _httpClientFactory;

    public AdminSeriesController(IHttpClientFactory httpClientFactory)
    {
        _httpClientFactory = httpClientFactory;
    }

    public async Task<IActionResult> SeriesList(CancellationToken cancellationToken)
    {
        var client = _httpClientFactory.CreateClient();

        var responseMessage = await client.GetAsync("https://localhost:7031/api/Serieses", cancellationToken);

        if (responseMessage.IsSuccessStatusCode)
        {
            List<AdminResultSeriesDto>? values = await responseMessage.Content.ReadFromJsonAsync<List<AdminResultSeriesDto>>(cancellationToken);

            return View(values);
        }

        return View();
    }

    [HttpGet]
    public IActionResult CreateSeries()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> CreateSeries(AdminCreateSeriesDto createSeriesDto, CancellationToken cancellationToken)
    {
        var client = _httpClientFactory.CreateClient();
        var responseMessage = await client.PostAsJsonAsync("https://localhost:7031/api/Serieses", createSeriesDto, cancellationToken);
        if (!responseMessage.IsSuccessStatusCode)
        {
            return View(createSeriesDto);
        }
        return RedirectToAction(nameof(SeriesList), new { area = "Admin" });
    }
}
