using Microsoft.AspNetCore.Mvc;
using MovieApi.Dto.Dtos.UserRegisterDtos;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace MovieApi.WebUI.Controllers;

public class RegisterController : Controller
{
    private readonly IHttpClientFactory _httpClientFactory;

    public RegisterController(IHttpClientFactory httpClientFactory)
    {
        _httpClientFactory = httpClientFactory;
    }

    [HttpGet]
    public IActionResult SignUp()
    {
        return View();
    }
    [HttpPost]
    public async Task<IActionResult> SignUp(CreateUserRegisterDto createUserRegisterDto)
    {
        HttpClient client = _httpClientFactory.CreateClient();

        string jsonData = JsonSerializer.Serialize(createUserRegisterDto);

        StringContent stringContent = new(jsonData, Encoding.UTF8, "application/json");

        HttpResponseMessage response = await client.PostAsync("https://localhost:7031/api/Registers", stringContent);

        if (!response.IsSuccessStatusCode)
        {
            ViewBag.ErrorMessage = "Kayıt işlemi sırasında bir hata oluştu. Lütfen tekrar deneyiniz.";
            return View(createUserRegisterDto);
        }

        return RedirectToAction("SignIn", "Login");
    }
}
