////////////////////////////////////////////////////////////////////////////////////////////////////
// file:	ClassBuilder.cs
//
// summary:	Implements the class builder class
////////////////////////////////////////////////////////////////////////////////////////////////////

using Rizvis.ClassBuilder.Interfaces;
using System.Collections.Generic;
using System.Text;

namespace Rizvis.ClassBuilder
{
    ////////////////////////////////////////////////////////////////////////////////////////////////////
    /// <summary>   The class builder. This class cannot be inherited. </summary>
    ///
    /// <remarks>   Rizvi, 19/09/2020. </remarks>
    ////////////////////////////////////////////////////////////////////////////////////////////////////

    public sealed class ClassBuilder : IClass, IClassMethod, IClassProperty, IClassElement
    {
        /// <summary>   The sb. </summary>
        private readonly StringBuilder _sb;

        /// <summary>   The package sb. </summary>
        private readonly StringBuilder _packageSB;

        /// <summary>   The namespace. </summary>
        private string _namespace = "namespace ";

        /// <summary>   Type of the class. </summary>
        private string _classType = "";

        /// <summary>   The class extenders. </summary>
        private List<string> _classExtenders;

        /// <summary>   The method builder. </summary>
        private readonly MethodBuilder _methodBuilder;

        /// <summary>   The property builder. </summary>
        private readonly PropertyBuilder _propertyBuilder;

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Default constructor. </summary>
        ///
        /// <remarks>   Rizvi, 19/09/2020. </remarks>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public ClassBuilder()
        {
            _sb = new StringBuilder();
            _packageSB = new StringBuilder();
            _classExtenders = new List<string>();
            _methodBuilder = new MethodBuilder(_sb);
            _propertyBuilder = new PropertyBuilder(_sb);
        }

        #region Class Methods

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Creates class static. </summary>
        ///
        /// <remarks>   Rizvi, 19/09/2020. </remarks>
        ///
        /// <param name="name">         The name. </param>
        /// <param name="modifier">     The modifier. </param>
        /// <param name="description">  (Optional) The description. </param>
        ///
        /// <returns>   The new class static. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public IClass CreateClass(string name, Modifier modifier, string description = "")
        {
            if (!string.IsNullOrEmpty(description)) GenerateComment(description);

            var extender = "";

            if (_classExtenders.Count > 0)
            {
                extender = $" : {string.Join(",", _classExtenders.ToArray())}";
            }

            _sb.AppendLine($"{modifier.ToString().ToLower()} {_classType} class {name} {extender} {{");
            return this;
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   With namespace. </summary>
        ///
        /// <remarks>   Rizvi, 19/09/2020. </remarks>
        ///
        /// <param name="nameSpace">    The name space. </param>
        ///
        /// <returns>   An IClassElement. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public IClass WithNamespace(string nameSpace)
        {
            _namespace += $" {nameSpace}";
            return this;
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Extend with. </summary>
        ///
        /// <remarks>   Rizvi, 19/09/2020. </remarks>
        ///
        /// <param name="extendClassOrInterfaceName">   Name of the extend class or interface. </param>
        ///
        /// <returns>   An IClassElement. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public IClass ExtendWith(string extendClassOrInterfaceName)
        {
            _classExtenders.Add(extendClassOrInterfaceName);
            return this;
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Converts this  to a static. </summary>
        ///
        /// <remarks>   Rizvi, 19/09/2020. </remarks>
        ///
        /// <returns>   An IClassElement. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public IClass AsStatic()
        {
            _classType = "static";
            return this;
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Converts this  to a sealed. </summary>
        ///
        /// <remarks>   Rizvi, 19/09/2020. </remarks>
        ///
        /// <returns>   An IClassElement. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public IClass AsSealed()
        {
            _classType = "sealed";
            return this;
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Converts this  to an abstract. </summary>
        ///
        /// <remarks>   Rizvi, 19/09/2020. </remarks>
        ///
        /// <returns>   An IClassElement. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public IClass AsAbstract()
        {
            _classType = "abstract";
            return this;
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets the build. </summary>
        ///
        /// <remarks>   Rizvi, 19/09/2020. </remarks>
        ///
        /// <returns>   An IClassElement. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public IClassElement Build()
        {
            return this;
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Import package. </summary>
        ///
        /// <remarks>   Rizvi, 19/09/2020. </remarks>
        ///
        /// <param name="packageName">  Name of the package. </param>
        ///
        /// <returns>   An IClassElement. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public IClass ImportPackage(string packageName)
        {
            _packageSB.AppendLine($"using {packageName};");
            return this;
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Generates a comment. </summary>
        ///
        /// <remarks>   Rizvi, 19/09/2020. </remarks>
        ///
        /// <param name="msg">  The message. </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        private void GenerateComment(string msg)
        {
            _sb.AppendLine("\n");
            _sb.AppendLine("////////////////////////////////////////////////////////////////////////////////////////////////////");
            _sb.AppendLine($"/* <summary> {msg} </summary> */");
            _sb.AppendLine("////////////////////////////////////////////////////////////////////////////////////////////////////");
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Returns a string that represents the current object. </summary>
        ///
        /// <remarks>   Rizvi, 19/09/2020. </remarks>
        ///
        /// <returns>   A string that represents the current object. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public override string ToString()
        {
            _sb.AppendLine("}");
            return _packageSB.ToString() + _sb.ToString();
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets the methods. </summary>
        ///
        /// <remarks>   Rizvi, 19/09/2020. </remarks>
        ///
        /// <returns>   An IClassMethod. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public IClassMethod Methods()
        {
            return this;
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets the properties. </summary>
        ///
        /// <remarks>   Rizvi, 19/09/2020. </remarks>
        ///
        /// <returns>   An IClassProperty. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public IClassProperty Properties()
        {
            return this;
        }

        #endregion

        #region IClassMethods

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

        public IClassMethod CreateMethod(string name, Modifier modifier) => _methodBuilder.CreateMethod(name, modifier);

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   With arguments. </summary>
        ///
        /// <remarks>   Rizvi, 19/09/2020. </remarks>
        ///
        /// <param name="args"> A variable-length parameters list containing arguments. </param>
        ///
        /// <returns>   An IClassMethod. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public IClassMethod WithArguments(params string[] args) => _methodBuilder.WithArguments(args);

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Converts this  to a void. </summary>
        ///
        /// <remarks>   Rizvi, 19/09/2020. </remarks>
        ///
        /// <returns>   An IClassMethod. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public IClassMethod AsVoid() => _methodBuilder.AsVoid();

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   With asynchronous. </summary>
        ///
        /// <remarks>   Rizvi, 19/09/2020. </remarks>
        ///
        /// <returns>   An IClassMethod. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public IClassMethod WithAsync() => _methodBuilder.WithAsync();

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

        public IClassMethod AsReturnWithType<T>(T type) => _methodBuilder.AsReturnWithType(type);

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Adds a method description. </summary>
        ///
        /// <remarks>   Rizvi, 19/09/2020. </remarks>
        ///
        /// <param name="description">  The description. </param>
        ///
        /// <returns>   An IClassMethod. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public IClassMethod AddMethodDescription(string description) => _methodBuilder.AddMethodDescription(description);

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Adds a code black. </summary>
        ///
        /// <remarks>   Rizvi, 19/09/2020. </remarks>
        ///
        /// <param name="codeBlock">    The code block. </param>
        ///
        /// <returns>   An IClassMethod. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public IClassMethod AddCodeBlack(string codeBlock) => _methodBuilder.AddCodeBlack(codeBlock);

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Converts this  to a static. </summary>
        ///
        /// <remarks>   Rizvi, 19/09/2020. </remarks>
        ///
        /// <returns>   The IClass. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        IClassMethod IClassMethod.AsStatic() => _methodBuilder.AsStatic();

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Converts this  to a sealed. </summary>
        ///
        /// <remarks>   Rizvi, 19/09/2020. </remarks>
        ///
        /// <returns>   The IClass. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        IClassMethod IClassMethod.AsSealed() => _methodBuilder.AsSealed();

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Converts this  to an abstract. </summary>
        ///
        /// <remarks>   Rizvi, 19/09/2020. </remarks>
        ///
        /// <returns>   The IClass. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        IClassMethod IClassMethod.AsAbstract() => _methodBuilder.AsAbstract();

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Converts a type to a return with. </summary>
        ///
        /// <remarks>   Rizvi, 19/09/2020. </remarks>
        ///
        /// <param name="type"> The type. </param>
        ///
        /// <returns>   An IClassMethod. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public IClassMethod AsReturnWith(string type) => _methodBuilder.AsReturnWith(type);

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets the build. </summary>
        ///
        /// <remarks>   Rizvi, 19/09/2020. </remarks>
        ///
        /// <returns>   An IClassMethod. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        IClassMethod IClassMethod.Build() => _methodBuilder.Build();

        #endregion

        #region IClassProperty

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

        public IClassProperty CreateProperty(string name, Modifier modifier) => _propertyBuilder.CreateProperty(name, modifier);

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

        IClassProperty IClassProperty.AsReturnWithType<T>(T type) => _propertyBuilder.AsReturnWithType(type);

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Adds a property description. </summary>
        ///
        /// <remarks>   Rizvi, 19/09/2020. </remarks>
        ///
        /// <param name="description">  The description. </param>
        ///
        /// <returns>   An IClassProperty. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public IClassProperty AddPropertyDescription(string description) => _propertyBuilder.AddPropertyDescription(description);

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Converts this  to an abstract. </summary>
        ///
        /// <remarks>   Rizvi, 19/09/2020. </remarks>
        ///
        /// <returns>   An IClassProperty. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        IClassProperty IClassProperty.AsAbstract() => _propertyBuilder.AsAbstract();

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Converts this  to a static. </summary>
        ///
        /// <remarks>   Rizvi, 19/09/2020. </remarks>
        ///
        /// <returns>   An IClassProperty. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        IClassProperty IClassProperty.AsStatic() => _propertyBuilder.AsStatic();

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Reads the only. </summary>
        ///
        /// <remarks>   Rizvi, 19/09/2020. </remarks>
        ///
        /// <returns>   The only. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public IClassProperty ReadOnly() => _propertyBuilder.ReadOnly();

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets the getter. </summary>
        ///
        /// <remarks>   Rizvi, 19/09/2020. </remarks>
        ///
        /// <returns>   An IClassProperty. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public IClassProperty Getter() => _propertyBuilder.Getter();

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets the setter. </summary>
        ///
        /// <remarks>   Rizvi, 19/09/2020. </remarks>
        ///
        /// <returns>   An IClassProperty. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public IClassProperty Setter() => _propertyBuilder.Setter();

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Converts a type to a return with. </summary>
        ///
        /// <remarks>   Rizvi, 19/09/2020. </remarks>
        ///
        /// <param name="type"> The type. </param>
        ///
        /// <returns>   An IClassProperty. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        IClassProperty IClassProperty.AsReturnWith(string type) => _propertyBuilder.AsReturnWith(type);

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets the build. </summary>
        ///
        /// <remarks>   Rizvi, 19/09/2020. </remarks>
        ///
        /// <returns>   An IClassProperty. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        IClassProperty IClassProperty.Build() => _propertyBuilder.Build();
        #endregion

       
    }
}

