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
    public class RestaurantsController : ApiControllerBase
    {
        public RestaurantsController(ISender mediator) : base(mediator)
        {
        }

        [HttpPost]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        public async Task<IActionResult> CreateRestaurant([FromBody] CreateRestaurantCommand command)
        {
            await SendAsync(command);

            return Ok();
        }

        [HttpPost]
        [Route("{restaurantId}/menu-item")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        public async Task<IActionResult> AddMenuItem([FromRoute] string restaurantId, [FromBody] AddMenuItemCommand command)
        {
            command.RestaurantId = restaurantId;
            await SendAsync(command);

            return Ok();
        }

        [HttpPut]
        [Route("{restaurantId}/opening-hours")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        public async Task<IActionResult> SetOpeningHours([FromRoute] string restaurantId, [FromBody] SetOpeningHoursCommand command)
        {
            command.RestaurantId = restaurantId;
            await SendAsync(command);

            return Ok();
        }

        [HttpGet]
        [Route("/nearby")]
        public Task<IEnumerable<RestaurantModel>> GetNrearbyRrestaurants([FromQuery] double latitude, [FromQuery] double longitude, [FromQuery] double maxDistance)
        {
            return SendAsync(new GetNearbyRestaurantsQuery(latitude, longitude, maxDistance));
        }

        [HttpGet]
        [Route("/{restaurantId}")]
        public Task<RestaurantDetailsModel> GetRestaurantDetails([FromRoute] string restaurantId)
        {
            return SendAsync(new GetRestaurantDetailsQuery(restaurantId));
        }
    }
}
