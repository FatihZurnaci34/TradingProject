using Core.DataAccess.Request;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading.Tasks.Sources;
using TradingProject.Entities.Concrete;
using TradingProject.Entities.Dtos.Products;
using TradingProject.Entities.Models.Products;

namespace TradingProject.Business.Abstract
{
    public interface IProductService
    {
        public Task<Product> Create(CreateProductDto createProductDto);
        public Task<Product> Update(UpdateProductDto updateProductDto);
        public Task<Product> Delete(DeleteProductDto deleteProductDto);
        public Task<ProductGetByIdDto> GetById(int id);
        public Task<ProductListModel> GetList(PageRequest pageRequest);

    }
}
