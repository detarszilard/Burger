using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Burger.Common.Web.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ApiControllerBase : ControllerBase
    {
        private readonly ISender _mediator;

        public ApiControllerBase(ISender mediator)
        {
            _mediator = mediator;
        }

        protected virtual async Task<TResponse> SendAsync<TResponse>(IRequest<TResponse> command)
        {
            return await _mediator.Send(command, HttpContext.RequestAborted);
        }
    }
}
