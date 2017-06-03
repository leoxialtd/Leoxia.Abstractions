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

using System.IO;
using Leoxia.Abstractions.IO;

#endregion

namespace Leoxia.Implementations.IO
{
    /// <summary>
    ///     Factory for building <see cref="IDirectoryInfo" />
    /// </summary>
    /// <seealso cref="Leoxia.Abstractions.IO.IDirectoryInfoFactory" />
    public class DirectoryInfoFactory : IDirectoryInfoFactory
    {
        /// <summary>
        ///     Initializes a new instance of the <see cref="T:Leoxia.Abstractions.IO.IDirectoryInfo" /> class, which acts as a
        ///     wrapper for a directory
        ///     path.
        /// </summary>
        /// <param name="directoryName">The fully qualified name of the new directory, or the relative directory name.</param>
        /// <returns></returns>
        public IDirectoryInfo Build(string directoryName)
        {
            return new DirectoryInfo(directoryName).Adapt();
        }
    }
}