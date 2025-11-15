using MakFood.Kitchen.Application.Command.FoodRequest;
using MakFood.Kitchen.Application.Query.GetFoodRequestsByDateRange;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Storage.Json;

namespace MakFood.Kitchen.Controllers
{
    [ApiController]
    [Route("/api/[controller]")]
    public class FoodRequestController : ControllerBase
    {
        private readonly IMediator _mediator;

        public FoodRequestController(IMediator mediator)
        {
            _mediator = mediator;
        }


        [HttpPost]
        public async Task<IActionResult> AddFoodRequest([FromBody] FoodRequestCommand command)
        {
            var result = await _mediator.Send(command);

            return Ok(result);
        }

        [HttpGet("Product/Count")]
        public async Task<IActionResult> GetFoodRequestsByDateRange(DateOnly fromDate, DateOnly ToDate)
        {
            var query = new GetFoodRequestsByDateQuery()
            {
                FromDate = fromDate,
                ToDate = ToDate
            };

            var result = await _mediator.Send(query);

            return Ok(result);
        }
    }
}
