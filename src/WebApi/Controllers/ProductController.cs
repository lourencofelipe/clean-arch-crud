using CleanArch.Application.Commands.Product.Command;
using CleanArch.Application.Queries.Product.Query;
using Microsoft.AspNetCore.Http.Extensions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MediatR;

namespace CleanArch.WebApi.Controllers;

[ApiController]
[Route("api/products")]
[ApiExplorerSettings(IgnoreApi = false)]
public class ProductController : Controller
{
	private IMediator _mediator;

	public ProductController(IMediator mediator)
	{
		_mediator = mediator;
	}

	[HttpGet]
	public IActionResult GetAll([FromQuery] ProductGetAllQuery query)
	{
		var response = _mediator.Send(query).Result;
		return Ok(response);
	}

	[HttpGet("{id}"), Authorize]
	public IActionResult GetProduct(Guid id)
	{
		var query = new ProductGetByIdQuery(id);

		var response = _mediator.Send(query);
		return Ok(response);
	}

	[HttpPost, Authorize]
	public IActionResult AddProduct(ProductCreateCommand command)
	{
		var response = _mediator.Send(command);
		return Created(HttpContext.Request.GetDisplayUrl(), response.Result);
	}

	[HttpPut("{id}"), Authorize]
	public IActionResult UpdateProduct(ProductUpdateCommand command)
	{
		var response = _mediator.Send(command);
		if (response.IsFaulted)
			return BadRequest(response.Exception.InnerException.Message);
		
		return Ok(response.Result);
	}

	[HttpDelete("{id}"), Authorize]
	public async Task<IActionResult> RemoveProduct(ProductDeleteCommand command) 
	{
		await _mediator.Send(command);
		
		return Ok();
	}
}
