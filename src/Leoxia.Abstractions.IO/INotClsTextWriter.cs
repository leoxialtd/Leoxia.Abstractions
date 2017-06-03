#region Copyright (c) 2017 Leoxia Ltd

// The MIT License
// 
// Copyright © 2011 - 2017 Leoxia Ltd, https://www.leoxia.com
// 
// Permission is hereby granted, free of charge, to any person obtaining a copy
// of this software and associated documentation files (the "Software"), to deal
// in the Software without restriction, including without limitation the rights
// to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
// copies of the Software, and to permit persons to whom the Software is
// furnished to do so, subject to the following conditions:
// 
// The above copyright notice and this permission notice shall be included in
// all copies or substantial portions of the Software.
// 
// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
// IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
// FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
// AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
// LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
// OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN
// THE SOFTWARE.

#endregion

#region Usings

using System;

#endregion

namespace Leoxia.Abstractions.IO
{
    /// <summary>
    ///     TextWriter partial interface that is not CLS Compliant
    /// </summary>
    [CLSCompliant(false)]
    public interface INotClsTextWriter
    {
        /// <summary>Writes the text representation of a 4-byte unsigned integer to the text string or stream.</summary>
        /// <param name="value">The 4-byte unsigned integer to write. </param>
        /// <exception cref="T:System.ObjectDisposedException">The <see cref="T:System.IO.TextWriter" /> is closed. </exception>
        /// <exception cref="T:System.IO.IOException">An I/O error occurs. </exception>
        /// <filterpriority>1</filterpriority>
        [CLSCompliant(false)]
        void Write(uint value);

        /// <summary>Writes the text representation of an 8-byte unsigned integer to the text string or stream.</summary>
        /// <param name="value">The 8-byte unsigned integer to write. </param>
        /// <exception cref="T:System.ObjectDisposedException">The <see cref="T:System.IO.TextWriter" /> is closed. </exception>
        /// <exception cref="T:System.IO.IOException">An I/O error occurs. </exception>
        /// <filterpriority>1</filterpriority>
        [CLSCompliant(false)]
        void Write(ulong value);

        /// <summary>
        ///     Writes the text representation of a 4-byte unsigned integer followed by a line terminator to the text string
        ///     or stream.
        /// </summary>
        /// <param name="value">The 4-byte unsigned integer to write. </param>
        /// <exception cref="T:System.ObjectDisposedException">The <see cref="T:System.IO.TextWriter" /> is closed. </exception>
        /// <exception cref="T:System.IO.IOException">An I/O error occurs. </exception>
        /// <filterpriority>1</filterpriority>
        [CLSCompliant(false)]
        void WriteLine(uint value);

        /// <summary>
        ///     Writes the text representation of an 8-byte unsigned integer followed by a line terminator to the text string
        ///     or stream.
        /// </summary>
        /// <param name="value">The 8-byte unsigned integer to write. </param>
        /// <exception cref="T:System.ObjectDisposedException">The <see cref="T:System.IO.TextWriter" /> is closed. </exception>
        /// <exception cref="T:System.IO.IOException">An I/O error occurs. </exception>
        /// <filterpriority>1</filterpriority>
        [CLSCompliant(false)]
        void WriteLine(ulong value);
    }
}