using TwistedFizzBuzzLib.Interfaces;

namespace TwistedFizzBuzzLib.Services
{
    public sealed class ApiTokenService(HttpClient httpClient) : IApiTokenService
    {
        private readonly HttpClient _httpClient = httpClient;

        public async Task<(List<int> Numbers, List<string> Tokens)> FetchApiTokens(string apiUrl)
        {
            using var client = new HttpClient();
            var response = await _httpClient.GetStringAsync(apiUrl);
            // IF API IT'S WORKING
            // Assuming the response is in the format {"divisors":[...], "tokens":[...]}
            //  var apiResult = System.Text.Json.JsonSerializer.Deserialize<ApiResult>(response);

            // API isn't working 
            var apiResult = new ApiResult
            {
                Divisors = [1, 3, 5],
                Tokens = ["test1", "teste3", "test5"]
            };

            return (apiResult.Divisors, apiResult.Tokens);
        }

        private class ApiResult
        {
            public List<int> Divisors { get; set; }
            public List<string> Tokens { get; set; }
        }
    }
}
