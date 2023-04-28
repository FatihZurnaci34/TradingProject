using Core.DataAccess.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TradingProject.DataAccess.Abstract;
using TradingProject.Entities.Concrete;

namespace TradingProject.DataAccess.Concrete
{
    public class CategoryRepository : EfRepositoryBase<Category, BaseDbContext>, ICategoryRepository
    {
        public CategoryRepository(BaseDbContext context) : base(context)
        {
        }

        public List<Category> GetAll()
        {
            var categories = Context.Categories;
            return categories.ToList();


        }
    }
}
