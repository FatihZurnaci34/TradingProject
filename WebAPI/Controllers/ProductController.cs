using Core.DataAccess.Request;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TradingProject.Business.Abstract;
using TradingProject.Entities.Dtos.Products;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpPost("add")]
        public async Task<IActionResult> Create([FromBody] CreateProductDto createProductDto)
        {
            var result = await _productService.Create(createProductDto);
            return Ok(result);
        }

        [HttpPost("delete")]
        public async Task<IActionResult> Delete([FromBody] DeleteProductDto deleteProductDto)
        {
            var result = await _productService.Delete(deleteProductDto);
            return Ok(result);
        }

        [HttpPost("update")]
        public async Task<IActionResult> Update([FromBody] UpdateProductDto  updateProductDto)
        {
            var result = await _productService.Update(updateProductDto);
            return Ok(result);
        }

        [HttpGet("getbyid")]
        public async Task<IActionResult> GetById(int id)
        {
            var result = await _productService.GetById(id);
            return Ok(result);
        }

        [HttpGet("getlist")]
        public async Task<IActionResult> GetList([FromQuery] PageRequest pageRequest)
        {
            var result = await _productService.GetList(pageRequest);
            return Ok(result);
        }
    }
}
