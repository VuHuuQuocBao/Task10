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
    public class QuestionController : ControllerBase
    {
        protected readonly IQuestionService _QuestionService;

        public QuestionController(IQuestionService QuestionsService)
        {
            _QuestionService = QuestionsService;
        }

        [HttpGet("getAll")]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                return Ok(await _QuestionService.GetAll());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            try
            {
                var data = await _QuestionService.GetById(id);
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

        [HttpGet("paging")]
        public async Task<IActionResult> GetAllPaging([FromQuery] PagedRequest pagingRequest)
        {
            var products = await _QuestionService.GetAllPaging(pagingRequest);
            return Ok(products);
        }

        [HttpPost]
        public async Task<IActionResult> Create(QuestionDTO questions)
        {
            try
            {
                return Ok(await _QuestionService.Add(questions));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(QuestionDTOUpdateRequest questionDTP)
        {
            try
            {
                var result = await _QuestionService.Update(questionDTP);
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
                var result = await _QuestionService.Delete(id);
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