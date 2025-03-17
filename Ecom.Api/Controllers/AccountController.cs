using AutoMapper;
using Ecom.Core.DTO;
using Ecom.Core.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Ecom.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IUnitOfWork _work;
        private readonly IMapper _mapper;
        

        public AccountController(IUnitOfWork work , IMapper mapper)
        {
            _work = work;
            _mapper = mapper;
        }

        [HttpPost("Register")]

        public async Task<IActionResult> RegisterAsync(RegisterDto registerDto) 
        {
        var result = await _work.Auth.RegisterAsync(registerDto);
            if (result == null)
                return BadRequest("Something Wrong!");
            return Ok(result);
        }
       
    }
}
