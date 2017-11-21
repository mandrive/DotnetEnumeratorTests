using System;

namespace dotnet
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Starting test...");

            var am = new AssetManager(InitializationCollection.Enumerable);
            var resolvedInForeach = am.UpdatePropertyByResolvingEnumerableInForeachAndSecondTimeInReturn();
            var resolvedBeforeForeach = am.UpdatePropertyByResolvingEnumerableBeforeAndInForeachAndInReturn();
            
            Console.WriteLine("Testing for Linq2Objects enumerable as source...");
            Console.WriteLine($"Property not updated when enumerable resolved in foreach: {resolvedInForeach[0].Name.StartsWith("Name")}");
            Console.WriteLine($"Property updated when enumerable resolved before foreach: {resolvedBeforeForeach[0].Name.StartsWith("Better")}\n\n");

            am = new AssetManager(InitializationCollection.List);
            resolvedInForeach = am.UpdatePropertyByResolvingEnumerableInForeachAndSecondTimeInReturn();
            resolvedBeforeForeach = am.UpdatePropertyByResolvingEnumerableBeforeAndInForeachAndInReturn();

            Console.WriteLine("Testing for Linq2Objects enumerable.ToList() as source...");
            Console.WriteLine($"Property not updated when enumerable resolved in foreach: {resolvedInForeach[0].Name.StartsWith("Name")}");
            Console.WriteLine($"Property updated when enumerable resolved before foreach: {resolvedBeforeForeach[0].Name.StartsWith("Better")}\n\n");

            am = new AssetManager(InitializationCollection.Array);
            resolvedInForeach = am.UpdatePropertyByResolvingEnumerableInForeachAndSecondTimeInReturn();
            resolvedBeforeForeach = am.UpdatePropertyByResolvingEnumerableBeforeAndInForeachAndInReturn();

            Console.WriteLine("Testing for Linq2Objects enumerable.ToArray() as source...");
            Console.WriteLine($"Property not updated when enumerable resolved in foreach: {resolvedInForeach[0].Name.StartsWith("Name")}");
            Console.WriteLine($"Property updated when enumerable resolved before foreach: {resolvedBeforeForeach[0].Name.StartsWith("Better")}\n\n");

            am = new AssetManager(InitializationCollection.Queryable);
            resolvedInForeach = am.UpdatePropertyByResolvingEnumerableInForeachAndSecondTimeInReturn();
            resolvedBeforeForeach = am.UpdatePropertyByResolvingEnumerableBeforeAndInForeachAndInReturn();

            Console.WriteLine("Testing for Linq2Objects enumerable.AsQueryable() as source...");
            Console.WriteLine($"Property not updated when enumerable resolved in foreach: {resolvedInForeach[0].Name.StartsWith("Name")}");
            Console.WriteLine($"Property updated when enumerable resolved before foreach: {resolvedBeforeForeach[0].Name.StartsWith("Better")}\n\n");
        }
    }
}
