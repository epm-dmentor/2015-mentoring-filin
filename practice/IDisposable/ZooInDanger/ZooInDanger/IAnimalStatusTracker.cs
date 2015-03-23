#region

using Epam.NetMentoring.Zoo.Animals;

#endregion

namespace Epam.NetMentoring.Zoo
{
    public interface IAnimalStatusTracker
    {
        void IsInHunger(IAnimal animal);
        void Died(IAnimal animal);
    }
}