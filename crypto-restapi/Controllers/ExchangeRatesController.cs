using crypto_restapi.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace crypto_restapi.Controllers
{
	[Microsoft.AspNetCore.Authorization.Authorize]
	[Route("[controller]")]
	[ApiController]
	public class ExchangeRatesController : ControllerBase
	{

		private readonly cryptocurrency_integrationContext _context;
		public IConfiguration _configuration;

		private string API_Key= "1762844B-20CA-4136-A9C3-60D44BEACA8B";

		public ExchangeRatesController(cryptocurrency_integrationContext context, IConfiguration config)
		{
			_context = context;
			_configuration = config;
		}

		[HttpGet]
		public IActionResult GetAllCurrentExchangeRates()
		{
			var client = new RestClient("http://rest-sandbox.coinapi.io/v1/exchangerate/BTC?invert=false");
			var request = new RestRequest(Method.GET);
			request.AddHeader("X-CoinAPI-Key", API_Key);
			IRestResponse response = client.Execute(request);

			return Ok(response.Content);
		}

		[HttpGet("{id}")]
		public IActionResult GetAllCurrentExchangeRates(string id)
		{
			var client = new RestClient("http://rest-sandbox.coinapi.io/v1/exchangerate/BTC/" + id + "");
			var request = new RestRequest(Method.GET);
			request.AddHeader("X-CoinAPI-Key", API_Key);
			IRestResponse response = client.Execute(request);

			return Ok(response.Content);
		}
		
	}
}
