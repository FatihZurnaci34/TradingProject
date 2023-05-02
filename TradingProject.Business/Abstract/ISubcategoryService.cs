using Core.DataAccess.Request;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TradingProject.Entities.Concrete;
using TradingProject.Entities.Dtos.Categories;
using TradingProject.Entities.Dtos.Subcategories;
using TradingProject.Entities.Models.Subcategories;

namespace TradingProject.Business.Abstract
{
    public interface ISubcategoryService
    {
        public Subcategory Create(CreateSubcategoryDto createSubcategoryDto);
        public Subcategory Update(UpdateSubcategoryDto updateSubcategoryDto);
        public Subcategory Delete(DeleteSubcategoryDto deleteSubcategoryDto);
        public Task<SubcategoryGetByIdDto> GetById(int id);
        public Task<SubcategoryListModel> GetList(PageRequest pageRequest);
    }
}
