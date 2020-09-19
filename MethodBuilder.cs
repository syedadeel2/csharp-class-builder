////////////////////////////////////////////////////////////////////////////////////////////////////
// file:	MethodBuilder.cs
//
// summary:	Implements the method builder class
////////////////////////////////////////////////////////////////////////////////////////////////////

using Rizvis.ClassBuilder.Interfaces;
using System.Collections.Generic;
using System.Text;

namespace Rizvis.ClassBuilder
{
    ////////////////////////////////////////////////////////////////////////////////////////////////////
    /// <summary>   A method builder. This class cannot be inherited. </summary>
    ///
    /// <remarks>   Rizvi, 19/09/2020. </remarks>
    ////////////////////////////////////////////////////////////////////////////////////////////////////

    public sealed class MethodBuilder : IClassMethod
    {
        /// <summary>   The element. </summary>
        private readonly Dictionary<string, string> _elem;
        private readonly StringBuilder _sb;

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Default constructor. </summary>
        ///
        /// <remarks>   Rizvi, 19/09/2020. </remarks>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public MethodBuilder(StringBuilder sb)
        {
            _elem = new Dictionary<string, string> {
                { "comments", "" },
                { "modifier", "" },
                { "name", "" },
                { "args", "" },
                { "code", "" },
                { "type", "" },
                { "returnType", "" },
            };

            _sb = sb;
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Adds a method description. </summary>
        ///
        /// <remarks>   Rizvi, 19/09/2020. </remarks>
        ///
        /// <param name="description">  The description. </param>
        ///
        /// <returns>   An IClassMethod. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public IClassMethod AddMethodDescription(string description)
        {
            var sb = new StringBuilder();
            sb.AppendLine("\n");
            sb.AppendLine("////////////////////////////////////////////////////////////////////////////////////////////////////");
            sb.AppendLine($"/* <summary> {description} </summary> */");
            sb.AppendLine("////////////////////////////////////////////////////////////////////////////////////////////////////");

            _elem["comments"] = sb.ToString();
            return this;
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Converts a type to a return with. </summary>
        ///
        /// <remarks>   Rizvi, 19/09/2020. </remarks>
        ///
        /// <typeparam name="T">    Generic type parameter. </typeparam>
        /// <param name="type"> The type. </param>
        ///
        /// <returns>   An IClassMethod. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public IClassMethod AsReturnWithType<T>(T type)
        {
            _elem["returnType"] = type.GetType().Name;
            return this;
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Converts this  to a void. </summary>
        ///
        /// <remarks>   Rizvi, 19/09/2020. </remarks>
        ///
        /// <returns>   An IClassMethod. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public IClassMethod AsVoid()
        {
            _elem["returnType"] = "void";
            return this;
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Creates a method. </summary>
        ///
        /// <remarks>   Rizvi, 19/09/2020. </remarks>
        ///
        /// <param name="name">     The name. </param>
        /// <param name="modifier"> The modifier. </param>
        ///
        /// <returns>   The new method. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public IClassMethod CreateMethod(string name, Modifier modifier)
        {
            _elem["name"] = name;
            _elem["modifier"] = modifier.ToString().ToLower();
            return this;
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   With arguments. </summary>
        ///
        /// <remarks>   Rizvi, 19/09/2020. </remarks>
        ///
        /// <param name="args"> A variable-length parameters list containing arguments. </param>
        ///
        /// <returns>   An IClassMethod. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public IClassMethod WithArguments(params string[] args)
        {
            _elem["args"] = string.Join(",", args);
            return this;
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   With asynchronous. </summary>
        ///
        /// <remarks>   Rizvi, 19/09/2020. </remarks>
        ///
        /// <returns>   An IClassMethod. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public IClassMethod WithAsync()
        {
            _elem["returnType"] = "async " + _elem["returnType"] == "void" ? "void" : "Task<" + _elem["returnType"] + ">";
            return this;
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Adds a code black. </summary>
        ///
        /// <remarks>   Rizvi, 19/09/2020. </remarks>
        ///
        /// <param name="codeBlock">    The code block. </param>
        ///
        /// <returns>   An IClassMethod. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public IClassMethod AddCodeBlack(string codeBlock)
        {
            _elem["code"] = codeBlock;
            return this;
        }



        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Converts this  to a static. </summary>
        ///
        /// <remarks>   Rizvi, 19/09/2020. </remarks>
        ///
        /// <returns>   The IClass. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public IClassMethod AsStatic()
        {
            _elem["type"] = "static";
            return this;
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Converts this  to a sealed. </summary>
        ///
        /// <remarks>   Rizvi, 19/09/2020. </remarks>
        ///
        /// <returns>   The IClass. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public IClassMethod AsSealed()
        {
            _elem["type"] = "sealed";
            return this;
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Converts this  to an abstract. </summary>
        ///
        /// <remarks>   Rizvi, 19/09/2020. </remarks>
        ///
        /// <returns>   The IClass. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public IClassMethod AsAbstract()
        {
            _elem["type"] = "abstract";
            return this;
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Converts a type to a return with. </summary>
        ///
        /// <remarks>   Rizvi, 19/09/2020. </remarks>
        ///
        /// <param name="type"> The type. </param>
        ///
        /// <returns>   An IClassMethod. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public IClassMethod AsReturnWith(string type)
        {
            _elem["returnType"] = Utils.ProcessReturnType(type);
            return this;
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets the build. </summary>
        ///
        /// <remarks>   Rizvi, 19/09/2020. </remarks>
        ///
        /// <returns>   An IClassMethod. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public IClassMethod Build()
        {
            _sb.AppendLine(_elem["comments"]);
            _sb.AppendLine($"{_elem["modifier"]} {_elem["type"]} {_elem["returnType"]} {_elem["name"]} ({_elem["args"]}) {{\n {_elem["code"]} \n}} \n");
            return this;
        }

     
    }
}
