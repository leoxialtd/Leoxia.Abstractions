#region Copyright (c) 2017 Leoxia Ltd

// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IFileSystemInfo.cs" company="Leoxia Ltd">
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

#endregion

namespace Leoxia.Abstractions.IO
{
    /// <summary>Provides a common interfaces for both <see cref="IFileInfo" /> and <see cref="IDirectoryInfo" /> objects.</summary>
    /// <filterpriority>2</filterpriority>
    public interface IFileSystemInfo
    {
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
        /// <filterpriority>1</filterpriority>
        /// <PermissionSet>
        ///     <IPermission
        ///         class="System.Security.Permissions.FileIOPermission, mscorlib, Version=2.0.3600.0, Culture=neutral,  KeyToken=b77a5c561934e089"
        ///         version="1" Unrestricted="true" />
        /// </PermissionSet>
        FileAttributes Attributes { get; set; }

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
        /// <filterpriority>1</filterpriority>
        /// <PermissionSet>
        ///     <IPermission
        ///         class="System.Security.Permissions.FileIOPermission, mscorlib, Version=2.0.3600.0, Culture=neutral,  KeyToken=b77a5c561934e089"
        ///         version="1" Unrestricted="true" />
        /// </PermissionSet>
        DateTime CreationTime { get; set; }

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
        /// <filterpriority>1</filterpriority>
        /// <PermissionSet>
        ///     <IPermission
        ///         class="System.Security.Permissions.FileIOPermission, mscorlib, Version=2.0.3600.0, Culture=neutral,  KeyToken=b77a5c561934e089"
        ///         version="1" Unrestricted="true" />
        /// </PermissionSet>
        DateTime CreationTimeUtc { get; set; }

        /// <summary>Gets a value indicating whether the file or directory exists.</summary>
        /// <returns>true if the file or directory exists; otherwise, false.</returns>
        /// <filterpriority>1</filterpriority>
        bool Exists { get; }

        /// <summary>Gets the string representing the extension part of the file.</summary>
        /// <returns>A string containing the <see cref="T:System.IO.FileSystemInfo" /> extension.</returns>
        /// <filterpriority>1</filterpriority>
        string Extension { get; }

        /// <summary>Gets the full path of the directory or file.</summary>
        /// <returns>A string containing the full path.</returns>
        /// <exception cref="T:System.IO.PathTooLongException">The fully qualified path and file name is 260 or more characters.</exception>
        /// <exception cref="T:System.Security.SecurityException">The caller does not have the required permission. </exception>
        /// <filterpriority>1</filterpriority>
        /// <PermissionSet>
        ///     <IPermission
        ///         class="System.Security.Permissions.FileIOPermission, mscorlib, Version=2.0.3600.0, Culture=neutral,  KeyToken=b77a5c561934e089"
        ///         version="1" Unrestricted="true" />
        /// </PermissionSet>
        string FullName { get; }

        /// <summary>Gets or sets the time the current file or directory was last accessed.</summary>
        /// <returns>The time that the current file or directory was last accessed.</returns>
        /// <exception cref="T:System.IO.IOException">
        ///     <see cref="M:System.IO.FileSystemInfo.Refresh" /> cannot initialize the data.
        /// </exception>
        /// <exception cref="T:System.PlatformNotSupportedException">The current operating system is not Windows NT or later.</exception>
        /// <exception cref="T:System.ArgumentOutOfRangeException">The caller attempts to set an invalid access time</exception>
        /// <filterpriority>1</filterpriority>
        /// <PermissionSet>
        ///     <IPermission
        ///         class="System.Security.Permissions.FileIOPermission, mscorlib, Version=2.0.3600.0, Culture=neutral,  KeyToken=b77a5c561934e089"
        ///         version="1" Unrestricted="true" />
        /// </PermissionSet>
        DateTime LastAccessTime { get; set; }

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
        /// <filterpriority>1</filterpriority>
        /// <PermissionSet>
        ///     <IPermission
        ///         class="System.Security.Permissions.FileIOPermission, mscorlib, Version=2.0.3600.0, Culture=neutral,  KeyToken=b77a5c561934e089"
        ///         version="1" Unrestricted="true" />
        /// </PermissionSet>
        DateTime LastAccessTimeUtc { get; set; }

        /// <summary>Gets or sets the time when the current file or directory was last written to.</summary>
        /// <returns>The time the current file was last written.</returns>
        /// <exception cref="T:System.IO.IOException">
        ///     <see cref="M:System.IO.FileSystemInfo.Refresh" /> cannot initialize the data.
        /// </exception>
        /// <exception cref="T:System.PlatformNotSupportedException">The current operating system is not Windows NT or later.</exception>
        /// <exception cref="T:System.ArgumentOutOfRangeException">The caller attempts to set an invalid write time.</exception>
        /// <filterpriority>1</filterpriority>
        /// <PermissionSet>
        ///     <IPermission
        ///         class="System.Security.Permissions.FileIOPermission, mscorlib, Version=2.0.3600.0, Culture=neutral,  KeyToken=b77a5c561934e089"
        ///         version="1" Unrestricted="true" />
        /// </PermissionSet>
        DateTime LastWriteTime { get; set; }

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
        /// <filterpriority>1</filterpriority>
        /// <PermissionSet>
        ///     <IPermission
        ///         class="System.Security.Permissions.FileIOPermission, mscorlib, Version=2.0.3600.0, Culture=neutral,  KeyToken=b77a5c561934e089"
        ///         version="1" Unrestricted="true" />
        /// </PermissionSet>
        DateTime LastWriteTimeUtc { get; set; }

        /// <summary>
        ///     For files, gets the name of the file. For directories, gets the name of the last directory in the hierarchy if
        ///     a hierarchy exists. Otherwise, the Name property gets the name of the directory.
        /// </summary>
        /// <returns>
        ///     A string that is the name of the parent directory, the name of the last directory in the hierarchy, or the
        ///     name of a file, including the file name extension.
        /// </returns>
        /// <filterpriority>1</filterpriority>
        string Name { get; }

        /// <summary>Deletes a file or directory.</summary>
        /// <exception cref="T:System.IO.DirectoryNotFoundException">
        ///     The specified path is invalid; for example, it is on an
        ///     unmapped drive.
        /// </exception>
        /// <exception cref="T:System.IO.IOException">
        ///     There is an open handle on the file or directory, and the operating system is
        ///     Windows XP or earlier. This open handle can result from enumerating directories and files. For more information,
        ///     see How to: Enumerate Directories and Files.
        /// </exception>
        /// <filterpriority>2</filterpriority>
        void Delete();

        /// <summary>Refreshes the state of the object.</summary>
        /// <exception cref="T:System.IO.IOException">A device such as a disk drive is not ready. </exception>
        /// <filterpriority>1</filterpriority>
        void Refresh();
    }
}