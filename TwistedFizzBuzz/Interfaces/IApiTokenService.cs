namespace TwistedFizzBuzzLib.Interfaces
{
    public interface IApiTokenService
    {
        Task<(List<int> Numbers, List<string> Tokens)> FetchApiTokens(string apiUrl);
    }
}
