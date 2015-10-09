using System.ServiceModel;
using System.Threading.Tasks;

namespace WCF_Service
{
    [ServiceContract]
    public interface IJokeService
    {
        [OperationContract]
        Task<Joke> GetJokeAsync();
    }
}