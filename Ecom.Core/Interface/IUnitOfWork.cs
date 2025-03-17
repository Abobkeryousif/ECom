using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecom.Core.Interface
{
    public interface IUnitOfWork
    {
        public IProductRepository productRepository { get; }
        public ICategoryRepository categoryRepository { get; }
        public IPhotoRepository photoRepository { get; }

        //public ICustomerBasketRepsitory customerBasketRepsitory { get; }

        public IAuth Auth { get; }  
    }
}
