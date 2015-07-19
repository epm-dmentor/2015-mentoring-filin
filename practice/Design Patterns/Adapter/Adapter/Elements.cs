using System.Collections.Generic;

namespace Epam.NetMentoring.DesignPatterns.Adapter
{
    internal class Elements : IElements<string>
    {
        private readonly IEnumerable<string> lists;

        public Elements(IEnumerable<string> lists)
        {
            this.lists = lists;
        }

        public IEnumerable<string> GetElements()
        {
            return lists;
        }
    }
}