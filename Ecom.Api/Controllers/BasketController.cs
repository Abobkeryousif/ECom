//using AutoMapper;
//using Ecom.Core.Entities;
//using Ecom.Core.Interface;
//using Microsoft.AspNetCore.Http;
//using Microsoft.AspNetCore.Mvc;

//namespace Ecom.Api.Controllers
//{
//    [Route("api/[controller]")]
//    [ApiController]
//    public class BasketController : ControllerBase
//    {
//        private readonly IUnitOfWork _work;
//        private readonly IMapper _mapper;

//        public BasketController(IUnitOfWork work , IMapper mapper)
//        {
//            _work = work;
//            _mapper = mapper;
//        }

//        [HttpGet]
//        [Route("{Id}")]
//        public async Task<IActionResult> GetAllAsync(string Id) 

//        {
//            var result = await _work.customerBasketRepsitory.GetBasketAsync(Id);
//            if (result == null) 
//            {
//                return BadRequest($"Not Found With ID: {Id}");
//            }
//            return Ok(result);
//        }

//        [HttpPost]

//        public async Task<IActionResult> CreateAsync(CustomerBasket basket) 
//        {
//            var result = await _work.customerBasketRepsitory.UpdateBasketAsync(basket);
//            return Ok(result);
//        }
//        [HttpDelete]
//        [Route("{Id}")]

//        public async Task<IActionResult> DeleteAsync(string Id) 
//        {
//            var result = await _work.customerBasketRepsitory.DeleteBaskeAsync(Id);
//            return result ? Ok(result) : BadRequest($"Not Found With ID: {Id}"); 
//            //ارجع للفيديو 87 عشان اتذكر    
//        }

//    }
//}






