
# csharp-class-builder
Sometime you need fluent api to design the class and output as string for Reflection or anyother purposes and you end up with lot of string lines and messy code. This library will provide you fluent api to design the class and out as string.

# Future Changes
1. Compile Class
2. Execute Methods
3. Generate Dll on Runtime.

# Usages

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
# Output 

    using System;
    using System.Threading.Tasks;
    namespace Rizvis.Tester.App { 
    
    ////////////////////////////////////////////////////////////////////////////////////////////////////
    /* <summary> My Test Class </summary> */
    ////////////////////////////////////////////////////////////////////////////////////////////////////
    public class Main  {
    
    
    ////////////////////////////////////////////////////////////////////////////////////////////////////
    /* <summary> My Hello World Method </summary> */
    ////////////////////////////////////////////////////////////////////////////////////////////////////
    
    public void HelloWorld () {
     Console.WriteLine("Hello World") 
    } 
    
    
    
    ////////////////////////////////////////////////////////////////////////////////////////////////////
    /* <summary> This is my test property 1 </summary> */
    ////////////////////////////////////////////////////////////////////////////////////////////////////
    
    public Boolean myGetProperty { get; set; }
    
    
    ////////////////////////////////////////////////////////////////////////////////////////////////////
    /* <summary> This is my test property 2 </summary> */
    ////////////////////////////////////////////////////////////////////////////////////////////////////
    
    private dynamic myGetProperty2 { get; set; }
    }
    
    }

# API

Class API
> 1. `CreateClass(string name, Modifier modifier, string description = "")`
> 2. `WithNamespace(string nameSpace)`
> 3. `ExtendWith(string extendClassOrInterfaceName)`
> 4. `ImportPackage(string packageName)`
> 5. `AsStatic()`
> 6. `AsSealed()`
> 7. `AsAbstract()`
> 8. `Build()`

Method API
> 1. `CreateMethod(string name, Modifier modifier)`
> 2. `WithArguments(params string[] args)`
> 3. `AsVoid()`
> 4. `WithAsync()`
> 5. `AsReturnWithType<T>(T type)`
> 6. `AsReturnWith(string type)`
> 7. `AddMethodDescription(string description)`
> 8. `AddCodeBlack(string codeBlock)`
> 9. `AsStatic()`
> 10. `AsSealed()`
> 11. `AsAbstract()`
> 12. `Build()`

Property API
> 1. `CreateProperty(string name, Modifier modifier)`
> 2. `AsReturnWithType<T>(T type)`
> 3. `AsReturnWith(string type)`
> 4. `AddPropertyDescription(string description)`
> 5. `AsAbstract()`
> 6. `AsStatic()`
> 7. `ReadOnly()`
> 8. `Getter()`
> 9. `Setter()`
> 10. `Build()`

# Sample Code
Please clone this project and run Rizvis.ClassBuilder.Tester 

For online demo click here <a href="https://dotnetfiddle.net/mbqaZT">https://dotnetfiddle.net/mbqaZT</a>
