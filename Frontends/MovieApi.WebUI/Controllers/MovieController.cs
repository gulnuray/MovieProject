using Microsoft.AspNetCore.Mvc;
using MovieApi.Dto.Dtos.MovieDtos;
using Newtonsoft.Json;

namespace MovieApi.WebUI.Controllers
{
	public class MovieController : Controller
	{
		private readonly IHttpClientFactory _httpClientFactory;
		

		public MovieController(IHttpClientFactory httpClientFactory)
		{
			_httpClientFactory = httpClientFactory;
		}

		public async Task<IActionResult> MovieList()
		{
			ViewBag.v1 = "Film Listesi";
			ViewBag.v2 = "Ana Sayfa";
			ViewBag.v3 = "Tüm Filmler";

			var client = _httpClientFactory.CreateClient("MovieApi");

			try
			{
				var responseMessage = await client.GetAsync("api/Movies");
				if (responseMessage.IsSuccessStatusCode)
				{
					var jsonData = await responseMessage.Content.ReadAsStringAsync();
					var values = JsonConvert.DeserializeObject<List<ResultMovieDto>>(jsonData) ?? [];
					ViewBag.MovieCount = values.Count;
					return View(values);
				}

				ViewBag.ApiError = "Film listesi API'den alınamadı.";
			}
			catch (HttpRequestException)
			{
				ViewBag.ApiError = "Film listesini görmek için MovieApi.WebApi projesi de çalışıyor olmalı.";
			}

			ViewBag.MovieCount = 0;
			return View(new List<ResultMovieDto>());
		}
	}
}
