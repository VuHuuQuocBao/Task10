using Task10_11.DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Task10_11.Application.Interface;
using Task10_11.Services;
using Task10_11.DTOs.Paging;

namespace Task10_11.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DocumentItemController : ControllerBase
    {
        protected readonly IDocumentItemService _DocItemService;

        public DocumentItemController(IDocumentItemService DocItemService)
        {
            _DocItemService = DocItemService;
        }

        [HttpGet("getAll")]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                return Ok(await _DocItemService.GetAll());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("paging")]
        public async Task<IActionResult> GetAllPaging([FromQuery] PagedRequest pagingRequest)
        {
            var products = await _DocItemService.GetAllPaging(pagingRequest);
            return Ok(products);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            try
            {
                var data = await _DocItemService.GetById(id);
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
        public async Task<IActionResult> Create(DocumentItemDTO documentItemDTO)
        {
            try
            {
                return Ok(await _DocItemService.Add(documentItemDTO));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(DocumentItemDTOUpdateRequest documentItemDTO)
        {
            try
            {
                var result = await _DocItemService.Update(documentItemDTO);
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
                var result = await _DocItemService.Delete(id);
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