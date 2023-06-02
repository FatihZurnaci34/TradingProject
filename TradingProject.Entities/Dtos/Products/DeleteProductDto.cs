using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TradingProject.Entities.Dtos.Products
{
    public class DeleteProductDto
    {
        public int Id { get; set; }
        public int SupplierId { get; set; }
    }
}
