using AutoMapper;
using Ecom.Core.DTO;
using Ecom.Core.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Ecom.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public ProductController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllAsync()
        {
            var product = await _unitOfWork.productRepository.GetAllAsync(x => x.Categories, x => x.photos);
            var result = _mapper.Map<List<ProductDto>>(product);
            if (product is null)
            {
                return BadRequest();
            }

            return Ok(result);
        }

        [HttpGet]
        [Route("{Id}")]
        public async Task<IActionResult> GetByIdAsync(int Id)
        {
            var product = await _unitOfWork.productRepository.GetByIdAsync(Id, x => x.Categories, x => x.photos);
            if (product is null) {
                return BadRequest();
            }
            var result = _mapper.Map<ProductDto>(product);
            return Ok(result);
        }
        [HttpPost]
        public async Task<IActionResult> AddProduct(AddProductDto addProductDto)
        {
            //ارجع للفيديو رقم 22 بوضح الغكرة
            await _unitOfWork.productRepository.AddAsync(addProductDto);
            return Ok("Product Add Sccessfuly!");
        }

        [HttpPut]
        [Route("{Id}")]
        
        public async Task<IActionResult> UpdateAsync(UpdateProductDto updateProductDto) 
        {
            await _unitOfWork.productRepository.UpdateAsync(updateProductDto);
            return Ok("Updated Complete!");
        }

        [HttpDelete]
        [Route("{Id}")]

        public async Task<IActionResult> DeleteAsync(int Id)
        {
            var product = await _unitOfWork.productRepository.GetByIdAsync(Id, x => x.photos);
            
            await _unitOfWork.productRepository.DeleteAsyncs(product);
            return Ok("Delete Product Sccessful!");

        }

    }
}












