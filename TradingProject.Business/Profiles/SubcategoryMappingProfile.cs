using AutoMapper;
using Core.DataAccess.Paging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TradingProject.Entities.Concrete;
using TradingProject.Entities.Dtos.Subcategories;
using TradingProject.Entities.Models.Subcategories;

namespace TradingProject.Business.Profiles
{
    public class SubcategoryMappingProfile:Profile
    {
        public SubcategoryMappingProfile()
        {
            CreateMap<Subcategory, CreateSubcategoryDto > ().ReverseMap();
            CreateMap<Subcategory, DeleteSubcategoryDto > ().ReverseMap();
            CreateMap<Subcategory, UpdateSubcategoryDto > ().ReverseMap();
            CreateMap<Subcategory, SubcategoryGetByIdDto>().ForMember(p => p.CategoryName, opt => opt.MapFrom(p => p.Category.Name))
                                                 .ReverseMap();
            CreateMap<Subcategory, SubcategoryListDto>().ForMember(p=>p.CategoryName,opt => opt.MapFrom(p=>p.Category.Name)).ReverseMap();
            CreateMap<IPaginate<Subcategory>, SubcategoryListModel>().ReverseMap();
        }
    }
}
