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

        //~Cat()
        //{
        //    Logger.LogYellow("Finalizing cat!");
        //    //BK: What happens if A is a base class for B, we initialize A a = new B(); and a then garbage collected? Think about that and try to think what happens in context of animal and cat
        //    //Releasea object only in case troops number > 100
        //    //while (Zoo.Troops > 200)
        //    //{
        //    //    Interlocked.Decrement(ref Zoo.Troops);
        //    //}
        //}
    }
}