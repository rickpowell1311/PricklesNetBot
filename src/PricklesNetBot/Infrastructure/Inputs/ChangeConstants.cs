using System;
using System.ComponentModel;
using System.Linq;
using System.Reflection;

namespace PricklesNetBot.Infrastructure.Inputs
{
    public static class ChangeConstants
    {
        public static void Go()
        {
            Console.Write("Enter a class name: ");
            var className = Console.ReadLine();

            Console.Write("Enter a variable name: ");
            var variableName = Console.ReadLine();

            Console.Write("Enter a value: ");
            if (!int.TryParse(Console.ReadLine(), out int value))
            {
                Console.WriteLine("Could not parse value - it should be a number");
            }

            var classMatch = Assembly.GetExecutingAssembly().GetTypes()
                .SingleOrDefault(t => t.IsClass && t.Name == className);

            var memberMatch = classMatch?.GetField(variableName);

            if (memberMatch != null)
            {
                try
                {
                    var originalValue = memberMatch.GetValue(null);
                    memberMatch.SetValue(null, value);
                    Console.WriteLine($"Successfully changed property value from {originalValue} to {value}!");
                    Console.WriteLine();
                    return;
                }
                catch
                {
                    Console.WriteLine("Error setting variable value");
                    Console.WriteLine();
                    return;
                }
            }

            Console.WriteLine("Could not find either class or property");
            Console.WriteLine();
        }
    }
}
