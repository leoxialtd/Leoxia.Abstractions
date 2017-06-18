#region Copyright (c) 2017 Leoxia Ltd

// --------------------------------------------------------------------------------------------------------------------
// <copyright file="SystemInfoExtensions.cs" company="Leoxia Ltd">
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
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Leoxia.Abstractions.IO;

#endregion

namespace Leoxia.Implementations.IO
{
    /// <summary>
    ///     Extensions methods for FileSystemInfo and derived classes.
    /// </summary>
    public static class SystemInfoExtensions
    {
        /// <summary>
        ///     Adapts the specified enumerable.
        /// </summary>
        /// <param name="enumerable">The enumerable.</param>
        /// <returns></returns>
        public static IFileSystemInfo[] Adapt(this IEnumerable<FileSystemInfo> enumerable)
        {
            return enumerable.Select(item => item.Adapt()).ToArray();
        }

        /// <summary>
        ///     Adapts the specified enumerable.
        /// </summary>
        /// <param name="enumerable">The enumerable.</param>
        /// <returns></returns>
        public static IDirectoryInfo[] Adapt(this IEnumerable<DirectoryInfo> enumerable)
        {
            return enumerable.Select(d => d.Adapt()).ToArray();
        }

        /// <summary>
        ///     Adapts the specified enumerable.
        /// </summary>
        /// <param name="enumerable">The enumerable.</param>
        /// <returns></returns>
        public static IFileInfo[] Adapt(this IEnumerable<FileInfo> enumerable)
        {
            return enumerable.Select(f => f.Adapt()).ToArray();
        }

        /// <summary>
        ///     Adapts the specified file information.
        /// </summary>
        /// <param name="fileInfo">The file information.</param>
        /// <returns></returns>
        public static IFileInfo Adapt(this FileInfo fileInfo)
        {
            return new FileInfoAdapter(fileInfo);
        }

        /// <summary>
        ///     Adapts the specified directory information.
        /// </summary>
        /// <param name="directoryInfo">The directory information.</param>
        /// <returns></returns>
        public static IDirectoryInfo Adapt(this DirectoryInfo directoryInfo)
        {
            return new DirectoryInfoAdapter(directoryInfo);
        }

        /// <summary>
        ///     Adapts the specified writer.
        /// </summary>
        /// <param name="writer">The writer.</param>
        /// <returns></returns>
        public static IStreamWriter Adapt(this StreamWriter writer)
        {
            return new StreamWriterAdapter(writer);
        }

        /// <summary>
        ///     Adapts the specified reader.
        /// </summary>
        /// <param name="reader">The reader.</param>
        /// <returns></returns>
        public static IStreamReader Adapt(this StreamReader reader)
        {
            return new StreamReaderAdapter(reader);
        }

        /// <summary>
        ///     Adapts the specified file system information.
        /// </summary>
        /// <param name="fileSystemInfo">The file system information.</param>
        /// <returns></returns>
        /// <exception cref="System.NotSupportedException"></exception>
        public static IFileSystemInfo Adapt(this FileSystemInfo fileSystemInfo)
        {
            var file = fileSystemInfo as FileInfo;
            if (file != null)
            {
                return new FileInfoAdapter(file);
            }

            var directory = fileSystemInfo as DirectoryInfo;
            if (directory != null)
            {
                return new DirectoryInfoAdapter(directory);
            }

            var typeName = fileSystemInfo.GetType().AssemblyQualifiedName;
            throw new NotSupportedException($"The type {typeName} is not supported by the Leoxia.Abstractions.IO.");
        }
    }
}