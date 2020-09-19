﻿////////////////////////////////////////////////////////////////////////////////////////////////////
// file:	IClassElement.cs
//
// summary:	Declares the IClassElement interface
////////////////////////////////////////////////////////////////////////////////////////////////////

namespace Rizvis.ClassBuilder.Interfaces
{
    ////////////////////////////////////////////////////////////////////////////////////////////////////
    /// <summary>   Interface for class element. </summary>
    ///
    /// <remarks>   Rizvi, 19/09/2020. </remarks>
    ////////////////////////////////////////////////////////////////////////////////////////////////////

    public interface IClassElement
    {
        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets the methods. </summary>
        ///
        /// <returns>   An IClassMethod. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        IClassMethod Methods();

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets the properties. </summary>
        ///
        /// <returns>   An IClassProperty. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        IClassProperty Properties();

    }
}