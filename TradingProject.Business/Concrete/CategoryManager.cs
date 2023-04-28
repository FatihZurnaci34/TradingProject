using AutoMapper;
using Core.Utilities.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TradingProject.Business.Abstract;
using TradingProject.DataAccess.Abstract;
using TradingProject.Entities.Concrete;
using TradingProject.Entities.Dtos.Categories;
using TradingProject.Entities.Models.Categories;

namespace TradingProject.Business.Concrete
{
    public class CategoryManager : ICategoryService
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly IMapper _mapper;

        public CategoryManager(ICategoryRepository categoryRepository, IMapper mapper)
        {
            _categoryRepository = categoryRepository;
            _mapper = mapper;
        }

        public Category Create(CreateCategoryDto createCategoryDto)
        {
            Category mappedCategory = _mapper.Map<Category>(createCategoryDto);
            _categoryRepository.Add(mappedCategory);
            return mappedCategory;
        }

        public Category Delete(DeleteCategoryDto deleteCategoryDto)
        {
            Category mappedCategory = _mapper.Map<Category>(deleteCategoryDto);
            _categoryRepository.Delete(mappedCategory);
            return mappedCategory;
            
        }

        public CategoryGetByIdDto GetById(int id)
        {
            Category category = _categoryRepository.Get(c=>c.Id==id);
            CategoryGetByIdDto categoryGetByIdDto = _mapper.Map<CategoryGetByIdDto>(category);
            return categoryGetByIdDto;
        }

        public List<CategoryListDto> GetList()
        {
            List<Category> category = _categoryRepository.GetAll();
            List<CategoryListDto> categoryListDto = _mapper.Map<List<CategoryListDto>>(category);
            return categoryListDto;
        }

        public Category Update(UpdateCategoryDto updateCategoryDto)
        {
            Category mappedCategory = _mapper.Map<Category>(updateCategoryDto);
            _categoryRepository.Update(mappedCategory);
            return mappedCategory;
        }
    }
}
