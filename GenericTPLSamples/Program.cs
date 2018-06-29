using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GenericTPLSamples
{
    class Program
    {
        static void Main(string[] args)
        {
            List<IntObject> intObjects = new List<IntObject>() {
                new IntObject() { IntProperty = 1 },
                new IntObject() { IntProperty = 2 },
                new IntObject() { IntProperty = 3 },
            };

            TplThis(IncrementPrint, intObjects);
        }

        static void TplThis<T>(Action<T> method, List<T> arg)
        {
            List<Task> tasks = new List<Task>();

            arg.ForEach(a => {
                tasks.Add( Task.Factory.StartNew( () => method(a) ) );
            });

            Task.WaitAll(tasks.ToArray());
        }

        static void IncrementPrint(IntObject intObject)
        {
            Console.WriteLine($"{++intObject.IntProperty}");
        }
        
    }

    public class IntObject
    {
        public int IntProperty { get; set; }
    }
}
