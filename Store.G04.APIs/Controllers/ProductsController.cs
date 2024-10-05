using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Store.G04.Core.Entities;
using Store.G04.Core.Services.Contract;

namespace Store.G04.APIs.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class ProductsController : ControllerBase
	{
		private readonly IProductService _productService;

		public ProductsController(IProductService productService)
        {
			_productService = productService;
		}


		[HttpGet] //Get BaseUrl/api/Products
		public async Task<IActionResult>  GetAllProducts() //End Point
		{
			var result = await _productService.GetAllProductsAsync();
			return Ok(result);

		}

		[HttpGet ("brands")]  //Get BaseUrl/api/Products/brands
		public async Task<IActionResult> GetAllBrands() //End Point
		{
			var result = await _productService.GetAllBrandsAsync();
			return Ok(result);
		}
		[HttpGet("types")]  //Get BaseUrl/api/Products/types
		public async Task<IActionResult> GetAllTypes() //End Point
		{
			var result = await _productService.GetAllTypesAsync();
			return Ok(result);
		}
		[HttpGet ("{id}")]  //Get BaseUrl/api/Products
		public async Task<IActionResult> GetProudctById(int? id)
		{
			if (id is null) return BadRequest("Invalid id !!");
			var result = await _productService.GetProductById(id.Value);

			if (result is null) return NotFound($"The  Product With Id : {id} not found ");
			return Ok(result);
		}
	}
}
