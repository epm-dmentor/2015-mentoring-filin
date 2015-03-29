using System.Globalization;

namespace Self_Recovering
{
    //Emulate data
    public class Data
    {
        private byte[] _data;

        public Data(int size)
        {
            _data = new byte[size*1024];
            Name = size.ToString(CultureInfo.InvariantCulture);
        }

        public string Name { get; private set; }
    }
}