using Core.DataAccess.Paging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TradingProject.Entities.Dtos.Products;

namespace TradingProject.Entities.Models.Products
{
    public class ProductListModel:BasePageableModel
    {
        public IList<ProductListDto> Items { get; set; }
    }
}
