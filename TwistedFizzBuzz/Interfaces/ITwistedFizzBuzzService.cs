namespace TwistedFizzBuzzLib.Interfaces
{
    public interface ITwistedFizzBuzzService
    {
        List<string> GenerateFizzBuzzForRange(int start, int end);
        List<string> GenerateFizzBuzzForList(List<int> numbers);
        List<string> GenerateCustomFizzBuzzForRange(int start, int end, List<int> divisors, List<string> tokens);
    }
}
