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
    ///     Adapter for <see cref="Path" /> into <see cref="IPath" />
    /// </summary>
    /// <seealso cref="Leoxia.Abstractions.IO.IPath" />
    public class PathAdapter : IPath
    {
        /// <summary>
        ///     Provides a platform-specific alternate character used to separate directory levels in a path string that
        ///     reflects a hierarchical file system organization.
        /// </summary>
        public char AltDirectorySeparatorChar => Path.AltDirectorySeparatorChar;

        /// <summary>
        ///     Provides a platform-specific character used to separate directory levels in a path string that reflects a
        ///     hierarchical file system organization.
        /// </summary>
        public char DirectorySeparatorChar => Path.DirectorySeparatorChar;

        /// <summary>
        ///     A platform-specific separator character used to separate path strings in environment variables.
        /// </summary>
        public char PathSeparator => Path.PathSeparator;

        /// <summary>
        ///     Provides a platform-specific volume separator character.
        /// </summary>
        public char VolumeSeparatorChar => Path.VolumeSeparatorChar;

        /// <summary>
        ///     Changes the extension of a path string.
        /// </summary>
        /// <param name="path">
        ///     The path information to modify. The path cannot contain any of the characters defined in
        ///     <see cref="M:System.IO.Path.GetInvalidPathChars" />.
        /// </param>
        /// <param name="extension">
        ///     The new extension (with or without a leading period). Specify null to remove an existing
        ///     extension from <paramref name="path" />.
        /// </param>
        /// <returns>
        ///     The modified path information.On Windows-based desktop platforms, if <paramref name="path" /> is null or an
        ///     empty string (""), the path information is returned unmodified. If <paramref name="extension" /> is null, the
        ///     returned string contains the specified path with its extension removed. If <paramref name="path" /> has no
        ///     extension, and <paramref name="extension" /> is not null, the returned path string contains
        ///     <paramref name="extension" /> appended to the end of <paramref name="path" />.
        /// </returns>
        public string ChangeExtension(string path, string extension)
        {
            return Path.ChangeExtension(path, extension);
        }

        /// <summary>
        ///     Combines an array of strings into a path.
        /// </summary>
        /// <param name="paths">An array of parts of the path.</param>
        /// <returns>
        ///     The combined paths.
        /// </returns>
        public string Combine(params string[] paths)
        {
            return Path.Combine(paths);
        }

        /// <summary>
        ///     Combines two strings into a path.
        /// </summary>
        /// <param name="path1">The first path to combine.</param>
        /// <param name="path2">The second path to combine.</param>
        /// <returns>
        ///     The combined paths. If one of the specified paths is a zero-length string, this method returns the other path.
        ///     If <paramref name="path2" /> contains an absolute path, this method returns <paramref name="path2" />.
        /// </returns>
        public string Combine(string path1, string path2)
        {
            return Path.Combine(path1, path2);
        }

        /// <summary>
        ///     Combines three strings into a path.
        /// </summary>
        /// <param name="path1">The first path to combine.</param>
        /// <param name="path2">The second path to combine.</param>
        /// <param name="path3">The third path to combine.</param>
        /// <returns>
        ///     The combined paths.
        /// </returns>
        public string Combine(string path1, string path2, string path3)
        {
            return Path.Combine(path1, path2, path3);
        }

        /// <summary>
        ///     Returns the directory information for the specified path string.
        /// </summary>
        /// <param name="path">The path of a file or directory.</param>
        /// <returns>
        ///     Directory information for <paramref name="path" />, or null if <paramref name="path" /> denotes a root
        ///     directory or is null. Returns <see cref="F:System.String.Empty" /> if <paramref name="path" /> does not contain
        ///     directory information.
        /// </returns>
        public string GetDirectoryName(string path)
        {
            return Path.GetDirectoryName(path);
        }

        /// <summary>
        ///     Returns the extension of the specified path string.
        /// </summary>
        /// <param name="path">The path string from which to get the extension.</param>
        /// <returns>
        ///     The extension of the specified path (including the period "."), or null, or
        ///     <see cref="F:System.String.Empty" />. If <paramref name="path" /> is null,
        ///     <see cref="M:System.IO.Path.GetExtension(System.String)" /> returns null. If <paramref name="path" /> does not have
        ///     extension information, <see cref="M:System.IO.Path.GetExtension(System.String)" /> returns
        ///     <see cref="F:System.String.Empty" />.
        /// </returns>
        public string GetExtension(string path)
        {
            return Path.GetExtension(path);
        }

        /// <summary>
        ///     Returns the file name and extension of the specified path string.
        /// </summary>
        /// <param name="path">The path string from which to obtain the file name and extension.</param>
        /// <returns>
        ///     The characters after the last directory character in <paramref name="path" />. If the last character of
        ///     <paramref name="path" /> is a directory or volume separator character, this method returns
        ///     <see cref="F:System.String.Empty" />. If <paramref name="path" /> is null, this method returns null.
        /// </returns>
        public string GetFileName(string path)
        {
            return Path.GetFileName(path);
        }

        /// <summary>
        ///     Returns the file name of the specified path string without the extension.
        /// </summary>
        /// <param name="path">The path of the file.</param>
        /// <returns>
        ///     The string returned by <see cref="M:System.IO.Path.GetFileName(System.String)" />, minus the last period (.)
        ///     and all characters following it.
        /// </returns>
        public string GetFileNameWithoutExtension(string path)
        {
            return Path.GetFileNameWithoutExtension(path);
        }

        /// <summary>
        ///     Returns the absolute path for the specified path string.
        /// </summary>
        /// <param name="path">The file or directory for which to obtain absolute path information.</param>
        /// <returns>
        ///     The fully qualified location of <paramref name="path" />, such as "C:\MyFile.txt".
        /// </returns>
        /// <PermissionSet>
        ///     <IPermission
        ///         class="System.Security.Permissions.FileIOPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"
        ///         version="1" PathDiscovery="*AllFiles*" />
        /// </PermissionSet>
        public string GetFullPath(string path)
        {
            return Path.GetFullPath(path);
        }

        /// <summary>
        ///     Gets an array containing the characters that are not allowed in file names.
        /// </summary>
        /// <returns>
        ///     An array containing the characters that are not allowed in file names.
        /// </returns>
        public char[] GetInvalidFileNameChars()
        {
            return Path.GetInvalidFileNameChars();
        }

        /// <summary>
        ///     Gets an array containing the characters that are not allowed in path names.
        /// </summary>
        /// <returns>
        ///     An array containing the characters that are not allowed in path names.
        /// </returns>
        public char[] GetInvalidPathChars()
        {
            return Path.GetInvalidPathChars();
        }

        /// <summary>
        ///     Gets the root directory information of the specified path.
        /// </summary>
        /// <param name="path">The path from which to obtain root directory information.</param>
        /// <returns>
        ///     The root directory of <paramref name="path" />, such as "C:\", or null if <paramref name="path" /> is null, or
        ///     an empty string if <paramref name="path" /> does not contain root directory information.
        /// </returns>
        public string GetPathRoot(string path)
        {
            return Path.GetPathRoot(path);
        }

        /// <summary>
        ///     Returns a random folder name or file name.
        /// </summary>
        /// <returns>
        ///     A random folder name or file name.
        /// </returns>
        public string GetRandomFileName()
        {
            return Path.GetRandomFileName();
        }

        /// <summary>
        ///     Creates a uniquely named, zero-byte temporary file on disk and returns the full path of that file.
        /// </summary>
        /// <returns>
        ///     The full path of the temporary file.
        /// </returns>
        /// <PermissionSet>
        ///     <IPermission
        ///         class="System.Security.Permissions.EnvironmentPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"
        ///         version="1" Unrestricted="true" />
        ///     <IPermission
        ///         class="System.Security.Permissions.FileIOPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"
        ///         version="1" Unrestricted="true" />
        /// </PermissionSet>
        public string GetTempFileName()
        {
            return Path.GetTempFileName();
        }

        /// <summary>
        ///     Returns the path of the current user's temporary folder.
        /// </summary>
        /// <returns>
        ///     The path to the temporary folder, ending with a backslash.
        /// </returns>
        /// <PermissionSet>
        ///     <IPermission
        ///         class="System.Security.Permissions.EnvironmentPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"
        ///         version="1" Unrestricted="true" />
        /// </PermissionSet>
        public string GetTempPath()
        {
            return Path.GetTempPath();
        }

        /// <summary>
        ///     Determines whether a path includes a file name extension.
        /// </summary>
        /// <param name="path">The path to search for an extension.</param>
        /// <returns>
        ///     true if the characters that follow the last directory separator (\\ or /) or volume separator (:) in the path
        ///     include a period (.) followed by one or more characters; otherwise, false.
        /// </returns>
        public bool HasExtension(string path)
        {
            return Path.HasExtension(path);
        }

        /// <summary>
        ///     Gets a value indicating whether the specified path string contains a root.
        /// </summary>
        /// <param name="path">The path to test.</param>
        /// <returns>
        ///     true if <paramref name="path" /> contains a root; otherwise, false.
        /// </returns>
        public bool IsPathRooted(string path)
        {
            return Path.IsPathRooted(path);
        }

        /// <summary>
        ///     Combines the specified path1.
        /// </summary>
        /// <param name="path1">The path1.</param>
        /// <param name="path2">The path2.</param>
        /// <param name="path3">The path3.</param>
        /// <param name="path4">The path4.</param>
        /// <returns></returns>
        public string Combine(string path1, string path2, string path3, string path4)
        {
            return Path.Combine(path1, path2, path3, path4);
        }
    }
}