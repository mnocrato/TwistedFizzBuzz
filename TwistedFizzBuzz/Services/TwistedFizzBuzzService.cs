using TwistedFizzBuzzLib.Interfaces;

namespace TwistedFizzBuzzLib.Services
{
    public sealed class TwistedFizzBuzzService : ITwistedFizzBuzzService
    {
        public List<string> GenerateFizzBuzzForRange(int start, int end)
            => GenerateFizzBuzzValuesForRange(start, end, [3, 5], ["Fizz", "Buzz"]);

        public List<string> GenerateCustomFizzBuzzForRange(int start, int end, List<int> divisors, List<string> tokens)
            => GenerateFizzBuzzValuesForRange(start, end, divisors, tokens);

        private static List<string> GenerateFizzBuzzValuesForRange(int start, int end, List<int> divisors, List<string> tokens)
        {
            var results = new List<string>();
            for (int i = start; i <= end; i++)
                results.Add(GenerateFizzBuzzValue(i, divisors, tokens));

            return results;
        }

        private static string GenerateFizzBuzzValue(int number, List<int> divisors, List<string> tokens)
        {
            var result = string.Empty;

            for (int i = 0; i < divisors.Count; i++)
                if (number % divisors[i] == 0)
                    result += tokens[i];

            return string.IsNullOrEmpty(result) ? number.ToString() : result;
        }

        public List<string> GenerateFizzBuzzForList(List<int> numbers)
        {
            var results = new List<string>();
            foreach (var number in numbers)
                results.Add(GenerateFizzBuzzValue(number, new List<int> { 3, 5 }, new List<string> { "Fizz", "Buzz" }));

            return results;
        }
    }
}