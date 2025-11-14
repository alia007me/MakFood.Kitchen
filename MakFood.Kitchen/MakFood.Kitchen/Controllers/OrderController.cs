using MakFood.Kitchen.Application.Command.CancelOrder;
using MakFood.Kitchen.Application.Query.GetAllMiseOnPlaceOrderByDateRange;
using MakFood.Kitchen.Application.Query.GetProductOrderCountsByDateRange;
using MakFood.Kitchen.Application.Query.GetTotalSalesByDateRange;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace MakFood.Kitchen.Controllers
{
    [ApiController]
    [Route("/api/[controller]")]

    public class OrderController : ControllerBase
    {
        private readonly IMediator _mediator;

        public OrderController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("State/Mise-On-Place")]
        public async Task<IActionResult> GetAllMiseOnPlaceOrdersByDateRange(DateOnly fromDate,DateOnly ToDate)
        {
            var getAllMiseOnPlaceOrdersByDateRangeQuery = new GetAllMiseOnPlaceOrdersByDateRangeQuery{FromDate = fromDate,ToDate = ToDate };

            var result = await _mediator.Send(getAllMiseOnPlaceOrdersByDateRangeQuery);

            return Ok(result);
        }

        [HttpGet("Product/Count")]
        public async Task<IActionResult> GetProductOrderCountsByDateRange(DateOnly fromDate, DateOnly ToDate)
        {
            var GetProductOrderCountsByDateRangeQuery = new GetProductOrderCountsByDateRangeQuery { FromDate = fromDate, ToDate = ToDate };

            var result = await _mediator.Send(GetProductOrderCountsByDateRangeQuery);

            return Ok(result);
        }

        [HttpGet("Sold/Amount")]
        public async Task<IActionResult> GetTotalSalesByDateRange(DateOnly fromDate, DateOnly ToDate)
        {
            var GetTotalSalesByDateRangeQuery = new GetTotalSalesByDateRangeQuery { FromDate = fromDate, ToDate = ToDate };

            var result = await _mediator.Send(GetTotalSalesByDateRangeQuery);

            return Ok(result);
        }

        [HttpPatch("{orderId}/Cancel")]
        public async Task<IActionResult> CancelOrder(Guid orderId, Guid customerId)
        {
            var CancelOrderCommand = new CancelOrderCommand(customerId,orderId);

            var result = await _mediator.Send(CancelOrderCommand);

            return Ok(result);
        }



    }
}
