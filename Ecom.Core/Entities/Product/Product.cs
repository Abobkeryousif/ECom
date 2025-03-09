using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecom.Core.Entities.Product
{
    public class Product : BaseEntitiy<int>
    {
        public string Name { get; set; }
        public string Dscription { get; set; }

        public decimal NewPrice { get; set; }
        public decimal OldPrice { get; set; }

        public List<Photo> photos { get; set; }
        public int CategoryId { get; set; }
        [ForeignKey(nameof(CategoryId))]
        public virtual Categories Categories { get; set; }
    }
}
