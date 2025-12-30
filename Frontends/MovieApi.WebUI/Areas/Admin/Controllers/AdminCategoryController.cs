using Microsoft.AspNetCore.Mvc;
using MovieApi.Dto.Dtos.AdminCategoryDtos;

namespace MovieApi.WebUI.Areas.Admin.Controllers;

[Area("Admin")]
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
            List<AdminResultCategoryDto>? values = await responseMessage.Content.ReadFromJsonAsync<List<AdminResultCategoryDto>>();

            return View(values);
        }

        return View();
    }

    [HttpGet]
    public IActionResult CreateCategory()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> CreateCategory(AdminCreateCategoryDto createCategoryDto)
    {
        var client = _httpClientFactory.CreateClient();

        var responseMessage = await client.PostAsJsonAsync("https://localhost:7031/api/Categories", createCategoryDto);

        if (!responseMessage.IsSuccessStatusCode)
        {
            return View(createCategoryDto);
        }

        return RedirectToAction(nameof(CategoryList));
    }

}
