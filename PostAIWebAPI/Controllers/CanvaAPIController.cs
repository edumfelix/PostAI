using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PostAIWebAPI.Services;

namespace PostAIWebAPI.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class CanvaAPIController : ControllerBase
    {
        private readonly GetCanvaApiService _getCanvaApiService;
        private readonly PostCanvaApiService _postCanvaApiService;

        public CanvaAPIController(GetCanvaApiService getCanvaApiService, PostCanvaApiService postCanvaApiService)
        {
            _getCanvaApiService = getCanvaApiService;
            _postCanvaApiService = postCanvaApiService;
        }

        [HttpGet("job/{jobId}")]
        public async Task<IActionResult> GetJobDetails([FromRoute] string jobId, [FromHeader] string token)
        {
            if (string.IsNullOrEmpty(token))
            {
                return BadRequest("Token is required.");
            }

            try
            {
                var result = await _getCanvaApiService.GetJobDetailsAsync(jobId, token);
                return Ok(result);
            }
            catch (HttpRequestException ex)
            {
                return StatusCode(500, $"Error while fetching job details: {ex.Message}");
            }
        }

        [HttpPost("autofills")]
        public async Task<IActionResult> PostAutofillData([FromHeader] string uri, [FromHeader] string token, [FromHeader] string jsonBody)
        {
            if (string.IsNullOrEmpty(token))
            {
                return BadRequest("Token is required.");
            }

            if (string.IsNullOrEmpty(uri))
            {
                return BadRequest("Uri is required.");
            }

            if (string.IsNullOrEmpty(jsonBody))
            {
                return BadRequest("jsonBody is required.");
            }

            try
            {
                // Corrigindo a chamada ao método correto
                await _postCanvaApiService.SendPostRequestAsync(uri, token, jsonBody);
                return Ok("Data posted successfully.");
            }
            catch (HttpRequestException ex)
            {
                return StatusCode(500, $"Error while posting data: {ex.Message}");
            }
        }
    }
}
