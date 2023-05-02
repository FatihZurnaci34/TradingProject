using AutoMapper;
using Core.DataAccess.Paging;
using Core.DataAccess.Request;
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

        public async Task<CategoryGetByIdDto> GetById(int id)
        {
            Category category = await _categoryRepository.GetAsync(c=>c.Id==id);
            CategoryGetByIdDto categoryGetByIdDto = _mapper.Map<CategoryGetByIdDto>(category);
            return categoryGetByIdDto;
        }

        public async Task<CategoryListModel> GetList(PageRequest pageRequest)
        {
            IPaginate<Category> category = await _categoryRepository.GetListAsync(index: pageRequest.Page, size: pageRequest.PageSize);
            CategoryListModel mappedCategory = _mapper.Map<CategoryListModel>(category);
            return mappedCategory;
        }

        public Category Update(UpdateCategoryDto updateCategoryDto)
        {
            Category mappedCategory = _mapper.Map<Category>(updateCategoryDto);
            _categoryRepository.Update(mappedCategory);
            return mappedCategory;
        }
    }
}
