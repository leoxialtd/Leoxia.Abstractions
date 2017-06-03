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
using System.IO;
using Leoxia.Abstractions.IO.FileSystem.Watcher;

#endregion

namespace Leoxia.Implementations.IO.FileSystem.Watcher
{
    /// <summary>
    ///     Adapter for <see cref="FileSystemWatcher" /> into <see cref="IFileSystemWatcher" />
    /// </summary>
    /// <seealso cref="Leoxia.Abstractions.IO.FileSystem.Watcher.IFileSystemWatcher" />
    public class FileSystemWatcherAdapter : IFileSystemWatcher
    {
        private readonly FileSystemWatcher _watcher;


        /// <summary>Initializes a new instance of the <see cref="FileSystemWatcherAdapter" /> class.</summary>
        public FileSystemWatcherAdapter()
            : this(new FileSystemWatcher())
        {
        }

        /// <summary>
        ///     Initializes a new instance of the <see cref="FileSystemWatcherAdapter" /> class, given the specified directory
        ///     to monitor.
        /// </summary>
        /// <param name="path">The directory to monitor, in standard or Universal Naming Convention (UNC) notation. </param>
        /// <exception cref="T:System.ArgumentNullException">The <paramref name="path" /> parameter is null. </exception>
        /// <exception cref="T:System.ArgumentException">
        ///     The <paramref name="path" /> parameter is an empty string ("").-or- The
        ///     path specified through the <paramref name="path" /> parameter does not exist.
        /// </exception>
        /// <exception cref="T:System.IO.PathTooLongException">
        ///     <paramref name="path" /> is too long.
        /// </exception>
        public FileSystemWatcherAdapter(string path)
            : this(new FileSystemWatcher(path))
        {
        }

        /// <summary>
        ///     Initializes a new instance of the <see cref="FileSystemWatcherAdapter" /> class, given the specified directory
        ///     and type of files to monitor.
        /// </summary>
        /// <param name="path">The directory to monitor, in standard or Universal Naming Convention (UNC) notation. </param>
        /// <param name="filter">The type of files to watch. For example, "*.txt" watches for changes to all text files. </param>
        /// <exception cref="T:System.ArgumentNullException">
        ///     The <paramref name="path" /> parameter is null.-or- The
        ///     <paramref name="filter" /> parameter is null.
        /// </exception>
        /// <exception cref="T:System.ArgumentException">
        ///     The <paramref name="path" /> parameter is an empty string ("").-or- The
        ///     path specified through the <paramref name="path" /> parameter does not exist.
        /// </exception>
        /// <exception cref="T:System.IO.PathTooLongException">
        ///     <paramref name="path" /> is too long.
        /// </exception>
        public FileSystemWatcherAdapter(string path, string filter)
            : this(new FileSystemWatcher(path, filter))
        {
        }

        /// <summary>
        ///     Initializes a new instance of the <see cref="FileSystemWatcherAdapter" /> class.
        /// </summary>
        /// <param name="watcher">The watcher.</param>
        public FileSystemWatcherAdapter(FileSystemWatcher watcher)
        {
            _watcher = watcher ?? throw new ArgumentNullException(nameof(watcher));
        }

        /// <summary>
        ///     Occurs when a file or directory in the specified <see cref="P:System.IO.FileSystemWatcher.Path" /> is changed.
        /// </summary>
        public event FileSystemEventHandler Changed
        {
            add => _watcher.Changed += value;
            remove => _watcher.Changed -= value;
        }

        /// <summary>
        ///     Occurs when a file or directory in the specified <see cref="P:System.IO.FileSystemWatcher.Path" /> is created.
        /// </summary>
        public event FileSystemEventHandler Created
        {
            add => _watcher.Created += value;
            remove => _watcher.Created -= value;
        }

        /// <summary>
        ///     Occurs when a file or directory in the specified <see cref="P:System.IO.FileSystemWatcher.Path" /> is deleted.
        /// </summary>
        public event FileSystemEventHandler Deleted
        {
            add => _watcher.Deleted += value;
            remove => _watcher.Deleted -= value;
        }

        /// <summary>
        ///     Releases unmanaged and - optionally - managed resources.
        /// </summary>
        public void Dispose()
        {
            _watcher.Dispose();
        }

        /// <summary>
        ///     Gets or sets a value indicating whether [enable raising events].
        /// </summary>
        /// <value>
        ///     <c>true</c> if [enable raising events]; otherwise, <c>false</c>.
        /// </value>
        public bool EnableRaisingEvents
        {
            get => _watcher.EnableRaisingEvents;
            set => _watcher.EnableRaisingEvents = value;
        }

        /// <summary>
        ///     Occurs when the instance of <see cref="T:System.IO.FileSystemWatcher" /> is unable to continue monitoring
        ///     changes or when the internal buffer overflows.
        /// </summary>
        public event ErrorEventHandler Error
        {
            add => _watcher.Error += value;
            remove => _watcher.Error -= value;
        }

        /// <summary>
        ///     Gets or sets the filter.
        /// </summary>
        /// <value>
        ///     The filter.
        /// </value>
        public string Filter
        {
            get => _watcher.Filter;
            set => _watcher.Filter = value;
        }

        /// <summary>
        ///     Gets or sets a value indicating whether [include subdirectories].
        /// </summary>
        /// <value>
        ///     <c>true</c> if [include subdirectories]; otherwise, <c>false</c>.
        /// </value>
        public bool IncludeSubdirectories
        {
            get => _watcher.IncludeSubdirectories;
            set => _watcher.IncludeSubdirectories = value;
        }

        /// <summary>
        ///     Gets or sets the size of the internal buffer.
        /// </summary>
        /// <value>
        ///     The size of the internal buffer.
        /// </value>
        public int InternalBufferSize
        {
            get => _watcher.InternalBufferSize;
            set => _watcher.InternalBufferSize = value;
        }

        /// <summary>
        ///     Gets or sets the notify filter.
        /// </summary>
        /// <value>
        ///     The notify filter.
        /// </value>
        public NotifyFilters NotifyFilter
        {
            get => _watcher.NotifyFilter;
            set => _watcher.NotifyFilter = value;
        }

        /// <summary>
        ///     Gets or sets the path.
        /// </summary>
        /// <value>
        ///     The path.
        /// </value>
        public string Path
        {
            get => _watcher.Path;
            set => _watcher.Path = value;
        }

        /// <summary>
        ///     Occurs when a file or directory in the specified <see cref="P:System.IO.FileSystemWatcher.Path" /> is renamed.
        /// </summary>
        public event RenamedEventHandler Renamed
        {
            add => _watcher.Renamed += value;
            remove => _watcher.Renamed -= value;
        }

        /// <summary>
        ///     Waits for changed.
        /// </summary>
        /// <param name="changeType">Type of the change.</param>
        /// <returns></returns>
        public WaitForChangedResult WaitForChanged(WatcherChangeTypes changeType)
        {
            return _watcher.WaitForChanged(changeType);
        }

        /// <summary>
        ///     Waits for changed.
        /// </summary>
        /// <param name="changeType">Type of the change.</param>
        /// <param name="timeout">The timeout.</param>
        /// <returns></returns>
        public WaitForChangedResult WaitForChanged(WatcherChangeTypes changeType, int timeout)
        {
            return _watcher.WaitForChanged(changeType, timeout);
        }

        /// <summary>Returns a string that represents the current object.</summary>
        /// <returns>A string that represents the current object.</returns>
        public override string ToString()
        {
            return _watcher.ToString();
        }
    }
}