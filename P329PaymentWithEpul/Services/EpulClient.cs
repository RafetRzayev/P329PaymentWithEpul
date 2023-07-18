using Newtonsoft.Json;
using P329PaymentWithEpul.Models;
using System.Transactions;

namespace P329PaymentWithEpul.Services
{
    public class EpulClient
    {
        private readonly HttpClient _httpClient = new HttpClient();
        private readonly string _username = "code";
        private readonly string _password = "code2023";

        public async Task<EpulTransactionModel> CreateTransaction(decimal orderPrice, string orderDescription, string transactionId)
        {
            orderPrice *= 100;

            string url = $"https://www.e-pul.az/epul_api/pay_via_epul/register_transaction?" +
                $"username={_username}" +
                $"&password={_password}" +
                $"&amount={orderPrice}" +
                $"&description={orderDescription}" +
                $"&transactionId={transactionId}" +
                $"&backUrl=https://localhost:7054/home/checkTransaction" +
                $"&errorUrl=https://localhost:7054/home/checkTransaction" +
                $"&directPay=true";

            var response = await _httpClient.GetAsync(url);

            if (!response.IsSuccessStatusCode)
            {
                throw new Exception($"Error happened request this url {response.RequestMessage.RequestUri}. Status code :{response.StatusCode}");
            }

            var json = await response.Content.ReadAsStringAsync();
            var model = JsonConvert.DeserializeObject<EpulTransactionModel>(json);

            return model ?? new EpulTransactionModel();
        }

        public async Task<bool> CheckTransaction(string orderId)
        {
            string url = $"https://www.e-pul.az/epul_api/pay_via_epul/check_transaction?" +
               $"username={_username}" +
               $"&password={_password}" +
               $"&orderId={orderId}";
            
            var response = await _httpClient.GetAsync(url);

            if (!response.IsSuccessStatusCode)
            {
                throw new Exception($"Error happened request this url {response.RequestMessage.RequestUri}. Status code :{response.StatusCode}");
            }

            var json = await response.Content.ReadAsStringAsync();
            var model = JsonConvert.DeserializeObject<EpulTransactionModel>(json);

            return model?.Success ?? false;
        }
    }
}
