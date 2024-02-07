using System;

namespace SingletonDemo
{
    class SingletonClass
    {
        private static SingletonClass _instance;

        // private static readonly object _lock = new object();

        // Private constructor 
        private SingletonClass() { }

        public static SingletonClass Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new SingletonClass();
                }
                return _instance;
            }
        }

        //public static SingletonClass Instance
        //{
        //    get
        //    {
        //        // Double-check locking for thread safety
        //        if (_instance == null)
        //        {
        //            lock (_lock)
        //            {
        //                if (_instance == null)
        //                {
        //                    _instance = new SingletonClass();
        //                }
        //            }
        //        }
        //        return _instance;
        //    }
        //}



        public void Greeting(string name)
        {
            Console.WriteLine($"Hello, {name}");
        }
    }
}
