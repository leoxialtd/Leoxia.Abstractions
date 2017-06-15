#region Copyright (c) 2017 Leoxia Ltd

// MIT License
// 
// Copyright (c) 2017 Leoxia Ltd
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

#endregion

#region Usings

using System;
using System.IO;
using Leoxia.Abstractions.IO;

#endregion

namespace Leoxia.Implementations.IO
{
    /// <summary>
    ///     Provide the writers for output and error of <see cref="System.Console" />
    /// </summary>
    /// <seealso cref="Leoxia.Abstractions.IO.IStandardWriterProvider" />
    public class ConsoleWriterProvider : IStandardWriterProvider
    {
        /// <summary>
        ///     Gets or sets the output.
        /// </summary>
        /// <value>
        ///     The out.
        /// </value>
        public TextWriter Out => Console.Out;

        /// <summary>
        ///     Gets or sets the error output.
        /// </summary>
        /// <value>
        ///     The error.
        /// </value>
        public TextWriter Error => Console.Error;
    }
}