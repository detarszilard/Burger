using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using Burger.Common.Web.Controllers;
using Burger.Services.Restaurants.Application.Commands;
using Burger.Services.Restaurants.Application.Queries;
using Burger.Services.Restaurants.Application.ResponseModels;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Burger.Services.Restaurants.Web.Controllers
{
    public class ReviewController : ApiControllerBase
    {
        public ReviewController(ISender mediator) : base(mediator)
        {
        }

        [HttpPost]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        public async Task<IActionResult> CreateReview([FromBody] AddReviewCommand command)
        {
            await SendAsync(command);

            return Ok();
        }

        [HttpGet]
        [Route("/{menuItemId}")]
        public Task<IEnumerable<ReviewModel>> GetRestaurantDetails([FromRoute] string menuItemId)
        {
            return SendAsync(new GetReviewsQuery(menuItemId));
        }
    }
}
