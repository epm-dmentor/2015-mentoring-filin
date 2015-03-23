#region

using Epam.NetMentoring.Zoo.Animals;

#endregion

namespace Epam.NetMentoring.Zoo
{
    public interface IAnimalReceiver
    {
        void Receive(IAnimal animal);
    }
}