using Ecom.Core.Entities.Product;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecom.Core.DTO
{
   public record ProductDto
    {
        public string Name { get; set; }
        public string Dscription { get; set; }

        public decimal Price { get; set; }

        public string CategoryName { get; set; }

        public List<PhotoDto> photos { get; set; }
    }

    public record PhotoDto 
    {
        public string ImageName { get; set; }
        public int ProductId { get; set; }
    }

    public record AddProductDto 
    {
        public string Name { get; set; }
        public string Dscription { get; set; }

        public decimal NewPrice { get; set; }
        public decimal OldPrice { get; set; }

        public int CategoryId { get; set; }

        public IFormFileCollection Photos { get; set; }
    }

}






