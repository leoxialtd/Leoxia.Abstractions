#region Copyright (c) 2017 Leoxia Ltd

// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IStreamWriter.cs" company="Leoxia Ltd">
//    Copyright (c) 2017 Leoxia Ltd
// </copyright>
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

using System.IO;

#endregion

namespace Leoxia.Abstractions.IO
{
    /// <summary>
    ///     Implements a <see cref="T:System.IO.TextWriter" /> for writing characters to a stream in a particular
    ///     encoding.To browse the .NET Framework source code for this type, see the Reference Source.
    /// </summary>
    /// <filterpriority>1</filterpriority>
    public interface IStreamWriter : ITextWriter
    {
        /// <summary>
        ///     Gets or sets a value indicating whether the <see cref="T:System.IO.StreamWriter" /> will flush its buffer to
        ///     the underlying stream after every call to <see cref="M:System.IO.StreamWriter.Write(System.Char)" />.
        /// </summary>
        /// <returns>true to force <see cref="T:System.IO.StreamWriter" /> to flush its buffer; otherwise, false.</returns>
        /// <filterpriority>1</filterpriority>
        bool AutoFlush { get; set; }

        /// <summary>Gets the underlying stream that interfaces with a backing store.</summary>
        /// <returns>The stream this StreamWriter is writing to.</returns>
        /// <filterpriority>2</filterpriority>
        Stream BaseStream { get; }
    }
}