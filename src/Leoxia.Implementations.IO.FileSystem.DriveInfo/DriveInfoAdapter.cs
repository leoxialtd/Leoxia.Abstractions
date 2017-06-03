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
using Leoxia.Abstractions.IO;
using Leoxia.Abstractions.IO.FileSystem.DriveInfo;

#endregion

namespace Leoxia.Implementations.IO.FileSystem.DriveInfo
{
    /// <summary>
    ///     Adapter for a <see cref="DriveInfo" /> into <see cref="IDriveInfo"/>.
    /// </summary>
    public class DriveInfoAdapter : IDriveInfo
    {
        /// <summary>
        ///     The real wrapped drive information
        /// </summary>
        private readonly System.IO.DriveInfo _driveInfo;


        /// <summary>
        ///     Initializes a new instance of the <see cref="DriveInfoAdapter" /> class which acts as a wrapper of
        ///     <see cref="DriveInfo" />
        /// </summary>
        /// <param name="driveInfo">The drive information.</param>
        public DriveInfoAdapter(System.IO.DriveInfo driveInfo)
        {
            _driveInfo = driveInfo ?? throw new ArgumentNullException(nameof(driveInfo));
        }


        /// <summary>Indicates the amount of available free space on a drive, in bytes.</summary>
        /// <returns>The amount of free space available on the drive, in bytes.</returns>
        /// <exception cref="T:System.UnauthorizedAccessException">Access to the drive information is denied.</exception>
        /// <exception cref="T:System.IO.IOException">An I/O error occurred (for example, a disk error or a drive was not ready). </exception>
        public long AvailableFreeSpace => _driveInfo.AvailableFreeSpace;

        /// <summary>Gets the name of the file system, such as NTFS or FAT32.</summary>
        /// <returns>The name of the file system on the specified drive.</returns>
        /// <exception cref="T:System.UnauthorizedAccessException">Access to the drive information is denied.</exception>
        /// <exception cref="T:System.IO.DriveNotFoundException">The drive does not exist or is not mapped.</exception>
        /// <exception cref="T:System.IO.IOException">An I/O error occurred (for example, a disk error or a drive was not ready). </exception>
        public string DriveFormat => _driveInfo.DriveFormat;

        /// <summary>Gets the drive type, such as CD-ROM, removable, network, or fixed.</summary>
        /// <returns>One of the enumeration values that specifies a drive type. </returns>
        public DriveType DriveType => _driveInfo.DriveType;

        /// <summary>Gets a value that indicates whether a drive is ready.</summary>
        /// <returns>true if the drive is ready; false if the drive is not ready.</returns>
        public bool IsReady => _driveInfo.IsReady;

        /// <summary>Gets the name of a drive, such as C:\.</summary>
        /// <returns>The name of the drive.</returns>
        public string Name => _driveInfo.Name;

        /// <summary>Gets the root directory of a drive.</summary>
        /// <returns>An object that contains the root directory of the drive.</returns>
        /// <PermissionSet>
        ///     <IPermission
        ///         class="System.Security.Permissions.FileIOPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"
        ///         version="1" Unrestricted="true" />
        /// </PermissionSet>
        public IDirectoryInfo RootDirectory => _driveInfo.RootDirectory.Adapt();

        /// <summary>Gets the total amount of free space available on a drive, in bytes.</summary>
        /// <returns>The total free space available on a drive, in bytes.</returns>
        /// <exception cref="T:System.UnauthorizedAccessException">Access to the drive information is denied.</exception>
        /// <exception cref="T:System.IO.DriveNotFoundException">The drive is not mapped or does not exist.</exception>
        /// <exception cref="T:System.IO.IOException">An I/O error occurred (for example, a disk error or a drive was not ready). </exception>
        public long TotalFreeSpace => _driveInfo.TotalFreeSpace;

        /// <summary>Gets the total size of storage space on a drive, in bytes.</summary>
        /// <returns>The total size of the drive, in bytes.</returns>
        /// <exception cref="T:System.UnauthorizedAccessException">Access to the drive information is denied.</exception>
        /// <exception cref="T:System.IO.DriveNotFoundException">The drive is not mapped or does not exist. </exception>
        /// <exception cref="T:System.IO.IOException">An I/O error occurred (for example, a disk error or a drive was not ready). </exception>
        public long TotalSize => _driveInfo.TotalSize;

        /// <summary>Gets or sets the volume label of a drive.</summary>
        /// <returns>The volume label.</returns>
        /// <exception cref="T:System.IO.IOException">An I/O error occurred (for example, a disk error or a drive was not ready). </exception>
        /// <exception cref="T:System.IO.DriveNotFoundException">The drive is not mapped or does not exist.</exception>
        /// <exception cref="T:System.Security.SecurityException">The caller does not have the required permission. </exception>
        /// <exception cref="T:System.UnauthorizedAccessException">
        ///     The volume label is being set on a network or CD-ROM
        ///     drive.-or-Access to the drive information is denied.
        /// </exception>
        /// <PermissionSet>
        ///     <IPermission
        ///         class="System.Security.Permissions.FileIOPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"
        ///         version="1" Unrestricted="true" />
        /// </PermissionSet>
        public string VolumeLabel
        {
            get => _driveInfo.VolumeLabel;
            set => _driveInfo.VolumeLabel = value;
        }

        /// <summary>Returns a string that represents the current object.</summary>
        /// <returns>A string that represents the current object.</returns>
        public override string ToString()
        {
            return _driveInfo.ToString();
        }
    }
}