using MagicVillaApi.Data;
using MagicVillaApi.Dto;
using MagicVillaApi.Models;
using Microsoft.AspNetCore.Mvc;

namespace MagicVillaApi.Controllers
{
    [Route("api/VillaApi")]
    //[Route("api/[controller]")]
    [ApiController]
    public class VillaApiController:ControllerBase
    {
        [HttpGet]
        [ProducesResponseType(200)]
        public ActionResult<IEnumerable<VillaDto>> GetVillas() 
        {
            return Ok(VillaStore.villaList);
        
        }

        [HttpGet("{id:int}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound,Type =typeof(VillaDto))]

      

        //public ActionResult<VillaDto> GetVilla(int id) 
        public ActionResult GetVilla(int id) 

        {
            if(id == 0)
            {
                return BadRequest();
            }
            var villa = VillaStore.villaList.FirstOrDefault(v => v.Id == id);
            if(villa is null)
            {
                return NotFound();
            }
            return Ok(villa);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK,Type =typeof(VillaDto))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]

        public ActionResult Create([FromBody] VillaDto villaDto)
        {
            if(villaDto is null)
            {
                return BadRequest(villaDto);
            }
            if(villaDto.Id > 0) 
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
            villaDto.Id = VillaStore.villaList.OrderByDescending(v => v.Id).FirstOrDefault().Id + 1;
             VillaStore.villaList.Add(villaDto);

            return Ok(villaDto);
        }

    }
}
