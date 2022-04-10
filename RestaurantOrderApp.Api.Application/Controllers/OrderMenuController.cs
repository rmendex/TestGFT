using MediatR;
using Microsoft.AspNetCore.Mvc;
using RestaurantOrderApp.Api.Infra.Resources.Queries;
using RestaurantOrderApp.Api.Shared.Enums;
using RestaurantOrderApp.Api.Shared.Implementation;
using RestaurantOrderApp.Api.Shared.Interface;
using RestaurantOrderApp.Api.Shared.Utils;
using System;
using System.Threading.Tasks;

namespace RestaurantOrderApp.Api.Application.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class OrderMenuController : ControllerBase
    {
        // POST v1/OrderMenu
        /// <summary>
        /// Request Dishes
        /// </summary>
        /// <remarks>
        /// Example:
        ///
        ///     POST /api/OrderMenu/v1/meals
        ///     {
        ///        "TimeOfDay": "morning",
        ///        "DishType": [1,2,3]
        ///     }
        ///
        /// </remarks>
        /// <returns>Order requested</returns>
        /// <response code="200">Returns meals requested</response>
        /// <response code="400">Bad Request</response>
        /// <response code="500">Internal Server Error</response> 
        [HttpPost]
        [Route("v1/meals")]
        public async Task<ICommandResult> OrderMeals([FromServices]IMediator mediator, [FromBody] GetDishesQuery getDishes)
        {
            Task<CommandResult> commandResult = null;

            try
            {
                var obj = await mediator.Send(getDishes);

                if (obj != null)
                {
                    commandResult = Task.Factory.StartNew(() => new CommandResult
                    (
                        true, "", RetornoApi.Sucess, obj)
                    );
                }
            }
            catch (Exception e)
            {
                commandResult = Task.Factory.StartNew(() => new CommandResult(false, e.Message, CacheReturnHttpCode.ReturnApi, null));
            }

            return await commandResult;

        }
    }
}
