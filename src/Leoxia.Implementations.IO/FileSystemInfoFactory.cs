#region Copyright (c) 2017 Leoxia Ltd

// --------------------------------------------------------------------------------------------------------------------
// <copyright file="FileSystemInfoFactory.cs" company="Leoxia Ltd">
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

using Leoxia.Abstractions.IO;

#endregion

namespace Leoxia.Implementations.IO
{
    /// <summary>
    ///     Factory for <see cref="IFileSystemInfo" />
    /// </summary>
    /// <seealso cref="Leoxia.Abstractions.IO.IFileSystemInfoFactory" />
    public class FileSystemInfoFactory : IFileSystemInfoFactory
    {
        private readonly IDirectoryInfoFactory _directoryInfoFactory = new DirectoryInfoFactory();

        private readonly IFileInfoFactory _fileInfoFactory = new FileInfoFactory();

        /// <summary>
        ///     Initializes a new instance of the <see cref="FileSystemInfoFactory" /> class.
        /// </summary>
        public FileSystemInfoFactory()
        {
        }

        /// <summary>
        ///     Initializes a new instance of the <see cref="FileSystemInfoFactory" /> class.
        /// </summary>
        /// <param name="fileInfoFactory">The file information factory.</param>
        /// <param name="directoryInfoFactory">The directory information factory.</param>
        public FileSystemInfoFactory(IFileInfoFactory fileInfoFactory, IDirectoryInfoFactory directoryInfoFactory)
        {
            _fileInfoFactory = fileInfoFactory;
            _directoryInfoFactory = directoryInfoFactory;
        }

        /// <summary>
        ///     Initializes a new instance of the <see cref="T:IFileSystemInfo" /> implementation, which acts as a wrapper for a
        ///     file path.
        /// </summary>
        /// <param name="fileName">
        ///     The fully qualified name of the new file or directory, or the relative file name or directory name. Do not end the
        ///     path with
        ///     the directory separator character.
        /// </param>
        /// <returns></returns>
        public IFileSystemInfo Build(string fileName)
        {
            var fileInfo = _fileInfoFactory.Build(fileName);
            if (fileInfo.Exists)
            {
                return fileInfo;
            }

            return _directoryInfoFactory.Build(fileName);
        }
    }
}