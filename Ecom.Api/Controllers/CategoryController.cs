using AutoMapper;
using Ecom.Core.DTO;
using Ecom.Core.Entities.Product;
using Ecom.Core.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Ecom.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly IUnitOfWork _work;
        private readonly IMapper _mapper;

        public CategoryController(IUnitOfWork work, IMapper mapper)
        {

            _work = work;
            _mapper = mapper;
        }

        [HttpGet("Get")]
        public async Task<IActionResult> GetAllAsync()
        {
            try
            {
                var category = await _work.categoryRepository.GetAllAsync();
                if (category is null)
                {
                    return BadRequest();
                }
                return Ok(category);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpGet]
        [Route("{Id}")]

        public async Task<IActionResult> GetByIdAsync(int Id)
        {
            try
            {
                var category = await _work.categoryRepository.GetByIdAsync(Id);
                if (category is null)
                {
                    return BadRequest($"Could not find category {Id}");
                }
                        return Ok(category);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

        [HttpPost]
        public async Task<IActionResult> CreateCategoryAsync(CategoryDto categoryDto) 
        {
            try {
                var category = _mapper.Map<Categories>(categoryDto);
                await _work.categoryRepository.AddAsync(category);
                return Ok("Item Has been Created!");
            }
            catch (Exception ex) 
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut]
        [Route("{Id}")]
        public async Task<IActionResult> UpdateAsync(UpdateCategoryDto categoryDto, int Id) 
        {
            try {
                var category = _mapper.Map<Categories>(categoryDto);
                await _work.categoryRepository.UpdateAsync(category);
                return Ok("Category Has been Updated!");
            } catch (Exception ex) 
            {
                return BadRequest(ex.Message);
                    }
        
        }
        [HttpDelete]
        [Route("{Id}")]
        public async Task<IActionResult> DeleteCategoryAsync(int Id)
        {
            try {
                 await _work.categoryRepository.DeleteAsync(Id);
                return Ok("Category Has been Deleted");
                    
            }
            catch (Exception ex) {
                return BadRequest(ex.Message);
            }
        }
    }
}









