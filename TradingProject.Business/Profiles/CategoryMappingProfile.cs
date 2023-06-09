﻿using AutoMapper;
using Core.DataAccess.Paging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TradingProject.Entities.Concrete;
using TradingProject.Entities.Dtos.Categories;
using TradingProject.Entities.Dtos.Subcategories;
using TradingProject.Entities.Models.Categories;
using TradingProject.Entities.Models.Subcategories;

namespace TradingProject.Business.Profiles
{
    public class CategoryMappingProfile : Profile
    {
        public CategoryMappingProfile()
        {
            CreateMap<Category, CreateCategoryDto>().ReverseMap();
            CreateMap<Category, UpdateCategoryDto>().ReverseMap();
            CreateMap<Category, DeleteCategoryDto>().ReverseMap();
            CreateMap<Category, CategoryGetByIdDto>().ReverseMap();
            CreateMap<Category, CategoryListDto>().ReverseMap();
            CreateMap<IPaginate<Category>,CategoryListModel>().ReverseMap();

        }
    }
}
