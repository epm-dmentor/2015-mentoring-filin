using System;
using System.Collections.Generic;

namespace Self_Recovering
{
    public class SelfRecoveringObj
    {
        //Create the cache. 
        private readonly Dictionary<int, WeakReference> _cache;

        public SelfRecoveringObj(int count)
        {
            RegenerationCount = 0;
            _cache = new Dictionary<int, WeakReference>();

            //Add objects with a short weak reference to the cache. 
            for (int i = 0; i < count; i++)
            {
                //BK: What is this flag can be used for?
                //AF: True is long and false is short weak references
                //Short – Once the object is reclaimed by garbage collection, the reference is set to null. 
                //Long – If the object has a finalizer AND the reference is created with the correct options, 
                //then the reference will point to the object until the finalizer completes.
                _cache.Add(i, new WeakReference(new Data(i), false));
            }
        }

        //Number of items in the cache. 
        public int Count
        {
            get { return _cache.Count; }
        }

        //Number of times an object needs to be regenerated. 
        public int RegenerationCount { get; private set; }

        //Retrieve a data object from the cache. 
        public Data this[int index]
        {
            get
            {
                var d = (Data)_cache[index].Target;
                if (d == null)
                {
                    //If the object was reclaimed, recreate a new one.
                    Console.WriteLine("Recreate object at {0}: Yes", index);
                    d = new Data(index);
                    _cache[index].Target = d;
                    RegenerationCount++;
                }
                else
                {
                    //Object was obtained with the weak reference.
                    Console.WriteLine("Recreate object at {0}: No", index);
                }

                return d;
            }
        }
    }
}
