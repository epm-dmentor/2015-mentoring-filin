﻿using System;
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