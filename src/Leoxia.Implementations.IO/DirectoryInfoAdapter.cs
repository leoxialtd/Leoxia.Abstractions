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
using System.Collections.Generic;
using System.IO;
using Leoxia.Abstractions.IO;

#endregion

namespace Leoxia.Implementations.IO
{
    /// <summary>
    ///     Adapter for <see cref="DirectoryInfo" /> into <see cref="IDirectoryInfo" /> interface.
    /// </summary>
    /// <seealso cref="Leoxia.Abstractions.IO.IDirectoryInfo" />
    public class DirectoryInfoAdapter : IDirectoryInfo
    {
        private readonly DirectoryInfo _directoryInfo;

        /// <summary>
        ///     Initializes a new instance of the <see cref="DirectoryInfoAdapter" /> class.
        /// </summary>
        /// <param name="directoryInfo">The directory information.</param>
        public DirectoryInfoAdapter(DirectoryInfo directoryInfo)
        {
            _directoryInfo = directoryInfo ?? throw new ArgumentNullException(nameof(directoryInfo));
        }

        /// <summary>Gets or sets the attributes for the current file or directory.</summary>
        /// <returns>
        ///     <see cref="T:System.IO.FileAttributes" /> of the current <see cref="T:System.IO.FileSystemInfo" />.
        /// </returns>
        /// <exception cref="T:System.IO.FileNotFoundException">The specified file does not exist. </exception>
        /// <exception cref="T:System.IO.DirectoryNotFoundException">
        ///     The specified path is invalid; for example, it is on an
        ///     unmapped drive.
        /// </exception>
        /// <exception cref="T:System.Security.SecurityException">The caller does not have the required permission. </exception>
        /// <exception cref="T:System.ArgumentException">
        ///     The caller attempts to set an invalid file attribute. -or-The user
        ///     attempts to set an attribute value but does not have write permission.
        /// </exception>
        /// <exception cref="T:System.IO.IOException">
        ///     <see cref="M:System.IO.FileSystemInfo.Refresh" /> cannot initialize the data.
        /// </exception>
        /// <PermissionSet>
        ///     <IPermission
        ///         class="System.Security.Permissions.FileIOPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"
        ///         version="1" Unrestricted="true" />
        /// </PermissionSet>
        public FileAttributes Attributes
        {
            get => _directoryInfo.Attributes;
            set => _directoryInfo.Attributes = value;
        }

        /// <summary>Creates a directory.</summary>
        /// <exception cref="T:System.IO.IOException">The directory cannot be created. </exception>
        /// <PermissionSet>
        ///     <IPermission
        ///         class="System.Security.Permissions.FileIOPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"
        ///         version="1" Unrestricted="true" />
        /// </PermissionSet>
        public void Create()
        {
            _directoryInfo.Create();
        }

        /// <summary>
        ///     Creates a subdirectory or subdirectories on the specified path. The specified path can be relative to this
        ///     instance of the <see cref="T:System.IO.DirectoryInfo" /> class.
        /// </summary>
        /// <returns>The last directory specified in <paramref name="path" />.</returns>
        /// <param name="path">
        ///     The specified path. This cannot be a different disk volume or Universal Naming Convention (UNC)
        ///     name.
        /// </param>
        /// <exception cref="T:System.ArgumentException">
        ///     <paramref name="path" /> does not specify a valid file path or contains invalid DirectoryInfo characters.
        /// </exception>
        /// <exception cref="T:System.ArgumentNullException">
        ///     <paramref name="path" /> is null.
        /// </exception>
        /// <exception cref="T:System.IO.DirectoryNotFoundException">
        ///     The specified path is invalid, such as being on an unmapped
        ///     drive.
        /// </exception>
        /// <exception cref="T:System.IO.IOException">
        ///     The subdirectory cannot be created.-or- A file or directory already has the
        ///     name specified by <paramref name="path" />.
        /// </exception>
        /// <exception cref="T:System.IO.PathTooLongException">
        ///     The specified path, file name, or both exceed the system-defined
        ///     maximum length. For example, on Windows-based platforms, paths must be less than 248 characters, and file names
        ///     must be less than 260 characters. The specified path, file name, or both are too long.
        /// </exception>
        /// <exception cref="T:System.Security.SecurityException">
        ///     The caller does not have code access permission to create the
        ///     directory.-or-The caller does not have code access permission to read the directory described by the returned
        ///     <see cref="T:System.IO.DirectoryInfo" /> object.  This can occur when the <paramref name="path" /> parameter
        ///     describes an existing directory.
        /// </exception>
        /// <exception cref="T:System.NotSupportedException">
        ///     <paramref name="path" /> contains a colon character (:) that is not part of a drive label ("C:\").
        /// </exception>
        /// <PermissionSet>
        ///     <IPermission
        ///         class="System.Security.Permissions.FileIOPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"
        ///         version="1" Unrestricted="true" />
        /// </PermissionSet>
        public IDirectoryInfo CreateSubdirectory(string path)
        {
            return _directoryInfo.CreateSubdirectory(path).Adapt();
        }

        /// <summary>Gets or sets the creation time of the current file or directory.</summary>
        /// <returns>The creation date and time of the current <see cref="T:System.IO.FileSystemInfo" /> object.</returns>
        /// <exception cref="T:System.IO.IOException">
        ///     <see cref="M:System.IO.FileSystemInfo.Refresh" /> cannot initialize the data.
        /// </exception>
        /// <exception cref="T:System.IO.DirectoryNotFoundException">
        ///     The specified path is invalid; for example, it is on an
        ///     unmapped drive.
        /// </exception>
        /// <exception cref="T:System.PlatformNotSupportedException">The current operating system is not Windows NT or later.</exception>
        /// <exception cref="T:System.ArgumentOutOfRangeException">The caller attempts to set an invalid creation time.</exception>
        /// <PermissionSet>
        ///     <IPermission
        ///         class="System.Security.Permissions.FileIOPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"
        ///         version="1" Unrestricted="true" />
        /// </PermissionSet>
        public DateTime CreationTime
        {
            get => _directoryInfo.CreationTime;
            set => _directoryInfo.CreationTime = value;
        }

        /// <summary>Gets or sets the creation time, in coordinated universal time (UTC), of the current file or directory.</summary>
        /// <returns>The creation date and time in UTC format of the current <see cref="T:System.IO.FileSystemInfo" /> object.</returns>
        /// <exception cref="T:System.IO.IOException">
        ///     <see cref="M:System.IO.FileSystemInfo.Refresh" /> cannot initialize the data.
        /// </exception>
        /// <exception cref="T:System.IO.DirectoryNotFoundException">
        ///     The specified path is invalid; for example, it is on an
        ///     unmapped drive.
        /// </exception>
        /// <exception cref="T:System.PlatformNotSupportedException">The current operating system is not Windows NT or later.</exception>
        /// <exception cref="T:System.ArgumentOutOfRangeException">The caller attempts to set an invalid access time.</exception>
        /// <PermissionSet>
        ///     <IPermission
        ///         class="System.Security.Permissions.FileIOPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"
        ///         version="1" Unrestricted="true" />
        /// </PermissionSet>
        public DateTime CreationTimeUtc
        {
            get => _directoryInfo.CreationTimeUtc;
            set => _directoryInfo.CreationTimeUtc = value;
        }

        /// <summary>
        ///     Deletes this instance of a <see cref="T:System.IO.DirectoryInfo" />, specifying whether to delete
        ///     subdirectories and files.
        /// </summary>
        /// <param name="recursive">true to delete this directory, its subdirectories, and all files; otherwise, false. </param>
        /// <exception cref="T:System.UnauthorizedAccessException">The directory contains a read-only file.</exception>
        /// <exception cref="T:System.IO.DirectoryNotFoundException">
        ///     The directory described by this
        ///     <see cref="T:System.IO.DirectoryInfo" /> object does not exist or could not be found.
        /// </exception>
        /// <exception cref="T:System.IO.IOException">
        ///     The directory is read-only.-or- The directory contains one or more files or
        ///     subdirectories and <paramref name="recursive" /> is false.-or-The directory is the application's current working
        ///     directory. -or-There is an open handle on the directory or on one of its files, and the operating system is Windows
        ///     XP or earlier. This open handle can result from enumerating directories and files. For more information, see How
        ///     to: Enumerate Directories and Files.
        /// </exception>
        /// <exception cref="T:System.Security.SecurityException">The caller does not have the required permission. </exception>
        /// <PermissionSet>
        ///     <IPermission
        ///         class="System.Security.Permissions.FileIOPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"
        ///         version="1" Unrestricted="true" />
        /// </PermissionSet>
        public void Delete(bool recursive)
        {
            _directoryInfo.Delete(recursive);
        }

        /// <summary>Deletes this <see cref="T:System.IO.DirectoryInfo" /> if it is empty.</summary>
        /// <exception cref="T:System.UnauthorizedAccessException">The directory contains a read-only file.</exception>
        /// <exception cref="T:System.IO.DirectoryNotFoundException">
        ///     The directory described by this
        ///     <see cref="T:System.IO.DirectoryInfo" /> object does not exist or could not be found.
        /// </exception>
        /// <exception cref="T:System.IO.IOException">
        ///     The directory is not empty. -or-The directory is the application's current
        ///     working directory.-or-There is an open handle on the directory, and the operating system is Windows XP or earlier.
        ///     This open handle can result from enumerating directories. For more information, see How to: Enumerate Directories
        ///     and Files.
        /// </exception>
        /// <exception cref="T:System.Security.SecurityException">The caller does not have the required permission. </exception>
        /// <PermissionSet>
        ///     <IPermission
        ///         class="System.Security.Permissions.FileIOPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"
        ///         version="1" Unrestricted="true" />
        /// </PermissionSet>
        public void Delete()
        {
            _directoryInfo.Delete();
        }

        /// <summary>
        ///     Returns an enumerable collection of directory information that matches a specified search pattern and search
        ///     subdirectory option.
        /// </summary>
        /// <returns>
        ///     An enumerable collection of directories that matches <paramref name="searchPattern" /> and
        ///     <paramref name="searchOption" />.
        /// </returns>
        /// <param name="searchPattern">
        ///     The search string to match against the names of directories.  This parameter can contain a
        ///     combination of valid literal path and wildcard (* and ?) characters (see Remarks), but doesn't support regular
        ///     expressions. The default pattern is "*", which returns all files.
        /// </param>
        /// <param name="searchOption">
        ///     One of the enumeration values that specifies whether the search operation should include
        ///     only the current directory or all subdirectories. The default value is
        ///     <see cref="F:System.IO.SearchOption.TopDirectoryOnly" />.
        /// </param>
        /// <exception cref="T:System.ArgumentNullException">
        ///     <paramref name="searchPattern" /> is null.
        /// </exception>
        /// <exception cref="T:System.ArgumentOutOfRangeException">
        ///     <paramref name="searchOption" /> is not a valid <see cref="T:System.IO.SearchOption" /> value.
        /// </exception>
        /// <exception cref="T:System.IO.DirectoryNotFoundException">
        ///     The path encapsulated in the
        ///     <see cref="T:System.IO.DirectoryInfo" /> object is invalid (for example, it is on an unmapped drive).
        /// </exception>
        /// <exception cref="T:System.Security.SecurityException">The caller does not have the required permission. </exception>
        public IEnumerable<IDirectoryInfo> EnumerateDirectories(string searchPattern, SearchOption searchOption)
        {
            return _directoryInfo.EnumerateDirectories(searchPattern, searchOption).Adapt();
        }

        /// <summary>Returns an enumerable collection of directory information that matches a specified search pattern.</summary>
        /// <returns>An enumerable collection of directories that matches <paramref name="searchPattern" />.</returns>
        /// <param name="searchPattern">
        ///     The search string to match against the names of directories.  This parameter can contain a
        ///     combination of valid literal path and wildcard (* and ?) characters (see Remarks), but doesn't support regular
        ///     expressions. The default pattern is "*", which returns all files.
        /// </param>
        /// <exception cref="T:System.ArgumentNullException">
        ///     <paramref name="searchPattern" /> is null.
        /// </exception>
        /// <exception cref="T:System.IO.DirectoryNotFoundException">
        ///     The path encapsulated in the
        ///     <see cref="T:System.IO.DirectoryInfo" /> object is invalid (for example, it is on an unmapped drive).
        /// </exception>
        /// <exception cref="T:System.Security.SecurityException">The caller does not have the required permission. </exception>
        public IEnumerable<IDirectoryInfo> EnumerateDirectories(string searchPattern)
        {
            return _directoryInfo.EnumerateDirectories(searchPattern).Adapt();
        }

        /// <summary>Returns an enumerable collection of directory information in the current directory.</summary>
        /// <returns>An enumerable collection of directories in the current directory.</returns>
        /// <exception cref="T:System.IO.DirectoryNotFoundException">
        ///     The path encapsulated in the
        ///     <see cref="T:System.IO.DirectoryInfo" /> object is invalid (for example, it is on an unmapped drive).
        /// </exception>
        /// <exception cref="T:System.Security.SecurityException">The caller does not have the required permission. </exception>
        public IEnumerable<IDirectoryInfo> EnumerateDirectories()
        {
            return _directoryInfo.EnumerateDirectories().Adapt();
        }

        /// <summary>Returns an enumerable collection of file information that matches a search pattern.</summary>
        /// <returns>An enumerable collection of files that matches <paramref name="searchPattern" />.</returns>
        /// <param name="searchPattern">
        ///     The search string to match against the names of files.  This parameter can contain a
        ///     combination of valid literal path and wildcard (* and ?) characters (see Remarks), but doesn't support regular
        ///     expressions. The default pattern is "*", which returns all files.
        /// </param>
        /// <exception cref="T:System.ArgumentNullException">
        ///     <paramref name="searchPattern" /> is null.
        /// </exception>
        /// <exception cref="T:System.IO.DirectoryNotFoundException">
        ///     The path encapsulated in the
        ///     <see cref="T:System.IO.DirectoryInfo" /> object is invalid, (for example, it is on an unmapped drive).
        /// </exception>
        /// <exception cref="T:System.Security.SecurityException">The caller does not have the required permission. </exception>
        public IEnumerable<IFileInfo> EnumerateFiles(string searchPattern)
        {
            return _directoryInfo.EnumerateFiles(searchPattern).Adapt();
        }

        /// <summary>
        ///     Returns an enumerable collection of file information that matches a specified search pattern and search
        ///     subdirectory option.
        /// </summary>
        /// <returns>
        ///     An enumerable collection of files that matches <paramref name="searchPattern" /> and
        ///     <paramref name="searchOption" />.
        /// </returns>
        /// <param name="searchPattern">
        ///     The search string to match against the names of files.  This parameter can contain a
        ///     combination of valid literal path and wildcard (* and ?) characters (see Remarks), but doesn't support regular
        ///     expressions. The default pattern is "*", which returns all files.
        /// </param>
        /// <param name="searchOption">
        ///     One of the enumeration values that specifies whether the search operation should include
        ///     only the current directory or all subdirectories. The default value is
        ///     <see cref="F:System.IO.SearchOption.TopDirectoryOnly" />.
        /// </param>
        /// <exception cref="T:System.ArgumentNullException">
        ///     <paramref name="searchPattern" /> is null.
        /// </exception>
        /// <exception cref="T:System.ArgumentOutOfRangeException">
        ///     <paramref name="searchOption" /> is not a valid <see cref="T:System.IO.SearchOption" /> value.
        /// </exception>
        /// <exception cref="T:System.IO.DirectoryNotFoundException">
        ///     The path encapsulated in the
        ///     <see cref="T:System.IO.DirectoryInfo" /> object is invalid (for example, it is on an unmapped drive).
        /// </exception>
        /// <exception cref="T:System.Security.SecurityException">The caller does not have the required permission. </exception>
        public IEnumerable<IFileInfo> EnumerateFiles(string searchPattern, SearchOption searchOption)
        {
            return _directoryInfo.EnumerateFiles(searchPattern, searchOption).Adapt();
        }

        /// <summary>Returns an enumerable collection of file information in the current directory.</summary>
        /// <returns>An enumerable collection of the files in the current directory.</returns>
        /// <exception cref="T:System.IO.DirectoryNotFoundException">
        ///     The path encapsulated in the
        ///     <see cref="T:System.IO.DirectoryInfo" /> object is invalid (for example, it is on an unmapped drive).
        /// </exception>
        /// <exception cref="T:System.Security.SecurityException">The caller does not have the required permission. </exception>
        public IEnumerable<IFileInfo> EnumerateFiles()
        {
            return _directoryInfo.EnumerateFiles().Adapt();
        }

        /// <summary>Returns an enumerable collection of file system information that matches a specified search pattern.</summary>
        /// <returns>An enumerable collection of file system information objects that matches <paramref name="searchPattern" />.</returns>
        /// <param name="searchPattern">
        ///     The search string to match against the names of directories.  This parameter can contain a
        ///     combination of valid literal path and wildcard (* and ?) characters (see Remarks), but doesn't support regular
        ///     expressions. The default pattern is "*", which returns all files.
        /// </param>
        /// <exception cref="T:System.ArgumentNullException">
        ///     <paramref name="searchPattern" /> is null.
        /// </exception>
        /// <exception cref="T:System.IO.DirectoryNotFoundException">
        ///     The path encapsulated in the
        ///     <see cref="T:System.IO.DirectoryInfo" /> object is invalid (for example, it is on an unmapped drive).
        /// </exception>
        /// <exception cref="T:System.Security.SecurityException">The caller does not have the required permission. </exception>
        public IEnumerable<IFileSystemInfo> EnumerateFileSystemInfos(string searchPattern)
        {
            return _directoryInfo.EnumerateFileSystemInfos(searchPattern).Adapt();
        }

        /// <summary>
        ///     Returns an enumerable collection of file system information that matches a specified search pattern and search
        ///     subdirectory option.
        /// </summary>
        /// <returns>
        ///     An enumerable collection of file system information objects that matches <paramref name="searchPattern" /> and
        ///     <paramref name="searchOption" />.
        /// </returns>
        /// <param name="searchPattern">
        ///     The search string to match against the names of directories.  This parameter can contain a
        ///     combination of valid literal path and wildcard (* and ?) characters (see Remarks), but doesn't support regular
        ///     expressions. The default pattern is "*", which returns all files.
        /// </param>
        /// <param name="searchOption">
        ///     One of the enumeration values that specifies whether the search operation should include
        ///     only the current directory or all subdirectories. The default value is
        ///     <see cref="F:System.IO.SearchOption.TopDirectoryOnly" />.
        /// </param>
        /// <exception cref="T:System.ArgumentNullException">
        ///     <paramref name="searchPattern" /> is null.
        /// </exception>
        /// <exception cref="T:System.ArgumentOutOfRangeException">
        ///     <paramref name="searchOption" /> is not a valid <see cref="T:System.IO.SearchOption" /> value.
        /// </exception>
        /// <exception cref="T:System.IO.DirectoryNotFoundException">
        ///     The path encapsulated in the
        ///     <see cref="T:System.IO.DirectoryInfo" /> object is invalid (for example, it is on an unmapped drive).
        /// </exception>
        /// <exception cref="T:System.Security.SecurityException">The caller does not have the required permission. </exception>
        public IEnumerable<IFileSystemInfo> EnumerateFileSystemInfos(string searchPattern, SearchOption searchOption)
        {
            return _directoryInfo.EnumerateFileSystemInfos(searchPattern, searchOption).Adapt();
        }

        /// <summary>Returns an enumerable collection of file system information in the current directory.</summary>
        /// <returns>An enumerable collection of file system information in the current directory. </returns>
        /// <exception cref="T:System.IO.DirectoryNotFoundException">
        ///     The path encapsulated in the
        ///     <see cref="T:System.IO.DirectoryInfo" /> object is invalid (for example, it is on an unmapped drive).
        /// </exception>
        /// <exception cref="T:System.Security.SecurityException">The caller does not have the required permission. </exception>
        public IEnumerable<IFileSystemInfo> EnumerateFileSystemInfos()
        {
            return _directoryInfo.EnumerateFileSystemInfos().Adapt();
        }

        /// <summary>Gets a value indicating whether the directory exists.</summary>
        /// <returns>true if the directory exists; otherwise, false.</returns>
        public bool Exists => _directoryInfo.Exists;

        /// <summary>Gets the string representing the extension part of the file.</summary>
        /// <returns>A string containing the <see cref="T:System.IO.FileSystemInfo" /> extension.</returns>
        public string Extension => _directoryInfo.Extension;

        /// <summary>Gets the full path of the directory or file.</summary>
        /// <returns>A string containing the full path.</returns>
        /// <exception cref="T:System.IO.PathTooLongException">The fully qualified path and file name is 260 or more characters.</exception>
        /// <exception cref="T:System.Security.SecurityException">The caller does not have the required permission. </exception>
        /// <PermissionSet>
        ///     <IPermission
        ///         class="System.Security.Permissions.FileIOPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"
        ///         version="1" Unrestricted="true" />
        /// </PermissionSet>
        public string FullName => _directoryInfo.FullName;

        /// <summary>
        ///     Returns an array of directories in the current <see cref="T:System.IO.DirectoryInfo" /> matching the given
        ///     search criteria and using a value to determine whether to search subdirectories.
        /// </summary>
        /// <returns>An array of type DirectoryInfo matching <paramref name="searchPattern" />.</returns>
        /// <param name="searchPattern">
        ///     The search string to match against the names of directories.  This parameter can contain a
        ///     combination of valid literal path and wildcard (* and ?) characters (see Remarks), but doesn't support regular
        ///     expressions. The default pattern is "*", which returns all files.
        /// </param>
        /// <param name="searchOption">
        ///     One of the enumeration values that specifies whether the search operation should include
        ///     only the current directory or all subdirectories.
        /// </param>
        /// <exception cref="T:System.ArgumentException">
        ///     <paramref name="searchPattern " />contains one or more invalid characters defined by the
        ///     <see cref="M:System.IO.Path.GetInvalidPathChars" /> method.
        /// </exception>
        /// <exception cref="T:System.ArgumentNullException">
        ///     <paramref name="searchPattern" /> is null.
        /// </exception>
        /// <exception cref="T:System.ArgumentOutOfRangeException">
        ///     <paramref name="searchOption" /> is not a valid <see cref="T:System.IO.SearchOption" /> value.
        /// </exception>
        /// <exception cref="T:System.IO.DirectoryNotFoundException">
        ///     The path encapsulated in the DirectoryInfo object is invalid
        ///     (for example, it is on an unmapped drive).
        /// </exception>
        /// <exception cref="T:System.UnauthorizedAccessException">The caller does not have the required permission. </exception>
        public IDirectoryInfo[] GetDirectories(string searchPattern, SearchOption searchOption)
        {
            return _directoryInfo.GetDirectories(searchPattern, searchOption).Adapt();
        }

        /// <summary>
        ///     Returns an array of directories in the current <see cref="T:System.IO.DirectoryInfo" /> matching the given
        ///     search criteria.
        /// </summary>
        /// <returns>An array of type DirectoryInfo matching <paramref name="searchPattern" />.</returns>
        /// <param name="searchPattern">
        ///     The search string to match against the names of directories.  This parameter can contain a
        ///     combination of valid literal path and wildcard (* and ?) characters (see Remarks), but doesn't support regular
        ///     expressions. The default pattern is "*", which returns all files.
        /// </param>
        /// <exception cref="T:System.ArgumentException">
        ///     <paramref name="searchPattern " />contains one or more invalid characters defined by the
        ///     <see cref="M:System.IO.Path.GetInvalidPathChars" /> method.
        /// </exception>
        /// <exception cref="T:System.ArgumentNullException">
        ///     <paramref name="searchPattern" /> is null.
        /// </exception>
        /// <exception cref="T:System.IO.DirectoryNotFoundException">
        ///     The path encapsulated in the DirectoryInfo object is invalid
        ///     (for example, it is on an unmapped drive).
        /// </exception>
        /// <exception cref="T:System.UnauthorizedAccessException">The caller does not have the required permission. </exception>
        /// <PermissionSet>
        ///     <IPermission
        ///         class="System.Security.Permissions.FileIOPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"
        ///         version="1" Unrestricted="true" />
        /// </PermissionSet>
        public IDirectoryInfo[] GetDirectories(string searchPattern)
        {
            return _directoryInfo.GetDirectories(searchPattern).Adapt();
        }

        /// <summary>Returns the subdirectories of the current directory.</summary>
        /// <returns>An array of <see cref="T:System.IO.DirectoryInfo" /> objects.</returns>
        /// <exception cref="T:System.IO.DirectoryNotFoundException">
        ///     The path encapsulated in the
        ///     <see cref="T:System.IO.DirectoryInfo" /> object is invalid, such as being on an unmapped drive.
        /// </exception>
        /// <exception cref="T:System.Security.SecurityException">The caller does not have the required permission. </exception>
        /// <exception cref="T:System.UnauthorizedAccessException">The caller does not have the required permission. </exception>
        /// <PermissionSet>
        ///     <IPermission
        ///         class="System.Security.Permissions.FileIOPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"
        ///         version="1" Unrestricted="true" />
        /// </PermissionSet>
        public IDirectoryInfo[] GetDirectories()
        {
            return _directoryInfo.GetDirectories().Adapt();
        }

        /// <summary>Returns a file list from the current directory.</summary>
        /// <returns>An array of type <see cref="T:System.IO.FileInfo" />.</returns>
        /// <exception cref="T:System.IO.DirectoryNotFoundException">The path is invalid, such as being on an unmapped drive. </exception>
        /// <PermissionSet>
        ///     <IPermission
        ///         class="System.Security.Permissions.FileIOPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"
        ///         version="1" Unrestricted="true" />
        /// </PermissionSet>
        public IFileInfo[] GetFiles()
        {
            return _directoryInfo.GetFiles().Adapt();
        }

        /// <summary>Returns a file list from the current directory matching the given search pattern.</summary>
        /// <returns>An array of type <see cref="T:System.IO.FileInfo" />.</returns>
        /// <param name="searchPattern">
        ///     The search string to match against the names of files.  This parameter can contain a
        ///     combination of valid literal path and wildcard (* and ?) characters (see Remarks), but doesn't support regular
        ///     expressions. The default pattern is "*", which returns all files.
        /// </param>
        /// <exception cref="T:System.ArgumentException">
        ///     <paramref name="searchPattern " />contains one or more invalid characters defined by the
        ///     <see cref="M:System.IO.Path.GetInvalidPathChars" /> method.
        /// </exception>
        /// <exception cref="T:System.ArgumentNullException">
        ///     <paramref name="searchPattern" /> is null.
        /// </exception>
        /// <exception cref="T:System.IO.DirectoryNotFoundException">The path is invalid (for example, it is on an unmapped drive). </exception>
        /// <exception cref="T:System.Security.SecurityException">The caller does not have the required permission. </exception>
        /// <PermissionSet>
        ///     <IPermission
        ///         class="System.Security.Permissions.FileIOPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"
        ///         version="1" Unrestricted="true" />
        /// </PermissionSet>
        public IFileInfo[] GetFiles(string searchPattern)
        {
            return _directoryInfo.GetFiles(searchPattern).Adapt();
        }

        /// <summary>
        ///     Returns a file list from the current directory matching the given search pattern and using a value to
        ///     determine whether to search subdirectories.
        /// </summary>
        /// <returns>An array of type <see cref="T:System.IO.FileInfo" />.</returns>
        /// <param name="searchPattern">
        ///     The search string to match against the names of files.  This parameter can contain a
        ///     combination of valid literal path and wildcard (* and ?) characters (see Remarks), but doesn't support regular
        ///     expressions. The default pattern is "*", which returns all files.
        /// </param>
        /// <param name="searchOption">
        ///     One of the enumeration values that specifies whether the search operation should include
        ///     only the current directory or all subdirectories.
        /// </param>
        /// <exception cref="T:System.ArgumentException">
        ///     <paramref name="searchPattern " />contains one or more invalid characters defined by the
        ///     <see cref="M:System.IO.Path.GetInvalidPathChars" /> method.
        /// </exception>
        /// <exception cref="T:System.ArgumentNullException">
        ///     <paramref name="searchPattern" /> is null.
        /// </exception>
        /// <exception cref="T:System.ArgumentOutOfRangeException">
        ///     <paramref name="searchOption" /> is not a valid <see cref="T:System.IO.SearchOption" /> value.
        /// </exception>
        /// <exception cref="T:System.IO.DirectoryNotFoundException">The path is invalid (for example, it is on an unmapped drive). </exception>
        /// <exception cref="T:System.Security.SecurityException">The caller does not have the required permission. </exception>
        public IFileInfo[] GetFiles(string searchPattern, SearchOption searchOption)
        {
            return _directoryInfo.GetFiles(searchPattern, searchOption).Adapt();
        }

        /// <summary>
        ///     Retrieves an array of <see cref="T:System.IO.FileSystemInfo" /> objects that represent the files and
        ///     subdirectories matching the specified search criteria.
        /// </summary>
        /// <returns>An array of file system entries that match the search criteria.</returns>
        /// <param name="searchPattern">
        ///     The search string to match against the names of directories and filesa.  This parameter can
        ///     contain a combination of valid literal path and wildcard (* and ?) characters (see Remarks), but doesn't support
        ///     regular expressions. The default pattern is "*", which returns all files.
        /// </param>
        /// <param name="searchOption">
        ///     One of the enumeration values that specifies whether the search operation should include
        ///     only the current directory or all subdirectories. The default value is
        ///     <see cref="F:System.IO.SearchOption.TopDirectoryOnly" />.
        /// </param>
        /// <exception cref="T:System.ArgumentException">
        ///     <paramref name="searchPattern " />contains one or more invalid characters defined by the
        ///     <see cref="M:System.IO.Path.GetInvalidPathChars" /> method.
        /// </exception>
        /// <exception cref="T:System.ArgumentNullException">
        ///     <paramref name="searchPattern" /> is null.
        /// </exception>
        /// <exception cref="T:System.ArgumentOutOfRangeException">
        ///     <paramref name="searchOption" /> is not a valid <see cref="T:System.IO.SearchOption" /> value.
        /// </exception>
        /// <exception cref="T:System.IO.DirectoryNotFoundException">
        ///     The specified path is invalid (for example, it is on an
        ///     unmapped drive).
        /// </exception>
        /// <exception cref="T:System.Security.SecurityException">The caller does not have the required permission. </exception>
        public IFileSystemInfo[] GetFileSystemInfos(string searchPattern, SearchOption searchOption)
        {
            return _directoryInfo.GetFileSystemInfos(searchPattern, searchOption).Adapt();
        }

        /// <summary>
        ///     Retrieves an array of strongly typed <see cref="T:System.IO.FileSystemInfo" /> objects representing the files
        ///     and subdirectories that match the specified search criteria.
        /// </summary>
        /// <returns>An array of strongly typed FileSystemInfo objects matching the search criteria.</returns>
        /// <param name="searchPattern">
        ///     The search string to match against the names of directories and files.  This parameter can
        ///     contain a combination of valid literal path and wildcard (* and ?) characters (see Remarks), but doesn't support
        ///     regular expressions. The default pattern is "*", which returns all files.
        /// </param>
        /// <exception cref="T:System.ArgumentException">
        ///     <paramref name="searchPattern " />contains one or more invalid characters defined by the
        ///     <see cref="M:System.IO.Path.GetInvalidPathChars" /> method.
        /// </exception>
        /// <exception cref="T:System.ArgumentNullException">
        ///     <paramref name="searchPattern" /> is null.
        /// </exception>
        /// <exception cref="T:System.IO.DirectoryNotFoundException">
        ///     The specified path is invalid (for example, it is on an
        ///     unmapped drive).
        /// </exception>
        /// <exception cref="T:System.Security.SecurityException">The caller does not have the required permission. </exception>
        /// <PermissionSet>
        ///     <IPermission
        ///         class="System.Security.Permissions.FileIOPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"
        ///         version="1" Unrestricted="true" />
        /// </PermissionSet>
        public IFileSystemInfo[] GetFileSystemInfos(string searchPattern)
        {
            return _directoryInfo.GetFileSystemInfos(searchPattern).Adapt();
        }

        /// <summary>
        ///     Returns an array of strongly typed <see cref="T:System.IO.FileSystemInfo" /> entries representing all the
        ///     files and subdirectories in a directory.
        /// </summary>
        /// <returns>An array of strongly typed <see cref="T:System.IO.FileSystemInfo" /> entries.</returns>
        /// <exception cref="T:System.IO.DirectoryNotFoundException">The path is invalid (for example, it is on an unmapped drive). </exception>
        /// <PermissionSet>
        ///     <IPermission
        ///         class="System.Security.Permissions.FileIOPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"
        ///         version="1" Unrestricted="true" />
        /// </PermissionSet>
        public IFileSystemInfo[] GetFileSystemInfos()
        {
            return _directoryInfo.GetFileSystemInfos().Adapt();
        }

        /// <summary>Gets or sets the time the current file or directory was last accessed.</summary>
        /// <returns>The time that the current file or directory was last accessed.</returns>
        /// <exception cref="T:System.IO.IOException">
        ///     <see cref="M:System.IO.FileSystemInfo.Refresh" /> cannot initialize the data.
        /// </exception>
        /// <exception cref="T:System.PlatformNotSupportedException">The current operating system is not Windows NT or later.</exception>
        /// <exception cref="T:System.ArgumentOutOfRangeException">The caller attempts to set an invalid access time</exception>
        /// <PermissionSet>
        ///     <IPermission
        ///         class="System.Security.Permissions.FileIOPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"
        ///         version="1" Unrestricted="true" />
        /// </PermissionSet>
        public DateTime LastAccessTime
        {
            get => _directoryInfo.LastAccessTime;
            set => _directoryInfo.LastAccessTime = value;
        }

        /// <summary>
        ///     Gets or sets the time, in coordinated universal time (UTC), that the current file or directory was last
        ///     accessed.
        /// </summary>
        /// <returns>The UTC time that the current file or directory was last accessed.</returns>
        /// <exception cref="T:System.IO.IOException">
        ///     <see cref="M:System.IO.FileSystemInfo.Refresh" /> cannot initialize the data.
        /// </exception>
        /// <exception cref="T:System.PlatformNotSupportedException">The current operating system is not Windows NT or later.</exception>
        /// <exception cref="T:System.ArgumentOutOfRangeException">The caller attempts to set an invalid access time.</exception>
        /// <PermissionSet>
        ///     <IPermission
        ///         class="System.Security.Permissions.FileIOPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"
        ///         version="1" Unrestricted="true" />
        /// </PermissionSet>
        public DateTime LastAccessTimeUtc
        {
            get => _directoryInfo.LastAccessTimeUtc;
            set => _directoryInfo.LastAccessTimeUtc = value;
        }

        /// <summary>Gets or sets the time when the current file or directory was last written to.</summary>
        /// <returns>The time the current file was last written.</returns>
        /// <exception cref="T:System.IO.IOException">
        ///     <see cref="M:System.IO.FileSystemInfo.Refresh" /> cannot initialize the data.
        /// </exception>
        /// <exception cref="T:System.PlatformNotSupportedException">The current operating system is not Windows NT or later.</exception>
        /// <exception cref="T:System.ArgumentOutOfRangeException">The caller attempts to set an invalid write time.</exception>
        /// <PermissionSet>
        ///     <IPermission
        ///         class="System.Security.Permissions.FileIOPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"
        ///         version="1" Unrestricted="true" />
        /// </PermissionSet>
        public DateTime LastWriteTime
        {
            get => _directoryInfo.LastWriteTime;
            set => _directoryInfo.LastWriteTime = value;
        }

        /// <summary>
        ///     Gets or sets the time, in coordinated universal time (UTC), when the current file or directory was last
        ///     written to.
        /// </summary>
        /// <returns>The UTC time when the current file was last written to.</returns>
        /// <exception cref="T:System.IO.IOException">
        ///     <see cref="M:System.IO.FileSystemInfo.Refresh" /> cannot initialize the data.
        /// </exception>
        /// <exception cref="T:System.PlatformNotSupportedException">The current operating system is not Windows NT or later.</exception>
        /// <exception cref="T:System.ArgumentOutOfRangeException">The caller attempts to set an invalid write time.</exception>
        /// <PermissionSet>
        ///     <IPermission
        ///         class="System.Security.Permissions.FileIOPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"
        ///         version="1" Unrestricted="true" />
        /// </PermissionSet>
        public DateTime LastWriteTimeUtc
        {
            get => _directoryInfo.LastWriteTimeUtc;
            set => _directoryInfo.LastWriteTimeUtc = value;
        }

        /// <summary>Moves a <see cref="T:System.IO.DirectoryInfo" /> instance and its contents to a new path.</summary>
        /// <param name="destDirName">
        ///     The name and path to which to move this directory. The destination cannot be another disk
        ///     volume or a directory with the identical name. It can be an existing directory to which you want to add this
        ///     directory as a subdirectory.
        /// </param>
        /// <exception cref="T:System.ArgumentNullException">
        ///     <paramref name="destDirName" /> is null.
        /// </exception>
        /// <exception cref="T:System.ArgumentException">
        ///     <paramref name="destDirName" /> is an empty string (''").
        /// </exception>
        /// <exception cref="T:System.IO.IOException">
        ///     An attempt was made to move a directory to a different volume. -or-
        ///     <paramref name="destDirName" /> already exists.-or-You are not authorized to access this path.-or- The directory
        ///     being moved and the destination directory have the same name.
        /// </exception>
        /// <exception cref="T:System.Security.SecurityException">The caller does not have the required permission. </exception>
        /// <exception cref="T:System.IO.DirectoryNotFoundException">The destination directory cannot be found.</exception>
        /// <PermissionSet>
        ///     <IPermission
        ///         class="System.Security.Permissions.FileIOPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"
        ///         version="1" Unrestricted="true" />
        /// </PermissionSet>
        public void MoveTo(string destDirName)
        {
            _directoryInfo.MoveTo(destDirName);
        }

        /// <summary>Gets the name of this <see cref="T:System.IO.DirectoryInfo" /> instance.</summary>
        /// <returns>The directory name.</returns>
        public string Name => _directoryInfo.Name;

        /// <summary>Gets the parent directory of a specified subdirectory.</summary>
        /// <returns>
        ///     The parent directory, or null if the path is null or if the file path denotes a root (such as "\", "C:", or *
        ///     "\\server\share").
        /// </returns>
        /// <exception cref="T:System.Security.SecurityException">The caller does not have the required permission. </exception>
        /// <PermissionSet>
        ///     <IPermission
        ///         class="System.Security.Permissions.FileIOPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"
        ///         version="1" Unrestricted="true" />
        /// </PermissionSet>
        public IDirectoryInfo Parent => _directoryInfo.Parent.Adapt();

        /// <summary>Refreshes the state of the object.</summary>
        /// <exception cref="T:System.IO.IOException">A device such as a disk drive is not ready. </exception>
        public void Refresh()
        {
            _directoryInfo.Refresh();
        }

        /// <summary>Gets the root portion of the directory.</summary>
        /// <returns>An object that represents the root of the directory.</returns>
        /// <exception cref="T:System.Security.SecurityException">The caller does not have the required permission. </exception>
        /// <PermissionSet>
        ///     <IPermission
        ///         class="System.Security.Permissions.FileIOPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"
        ///         version="1" Unrestricted="true" />
        /// </PermissionSet>
        public IDirectoryInfo Root => _directoryInfo.Root.Adapt();

        /// <summary>Returns a string that represents the current object.</summary>
        /// <returns>A string that represents the current object.</returns>
        public override string ToString()
        {
            return _directoryInfo.ToString();
        }
    }
}