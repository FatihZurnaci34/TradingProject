using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TradingProject.DataAccess.Abstract;
using TradingProject.DataAccess.Concrete;
using TradingProject.Entities.Concrete;

namespace TradingProject.Business.Rules
{
    public class ProductBusinessRules
    {
        private readonly IProductRepository _productRepository;
        private readonly ISupplierRepository _supplierRepository;

        public ProductBusinessRules(IProductRepository productRepository, ISupplierRepository supplierRepository)
        {
            _productRepository = productRepository;
            _supplierRepository = supplierRepository;
        }

        public void ProductShouldExistWhenRequested(Subcategory subcategory)
        {
            if (subcategory == null)
                throw new ("İstenilen alt kategori mevcut değil");
        }

    }
}
