using System.CodeDom.Compiler;
using System.ServiceModel;
using System.Threading.Tasks;

namespace WCFClient
{
    [GeneratedCode("System.ServiceModel", "4.0.0.0")]
    [ServiceContract(ConfigurationName = "JokeService.IJokeService")]
    public interface IJokeService
    {
        [OperationContract(Action = "http://tempuri.org/IJokeService/GetJoke",
            ReplyAction = "http://tempuri.org/IJokeService/GetJokeResponse")]
        JokeService.Joke GetJoke();

        [OperationContract(Action = "http://tempuri.org/IJokeService/GetJoke",
            ReplyAction = "http://tempuri.org/IJokeService/GetJokeResponse")]
        Task<JokeService.Joke> GetJokeAsync();
    }
}