////////////////////////////////////////////////////////////////////////////////////////////////////
// file:	PropertyBuilder.cs
//
// summary:	Implements the property builder class
////////////////////////////////////////////////////////////////////////////////////////////////////

using Rizvis.ClassBuilder.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Rizvis.ClassBuilder
{
    ////////////////////////////////////////////////////////////////////////////////////////////////////
    /// <summary>   A property builder. This class cannot be inherited. </summary>
    ///
    /// <remarks>   Rizvi, 19/09/2020. </remarks>
    ////////////////////////////////////////////////////////////////////////////////////////////////////

    public class PropertyBuilder : IClassProperty
    {
        private readonly StringBuilder _sb;

        /// <summary>   The element. </summary>
        private Dictionary<string, string> _elem;

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Default constructor. </summary>
        ///
        /// <remarks>   Rizvi, 19/09/2020. </remarks>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public PropertyBuilder(StringBuilder sb)
        {
            _elem = new Dictionary<string, string> {
                { "comments", "" },
                { "modifier", "" },
                { "name", "" },
                { "type", "" },
                { "getter", "" },
                { "setter", "" },
                { "readonly", "" },
                { "returnType", "" },
            };

            _sb = sb;
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Adds a property description. </summary>
        ///
        /// <remarks>   Rizvi, 19/09/2020. </remarks>
        ///
        /// <param name="description">  The description. </param>
        ///
        /// <returns>   An IClassProperty. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public IClassProperty AddPropertyDescription(string description)
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
        /// <summary>   Converts this  to an abstract. </summary>
        ///
        /// <remarks>   Rizvi, 19/09/2020. </remarks>
        ///
        /// <returns>   An IClassProperty. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public IClassProperty AsAbstract()
        {
            _elem["type"] = "abstract";
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
        /// <returns>   An IClassProperty. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public IClassProperty AsReturnWithType<T>(T type)
        {
            _elem["returnType"] = type.GetType().Name;
            return this;
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Converts a type to a return with. </summary>
        ///
        /// <remarks>   Rizvi, 19/09/2020. </remarks>
        ///
        /// <param name="type"> The type. </param>
        ///
        /// <returns>   An IClassProperty. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public IClassProperty AsReturnWith(string type)
        {
            _elem["returnType"] = Utils.ProcessReturnType(type);
            return this;
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Converts this  to a static. </summary>
        ///
        /// <remarks>   Rizvi, 19/09/2020. </remarks>
        ///
        /// <returns>   An IClassProperty. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public IClassProperty AsStatic()
        {
            _elem["type"] = "static";
            return this;
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets the build. </summary>
        ///
        /// <remarks>   Rizvi, 19/09/2020. </remarks>
        ///
        /// <returns>   An IClassProperty. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public IClassProperty Build()
        {
            _sb.AppendLine(_elem["comments"]);
            _sb.AppendLine($"{_elem["modifier"]} {_elem["readonly"]} {_elem["type"]} {_elem["returnType"]} {_elem["name"]} {{ {_elem["getter"]} {_elem["setter"]} }}");
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

        public IClassProperty CreateProperty(string name, Modifier modifier)
        {
            _elem["name"] = name;
            _elem["modifier"] = modifier.ToString().ToLower();
            return this;
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets the getter. </summary>
        ///
        /// <remarks>   Rizvi, 19/09/2020. </remarks>
        ///
        /// <returns>   An IClassProperty. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public IClassProperty Getter()
        {
            _elem["getter"] = "get;";
            return this;
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Reads the only. </summary>
        ///
        /// <remarks>   Rizvi, 19/09/2020. </remarks>
        ///
        /// <exception cref="Exception">    Thrown when an exception error condition occurs. </exception>
        ///
        /// <returns>   The only. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public IClassProperty ReadOnly()
        {
            if (_elem["getter"] != "") throw new Exception("You cannot use Readonly because you have already defined Getter.");

            _elem["readonly"] = "readonly";
            return this;
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets the setter. </summary>
        ///
        /// <remarks>   Rizvi, 19/09/2020. </remarks>
        ///
        /// <exception cref="Exception">    Thrown when an exception error condition occurs. </exception>
        ///
        /// <returns>   An IClassProperty. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public IClassProperty Setter()
        {
            if (_elem["getter"] == "") throw new Exception("You cannot use Setter standalone, please use Getter with it.");

            _elem["setter"] = "set;";
            return this;
        }


    }
}
