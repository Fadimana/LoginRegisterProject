using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SchoolAPI.Data.Entity;
using SchoolAPI.Data.Interface;

namespace SchoolAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SchoolController : ControllerBase
    {

        private readonly ISchoolServices<Bölüm> _bölüm;
        private readonly ISchoolServices<Fakülte> _fakülte;

        public SchoolController(ISchoolServices<Fakülte> fakülte, ISchoolServices<Bölüm> bölüm)
        {
            _fakülte = fakülte;
            _bölüm = bölüm;
        }
        [HttpGet("fakülte")]
        public async Task<IActionResult> GetAllFakülte()
        {
            await _fakülte.GetAll();
            return Ok();    
        }
        [HttpGet("bölüm")]
        public async Task<IActionResult> GetAllBölüm()
        {
            await _bölüm.GetAll();
            return Ok();
        }
        [HttpPost("Fakülte")]
        public async Task<IActionResult> CreateFakülte([FromBody ]Fakülte fakülte)
        {
           if(ModelState.IsValid)
            {
                await _fakülte.Create(fakülte);
                return Ok();
            }
           return BadRequest();
        }
        [HttpPost("Bölüm")]
        public async Task<IActionResult> CreateBölüm([FromBody] Bölüm bölüm)
        {
            if (ModelState.IsValid)
            {
                await _bölüm.Create(bölüm);
                return Ok();
            }
            return BadRequest();
        }
        [HttpPatch("Fakülte")]
        public async Task<IActionResult> UpdateFakülte([FromBody] Fakülte fakülte)
        {
            if(ModelState.IsValid)
            {
                 _fakülte.Update(fakülte);
                return Ok();
            }
            return BadRequest();

        }
        [HttpPatch("Bölüm")]
        public async Task<IActionResult> UpdateBölüm([FromBody]Bölüm bölüm)
        {
            if (ModelState.IsValid)
            {
                _bölüm.Update(bölüm);
                return Ok();
            }
            return BadRequest();

        }
        [HttpDelete("Fakülte")]
        public async Task<IActionResult> DeleteFakülte(Fakülte fakülte)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest();
            }
            _fakülte.Delete(fakülte);
            return Ok();
        }
        [HttpDelete("Bölüm")]
        public async Task<IActionResult> DeleteBölüm(Bölüm bölüm)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            _bölüm.Delete(bölüm);
            return Ok();
        }

    }
}
