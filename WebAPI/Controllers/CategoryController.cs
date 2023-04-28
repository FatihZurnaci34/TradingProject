using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TradingProject.Business.Abstract;
using TradingProject.Entities.Dtos.Categories;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryService _categoryService;
        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }
        [Route("add")]
        [HttpPost]
        public IActionResult Create([FromBody] CreateCategoryDto createCategoryDto)
        {
            var result = _categoryService.Create(createCategoryDto);
            return Ok(result);
        }

        [Route("delete")]
        [HttpPost]
        public IActionResult Delete([FromBody] DeleteCategoryDto deleteCategoryDto)
        {
            var result = _categoryService.Delete(deleteCategoryDto);
            return Ok(result);
        }

        [Route("update")]
        [HttpPost]
        public IActionResult Update([FromBody] UpdateCategoryDto updateCategoryDto)
        {
            var result = _categoryService.Update(updateCategoryDto);
            return Ok(result);
        }

        
        [HttpGet("getbyid")]
        public IActionResult GetById( int id)
        {
            var result = _categoryService.GetById(id);
            return Ok(result);
        }
        [HttpGet("getlist")]
        public IActionResult GetList()
        {
            var result = _categoryService.GetList();
            return Ok(result);
        }
        
    }
}
