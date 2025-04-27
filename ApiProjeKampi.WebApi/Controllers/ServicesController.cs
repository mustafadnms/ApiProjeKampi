using ApiProjeKampi.WebApi.Context;
using ApiProjeKampi.WebApi.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ApiProjeKampi.WebApi.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class ServicesController : ControllerBase
	{
		private readonly ApiContext _context;

		public ServicesController(ApiContext context)
		{
			_context = context;
		}

		[HttpPost]
		public IActionResult CreateService(Service service)
		{
			_context.Services.Add(service);
			_context.SaveChanges();
			return Ok("Hizmet ekleme işlemi başarılı.");
		}

		[HttpGet]
		public IActionResult ServiceList()
		{
			var values = _context.Services.ToList();
			return Ok(values);
		}

		[HttpDelete]
		public IActionResult DeleteService(int id)
		{
			var value = _context.Services.Find(id);
			_context.Services.Remove(value);
			_context.SaveChanges();
			return Ok("Hizmet silme işlemi başarılı.");
		}

		[HttpGet("GetService")]
		public IActionResult GetService(int id)
		{
			var value = _context.Services.Find(id);
			return Ok(value);
		}

		[HttpPut]
		public IActionResult UpdateService(Service service)
		{
			_context.Services.Update(service);
			_context.SaveChanges();
			return Ok("Hizmet güncelleme işlemi başarılı.");
		}
	}
}
