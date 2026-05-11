using Api1.Dtos;
using FluentValidation;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Api1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RegisterController : ControllerBase
    {

        private readonly IValidator<RegisterDto> _validator;


        [HttpPost("register")]
        public async Task<IActionResult> Register(RegisterDto dto)
        {
            var result = await _validator.ValidateAsync(dto);
            if (!result.IsValid)
            {
                return BadRequest(result.Errors.Select(x => new { x.PropertyName, x.ErrorMessage }));
            }
            return Ok();
        }
    }
}
