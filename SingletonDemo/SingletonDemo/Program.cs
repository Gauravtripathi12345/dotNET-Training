using System;

namespace SingletonDemo
{
    class Program
    {
        static void Main(string[] args)
        {

            // instance of the SingletonClass
            SingletonClass singleton1 = SingletonClass.Instance;
            SingletonClass singleton2 = SingletonClass.Instance;

            Console.WriteLine(singleton1 == singleton2);

            string username = Username();
            singleton2.Greeting(username);

            Console.ReadLine();
        }

        public static string Username()
        {
            Console.WriteLine("Enter your name");
            string name = Console.ReadLine();
            return name;
        }
    }
}
