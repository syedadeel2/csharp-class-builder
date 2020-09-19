////////////////////////////////////////////////////////////////////////////////////////////////////
// file:	Modifier.cs
//
// summary:	Implements the modifier class
////////////////////////////////////////////////////////////////////////////////////////////////////

namespace Rizvis.ClassBuilder
{
    ////////////////////////////////////////////////////////////////////////////////////////////////////
    /// <summary>   Values that represent modifiers. </summary>
    ///
    /// <remarks>   Rizvi, 19/09/2020. </remarks>
    ////////////////////////////////////////////////////////////////////////////////////////////////////

    public enum Modifier
    {
        /// <summary>   An enum constant representing the public option. </summary>
        Public = 0,
        /// <summary>   An enum constant representing the private option. </summary>
        Private = 1,
        /// <summary>   An enum constant representing the internal option. </summary>
        Internal = 2,
        /// <summary>   An enum constant representing the protected option. </summary>
        Protected = 3

    }
}
