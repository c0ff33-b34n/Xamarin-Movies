using System.Threading.Tasks;

namespace Movies
{
    public interface INetworkService
    {
        Task<TResult> GetAsync<TResult>(string uri);
    }
}