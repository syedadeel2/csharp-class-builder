using System;
using System.IO;

namespace Rizvis.ClassBuilder.Tester
{
    class Program
    {
        static void Main(string[] args)
        {

            var cb = new ClassBuilder();

            // New class
            var c = cb.CreateClass("Main", Modifier.Public, "My Test Class")
                                  .AsSealed()
                                  .WithNamespace("Rizvis.Tester.App")
                                  .ImportPackage("System")
                                  .ImportPackage("System.Threading.Tasks")
                                  .Build();

            // New Method
            c.Methods().CreateMethod("HelloWorld", Modifier.Public)
                                           .AsVoid()
                                           .AddCodeBlack("Console.WriteLine(\"Hello World\")")
                                           .AddMethodDescription("My Hello World Method")
                                           .Build();

            // New Property 1
            c.Properties().CreateProperty("myGetProperty", Modifier.Public)
                          .AsReturnWithType(true)
                          .Getter()
                          .Setter()
                          .AddPropertyDescription("This is my test property 1")
                          .Build();

            // New Property 2
            c.Properties().CreateProperty("myGetProperty2", Modifier.Private)
                          .AsReturnWith("dynamic")
                          .Getter()
                          .Setter()
                          .AddPropertyDescription("This is my test property 2")
                          .Build();

            File.WriteAllText(@"test.cs", cb.ToString());

            Console.WriteLine(cb.ToString());
            Console.WriteLine("Done");

        }
    }
}
