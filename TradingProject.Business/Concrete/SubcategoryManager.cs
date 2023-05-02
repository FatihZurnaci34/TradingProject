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
using TradingProject.DataAccess.Abstract;
using TradingProject.DataAccess.Concrete;
using TradingProject.Entities.Concrete;
using TradingProject.Entities.Dtos.Categories;
using TradingProject.Entities.Dtos.Subcategories;
using TradingProject.Entities.Models.Subcategories;

namespace TradingProject.Business.Concrete
{
    public class SubcategoryManager : ISubcategoryService
    {
        private readonly IMapper _mapper;
        private readonly ISubcategoryRepository _subcategoryRepository;

        public SubcategoryManager(ISubcategoryRepository subcategoryRepository, IMapper mapper)
        {
            _subcategoryRepository = subcategoryRepository;
            _mapper = mapper;
        }

        public Subcategory Create(CreateSubcategoryDto createSubcategoryDto)
        {
            Subcategory mappedSubcategory = _mapper.Map<Subcategory>(createSubcategoryDto);
            _subcategoryRepository.Add(mappedSubcategory);
            return mappedSubcategory;

        }

        public Subcategory Delete(DeleteSubcategoryDto deleteSubcategoryDto)
        {
            Subcategory mappedSubcategory = _mapper.Map<Subcategory>(deleteSubcategoryDto);
            _subcategoryRepository.Delete(mappedSubcategory);
            return mappedSubcategory;
        }

        public async Task<SubcategoryGetByIdDto> GetById(int id)
        {
            Subcategory? subcategory = await _subcategoryRepository.GetAsync(s => s.Id == id,include: s=>s.Include(s=>s.Category));
            SubcategoryGetByIdDto subcategoryGetByIdDto = _mapper.Map<SubcategoryGetByIdDto>(subcategory);
            return subcategoryGetByIdDto;

        }

        public async Task<SubcategoryListModel> GetList(PageRequest pageRequest)
        {
            IPaginate<Subcategory> subcategory = await _subcategoryRepository.GetListAsync(index:pageRequest.Page,size:pageRequest.PageSize,include:s=>s.Include(p=>p.Category));
            SubcategoryListModel mappedSubcategory = _mapper.Map<SubcategoryListModel>(subcategory);
            return mappedSubcategory;

        }

        public Subcategory Update(UpdateSubcategoryDto updateSubcategoryDto)
        {
            Subcategory mappedSubcategory = _mapper.Map<Subcategory>(updateSubcategoryDto);
            _subcategoryRepository.Update(mappedSubcategory);
            return mappedSubcategory;
        }
    }
}
