using MakFood.Kitchen.Domain.Entities.OrderAggrigate.OrderAggrigate;
using MakFood.Kitchen.Domain.Entities.ProductAggrigate.Contract;
using Microsoft.AspNetCore.SignalR;
using System.Security.Claims;
using System.Text.Json;

namespace MakFood.Kitchen.Application.Command.LiveProductQuantity
{
    public class LiveProductQuantity : Hub
    {
        private readonly IProductRepository _productRepository;

        public LiveProductQuantity(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task ChangeAmountOfProduct(Order order)
        {
            await Clients.Clients(Context.ConnectionId).SendAsync("ChangeAmountOfProduct", JsonSerializer.Serialize(order));
        }

        public override async Task OnConnectedAsync()
        {

            var userId = Context.User?.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            Console.WriteLine($"User Connected: {userId} - ConnectionId: {Context.ConnectionId}");

            var allOrders = await _productRepository.GetAllProductsAsync();

            foreach (var order in allOrders)
            {
                await Clients.Client(Context.ConnectionId).SendAsync("OnConnect",JsonSerializer.Serialize(order));
            }
        }
    }
}


