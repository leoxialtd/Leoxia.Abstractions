#region Copyright (c) 2017 Leoxia Ltd

// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IEnvironment.cs" company="Leoxia Ltd">
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
using System.Collections;

#endregion

namespace Leoxia.Abstractions
{
    /// <summary>
    ///     Interface for <see cref="Environment" />.
    ///     Provides information about, and means to manipulate, the current environment and platform. This class cannot be
    ///     inherited.
    /// </summary>
    public interface IEnvironment
    {
        /// <summary>Gets a unique identifier for the current managed thread.</summary>
        /// <returns>An integer that represents a unique identifier for this managed thread.</returns>
        int CurrentManagedThreadId { get; }

        /// <summary>
        ///     Gets a value indicating whether the current application domain is being unloaded or the common language
        ///     runtime (CLR) is shutting down.
        /// </summary>
        /// <returns>true if the current application domain is being unloaded or the CLR is shutting down; otherwise, false.</returns>
        /// <filterpriority>1</filterpriority>
        bool HasShutdownStarted { get; }

        /// <summary>
        ///     Gets the name of the machine.
        /// </summary>
        /// <value>
        ///     The name of the machine.
        /// </value>
        string MachineName { get; }

        /// <summary>Gets the newline string defined for this environment.</summary>
        /// <returns>A string containing "\r\n" for non-Unix platforms, or a string containing "\n" for Unix platforms.</returns>
        /// <filterpriority>1</filterpriority>
        string NewLine { get; }

        /// <summary>Gets the number of processors on the current machine.</summary>
        /// <returns>
        ///     The 32-bit signed integer that specifies the number of processors on the current machine. There is no default.
        ///     If the current machine contains multiple processor groups, this property returns the number of logical processors
        ///     that are available for use by the common language runtime (CLR).
        /// </returns>
        /// <filterpriority>1</filterpriority>
        /// <PermissionSet>
        ///     <IPermission
        ///         class="System.Security.Permissions.EnvironmentPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"
        ///         version="1" Read="NUMBER_OF_PROCESSORS" />
        /// </PermissionSet>
        int ProcessorCount { get; }

        /// <summary>Gets current stack trace information.</summary>
        /// <returns>A string containing stack trace information. This value can be <see cref="F:System.String.Empty" />.</returns>
        /// <exception cref="T:System.ArgumentOutOfRangeException">The requested stack trace information is out of range.</exception>
        /// <filterpriority>1</filterpriority>
        /// <PermissionSet>
        ///     <IPermission
        ///         class="System.Security.Permissions.EnvironmentPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"
        ///         version="1" Unrestricted="true" />
        ///     <IPermission
        ///         class="System.Security.Permissions.FileIOPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"
        ///         version="1" PathDiscovery="*AllFiles*" />
        /// </PermissionSet>
        string StackTrace { get; }

        /// <summary>Gets the number of milliseconds elapsed since the system started.</summary>
        /// <returns>
        ///     A 32-bit signed integer containing the amount of time in milliseconds that has passed since the last time the
        ///     computer was started.
        /// </returns>
        /// <filterpriority>1</filterpriority>
        int TickCount { get; }

        /// <summary>
        ///     Replaces the name of each environment variable embedded in the specified string with the string equivalent of
        ///     the value of the variable, then returns the resulting string.
        /// </summary>
        /// <returns>A string with each environment variable replaced by its value.</returns>
        /// <param name="name">
        ///     A string containing the names of zero or more environment variables. Each environment variable is
        ///     quoted with the percent sign character (%).
        /// </param>
        /// <exception cref="T:System.ArgumentNullException">
        ///     <paramref name="name" /> is null.
        /// </exception>
        /// <filterpriority>1</filterpriority>
        /// <PermissionSet>
        ///     <IPermission
        ///         class="System.Security.Permissions.EnvironmentPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"
        ///         version="1" Unrestricted="true" />
        /// </PermissionSet>
        string ExpandEnvironmentVariables(string name);

        /// <summary>
        ///     Exits the program with the specific code.
        /// </summary>
        /// <param name="exitCode">The exit code.</param>
        void Exit(int exitCode);

        /// <summary>
        ///     Immediately terminates a process after writing a message to the Windows Application event log, and then
        ///     includes the message in error reporting to Microsoft.
        /// </summary>
        /// <param name="message">A message that explains why the process was terminated, or null if no explanation is provided.</param>
        void FailFast(string message);

        /// <summary>
        ///     Immediately terminates a process after writing a message to the Windows Application event log, and then
        ///     includes the message and exception information in error reporting to Microsoft.
        /// </summary>
        /// <param name="message">A message that explains why the process was terminated, or null if no explanation is provided.</param>
        /// <param name="exception">
        ///     An exception that represents the error that caused the termination. This is typically the
        ///     exception in a catch block.
        /// </param>
        void FailFast(string message, Exception exception);

        /// <summary>Retrieves the value of an environment variable from the current process. </summary>
        /// <returns>
        ///     The value of the environment variable specified by <paramref name="variable" />, or null if the environment
        ///     variable is not found.
        /// </returns>
        /// <param name="variable">The name of the environment variable.</param>
        /// <exception cref="T:System.ArgumentNullException">
        ///     <paramref name="variable" /> is null.
        /// </exception>
        /// <exception cref="T:System.Security.SecurityException">
        ///     The caller does not have the required permission to perform this
        ///     operation.
        /// </exception>
        /// <filterpriority>1</filterpriority>
        /// <PermissionSet>
        ///     <IPermission
        ///         class="System.Security.Permissions.EnvironmentPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"
        ///         version="1" Unrestricted="true" />
        /// </PermissionSet>
        string GetEnvironmentVariable(string variable);

        /// <summary>Retrieves all environment variable names and their values from the current process.</summary>
        /// <returns>
        ///     A dictionary that contains all environment variable names and their values; otherwise, an empty dictionary if
        ///     no environment variables are found.
        /// </returns>
        /// <exception cref="T:System.Security.SecurityException">
        ///     The caller does not have the required permission to perform this
        ///     operation.
        /// </exception>
        /// <exception cref="T:System.OutOfMemoryException">The buffer is out of memory.</exception>
        /// <filterpriority>1</filterpriority>
        /// <PermissionSet>
        ///     <IPermission
        ///         class="System.Security.Permissions.EnvironmentPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"
        ///         version="1" Unrestricted="true" />
        /// </PermissionSet>
        IDictionary GetEnvironmentVariables();

        /// <summary>Creates, modifies, or deletes an environment variable stored in the current process.</summary>
        /// <param name="variable">The name of an environment variable.</param>
        /// <param name="value">A value to assign to <paramref name="variable" />.</param>
        /// <exception cref="T:System.ArgumentNullException">
        ///     <paramref name="variable" /> is null.
        /// </exception>
        /// <exception cref="T:System.ArgumentException">
        ///     <paramref name="variable" /> contains a zero-length string, an initial hexadecimal zero character (0x00), or an
        ///     equal sign ("="). -or-The length of <paramref name="variable" /> or <paramref name="value" /> is greater than or
        ///     equal to 32,767 characters.-or-An error occurred during the execution of this operation.
        /// </exception>
        /// <exception cref="T:System.Security.SecurityException">
        ///     The caller does not have the required permission to perform this
        ///     operation.
        /// </exception>
        /// <filterpriority>1</filterpriority>
        /// <PermissionSet>
        ///     <IPermission
        ///         class="System.Security.Permissions.EnvironmentPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"
        ///         version="1" Unrestricted="true" />
        /// </PermissionSet>
        void SetEnvironmentVariable(string variable, string value);

        /// <summary>
        ///     Gets the command line arguments.
        /// </summary>
        /// <returns>command line arguments</returns>
        string[] GetCommandLineArgs();
    }
}