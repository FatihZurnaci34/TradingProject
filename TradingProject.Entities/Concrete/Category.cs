using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TradingProject.Core.DataAccess.Repositories;

namespace TradingProject.Entities.Concrete
{
    public class Category : Entity
    {
        public string Name { get; set; }
        public ICollection<Subcategory> Subcategories { get; set; }
        public Category()
        {

        }

        public Category(int id, string name) : this()
        {
            Id = id;
            Name = name;

        }
    }
}
