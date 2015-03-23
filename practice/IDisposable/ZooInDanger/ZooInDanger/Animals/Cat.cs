#region

using System.Threading;

#endregion

namespace Epam.NetMentoring.Zoo.Animals
{
    public class Cat : Animal
    {
        public Cat(IAnimalStatusTracker statusTracker) : base(statusTracker)
        {
        }

        public override int LifeInterval
        {
            get { return 13; }
        }

        public override int InfectionDeathInterval
        {
            get { return 300; }
        }

        ~Cat()
        {
            Logger.LogYellow("Finalizing cat!");

            //Releasea object only in case troops number > 100
            while (Zoo.Troops > 200)
            {
                Interlocked.Decrement(ref Zoo.Troops);
            }
        }
    }
}