using LoginRegister2.DATA.DTOS;
using LoginRegister2.DATA.Interface;
using LoginRegister2.DATA.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace LoginRegister2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class AddressController : ControllerBase
    {
        private readonly IAddressServices _adressServices;

        public AddressController(IAddressServices adressServices)
        {
            _adressServices = adressServices;
        }

        [HttpPost("Address")]
        public async Task<IActionResult> CreateAddress(Address address)
        {
            address.UserId= User.Claims.First(x=>x.Type=="Id").Value;


            var result = await _adressServices.CreateAddrees(address);
            if(ModelState.IsValid)
            {
                return Ok(result);

            }
            return BadRequest(result);

        }
        [HttpGet]
        public async Task<IActionResult> GetAddress()
        {
            var TokenId = User.Claims.First(x => x.Type == "Id").Value;
            var r=  await _adressServices.GetAddress(TokenId);   
           if(ModelState.IsValid)
            {
                return Ok(r);
            }
           return NotFound();
        }

        [HttpGet("GetAllAdres")]
        public async Task<IActionResult> GetAllUser()
        {
            var r = await _adressServices.GetAllUsers();
            if(ModelState.IsValid)
            {
                return Ok(r);
            }
            return BadRequest(r);
               
        }

        [HttpGet("GetAllUserId")]
        public async Task<IActionResult> GetAllUserId(string id)
        {
            var TokenId = User.Claims.First(x => x.Type == "Id").Value;
            var result=await _adressServices.GetAllUserId(id,TokenId);
            if(ModelState.IsValid)
            {
                return Ok(result);
            }
            return NotFound(result);    
            

        }


    }
}
