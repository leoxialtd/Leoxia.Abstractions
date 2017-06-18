#region Copyright (c) 2017 Leoxia Ltd

// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IStreamReader.cs" company="Leoxia Ltd">
//    Copyright (c) 2017 Leoxia Ltd
// </copyright>
// 
// .NET Software Development
// https://www.leoxia.com
// Build. Tomorrow. Together
// 
// MIT License
// 
// Permission is hereby granted, free of charge, to any person obtaining a copy
// of this software and associated documentation files (the "Software"), to deal
// in the Software without restriction, including without limitation the rights
// to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
// copies of the Software, and to permit persons to whom the Software is
// furnished to do so, subject to the following conditions:
// 
// The above copyright notice and this permission notice shall be included in all
// copies or substantial portions of the Software.
// 
// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
// IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
// FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
// AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
// LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
// OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE
// SOFTWARE.
//  --------------------------------------------------------------------------------------------------------------------

#endregion

#region Usings

using System;
using System.IO;
using System.Text;

#endregion

namespace Leoxia.Abstractions.IO
{
    /// <summary>
    ///     Interface for stream readers
    /// </summary>
    /// <seealso cref="Leoxia.Abstractions.IO.ITextReader" />
    /// <seealso cref="System.IDisposable" />
    public interface IStreamReader : ITextReader, IDisposable
    {
        /// <summary>Returns the underlying stream.</summary>
        /// <returns>The underlying stream.</returns>
        /// <filterpriority>2</filterpriority>
        Stream BaseStream { get; }

        /// <summary>Gets the current character encoding that the current <see cref="T:System.IO.StreamReader" /> object is using.</summary>
        /// <returns>
        ///     The current character encoding used by the current reader. The value can be different after the first call to
        ///     any <see cref="StreamReader.Read()" /> method of <see cref="T:System.IO.StreamReader" />, since encoding
        ///     autodetection is not done until the first call to a <see cref="StreamReader.Read()" /> method.
        /// </returns>
        /// <filterpriority>2</filterpriority>
        Encoding CurrentEncoding { get; }

        /// <summary>Gets a value that indicates whether the current stream position is at the end of the stream.</summary>
        /// <returns>true if the current stream position is at the end of the stream; otherwise false.</returns>
        /// <exception cref="T:System.ObjectDisposedException">The underlying stream has been disposed.</exception>
        /// <filterpriority>1</filterpriority>
        bool EndOfStream { get; }

        /// <summary>Clears the internal buffer.</summary>
        /// <filterpriority>2</filterpriority>
        void DiscardBufferedData();
    }
}