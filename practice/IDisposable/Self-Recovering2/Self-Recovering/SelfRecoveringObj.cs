using System;
using System.Collections.Generic;

namespace Self_Recovering
{
    public class SelfRecoveringObj
    {
        private readonly List<SelfRecoveringObj> _pool;

        public SelfRecoveringObj()
        {
            RegenerationCount = 0;
            _pool = new List<SelfRecoveringObj>();

        }

        public int RegenerationCount { get; private set; }

        ~SelfRecoveringObj()
        {
            RegenerationCount++;
            _pool.Add(this);
            GC.ReRegisterForFinalize(this);
            Console.WriteLine("Object {0} restored {1} times", GetHashCode(), RegenerationCount);
        }

        
    }
}