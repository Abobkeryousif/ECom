using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecom.Core.Entities.Product
{
    public class Categories : BaseEntitiy<int>
    {
        public string Name { get; set; }
        public string Descrpition { get; set; }

        //public ICollection<Product> Products { get; set; } =new HashSet<Product>();
    }
}
