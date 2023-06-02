using AutoMapper;
using Core.DataAccess.Paging;
using Core.DataAccess.Request;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TradingProject.Business.Abstract;
using TradingProject.Business.Rules;
using TradingProject.DataAccess.Abstract;
using TradingProject.Entities.Concrete;
using TradingProject.Entities.Dtos.Products;
using TradingProject.Entities.Models.Products;

namespace TradingProject.Business.Concrete
{
    public class ProductManager : IProductService
    {
        private readonly IProductRepository _productRepository;
        private readonly ISupplierRepository _supplierRepository;
        private readonly ProductBusinessRules _productBusinessRules;
        private readonly IMapper _mapper;

        public ProductManager(IProductRepository productRepository, IMapper mapper, ISupplierRepository supplierRepository, ProductBusinessRules productBusinessRules)
        {
            _productRepository = productRepository;
            _mapper = mapper;
            _supplierRepository = supplierRepository;
            _productBusinessRules = productBusinessRules;
        }

        public async Task<Product> Create(CreateProductDto createProductDto)
        {
            
            Product mappedProduct = _mapper.Map<Product>(createProductDto);
            await _productRepository.AddAsync(mappedProduct);

            Supplier supplier = await _supplierRepository.GetAsync(p => p.Id == mappedProduct.SupplierId);
            supplier.NumberOfProducts++;
            await _supplierRepository.UpdateAsync(supplier);
            
            return mappedProduct;
        }


        public async Task<Product> Delete(DeleteProductDto deleteProductDto)
        {
            Product mappedProduct = _mapper.Map<Product>(deleteProductDto);
            await _productRepository.DeleteAsync(mappedProduct);
            Supplier supplier = await _supplierRepository.GetAsync(p => p.Id == mappedProduct.SupplierId);
            supplier.NumberOfProducts--;
            await _supplierRepository.UpdateAsync(supplier);
            return mappedProduct;
        }


        public async Task<ProductGetByIdDto> GetById(int id)
        {
            Product? product = await _productRepository.GetAsync(p => p.Id == id,include: p=>p.Include(p=>p.Supplier).Include(p=>p.Subcategory));
            ProductGetByIdDto mappedProduct = _mapper.Map<ProductGetByIdDto>(product);
            return mappedProduct;
        }

        public async Task<ProductListModel> GetList(PageRequest pageRequest)
        {
            IPaginate<Product> product = await _productRepository.GetListAsync(index:pageRequest.PageSize,size: pageRequest.PageSize,include: p=>p.Include(p=>p.Supplier).Include(p=>p.Subcategory));
            ProductListModel mappedProduct = _mapper.Map<ProductListModel>(product);
            return mappedProduct;
        }

        public async Task<Product> Update(UpdateProductDto updateProductDto)
        {
            Product mappedProduct = _mapper.Map<Product>(updateProductDto);
            await _productRepository.UpdateAsync(mappedProduct);
            return mappedProduct;
        }
    }
}
