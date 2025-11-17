using MakFood.Kitchen.Domain.WalletService;
using System.Net.Http.Json;

namespace MakFood.Kitchen.Infrastructure.Persistence.Repository
{
    public class WalletHttpClientService : IWallerService
    {
        private readonly HttpClient _httpClient;

        public WalletHttpClientService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }


        public Task<bool> ProcessPaymentAsync(Guid orderId, decimal amount, Guid userId)
        {
            var paymentDto = new AddOrderDetailDto
            {
                OrderId = orderId,
                OrderAmount = amount,
                UserId = userId
            };

            var response = await _httpClient.PostAsJsonAsync("api/v1/wallet/pay", paymentDto);
        }
    }
}
