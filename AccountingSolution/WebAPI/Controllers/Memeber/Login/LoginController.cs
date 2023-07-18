
using Application.Member.Login.Commands;
using Domain.Model.Customer;
using Domain.Model.User;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace WebAPI.Controllers.Memeber.Login
{
    public class LoginController : Controller
    {
        private readonly IMediator _mediator;
        public LoginController(IMediator mediator)
        {
            _mediator = mediator;
        }


        [HttpPost]
        [Route("Login")]

        public async Task<ActionResult<LoginResultModel>> Login([FromBody] LoginCommand command)
        {
            var result = await _mediator.Send(command);
            return Ok(result);
        }


        [HttpPost]
        [Route("TokenRefresh")]
        public async Task<IActionResult> TokenRefresh([FromBody] TokenCommand command)
        {

            var result = await _mediator.Send(command);
            return Ok(result);



        }

    }
}
