using AutoMapper;
using Ecom.Core.DTO;
using Ecom.Core.Entities.Product;
using Ecom.Core.Interface;
using Ecom.Core.Services;
using Ecom.Infrstrucure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecom.Infrstrucure.Repositories
{
    public class ProductRepository : GenericRepository<Product>, IProductRepository
    {
            private readonly ApplicationDbContext dbContext;
            private readonly IMapper mapper;
            private readonly IImageService imageService;

        public ProductRepository(ApplicationDbContext dbContext, IMapper mapper, IImageService imageService) : base(dbContext)
        {
            this.dbContext = dbContext;
            this.mapper = mapper;
            this.imageService = imageService;
        }

        public async Task<bool> AddAsync(AddProductDto addProductDto)
        {

            if (addProductDto == null) return false;
            var product = mapper.Map<Product>(addProductDto);
            await dbContext.AddAsync(product);
            await dbContext.SaveChangesAsync();

            var ImagePath = await imageService.AddImageAsync(addProductDto.Photos, product.Name);
            var photo = ImagePath.Select(Path => new Photo
            {
                ImageName = Path,
                ProductId = product.Id

            }).ToList();
            await dbContext.Photo.AddRangeAsync(photo);
            await dbContext.SaveChangesAsync();
            return true;
        }

        public async Task DeleteAsyncs(Product product)
        {
            var photo = await dbContext.Photo.Where(x => x.ProductId == product.Id).ToListAsync();

            foreach (var item in photo)
            {
                imageService.DeleteAsync(item.ImageName);
            }

            dbContext.Products.Remove(product);
            await dbContext.SaveChangesAsync();
        }


        public async Task<bool> UpdateAsync(UpdateProductDto updateProductDto)
        {
            if (updateProductDto is null) 
            {
                return false;
            }
            var FindProduct = await dbContext.Products.Include(m => m.Categories)
                .Include(m=> m.photos).FirstOrDefaultAsync(x=> x.Id == updateProductDto.Id);
            if(FindProduct is null) 
            {
                return false;
            }
            mapper.Map<UpdateProductDto>(FindProduct);
            var photo = await dbContext.Photo.Where(x => x.ProductId == updateProductDto.Id).ToListAsync();

            foreach (var item in photo)
            {
                imageService.DeleteAsync(item.ImageName);
            }
            dbContext.Photo.RemoveRange(photo);
            var Imagepath = await imageService.AddImageAsync(updateProductDto.Photos, updateProductDto.Name);
            var ListPhoto = Imagepath.Select(path => 
            new Photo { 
            ImageName = path,
            ProductId = updateProductDto.Id,
            }).ToList();

            await dbContext.Photo.AddRangeAsync(ListPhoto);
            await dbContext.SaveChangesAsync();
            return true;
        }
    }
}
