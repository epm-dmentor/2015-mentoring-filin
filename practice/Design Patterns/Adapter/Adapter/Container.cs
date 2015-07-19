using System.Collections.Generic;
using System.Linq;

namespace Epam.NetMentoring.DesignPatterns.Adapter
{
    internal class Container : IContainer<string>
    {
        private readonly Elements elements;

        public Container(Elements elements)
        {
            this.elements = elements;
        }

        public IEnumerable<object> Items
        {
            get { return elements.GetElements(); }
        }

        public int Count
        {
            get { return elements.GetElements().Count(); }
        }
    }
}