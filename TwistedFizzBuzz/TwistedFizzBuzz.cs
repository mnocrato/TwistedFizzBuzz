using TwistedFizzBuzzLib.Interfaces;

namespace TwistedFizzBuzzLib
{
    public class TwistedFizzBuzz(ITwistedFizzBuzzService fizzBuzzService, IApiTokenService apiTokenService)
    {
        private readonly ITwistedFizzBuzzService _twistedFizzBuzzService = fizzBuzzService;
        private readonly IApiTokenService _apiTokenService = apiTokenService;

        public List<string> GenerateFizzBuzzForRange(int start, int end)
            => _twistedFizzBuzzService.GenerateFizzBuzzForRange(start, end);

        public List<string> GenerateFizzBuzzForList(List<int> numbers)
            => _twistedFizzBuzzService.GenerateFizzBuzzForList(numbers);

        public List<string> GenerateCustomFizzBuzzForRange(int start, int end, List<int> divisors, List<string> tokens)
            => _twistedFizzBuzzService.GenerateCustomFizzBuzzForRange(start, end, divisors, tokens);

        public async Task<List<string>> GenerateFizzBuzzWithApiTokens(int start, int end, string apiUrl)
        {
            var (Numbers, Tokens) = await _apiTokenService.FetchApiTokens(apiUrl);
            return _twistedFizzBuzzService.GenerateCustomFizzBuzzForRange(start, end, Numbers, Tokens);
        }
    }
}