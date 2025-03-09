using AutoMapper;
using Ecom.Core.Interface;
using Ecom.Core.Services;
using Ecom.Infrstrucure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecom.Infrstrucure.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly IMapper _mapper;
        private readonly IImageService _imageService;
        public IProductRepository productRepository { get; }

        public ICategoryRepository categoryRepository { get; }

        public IPhotoRepository photoRepository { get;  }

        public UnitOfWork(ApplicationDbContext dbContext, IMapper mapper, IImageService imageService)
        {
            _dbContext = dbContext;
            _mapper = mapper;
            _imageService = imageService;

            categoryRepository = new CategoryRepository(dbContext);
            productRepository = new ProductRepository(dbContext , _mapper, _imageService);
            photoRepository = new PhotoRepository(dbContext);
            
        }


    }
}
