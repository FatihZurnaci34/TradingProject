using AutoMapper;
using Core.DataAccess.Paging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TradingProject.Entities.Concrete;
using TradingProject.Entities.Dtos.Products;
using TradingProject.Entities.Models.Products;

namespace TradingProject.Business.Profiles
{
    public class ProductMappingProfile:Profile
    {
        public ProductMappingProfile()
        {
            CreateMap<Product, CreateProductDto>().ReverseMap();
            CreateMap<Product, UpdateProductDto>().ReverseMap();
            CreateMap<Product, DeleteProductDto>().ReverseMap();
            CreateMap<Product, ProductGetByIdDto>()
                .ForMember(p => p.SupplierName, opt => opt.MapFrom(p => p.Supplier.CompanyName))
                .ForMember(p => p.SubcategoryName, opt => opt.MapFrom(p => p.Subcategory.Name)).ReverseMap();
            CreateMap<Product, ProductListDto>()
                .ForMember(p => p.SupplierName, opt => opt.MapFrom(p => p.Supplier.CompanyName))
                .ForMember(p => p.SubcategoryName, opt => opt.MapFrom(p => p.Subcategory.Name)).ReverseMap();
            CreateMap<IPaginate<Product>, ProductListModel>().ReverseMap();
        }
    }
}
