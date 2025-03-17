using AutoMapper;
using Ecom.Core.Entities;
using Ecom.Core.Interface;
using Ecom.Core.Services;
using Ecom.Infrstrucure.Data;
using Ecom.Infrstrucure.Repositories.Service;
using Microsoft.AspNetCore.Identity;



namespace Ecom.Infrstrucure.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly IMapper _mapper;
        private readonly IImageService _imageService;
        private readonly UserManager<UserApp> _manager;
        private readonly IGenretToken _token;
        private readonly SignInManager<UserApp> _signInManager;
        private readonly IUnitOfWork unitOfWork;

        public IProductRepository productRepository { get; }

        public ICategoryRepository categoryRepository { get; }

        public IPhotoRepository photoRepository { get;  }

        //public ICustomerBasketRepsitory customerBasketRepsitory { get; }

        public IAuth Auth { get; }



        public UnitOfWork(ApplicationDbContext dbContext, IMapper mapper, IImageService imageService, UserManager<UserApp> manager, IGenretToken token, SignInManager<UserApp> signInManager)

        {
            _dbContext = dbContext;
            _mapper = mapper;
            _imageService = imageService;
            _manager = manager;
            categoryRepository = new CategoryRepository(dbContext);
            productRepository = new ProductRepository(dbContext, _mapper, _imageService);
            photoRepository = new PhotoRepository(dbContext);
            //customerBasketRepsitory = new CustomerBasketRepository(redis);
            _signInManager = signInManager;
            unitOfWork = unitOfWork;
            Auth = new AuthRepository(_manager,_signInManager,_token );
            _token = token;
        }


    }
}
