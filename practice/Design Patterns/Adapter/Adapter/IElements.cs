using System.Collections.Generic;

namespace Epam.NetMentoring.DesignPatterns.Adapter
{
    public interface IElements<out T>
    {
        IEnumerable<T> GetElements();
    }
}