using Core.DataAccess.Paging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TradingProject.Entities.Dtos.Categories;

namespace TradingProject.Entities.Models.Categories
{
    public class CategoryListModel:BasePageableModel
    {
        public IList<CategoryListDto> Items { get; set; }
    }
}
