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
    ///     Adapter for <see cref="System.IO.Directory" /> static class into <see cref="IDirectory" /> interface.
    /// </summary>
    /// <seealso cref="Leoxia.Abstractions.IO.IDirectory" />
    public class DirectoryAdapter : IDirectory
    {
        /// <summary>
        ///     Creates all directories and subdirectories in the specified path unless they already exist.
        /// </summary>
        /// <param name="path">The directory to create.</param>
        /// <returns>
        ///     An object that represents the directory at the specified path. This object is returned regardless of whether a
        ///     directory at the specified path already exists.
        /// </returns>
        /// <PermissionSet>
        ///     <IPermission
        ///         class="System.Security.Permissions.FileIOPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"
        ///         version="1" Unrestricted="true" />
        /// </PermissionSet>
        public IDirectoryInfo CreateDirectory(string path)
        {
            return new DirectoryInfoAdapter(Directory.CreateDirectory(path));
        }

        /// <summary>
        ///     Deletes an empty directory from a specified path.
        /// </summary>
        /// <param name="path">The name of the empty directory to remove. This directory must be writable and empty.</param>
        /// <PermissionSet>
        ///     <IPermission
        ///         class="System.Security.Permissions.FileIOPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"
        ///         version="1" Unrestricted="true" />
        /// </PermissionSet>
        public void Delete(string path)
        {
            Directory.Delete(path);
        }

        /// <summary>
        ///     Deletes the specified directory and, if indicated, any subdirectories and files in the directory.
        /// </summary>
        /// <param name="path">The name of the directory to remove.</param>
        /// <param name="recursive">
        ///     true to remove directories, subdirectories, and files in <paramref name="path" />; otherwise,
        ///     false.
        /// </param>
        /// <PermissionSet>
        ///     <IPermission
        ///         class="System.Security.Permissions.FileIOPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"
        ///         version="1" Unrestricted="true" />
        /// </PermissionSet>
        public void Delete(string path, bool recursive)
        {
            Directory.Delete(path, recursive);
        }

        /// <summary>
        ///     Determines whether the given path refers to an existing directory on disk.
        /// </summary>
        /// <param name="path">The path to test.</param>
        /// <returns>
        ///     true if <paramref name="path" /> refers to an existing directory; false if the directory does not exist or an
        ///     error occurs when trying to determine if the specified file exists.
        /// </returns>
        /// <PermissionSet>
        ///     <IPermission
        ///         class="System.Security.Permissions.FileIOPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"
        ///         version="1" Unrestricted="true" />
        /// </PermissionSet>
        public bool Exists(string path)
        {
            return Directory.Exists(path);
        }

        /// <summary>
        ///     Gets the creation date and time of a directory.
        /// </summary>
        /// <param name="path">The path of the directory.</param>
        /// <returns>
        ///     A structure that is set to the creation date and time for the specified directory. This value is expressed in
        ///     local time.
        /// </returns>
        /// <PermissionSet>
        ///     <IPermission
        ///         class="System.Security.Permissions.FileIOPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"
        ///         version="1" Unrestricted="true" />
        /// </PermissionSet>
        public DateTime GetCreationTime(string path)
        {
            return Directory.GetCreationTime(path);
        }

        /// <summary>
        ///     Gets the creation date and time, in Coordinated Universal Time (UTC) format, of a directory.
        /// </summary>
        /// <param name="path">The path of the directory.</param>
        /// <returns>
        ///     A structure that is set to the creation date and time for the specified directory. This value is expressed in
        ///     UTC time.
        /// </returns>
        /// <PermissionSet>
        ///     <IPermission
        ///         class="System.Security.Permissions.FileIOPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"
        ///         version="1" Unrestricted="true" />
        /// </PermissionSet>
        public DateTime GetCreationTimeUtc(string path)
        {
            return Directory.GetCreationTimeUtc(path);
        }

        /// <summary>
        ///     Gets the current working directory of the application.
        /// </summary>
        /// <returns>
        ///     A string that contains the path of the current working directory, and does not end with a backslash (\).
        /// </returns>
        /// <PermissionSet>
        ///     <IPermission
        ///         class="System.Security.Permissions.FileIOPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"
        ///         version="1" Unrestricted="true" />
        /// </PermissionSet>
        public string GetCurrentDirectory()
        {
            return Directory.GetCurrentDirectory();
        }

        /// <summary>
        ///     Returns the names of subdirectories (including their paths) in the specified directory.
        /// </summary>
        /// <param name="path">The relative or absolute path to the directory to search. This string is not case-sensitive.</param>
        /// <returns>
        ///     An array of the full names (including paths) of subdirectories in the specified path, or an empty array if no
        ///     directories are found.
        /// </returns>
        /// <PermissionSet>
        ///     <IPermission
        ///         class="System.Security.Permissions.FileIOPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"
        ///         version="1" Unrestricted="true" />
        /// </PermissionSet>
        public string[] GetDirectories(string path)
        {
            return Directory.GetDirectories(path);
        }

        /// <summary>
        ///     Returns the names of subdirectories (including their paths) that match the specified search pattern in the
        ///     specified directory.
        /// </summary>
        /// <param name="path">The relative or absolute path to the directory to search. This string is not case-sensitive.</param>
        /// <param name="searchPattern">
        ///     The search string to match against the names of subdirectories in <paramref name="path" />.
        ///     This parameter can contain a combination of valid literal and wildcard characters (see Remarks), but doesn't
        ///     support regular expressions.
        /// </param>
        /// <returns>
        ///     An array of the full names (including paths) of the subdirectories that match the search pattern in the
        ///     specified directory, or an empty array if no directories are found.
        /// </returns>
        /// <PermissionSet>
        ///     <IPermission
        ///         class="System.Security.Permissions.FileIOPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"
        ///         version="1" Unrestricted="true" />
        /// </PermissionSet>
        public string[] GetDirectories(string path, string searchPattern)
        {
            return Directory.GetDirectories(path, searchPattern);
        }

        /// <summary>
        ///     Returns the names of the subdirectories (including their paths) that match the specified search pattern in the
        ///     specified directory, and optionally searches subdirectories.
        /// </summary>
        /// <param name="path">The relative or absolute path to the directory to search. This string is not case-sensitive.</param>
        /// <param name="searchPattern">
        ///     The search string to match against the names of subdirectories in <paramref name="path" />.
        ///     This parameter can contain a combination of valid literal and wildcard characters (see Remarks), but doesn't
        ///     support regular expressions.
        /// </param>
        /// <param name="searchOption">
        ///     One of the enumeration values that specifies whether the search operation should include all
        ///     subdirectories or only the current directory.
        /// </param>
        /// <returns>
        ///     An array of the full names (including paths) of the subdirectories that match the specified criteria, or an
        ///     empty array if no directories are found.
        /// </returns>
        public string[] GetDirectories(string path, string searchPattern, SearchOption searchOption)
        {
            return Directory.GetDirectories(path, searchPattern, searchOption);
        }

        /// <summary>
        ///     Returns the volume information, root information, or both for the specified path.
        /// </summary>
        /// <param name="path">The path of a file or directory.</param>
        /// <returns>
        ///     A string that contains the volume information, root information, or both for the specified path.
        /// </returns>
        /// <PermissionSet>
        ///     <IPermission
        ///         class="System.Security.Permissions.FileIOPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"
        ///         version="1" Unrestricted="true" />
        /// </PermissionSet>
        public string GetDirectoryRoot(string path)
        {
            return Directory.GetDirectoryRoot(path);
        }

        /// <summary>
        ///     Returns the names of files (including their paths) in the specified directory.
        /// </summary>
        /// <param name="path">The relative or absolute path to the directory to search. This string is not case-sensitive.</param>
        /// <returns>
        ///     An array of the full names (including paths) for the files in the specified directory, or an empty array if no
        ///     files are found.
        /// </returns>
        /// <PermissionSet>
        ///     <IPermission
        ///         class="System.Security.Permissions.FileIOPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"
        ///         version="1" Unrestricted="true" />
        /// </PermissionSet>
        public string[] GetFiles(string path)
        {
            return Directory.GetFiles(path);
        }

        /// <summary>
        ///     Returns the names of files (including their paths) that match the specified search pattern in the specified
        ///     directory.
        /// </summary>
        /// <param name="path">The relative or absolute path to the directory to search. This string is not case-sensitive.</param>
        /// <param name="searchPattern">
        ///     The search string to match against the names of files in <paramref name="path" />.  This
        ///     parameter can contain a combination of valid literal path and wildcard (* and ?) characters (see Remarks), but
        ///     doesn't support regular expressions.
        /// </param>
        /// <returns>
        ///     An array of the full names (including paths) for the files in the specified directory that match the specified
        ///     search pattern, or an empty array if no files are found.
        /// </returns>
        /// <PermissionSet>
        ///     <IPermission
        ///         class="System.Security.Permissions.FileIOPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"
        ///         version="1" Unrestricted="true" />
        /// </PermissionSet>
        public string[] GetFiles(string path, string searchPattern)
        {
            return Directory.GetFiles(path, searchPattern);
        }

        /// <summary>
        ///     Returns the names of files (including their paths) that match the specified search pattern in the specified
        ///     directory, using a value to determine whether to search subdirectories.
        /// </summary>
        /// <param name="path">The relative or absolute path to the directory to search. This string is not case-sensitive.</param>
        /// <param name="searchPattern">
        ///     The search string to match against the names of files in <paramref name="path" />.  This
        ///     parameter can contain a combination of valid literal path and wildcard (* and ?) characters (see Remarks), but
        ///     doesn't support regular expressions.
        /// </param>
        /// <param name="searchOption">
        ///     One of the enumeration values that specifies whether the search operation should include all
        ///     subdirectories or only the current directory.
        /// </param>
        /// <returns>
        ///     An array of the full names (including paths) for the files in the specified directory that match the specified
        ///     search pattern and option, or an empty array if no files are found.
        /// </returns>
        public string[] GetFiles(string path, string searchPattern, SearchOption searchOption)
        {
            return Directory.GetFiles(path, searchPattern, searchOption);
        }

        /// <summary>
        ///     Returns the names of all files and subdirectories in a specified path.
        /// </summary>
        /// <param name="path">The relative or absolute path to the directory to search. This string is not case-sensitive.</param>
        /// <returns>
        ///     An array of the names of files and subdirectories in the specified directory, or an empty array if no files or
        ///     subdirectories are found.
        /// </returns>
        /// <PermissionSet>
        ///     <IPermission
        ///         class="System.Security.Permissions.FileIOPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"
        ///         version="1" Unrestricted="true" />
        /// </PermissionSet>
        public string[] GetFileSystemEntries(string path)
        {
            return Directory.GetFileSystemEntries(path);
        }

        /// <summary>
        ///     Returns an array of file names and directory names that that match a search pattern in a specified path.
        /// </summary>
        /// <param name="path">The relative or absolute path to the directory to search. This string is not case-sensitive.</param>
        /// <param name="searchPattern">
        ///     The search string to match against the names of file and directories in
        ///     <paramref name="path" />.  This parameter can contain a combination of valid literal path and wildcard (* and ?)
        ///     characters (see Remarks), but doesn't support regular expressions.
        /// </param>
        /// <returns>
        ///     An array of file names and directory names that match the specified search criteria, or an empty array if no
        ///     files or directories are found.
        /// </returns>
        /// <PermissionSet>
        ///     <IPermission
        ///         class="System.Security.Permissions.FileIOPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"
        ///         version="1" Unrestricted="true" />
        /// </PermissionSet>
        public string[] GetFileSystemEntries(string path, string searchPattern)
        {
            return Directory.GetFileSystemEntries(path, searchPattern);
        }

        /// <summary>
        ///     Returns an array of all the file names and directory names that match a search pattern in a specified path,
        ///     and optionally searches subdirectories.
        /// </summary>
        /// <param name="path">The relative or absolute path to the directory to search. This string is not case-sensitive.</param>
        /// <param name="searchPattern">
        ///     The search string to match against the names of files and directories in
        ///     <paramref name="path" />.  This parameter can contain a combination of valid literal path and wildcard (* and ?)
        ///     characters (see Remarks), but doesn't support regular expressions.
        /// </param>
        /// <param name="searchOption">
        ///     One of the enumeration values that specifies whether the search operation should include
        ///     only the current directory or should include all subdirectories.The default value is
        ///     <see cref="F:System.IO.SearchOption.TopDirectoryOnly" />.
        /// </param>
        /// <returns>
        ///     An array of file the file names and directory names that match the specified search criteria, or an empty
        ///     array if no files or directories are found.
        /// </returns>
        public string[] GetFileSystemEntries(string path, string searchPattern, SearchOption searchOption)
        {
            return Directory.GetFileSystemEntries(path, searchPattern, searchOption);
        }

        /// <summary>
        ///     Returns the date and time the specified file or directory was last accessed.
        /// </summary>
        /// <param name="path">The file or directory for which to obtain access date and time information.</param>
        /// <returns>
        ///     A structure that is set to the date and time the specified file or directory was last accessed. This value is
        ///     expressed in local time.
        /// </returns>
        /// <PermissionSet>
        ///     <IPermission
        ///         class="System.Security.Permissions.FileIOPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"
        ///         version="1" Unrestricted="true" />
        /// </PermissionSet>
        public DateTime GetLastAccessTime(string path)
        {
            return Directory.GetLastAccessTime(path);
        }

        /// <summary>
        ///     Returns the date and time, in Coordinated Universal Time (UTC) format, that the specified file or directory
        ///     was last accessed.
        /// </summary>
        /// <param name="path">The file or directory for which to obtain access date and time information.</param>
        /// <returns>
        ///     A structure that is set to the date and time the specified file or directory was last accessed. This value is
        ///     expressed in UTC time.
        /// </returns>
        /// <PermissionSet>
        ///     <IPermission
        ///         class="System.Security.Permissions.FileIOPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"
        ///         version="1" Unrestricted="true" />
        /// </PermissionSet>
        public DateTime GetLastAccessTimeUtc(string path)
        {
            return Directory.GetLastAccessTimeUtc(path);
        }

        /// <summary>
        ///     Returns the date and time the specified file or directory was last written to.
        /// </summary>
        /// <param name="path">The file or directory for which to obtain modification date and time information.</param>
        /// <returns>
        ///     A structure that is set to the date and time the specified file or directory was last written to. This value
        ///     is expressed in local time.
        /// </returns>
        /// <PermissionSet>
        ///     <IPermission
        ///         class="System.Security.Permissions.FileIOPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"
        ///         version="1" Unrestricted="true" />
        /// </PermissionSet>
        public DateTime GetLastWriteTime(string path)
        {
            return Directory.GetLastWriteTime(path);
        }

        /// <summary>
        ///     Returns the date and time, in Coordinated Universal Time (UTC) format, that the specified file or directory
        ///     was last written to.
        /// </summary>
        /// <param name="path">The file or directory for which to obtain modification date and time information.</param>
        /// <returns>
        ///     A structure that is set to the date and time the specified file or directory was last written to. This value
        ///     is expressed in UTC time.
        /// </returns>
        /// <PermissionSet>
        ///     <IPermission
        ///         class="System.Security.Permissions.FileIOPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"
        ///         version="1" Unrestricted="true" />
        /// </PermissionSet>
        public DateTime GetLastWriteTimeUtc(string path)
        {
            return Directory.GetLastWriteTimeUtc(path);
        }

        /// <summary>
        ///     Retrieves the parent directory of the specified path, including both absolute and relative paths.
        /// </summary>
        /// <param name="path">The path for which to retrieve the parent directory.</param>
        /// <returns>
        ///     The parent directory, or null if <paramref name="path" /> is the root directory, including the root of a UNC
        ///     server or share name.
        /// </returns>
        /// <PermissionSet>
        ///     <IPermission
        ///         class="System.Security.Permissions.FileIOPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"
        ///         version="1" Unrestricted="true" />
        /// </PermissionSet>
        public IDirectoryInfo GetParent(string path)
        {
            return new DirectoryInfoAdapter(Directory.GetParent(path));
        }

        /// <summary>
        ///     Moves a file or a directory and its contents to a new location.
        /// </summary>
        /// <param name="sourceDirName">The path of the file or directory to move.</param>
        /// <param name="destDirName">
        ///     The path to the new location for <paramref name="sourceDirName" />. If
        ///     <paramref name="sourceDirName" /> is a file, then <paramref name="destDirName" /> must also be a file name.
        /// </param>
        /// <PermissionSet>
        ///     <IPermission
        ///         class="System.Security.Permissions.FileIOPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"
        ///         version="1" Unrestricted="true" />
        /// </PermissionSet>
        public void Move(string sourceDirName, string destDirName)
        {
            Directory.Move(sourceDirName, destDirName);
        }

        /// <summary>
        ///     Sets the creation date and time for the specified file or directory.
        /// </summary>
        /// <param name="path">The file or directory for which to set the creation date and time information.</param>
        /// <param name="creationTime">
        ///     The date and time the file or directory was last written to. This value is expressed in
        ///     local time.
        /// </param>
        /// <PermissionSet>
        ///     <IPermission
        ///         class="System.Security.Permissions.FileIOPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"
        ///         version="1" Unrestricted="true" />
        /// </PermissionSet>
        public void SetCreationTime(string path, DateTime creationTime)
        {
            Directory.SetCreationTime(path, creationTime);
        }

        /// <summary>
        ///     Sets the creation date and time, in Coordinated Universal Time (UTC) format, for the specified file or
        ///     directory.
        /// </summary>
        /// <param name="path">The file or directory for which to set the creation date and time information.</param>
        /// <param name="creationTimeUtc">
        ///     The date and time the directory or file was created. This value is expressed in local
        ///     time.
        /// </param>
        /// <PermissionSet>
        ///     <IPermission
        ///         class="System.Security.Permissions.FileIOPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"
        ///         version="1" Unrestricted="true" />
        /// </PermissionSet>
        public void SetCreationTimeUtc(string path, DateTime creationTimeUtc)
        {
            Directory.SetCreationTimeUtc(path, creationTimeUtc);
        }

        /// <summary>
        ///     Sets the application's current working directory to the specified directory.
        /// </summary>
        /// <param name="path">The path to which the current working directory is set.</param>
        /// <PermissionSet>
        ///     <IPermission
        ///         class="System.Security.Permissions.SecurityPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"
        ///         version="1" Flags="UnmanagedCode" />
        /// </PermissionSet>
        public void SetCurrentDirectory(string path)
        {
            Directory.SetCurrentDirectory(path);
        }

        /// <summary>
        ///     Sets the date and time the specified file or directory was last accessed.
        /// </summary>
        /// <param name="path">The file or directory for which to set the access date and time information.</param>
        /// <param name="lastAccessTime">
        ///     An object that contains the value to set for the access date and time of
        ///     <paramref name="path" />. This value is expressed in local time.
        /// </param>
        /// <PermissionSet>
        ///     <IPermission
        ///         class="System.Security.Permissions.FileIOPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"
        ///         version="1" Unrestricted="true" />
        /// </PermissionSet>
        public void SetLastAccessTime(string path, DateTime lastAccessTime)
        {
            Directory.SetLastAccessTime(path, lastAccessTime);
        }

        /// <summary>
        ///     Sets the date and time, in Coordinated Universal Time (UTC) format, that the specified file or directory was
        ///     last accessed.
        /// </summary>
        /// <param name="path">The file or directory for which to set the access date and time information.</param>
        /// <param name="lastAccessTimeUtc">
        ///     An object that  contains the value to set for the access date and time of
        ///     <paramref name="path" />. This value is expressed in UTC time.
        /// </param>
        /// <PermissionSet>
        ///     <IPermission
        ///         class="System.Security.Permissions.FileIOPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"
        ///         version="1" Unrestricted="true" />
        /// </PermissionSet>
        public void SetLastAccessTimeUtc(string path, DateTime lastAccessTimeUtc)
        {
            Directory.SetLastAccessTimeUtc(path, lastAccessTimeUtc);
        }

        /// <summary>
        ///     Sets the date and time a directory was last written to.
        /// </summary>
        /// <param name="path">The path of the directory.</param>
        /// <param name="lastWriteTime">The date and time the directory was last written to. This value is expressed in local time.</param>
        /// <PermissionSet>
        ///     <IPermission
        ///         class="System.Security.Permissions.FileIOPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"
        ///         version="1" Unrestricted="true" />
        /// </PermissionSet>
        public void SetLastWriteTime(string path, DateTime lastWriteTime)
        {
            Directory.SetLastAccessTime(path, lastWriteTime);
        }

        /// <summary>
        ///     Sets the date and time, in Coordinated Universal Time (UTC) format, that a directory was last written to.
        /// </summary>
        /// <param name="path">The path of the directory.</param>
        /// <param name="lastWriteTimeUtc">
        ///     The date and time the directory was last written to. This value is expressed in UTC
        ///     time.
        /// </param>
        /// <PermissionSet>
        ///     <IPermission
        ///         class="System.Security.Permissions.FileIOPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"
        ///         version="1" Unrestricted="true" />
        /// </PermissionSet>
        public void SetLastWriteTimeUtc(string path, DateTime lastWriteTimeUtc)
        {
            Directory.SetLastWriteTimeUtc(path, lastWriteTimeUtc);
        }

        /// <summary>
        ///     Returns an enumerable collection of directory names in a specified path.
        /// </summary>
        /// <param name="path">The relative or absolute path to the directory to search. This string is not case-sensitive.</param>
        /// <returns>
        ///     An enumerable collection of the full names (including paths) for the directories in the directory specified by
        ///     <paramref name="path" />.
        /// </returns>
        public IEnumerable<string> EnumerateDirectories(string path)
        {
            return Directory.EnumerateDirectories(path);
        }

        /// <summary>
        ///     Returns an enumerable collection of directory names that match a search pattern in a specified path.
        /// </summary>
        /// <param name="path">The relative or absolute path to the directory to search. This string is not case-sensitive.</param>
        /// <param name="searchPattern">
        ///     The search string to match against the names of directories in <paramref name="path" />.
        ///     This parameter can contain a combination of valid literal path and wildcard (* and ?) characters (see Remarks), but
        ///     doesn't support regular expressions.
        /// </param>
        /// <returns>
        ///     An enumerable collection of the full names (including paths) for the directories in the directory specified by
        ///     <paramref name="path" /> and that match the specified search pattern.
        /// </returns>
        public IEnumerable<string> EnumerateDirectories(string path, string searchPattern)
        {
            return Directory.EnumerateDirectories(path, searchPattern);
        }

        /// <summary>
        ///     Returns an enumerable collection of directory names that match a search pattern in a specified path, and
        ///     optionally searches subdirectories.
        /// </summary>
        /// <param name="path">The relative or absolute path to the directory to search. This string is not case-sensitive.</param>
        /// <param name="searchPattern">
        ///     The search string to match against the names of directories in <paramref name="path" />.
        ///     This parameter can contain a combination of valid literal path and wildcard (* and ?) characters (see Remarks), but
        ///     doesn't support regular expressions.
        /// </param>
        /// <param name="searchOption">
        ///     One of the enumeration values that specifies whether the search operation should include
        ///     only the current directory or should include all subdirectories.The default value is
        ///     <see cref="F:System.IO.SearchOption.TopDirectoryOnly" />.
        /// </param>
        /// <returns>
        ///     An enumerable collection of the full names (including paths) for the directories in the directory specified by
        ///     <paramref name="path" /> and that match the specified search pattern and option.
        /// </returns>
        public IEnumerable<string> EnumerateDirectories(string path, string searchPattern, SearchOption searchOption)
        {
            return Directory.EnumerateDirectories(path, searchPattern, searchOption);
        }

        /// <summary>
        ///     Returns an enumerable collection of file names in a specified path.
        /// </summary>
        /// <param name="path">The relative or absolute path to the directory to search. This string is not case-sensitive.</param>
        /// <returns>
        ///     An enumerable collection of the full names (including paths) for the files in the directory specified by
        ///     <paramref name="path" />.
        /// </returns>
        public IEnumerable<string> EnumerateFiles(string path)
        {
            return Directory.EnumerateFiles(path);
        }

        /// <summary>
        ///     Returns an enumerable collection of file names that match a search pattern in a specified path.
        /// </summary>
        /// <param name="path">The relative or absolute path to the directory to search. This string is not case-sensitive.</param>
        /// <param name="searchPattern">
        ///     The search string to match against the names of files in <paramref name="path" />.  This
        ///     parameter can contain a combination of valid literal path and wildcard (* and ?) characters (see Remarks), but
        ///     doesn't support regular expressions.
        /// </param>
        /// <returns>
        ///     An enumerable collection of the full names (including paths) for the files in the directory specified by
        ///     <paramref name="path" /> and that match the specified search pattern.
        /// </returns>
        public IEnumerable<string> EnumerateFiles(string path, string searchPattern)
        {
            return Directory.EnumerateFiles(path, searchPattern);
        }

        /// <summary>
        ///     Returns an enumerable collection of file names that match a search pattern in a specified path, and optionally
        ///     searches subdirectories.
        /// </summary>
        /// <param name="path">The relative or absolute path to the directory to search. This string is not case-sensitive.</param>
        /// <param name="searchPattern">
        ///     The search string to match against the names of files in <paramref name="path" />.  This
        ///     parameter can contain a combination of valid literal path and wildcard (* and ?) characters (see Remarks), but
        ///     doesn't support regular expressions.
        /// </param>
        /// <param name="searchOption">
        ///     One of the enumeration values that specifies whether the search operation should include
        ///     only the current directory or should include all subdirectories.The default value is
        ///     <see cref="F:System.IO.SearchOption.TopDirectoryOnly" />.
        /// </param>
        /// <returns>
        ///     An enumerable collection of the full names (including paths) for the files in the directory specified by
        ///     <paramref name="path" /> and that match the specified search pattern and option.
        /// </returns>
        public IEnumerable<string> EnumerateFiles(string path, string searchPattern, SearchOption searchOption)
        {
            return Directory.EnumerateFiles(path, searchPattern, searchOption);
        }

        /// <summary>
        ///     Returns an enumerable collection of file names and directory names in a specified path.
        /// </summary>
        /// <param name="path">The relative or absolute path to the directory to search. This string is not case-sensitive.</param>
        /// <returns>
        ///     An enumerable collection of file-system entries in the directory specified by <paramref name="path" />.
        /// </returns>
        public IEnumerable<string> EnumerateFileSystemEntries(string path)
        {
            return Directory.EnumerateFileSystemEntries(path);
        }

        /// <summary>
        ///     Returns an enumerable collection of file names and directory names that  match a search pattern in a specified
        ///     path.
        /// </summary>
        /// <param name="path">The relative or absolute path to the directory to search. This string is not case-sensitive.</param>
        /// <param name="searchPattern">
        ///     The search string to match against the names of file-system entries in
        ///     <paramref name="path" />.  This parameter can contain a combination of valid literal path and wildcard (* and ?)
        ///     characters (see Remarks), but doesn't support regular expressions.
        /// </param>
        /// <returns>
        ///     An enumerable collection of file-system entries in the directory specified by <paramref name="path" /> and
        ///     that match the specified search pattern.
        /// </returns>
        public IEnumerable<string> EnumerateFileSystemEntries(string path, string searchPattern)
        {
            return Directory.EnumerateFileSystemEntries(path, searchPattern);
        }

        /// <summary>
        ///     Returns an enumerable collection of file names and directory names that match a search pattern in a specified
        ///     path, and optionally searches subdirectories.
        /// </summary>
        /// <param name="path">The relative or absolute path to the directory to search. This string is not case-sensitive.</param>
        /// <param name="searchPattern">
        ///     The search string to match against file-system entries in <paramref name="path" />.  This
        ///     parameter can contain a combination of valid literal path and wildcard (* and ?) characters (see Remarks), but
        ///     doesn't support regular expressions.
        /// </param>
        /// <param name="searchOption">
        ///     One of the enumeration values  that specifies whether the search operation should include
        ///     only the current directory or should include all subdirectories.The default value is
        ///     <see cref="F:System.IO.SearchOption.TopDirectoryOnly" />.
        /// </param>
        /// <returns>
        ///     An enumerable collection of file-system entries in the directory specified by <paramref name="path" /> and
        ///     that match the specified search pattern and option.
        /// </returns>
        public IEnumerable<string> EnumerateFileSystemEntries(string path, string searchPattern,
            SearchOption searchOption)
        {
            return Directory.EnumerateFileSystemEntries(path, searchPattern, searchOption);
        }
    }
}