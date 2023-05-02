using Core.DataAccess.Request;
using Core.Utilities.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TradingProject.Entities.Concrete;
using TradingProject.Entities.Dtos.Categories;
using TradingProject.Entities.Models.Categories;

namespace TradingProject.Business.Abstract
{
    public interface ICategoryService
    {
        public Category Create(CreateCategoryDto createCategoryDto);
        public Category Update(UpdateCategoryDto updateCategoryDto);
        public Category Delete(DeleteCategoryDto deleteCategoryDto);
        public Task<CategoryGetByIdDto> GetById(int id);
        public Task<CategoryListModel> GetList(PageRequest pageRequest);
    }
}
