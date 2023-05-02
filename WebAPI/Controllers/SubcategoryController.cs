using Core.DataAccess.Request;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TradingProject.Business.Abstract;
using TradingProject.Entities.Dtos.Categories;
using TradingProject.Entities.Dtos.Subcategories;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SubcategoryController : ControllerBase
    {
        private readonly ISubcategoryService _subcategoryService;

        public SubcategoryController(ISubcategoryService subcategoryService)
        {
            _subcategoryService = subcategoryService;
        }

        [Route("add")]
        [HttpPost]
        public IActionResult Create([FromBody] CreateSubcategoryDto createSubcategoryDto)
        {
            var result = _subcategoryService.Create(createSubcategoryDto);
            return Ok(result);
        }

        [HttpPost("delete")]
        public IActionResult Delete([FromBody]DeleteSubcategoryDto deleteSubcategoryDto)
        {
            var result = _subcategoryService.Delete(deleteSubcategoryDto);
            return Ok(result);
        }

        [HttpPost("update")]
        public IActionResult Update([FromBody] UpdateSubcategoryDto updateSubcategoryDto)
        {
            var result = _subcategoryService.Update(updateSubcategoryDto);
            return Ok(result);
        }

        [HttpGet("getbyid")]
        public async Task<IActionResult> GetById(int id)
        {
            var result = await _subcategoryService.GetById(id);
            return Ok(result);
        }

        [HttpGet("getlist")]
        public async Task<IActionResult> GetList([FromQuery] PageRequest pageRequest)
        {
            var result = await _subcategoryService.GetList(pageRequest);
            return Ok(result);
        }

    }
}
