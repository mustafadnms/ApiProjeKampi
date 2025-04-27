using ApiProjeKampi.WebApi.Context;
using ApiProjeKampi.WebApi.Dtos.MessageDtos;
using ApiProjeKampi.WebApi.Entities;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ApiProjeKampi.WebApi.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class MessagesController : ControllerBase
	{
		private readonly IMapper _mapper;
		private readonly ApiContext _context;

		public MessagesController(ApiContext context, IMapper mapper)
		{
			_context = context;
			_mapper = mapper;
		}

		[HttpGet]
		public IActionResult MessageList()
		{
			var value = _context.Messages.ToList();
			return Ok(_mapper.Map<ResultMessageDto>(value));
		}

		[HttpPost]
		public IActionResult CreateMessage(CreateMessageDto createMessageDto)
		{
			var value = _mapper.Map<Message>(createMessageDto);
			_context.Messages.Add(value);
			_context.SaveChanges();
			return Ok("Ekleme Başarılı.");
		}

		[HttpDelete]
		public IActionResult DeleteMessage(int id)
		{
			var value = _context.Messages.Find(id);
			_context.Messages.Remove(value);
			_context.SaveChanges();
			return Ok("Silme Başarılı.");
		}

		[HttpGet("GetMessage")]
		public IActionResult GetMessage(int id)
		{
			var values = _context.Messages.Find(id);
			return Ok(_mapper.Map<GetByIdMessageDto>(values));
		}

		[HttpPut]
		public IActionResult UpdateMessage(UpdateMesaageDto updateMesaageDto)
		{
			var value = _mapper.Map<Message>(updateMesaageDto);
			_context.Messages.Update(value);
			_context.SaveChanges();
			return Ok("Güncelleme Başarılı."); 
		}

	}
}
