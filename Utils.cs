////////////////////////////////////////////////////////////////////////////////////////////////////
// file:	Utils.cs
//
// summary:	Implements the utilities class
////////////////////////////////////////////////////////////////////////////////////////////////////

using System;
using System.Collections.Generic;
using System.Text;

namespace Rizvis.ClassBuilder
{
    ////////////////////////////////////////////////////////////////////////////////////////////////////
    /// <summary>   An utilities. </summary>
    ///
    /// <remarks>   Rizvi, 19/09/2020. </remarks>
    ////////////////////////////////////////////////////////////////////////////////////////////////////

    static class Utils
    {
        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Process the return type described by type. </summary>
        ///
        /// <remarks>   Rizvi, 19/09/2020. </remarks>
        ///
        /// <param name="type"> The type. </param>
        ///
        /// <returns>   A string. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public static string ProcessReturnType(string type)
        {
            var dic = new Dictionary<string, string>
            {
                { "Boolean", "bool" },
                { "String", "string" },
                { "Promise", "async Task" },
                { "Object", "object" },
                { "Integer", "int" },
                { "Function", "Action" }
            };

            return dic.ContainsKey(type) ? dic[type] : type;
        }

    }
}
