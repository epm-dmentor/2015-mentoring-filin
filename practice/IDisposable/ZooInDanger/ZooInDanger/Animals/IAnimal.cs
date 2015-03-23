namespace Epam.NetMentoring.Zoo.Animals
{
    //Inheriting IDisposable is overdesign, but every our animal is need to be disposed!!!
    public interface IAnimal //: IDisposable
    {
        int Age { get; }
        bool IsAlive { get; }
        void Eat(string eatName);
        void Kill();
        void Infect();
    }
}