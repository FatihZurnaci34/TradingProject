using Core.DataAccess.Paging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TradingProject.Entities.Dtos.Subcategories;

namespace TradingProject.Entities.Models.Subcategories
{
    public class SubcategoryListModel:BasePageableModel
    {
        public IList<SubcategoryListDto> Items { get; set; }
    }
}
