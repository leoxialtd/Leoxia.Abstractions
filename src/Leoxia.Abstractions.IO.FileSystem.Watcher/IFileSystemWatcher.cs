﻿#region Copyright (c) 2017 Leoxia Ltd

// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IFileSystemWatcher.cs" company="Leoxia Ltd">
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

using System;
using System.IO;

#endregion

namespace Leoxia.Abstractions.IO.FileSystem.Watcher
{
    /// <summary>
    ///     Listens to the file system change notifications and raises events when a directory, or file in a directory,
    ///     changes.To browse the .NET Framework source code for this type, see the Reference Source.
    /// </summary>
    /// <filterpriority>2</filterpriority>
    public interface IFileSystemWatcher : IDisposable
    {
        /// <summary>Gets or sets a value indicating whether the component is enabled.</summary>
        /// <returns>
        ///     true if the component is enabled; otherwise, false. The default is false. If you are using the component on a
        ///     designer in Visual Studio 2005, the default is true.
        /// </returns>
        /// <exception cref="T:System.ObjectDisposedException">
        ///     The <see cref="T:System.IO.FileSystemWatcher" /> object has been
        ///     disposed.
        /// </exception>
        /// <exception cref="T:System.PlatformNotSupportedException">
        ///     The current operating system is not Microsoft Windows NT or
        ///     later.
        /// </exception>
        /// <exception cref="T:System.IO.FileNotFoundException">
        ///     The directory specified in
        ///     <see cref="P:System.IO.FileSystemWatcher.Path" /> could not be found.
        /// </exception>
        /// <exception cref="T:System.ArgumentException">
        ///     <see cref="P:System.IO.FileSystemWatcher.Path" /> has not been set or is invalid.
        /// </exception>
        /// <filterpriority>2</filterpriority>
        bool EnableRaisingEvents { get; set; }

        /// <summary>Gets or sets the filter string used to determine what files are monitored in a directory.</summary>
        /// <returns>The filter string. The default is "*.*" (Watches all files.) </returns>
        /// <filterpriority>2</filterpriority>
        string Filter { get; set; }

        /// <summary>Gets or sets a value indicating whether subdirectories within the specified path should be monitored.</summary>
        /// <returns>true if you want to monitor subdirectories; otherwise, false. The default is false.</returns>
        /// <filterpriority>2</filterpriority>
        bool IncludeSubdirectories { get; set; }

        /// <summary>Gets or sets the size (in bytes) of the internal buffer.</summary>
        /// <returns>The internal buffer size in bytes. The default is 8192 (8 KB).</returns>
        /// <filterpriority>2</filterpriority>
        int InternalBufferSize { get; set; }

        /// <summary>Gets or sets the type of changes to watch for.</summary>
        /// <returns>
        ///     One of the <see cref="T:System.IO.NotifyFilters" /> values. The default is the bitwise OR combination of
        ///     LastWrite, FileName, and DirectoryName.
        /// </returns>
        /// <exception cref="T:System.ArgumentException">
        ///     The value is not a valid bitwise OR combination of the
        ///     <see cref="T:System.IO.NotifyFilters" /> values.
        /// </exception>
        /// <exception cref="T:System.ComponentModel.InvalidEnumArgumentException">The value that is being set is not valid.</exception>
        /// <filterpriority>2</filterpriority>
        NotifyFilters NotifyFilter { get; set; }

        /// <summary>Gets or sets the path of the directory to watch.</summary>
        /// <returns>The path to monitor. The default is an empty string ("").</returns>
        /// <exception cref="T:System.ArgumentException">
        ///     The specified path does not exist or could not be found.-or- The specified
        ///     path contains wildcard characters.-or- The specified path contains invalid path characters.
        /// </exception>
        /// <filterpriority>2</filterpriority>
        string Path { get; set; }

        /// <summary>Occurs when a file or directory in the specified <see cref="P:System.IO.FileSystemWatcher.Path" /> is changed.</summary>
        /// <filterpriority>2</filterpriority>
        event FileSystemEventHandler Changed;

        /// <summary>Occurs when a file or directory in the specified <see cref="P:System.IO.FileSystemWatcher.Path" /> is created.</summary>
        /// <filterpriority>2</filterpriority>
        event FileSystemEventHandler Created;

        /// <summary>Occurs when a file or directory in the specified <see cref="P:System.IO.FileSystemWatcher.Path" /> is deleted.</summary>
        /// <filterpriority>2</filterpriority>
        event FileSystemEventHandler Deleted;

        /// <summary>
        ///     Occurs when the instance of <see cref="T:System.IO.FileSystemWatcher" /> is unable to continue monitoring
        ///     changes or when the internal buffer overflows.
        /// </summary>
        /// <filterpriority>2</filterpriority>
        event ErrorEventHandler Error;

        /// <summary>Occurs when a file or directory in the specified <see cref="P:System.IO.FileSystemWatcher.Path" /> is renamed.</summary>
        /// <filterpriority>2</filterpriority>
        event RenamedEventHandler Renamed;

        /// <summary>
        ///     Waits for file changed.
        /// </summary>
        /// <param name="changeType">Type of the change.</param>
        /// <returns></returns>
        WaitForChangedResult WaitForChanged(WatcherChangeTypes changeType);

        /// <summary>
        ///     Waits for file changed.
        /// </summary>
        /// <param name="changeType">Type of the change.</param>
        /// <param name="timeout">The timeout.</param>
        /// <returns></returns>
        WaitForChangedResult WaitForChanged(WatcherChangeTypes changeType, int timeout);
    }
}