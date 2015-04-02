namespace Epam.NetMentoring.Zoo.Animals
{
    //Inheriting IDisposable is overdesign, but every our animal is need to be disposed!!!
    //BK: If every animal needs to be disposed, than it is not overdesign :) May be you could try to implement some kind of dispose patter for every animal?
    public interface IAnimal //: IDisposable
    {
        int Age { get; }
        bool IsAlive { get; }
        void Eat(string eatName);
        void Kill();
        void Infect();
    }
}