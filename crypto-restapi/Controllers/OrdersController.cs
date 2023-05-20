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
	public class OrdersController : ControllerBase
	{
		
		private readonly cryptocurrency_integrationContext _context;
		public IConfiguration _configuration;

		private string API_Key = "22C2E08B-5338-4B6A-A611-24181C76FFB2";

		public OrdersController(cryptocurrency_integrationContext context, IConfiguration config)
		{
			_context = context;
			_configuration = config;
		}

		[HttpGet]
		public IActionResult GetAllCurrentExchangeRates()
		{
			var client = new RestClient("http://rest-sandbox.coinapi.io/v1/orderbooks/current?limit_levels=10");
			var request = new RestRequest(Method.GET);
			request.AddHeader("X-CoinAPI-Key", API_Key);
			IRestResponse response = client.Execute(request);

			return Ok(response.Content);
		}

	}
}
