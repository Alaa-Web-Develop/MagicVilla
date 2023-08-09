using AutoMapper;
using Azure;
using MagicVillaApi.Data;
using MagicVillaApi.Dto;
using MagicVillaApi.Logging;
using MagicVillaApi.Models;
using MagicVillaApi.Repository.IRepository;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System.Net;

namespace MagicVillaApi.Controllers
{
    [Route("api/VillaApi")]
    //[Route("api/[controller]")]
    [ApiController]
    public class VillaApiController : ControllerBase
    {
        private readonly ILoggerMyOwn logger;
        //private readonly AppDbContext _db;
        private readonly IVillaRepo _dbVilla;
        private readonly IMapper _mapper;
        protected ApiResponse _response;

        //public VillaApiController(ILogger<VillaApiController> logger)
        //{
        //    this.logger = logger;
        //}
        public VillaApiController(ILoggerMyOwn _logger,/*AppDbContext db,*/IMapper mapper, IVillaRepo db)
        {
            logger = _logger;
            _dbVilla = db;
            _mapper = mapper;
            this._response = new();
        }


        [HttpGet]
        [ProducesResponseType(200)]
        public async Task<ActionResult<ApiResponse>> GetVillas()
        {
            try
            {
                logger.Log("Get All Villas", "Info");
                //IEnumerable<Villa> villalist = await _db.Villas.ToListAsync();
                IEnumerable<Villa> villalist = await _dbVilla.GetAllAsync();
                _response.Result = _mapper.Map<IEnumerable<VillaDto>>(villalist);
                _response.StatusCode = HttpStatusCode.OK;
                return Ok(_response);
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.ErrorMessages = new List<string>() { ex.ToString()};
            }
            return _response;
           
        }

        [HttpGet("{id:int}", Name = "GetVilla")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        //[ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(VillaDto))]

        //public ActionResult<VillaDto> GetVilla(int id) 
        public async Task<ActionResult<ApiResponse>> GetVilla(int id)

        {
            try
            {
                if (id == 0)
                {
                    logger.Log("Villa with Error", "Error");


                    _response.StatusCode = HttpStatusCode.BadRequest;
                    return BadRequest(_response);
                }
                //var villa = await _db.Villas.FirstOrDefaultAsync(v => v.Id == id);
                var villa = await _dbVilla.GetAsync(v => v.Id == id);

                if (villa is null)
                {
                    _response.StatusCode = HttpStatusCode.NotFound;
                    return NotFound(_response);
                }

                _response.Result = _mapper.Map<VillaDto>(villa);
                _response.StatusCode = HttpStatusCode.OK;
                return Ok(_response);
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.ErrorMessages = new List<string>() { ex.ToString() };

            }
            return _response;
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(VillaDto))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]

        public async Task<ActionResult<ApiResponse>> Create([FromBody] VillaCreateDto villaCreateDto)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    _response.StatusCode = HttpStatusCode.BadRequest;
                    return BadRequest(_response);
                }
                //custom vaidation check villa name must be unique
                if (await _dbVilla.GetAsync(v => v.Name.ToLower() == villaCreateDto.Name.ToLower()) != null)
                {
                    ModelState.AddModelError("CustomValidation", "Villa Name Already exist");
                    return BadRequest(ModelState);
                }
                if (villaCreateDto is null)
                {
                    return BadRequest(villaCreateDto);
                }
                //if(villaDto.Id > 0) 
                //{
                //    return StatusCode(StatusCodes.Status500InternalServerError);
                //}
                //villaDto.Id = VillaStore.villaList.OrderByDescending(v => v.Id).FirstOrDefault().Id + 1;
                // VillaStore.villaList.Add(villaDto);

                //Villa model = new Villa()
                //{

                //    Name = villaDto.Name,
                //    Amenity = villaDto.Amenity,
                //    Details = villaDto.Details,
                //    ImageUrl = villaDto.ImageUrl,
                //    Occupancy = villaDto.Occupancy,
                //    sqfet = villaDto.sqfet,
                //    Rate = villaDto.Rate,
                //};

                Villa model = _mapper.Map<Villa>(villaCreateDto);
                //await _db.Villas.AddAsync(model);
                //await _db.SaveChangesAsync();
                await _dbVilla.CreateAsync(model);

                _response.Result = _mapper.Map<VillaCreateDto>(model);
                _response.StatusCode = HttpStatusCode.Created;
                //return Ok(villaDto);
                //return CreatedAtRoute("GetVilla", new { id = model.Id }, model);
                return CreatedAtRoute("GetVilla", new { id = model.Id }, _response);
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.ErrorMessages = new List<string>() { ex.ToString() };

            }

            return _response;
        }

        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(VillaDto))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]

        [HttpDelete("{id:int}")]
        public async Task<ActionResult<ApiResponse>> DeleteVilla(int id)
        {
            try
            {
                if (id == 0)
                {

                    _response.StatusCode = HttpStatusCode.BadRequest;
                    return BadRequest(_response);
                
                }
                var villa = await _dbVilla.GetAsync(v => v.Id == id);
                if (villa is null)
                {

                    _response.StatusCode = HttpStatusCode.NotFound;
                    return NotFound(_response);
                   
                }
                //VillaStore.villaList.Remove(villa);
                //_db.Villas.Remove(villa);
                //await _db.SaveChangesAsync();
                await _dbVilla.RemoveAsync(villa);

                _response.StatusCode = HttpStatusCode.NoContent;
                
                return Ok(_response);
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.ErrorMessages = new List<string>() { ex.ToString() };

            }
            return _response;
        }





        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]

        [HttpPut("Edit:{id:int}")]

        public async Task<ActionResult<ApiResponse>> UpdateVilla(int id, [FromBody] VillaUpdateDto villaupdateDto)
        {
            try
            {
                if (villaupdateDto is null || id != villaupdateDto.Id)
                {
                    ModelState.AddModelError("Error", "Confrim Id or object in re body");
                    return BadRequest(ModelState);
                }
                //var villa = VillaStore.villaList.FirstOrDefault(v => v.Id == id);
                //if (villa is null)
                //{
                //    return NotFound();
                //}
                //villa.Name = villaDto.Name;
                //villa.Occupancy = villaDto.Occupancy;
                //villa.sqfet = villaDto.sqfet;

                //Villa model = new Villa()
                //{
                //    Id=villaDto.Id,
                //    Name = villaDto.Name,
                //    Amenity = villaDto.Amenity,
                //    Details = villaDto.Details,
                //    ImageUrl = villaDto.ImageUrl,
                //    Occupancy = villaDto.Occupancy,
                //    sqfet = villaDto.sqfet,
                //    Rate = villaDto.Rate
                //};
                Villa model = _mapper.Map<Villa>(villaupdateDto);
                //_db.Villas.Update(model);
                //await _db.SaveChangesAsync();
                await _dbVilla.UpdateAsync(model);

                _response.StatusCode = HttpStatusCode.NoContent;
                _response.IsSuccess = true;
                return Ok(_response);
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.ErrorMessages = new List<string>() { ex.ToString() };

            }
            return _response;
        }







        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]

        [HttpPatch("{id:int}")]
        public async Task<IActionResult> updatePartial(int id, JsonPatchDocument<VillaUpdateDto> patchDto)
        {
            if (patchDto is null || id == 0)
            {
                return BadRequest();
            }
            var villa = await _dbVilla.GetAsync(v => v.Id == id, tracked: false);


            //VillaUpdateDto villaDto = new()
            //{
            //    Id = villa!.Id,
            //    Name = villa.Name,
            //    Amenity = villa.Amenity,
            //    Details = villa.Details,
            //    ImageUrl = villa.ImageUrl,
            //    Occupancy = villa.Occupancy,
            //    sqfet = villa.sqfet,
            //    Rate = villa.Rate
            //};
            VillaUpdateDto villaDto = _mapper.Map<VillaUpdateDto>(villa);
            if (villa is null)
            {
                return NotFound();
            }

            patchDto.ApplyTo(villaDto, ModelState);

            //Villa model = new Villa()
            //{
            //    Id=villaDto.Id,
            //    Name = villaDto.Name,
            //    Amenity = villaDto.Amenity,
            //    Details = villaDto.Details,
            //    ImageUrl = villaDto.ImageUrl,
            //    Occupancy = villaDto.Occupancy,
            //    sqfet = villaDto.sqfet,
            //    Rate = villaDto.Rate
            //};

            Villa model = _mapper.Map<Villa>(villaDto);

            //_db.Villas.Update(model);
            //await _db.SaveChangesAsync();


            await _dbVilla.UpdateAsync(model);

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            return NoContent();
        }



    }
}
