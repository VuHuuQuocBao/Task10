using Task10_11.DTOs;
using Task10_11.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Task10_11.Application.Interface;
using Task10_11.DTOs.Paging;

namespace Task10_11.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AnnouncementController : ControllerBase
    {
        protected readonly IAnnouncementService _AnnService;

        public AnnouncementController(IAnnouncementService AnnService)
        {
            _AnnService = AnnService;
        }

        [HttpGet("getAll")]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                return Ok(await _AnnService.GetAll());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("paging")]
        public async Task<IActionResult> GetAllPaging([FromQuery] PagedRequest pagingRequest)
        {
            var products = await _AnnService.GetAllPaging(pagingRequest);
            return Ok(products);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            try
            {
                var data = await _AnnService.GetById(id);
                if (data != null)
                {
                    return Ok(data);
                }
                else
                {
                    return NotFound();
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public async Task<IActionResult> Create(AnnouncementDTO announcementDTO)
        {
            try
            {
                return Ok(await _AnnService.Add(announcementDTO));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(AnnouncementDTOUpdateRequest announcementDTO)
        {
            try
            {
                var result = await _AnnService.Update(announcementDTO);
                if (result == 0)
                    return BadRequest();

                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var result = await _AnnService.Delete(id);
                if (result == 0)
                    return BadRequest();

                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}