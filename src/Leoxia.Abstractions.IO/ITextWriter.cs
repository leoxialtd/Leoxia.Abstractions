#region Copyright (c) 2017 Leoxia Ltd

// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ITextWriter.cs" company="Leoxia Ltd">
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
using System.Text;
using System.Threading.Tasks;

#endregion

namespace Leoxia.Abstractions.IO
{
    /// <summary>Represents a writer that can write a sequential series of characters. This class is abstract.</summary>
    /// <filterpriority>2</filterpriority>
    public interface ITextWriter : IDisposable
    {
        /// <summary>When overridden in a derived class, returns the character encoding in which the output is written.</summary>
        /// <returns>The character encoding in which the output is written.</returns>
        /// <filterpriority>1</filterpriority>
        Encoding Encoding { get; }

        /// <summary>Gets an object that controls formatting.</summary>
        /// <returns>
        ///     An <see cref="T:System.IFormatProvider" /> object for a specific culture, or the formatting of the current
        ///     culture if no other culture is specified.
        /// </returns>
        /// <filterpriority>2</filterpriority>
        IFormatProvider FormatProvider { get; }

        /// <summary>Gets or sets the line terminator string used by the current TextWriter.</summary>
        /// <returns>The line terminator string for the current TextWriter.</returns>
        /// <filterpriority>2</filterpriority>
        string NewLine { get; set; }

        /// <summary>Clears all buffers for the current writer and causes any buffered data to be written to the underlying device.</summary>
        /// <filterpriority>1</filterpriority>
        void Flush();


        /// <summary>Writes the text representation of a Boolean value to the text string or stream.</summary>
        /// <param name="value">The Boolean value to write. </param>
        /// <exception cref="T:System.ObjectDisposedException">The <see cref="T:System.IO.TextWriter" /> is closed. </exception>
        /// <exception cref="T:System.IO.IOException">An I/O error occurs. </exception>
        /// <filterpriority>1</filterpriority>
        void Write(bool value);

        /// <summary>Writes a character to the text string or stream.</summary>
        /// <param name="value">The character to write to the text stream. </param>
        /// <exception cref="T:System.ObjectDisposedException">The <see cref="T:System.IO.TextWriter" /> is closed. </exception>
        /// <exception cref="T:System.IO.IOException">An I/O error occurs. </exception>
        /// <filterpriority>1</filterpriority>
        void Write(char value);

        /// <summary>Writes a character array to the text string or stream.</summary>
        /// <param name="buffer">The character array to write to the text stream. </param>
        /// <exception cref="T:System.ObjectDisposedException">The <see cref="T:System.IO.TextWriter" /> is closed. </exception>
        /// <exception cref="T:System.IO.IOException">An I/O error occurs. </exception>
        /// <filterpriority>1</filterpriority>
        void Write(char[] buffer);

        /// <summary>Writes a subarray of characters to the text string or stream.</summary>
        /// <param name="buffer">The character array to write data from. </param>
        /// <param name="index">The character position in the buffer at which to start retrieving data. </param>
        /// <param name="count">The number of characters to write. </param>
        /// <exception cref="T:System.ArgumentException">
        ///     The buffer length minus <paramref name="index" /> is less than
        ///     <paramref name="count" />.
        /// </exception>
        /// <exception cref="T:System.ArgumentNullException">The <paramref name="buffer" /> parameter is null. </exception>
        /// <exception cref="T:System.ArgumentOutOfRangeException">
        ///     <paramref name="index" /> or <paramref name="count" /> is negative.
        /// </exception>
        /// <exception cref="T:System.ObjectDisposedException">The <see cref="T:System.IO.TextWriter" /> is closed. </exception>
        /// <exception cref="T:System.IO.IOException">An I/O error occurs. </exception>
        /// <filterpriority>1</filterpriority>
        void Write(char[] buffer, int index, int count);

        /// <summary>Writes the text representation of a decimal value to the text string or stream.</summary>
        /// <param name="value">The decimal value to write. </param>
        /// <exception cref="T:System.ObjectDisposedException">The <see cref="T:System.IO.TextWriter" /> is closed. </exception>
        /// <exception cref="T:System.IO.IOException">An I/O error occurs. </exception>
        /// <filterpriority>1</filterpriority>
        void Write(decimal value);

        /// <summary>Writes the text representation of an 8-byte floating-point value to the text string or stream.</summary>
        /// <param name="value">The 8-byte floating-point value to write. </param>
        /// <exception cref="T:System.ObjectDisposedException">The <see cref="T:System.IO.TextWriter" /> is closed. </exception>
        /// <exception cref="T:System.IO.IOException">An I/O error occurs. </exception>
        /// <filterpriority>1</filterpriority>
        void Write(double value);

        /// <summary>Writes the text representation of a 4-byte signed integer to the text string or stream.</summary>
        /// <param name="value">The 4-byte signed integer to write. </param>
        /// <exception cref="T:System.ObjectDisposedException">The <see cref="T:System.IO.TextWriter" /> is closed. </exception>
        /// <exception cref="T:System.IO.IOException">An I/O error occurs. </exception>
        /// <filterpriority>1</filterpriority>
        void Write(int value);

        /// <summary>Writes the text representation of an 8-byte signed integer to the text string or stream.</summary>
        /// <param name="value">The 8-byte signed integer to write. </param>
        /// <exception cref="T:System.ObjectDisposedException">The <see cref="T:System.IO.TextWriter" /> is closed. </exception>
        /// <exception cref="T:System.IO.IOException">An I/O error occurs. </exception>
        /// <filterpriority>1</filterpriority>
        void Write(long value);

        /// <summary>
        ///     Writes the text representation of an object to the text string or stream by calling the ToString method on
        ///     that object.
        /// </summary>
        /// <param name="value">The object to write. </param>
        /// <exception cref="T:System.ObjectDisposedException">The <see cref="T:System.IO.TextWriter" /> is closed. </exception>
        /// <exception cref="T:System.IO.IOException">An I/O error occurs. </exception>
        /// <filterpriority>1</filterpriority>
        void Write(object value);

        /// <summary>Writes the text representation of a 4-byte floating-point value to the text string or stream.</summary>
        /// <param name="value">The 4-byte floating-point value to write. </param>
        /// <exception cref="T:System.ObjectDisposedException">The <see cref="T:System.IO.TextWriter" /> is closed. </exception>
        /// <exception cref="T:System.IO.IOException">An I/O error occurs. </exception>
        /// <filterpriority>1</filterpriority>
        void Write(float value);

        /// <summary>Writes a string to the text string or stream.</summary>
        /// <param name="value">The string to write. </param>
        /// <exception cref="T:System.ObjectDisposedException">The <see cref="T:System.IO.TextWriter" /> is closed. </exception>
        /// <exception cref="T:System.IO.IOException">An I/O error occurs. </exception>
        /// <filterpriority>1</filterpriority>
        void Write(string value);

        /// <summary>
        ///     Writes a formatted string to the text string or stream, using the same semantics as the
        ///     <see cref="M:System.String.Format(System.String,System.Object)" /> method.
        /// </summary>
        /// <param name="format">A composite format string (see Remarks). </param>
        /// <param name="arg0">The object to format and write. </param>
        /// <exception cref="T:System.ArgumentNullException">
        ///     <paramref name="format" /> is null.
        /// </exception>
        /// <exception cref="T:System.ObjectDisposedException">The <see cref="T:System.IO.TextWriter" /> is closed. </exception>
        /// <exception cref="T:System.IO.IOException">An I/O error occurs. </exception>
        /// <exception cref="T:System.FormatException">
        ///     <paramref name="format" /> is not a valid composite format string.-or- The index of a format item is less than 0
        ///     (zero), or greater than or equal to the number of objects to be formatted (which, for this method overload, is
        ///     one).
        /// </exception>
        /// <filterpriority>1</filterpriority>
        void Write(string format, object arg0);

        /// <summary>
        ///     Writes a formatted string to the text string or stream, using the same semantics as the
        ///     <see cref="M:System.String.Format(System.String,System.Object,System.Object)" /> method.
        /// </summary>
        /// <param name="format">A composite format string (see Remarks). </param>
        /// <param name="arg0">The first object to format and write. </param>
        /// <param name="arg1">The second object to format and write. </param>
        /// <exception cref="T:System.ArgumentNullException">
        ///     <paramref name="format" /> is null.
        /// </exception>
        /// <exception cref="T:System.ObjectDisposedException">The <see cref="T:System.IO.TextWriter" /> is closed. </exception>
        /// <exception cref="T:System.IO.IOException">An I/O error occurs. </exception>
        /// <exception cref="T:System.FormatException">
        ///     <paramref name="format" /> is not a valid composite format string.-or- The index of a format item is less than 0
        ///     (zero) or greater than or equal to the number of objects to be formatted (which, for this method overload, is two).
        /// </exception>
        /// <filterpriority>1</filterpriority>
        void Write(string format, object arg0, object arg1);

        /// <summary>
        ///     Writes a formatted string to the text string or stream, using the same semantics as the
        ///     <see cref="M:System.String.Format(System.String,System.Object,System.Object,System.Object)" /> method.
        /// </summary>
        /// <param name="format">A composite format string (see Remarks). </param>
        /// <param name="arg0">The first object to format and write. </param>
        /// <param name="arg1">The second object to format and write. </param>
        /// <param name="arg2">The third object to format and write. </param>
        /// <exception cref="T:System.ArgumentNullException">
        ///     <paramref name="format" /> is null.
        /// </exception>
        /// <exception cref="T:System.ObjectDisposedException">The <see cref="T:System.IO.TextWriter" /> is closed. </exception>
        /// <exception cref="T:System.IO.IOException">An I/O error occurs. </exception>
        /// <exception cref="T:System.FormatException">
        ///     <paramref name="format" /> is not a valid composite format string.-or- The index of a format item is less than 0
        ///     (zero), or greater than or equal to the number of objects to be formatted (which, for this method overload, is
        ///     three).
        /// </exception>
        /// <filterpriority>1</filterpriority>
        void Write(string format, object arg0, object arg1, object arg2);

        /// <summary>
        ///     Writes a formatted string to the text string or stream, using the same semantics as the
        ///     <see cref="M:System.String.Format(System.String,System.Object[])" /> method.
        /// </summary>
        /// <param name="format">A composite format string (see Remarks). </param>
        /// <param name="arg">An object array that contains zero or more objects to format and write. </param>
        /// <exception cref="T:System.ArgumentNullException">
        ///     <paramref name="format" /> or <paramref name="arg" /> is null.
        /// </exception>
        /// <exception cref="T:System.ObjectDisposedException">The <see cref="T:System.IO.TextWriter" /> is closed. </exception>
        /// <exception cref="T:System.IO.IOException">An I/O error occurs. </exception>
        /// <exception cref="T:System.FormatException">
        ///     <paramref name="format" /> is not a valid composite format string.-or- The index of a format item is less than 0
        ///     (zero), or greater than or equal to the length of the <paramref name="arg" /> array.
        /// </exception>
        /// <filterpriority>1</filterpriority>
        void Write(string format, params object[] arg);

        /// <summary>Writes a line terminator to the text string or stream.</summary>
        /// <exception cref="T:System.ObjectDisposedException">The <see cref="T:System.IO.TextWriter" /> is closed. </exception>
        /// <exception cref="T:System.IO.IOException">An I/O error occurs. </exception>
        /// <filterpriority>1</filterpriority>
        void WriteLine();

        /// <summary>Writes the text representation of a Boolean value followed by a line terminator to the text string or stream.</summary>
        /// <param name="value">The Boolean value to write. </param>
        /// <exception cref="T:System.ObjectDisposedException">The <see cref="T:System.IO.TextWriter" /> is closed. </exception>
        /// <exception cref="T:System.IO.IOException">An I/O error occurs. </exception>
        /// <filterpriority>1</filterpriority>
        void WriteLine(bool value);

        /// <summary>Writes a character followed by a line terminator to the text string or stream.</summary>
        /// <param name="value">The character to write to the text stream. </param>
        /// <exception cref="T:System.ObjectDisposedException">The <see cref="T:System.IO.TextWriter" /> is closed. </exception>
        /// <exception cref="T:System.IO.IOException">An I/O error occurs. </exception>
        /// <filterpriority>1</filterpriority>
        void WriteLine(char value);

        /// <summary>Writes an array of characters followed by a line terminator to the text string or stream.</summary>
        /// <param name="buffer">The character array from which data is read. </param>
        /// <exception cref="T:System.ObjectDisposedException">The <see cref="T:System.IO.TextWriter" /> is closed. </exception>
        /// <exception cref="T:System.IO.IOException">An I/O error occurs. </exception>
        /// <filterpriority>1</filterpriority>
        void WriteLine(char[] buffer);

        /// <summary>Writes a subarray of characters followed by a line terminator to the text string or stream.</summary>
        /// <param name="buffer">The character array from which data is read. </param>
        /// <param name="index">The character position in <paramref name="buffer" /> at which to start reading data. </param>
        /// <param name="count">The maximum number of characters to write. </param>
        /// <exception cref="T:System.ArgumentException">
        ///     The buffer length minus <paramref name="index" /> is less than
        ///     <paramref name="count" />.
        /// </exception>
        /// <exception cref="T:System.ArgumentNullException">The <paramref name="buffer" /> parameter is null. </exception>
        /// <exception cref="T:System.ArgumentOutOfRangeException">
        ///     <paramref name="index" /> or <paramref name="count" /> is negative.
        /// </exception>
        /// <exception cref="T:System.ObjectDisposedException">The <see cref="T:System.IO.TextWriter" /> is closed. </exception>
        /// <exception cref="T:System.IO.IOException">An I/O error occurs. </exception>
        /// <filterpriority>1</filterpriority>
        void WriteLine(char[] buffer, int index, int count);

        /// <summary>Writes the text representation of a decimal value followed by a line terminator to the text string or stream.</summary>
        /// <param name="value">The decimal value to write. </param>
        /// <exception cref="T:System.ObjectDisposedException">The <see cref="T:System.IO.TextWriter" /> is closed. </exception>
        /// <exception cref="T:System.IO.IOException">An I/O error occurs. </exception>
        /// <filterpriority>1</filterpriority>
        void WriteLine(decimal value);

        /// <summary>
        ///     Writes the text representation of a 8-byte floating-point value followed by a line terminator to the text
        ///     string or stream.
        /// </summary>
        /// <param name="value">The 8-byte floating-point value to write. </param>
        /// <exception cref="T:System.ObjectDisposedException">The <see cref="T:System.IO.TextWriter" /> is closed. </exception>
        /// <exception cref="T:System.IO.IOException">An I/O error occurs. </exception>
        /// <filterpriority>1</filterpriority>
        void WriteLine(double value);

        /// <summary>
        ///     Writes the text representation of a 4-byte signed integer followed by a line terminator to the text string or
        ///     stream.
        /// </summary>
        /// <param name="value">The 4-byte signed integer to write. </param>
        /// <exception cref="T:System.ObjectDisposedException">The <see cref="T:System.IO.TextWriter" /> is closed. </exception>
        /// <exception cref="T:System.IO.IOException">An I/O error occurs. </exception>
        /// <filterpriority>1</filterpriority>
        void WriteLine(int value);

        /// <summary>
        ///     Writes the text representation of an 8-byte signed integer followed by a line terminator to the text string or
        ///     stream.
        /// </summary>
        /// <param name="value">The 8-byte signed integer to write. </param>
        /// <exception cref="T:System.ObjectDisposedException">The <see cref="T:System.IO.TextWriter" /> is closed. </exception>
        /// <exception cref="T:System.IO.IOException">An I/O error occurs. </exception>
        /// <filterpriority>1</filterpriority>
        void WriteLine(long value);

        /// <summary>
        ///     Writes the text representation of an object by calling the ToString method on that object, followed by a line
        ///     terminator to the text string or stream.
        /// </summary>
        /// <param name="value">The object to write. If <paramref name="value" /> is null, only the line terminator is written. </param>
        /// <exception cref="T:System.ObjectDisposedException">The <see cref="T:System.IO.TextWriter" /> is closed. </exception>
        /// <exception cref="T:System.IO.IOException">An I/O error occurs. </exception>
        /// <filterpriority>1</filterpriority>
        void WriteLine(object value);

        /// <summary>
        ///     Writes the text representation of a 4-byte floating-point value followed by a line terminator to the text
        ///     string or stream.
        /// </summary>
        /// <param name="value">The 4-byte floating-point value to write. </param>
        /// <exception cref="T:System.ObjectDisposedException">The <see cref="T:System.IO.TextWriter" /> is closed. </exception>
        /// <exception cref="T:System.IO.IOException">An I/O error occurs. </exception>
        /// <filterpriority>1</filterpriority>
        void WriteLine(float value);

        /// <summary>Writes a string followed by a line terminator to the text string or stream.</summary>
        /// <param name="value">The string to write. If <paramref name="value" /> is null, only the line terminator is written. </param>
        /// <exception cref="T:System.ObjectDisposedException">The <see cref="T:System.IO.TextWriter" /> is closed. </exception>
        /// <exception cref="T:System.IO.IOException">An I/O error occurs. </exception>
        /// <filterpriority>1</filterpriority>
        void WriteLine(string value);

        /// <summary>
        ///     Writes a formatted string and a new line to the text string or stream, using the same semantics as the
        ///     <see cref="M:System.String.Format(System.String,System.Object)" /> method.
        /// </summary>
        /// <param name="format">A composite format string (see Remarks).</param>
        /// <param name="arg0">The object to format and write. </param>
        /// <exception cref="T:System.ArgumentNullException">
        ///     <paramref name="format" /> is null.
        /// </exception>
        /// <exception cref="T:System.ObjectDisposedException">The <see cref="T:System.IO.TextWriter" /> is closed. </exception>
        /// <exception cref="T:System.IO.IOException">An I/O error occurs. </exception>
        /// <exception cref="T:System.FormatException">
        ///     <paramref name="format" /> is not a valid composite format string.-or- The index of a format item is less than 0
        ///     (zero), or greater than or equal to the number of objects to be formatted (which, for this method overload, is
        ///     one).
        /// </exception>
        /// <filterpriority>1</filterpriority>
        void WriteLine(string format, object arg0);

        /// <summary>
        ///     Writes a formatted string and a new line to the text string or stream, using the same semantics as the
        ///     <see cref="M:System.String.Format(System.String,System.Object,System.Object)" /> method.
        /// </summary>
        /// <param name="format">A composite format string (see Remarks).</param>
        /// <param name="arg0">The first object to format and write. </param>
        /// <param name="arg1">The second object to format and write. </param>
        /// <exception cref="T:System.ArgumentNullException">
        ///     <paramref name="format" /> is null.
        /// </exception>
        /// <exception cref="T:System.ObjectDisposedException">The <see cref="T:System.IO.TextWriter" /> is closed. </exception>
        /// <exception cref="T:System.IO.IOException">An I/O error occurs. </exception>
        /// <exception cref="T:System.FormatException">
        ///     <paramref name="format" /> is not a valid composite format string.-or- The index of a format item is less than 0
        ///     (zero), or greater than or equal to the number of objects to be formatted (which, for this method overload, is
        ///     two).
        /// </exception>
        /// <filterpriority>1</filterpriority>
        void WriteLine(string format, object arg0, object arg1);

        /// <summary>
        ///     Writes out a formatted string and a new line, using the same semantics as
        ///     <see cref="M:System.String.Format(System.String,System.Object)" />.
        /// </summary>
        /// <param name="format">A composite format string (see Remarks).</param>
        /// <param name="arg0">The first object to format and write. </param>
        /// <param name="arg1">The second object to format and write. </param>
        /// <param name="arg2">The third object to format and write. </param>
        /// <exception cref="T:System.ArgumentNullException">
        ///     <paramref name="format" /> is null.
        /// </exception>
        /// <exception cref="T:System.ObjectDisposedException">The <see cref="T:System.IO.TextWriter" /> is closed. </exception>
        /// <exception cref="T:System.IO.IOException">An I/O error occurs. </exception>
        /// <exception cref="T:System.FormatException">
        ///     <paramref name="format" /> is not a valid composite format string.-or- The index of a format item is less than 0
        ///     (zero), or greater than or equal to the number of objects to be formatted (which, for this method overload, is
        ///     three).
        /// </exception>
        /// <filterpriority>1</filterpriority>
        void WriteLine(string format, object arg0, object arg1, object arg2);

        /// <summary>
        ///     Writes out a formatted string and a new line, using the same semantics as
        ///     <see cref="M:System.String.Format(System.String,System.Object)" />.
        /// </summary>
        /// <param name="format">A composite format string (see Remarks).</param>
        /// <param name="arg">An object array that contains zero or more objects to format and write. </param>
        /// <exception cref="T:System.ArgumentNullException">A string or object is passed in as null. </exception>
        /// <exception cref="T:System.ObjectDisposedException">The <see cref="T:System.IO.TextWriter" /> is closed. </exception>
        /// <exception cref="T:System.IO.IOException">An I/O error occurs. </exception>
        /// <exception cref="T:System.FormatException">
        ///     <paramref name="format" /> is not a valid composite format string.-or- The index of a format item is less than 0
        ///     (zero), or greater than or equal to the length of the <paramref name="arg" /> array.
        /// </exception>
        /// <filterpriority>1</filterpriority>
        void WriteLine(string format, params object[] arg);

#if (!NET40)

        /// <summary>
        ///     Asynchronously clears all buffers for the current writer and causes any buffered data to be written to the
        ///     underlying device.
        /// </summary>
        /// <returns>A task that represents the asynchronous flush operation. </returns>
        /// <exception cref="T:System.ObjectDisposedException">The text writer is disposed.</exception>
        /// <exception cref="T:System.InvalidOperationException">The writer is currently in use by a previous write operation. </exception>
        Task FlushAsync();


        /// <summary>Writes a character to the text string or stream asynchronously.</summary>
        /// <returns>A task that represents the asynchronous write operation.</returns>
        /// <param name="value">The character to write to the text stream.</param>
        /// <exception cref="T:System.ObjectDisposedException">The text writer is disposed.</exception>
        /// <exception cref="T:System.InvalidOperationException">The text writer is currently in use by a previous write operation. </exception>
        Task WriteAsync(char value);

        /// <summary>Writes a character array to the text string or stream asynchronously.</summary>
        /// <returns>A task that represents the asynchronous write operation.</returns>
        /// <param name="buffer">
        ///     The character array to write to the text stream. If <paramref name="buffer" /> is null, nothing is
        ///     written.
        /// </param>
        /// <exception cref="T:System.ObjectDisposedException">The text writer is disposed.</exception>
        /// <exception cref="T:System.InvalidOperationException">The text writer is currently in use by a previous write operation. </exception>
        Task WriteAsync(char[] buffer);

        /// <summary>Writes a subarray of characters to the text string or stream asynchronously. </summary>
        /// <returns>A task that represents the asynchronous write operation.</returns>
        /// <param name="buffer">The character array to write data from. </param>
        /// <param name="index">The character position in the buffer at which to start retrieving data. </param>
        /// <param name="count">The number of characters to write. </param>
        /// <exception cref="T:System.ArgumentNullException">
        ///     <paramref name="buffer" /> is null.
        /// </exception>
        /// <exception cref="T:System.ArgumentException">
        ///     The <paramref name="index" /> plus <paramref name="count" /> is greater
        ///     than the buffer length.
        /// </exception>
        /// <exception cref="T:System.ArgumentOutOfRangeException">
        ///     <paramref name="index" /> or <paramref name="count" /> is negative.
        /// </exception>
        /// <exception cref="T:System.ObjectDisposedException">The text writer is disposed.</exception>
        /// <exception cref="T:System.InvalidOperationException">The text writer is currently in use by a previous write operation. </exception>
        Task WriteAsync(char[] buffer, int index, int count);

        /// <summary>Writes a string to the text string or stream asynchronously.</summary>
        /// <returns>A task that represents the asynchronous write operation. </returns>
        /// <param name="value">The string to write. If <paramref name="value" /> is null, nothing is written to the text stream.</param>
        /// <exception cref="T:System.ObjectDisposedException">The text writer is disposed.</exception>
        /// <exception cref="T:System.InvalidOperationException">The text writer is currently in use by a previous write operation. </exception>
        Task WriteAsync(string value);

        /// <summary>Writes a line terminator asynchronously to the text string or stream.</summary>
        /// <returns>A task that represents the asynchronous write operation. </returns>
        /// <exception cref="T:System.ObjectDisposedException">The text writer is disposed.</exception>
        /// <exception cref="T:System.InvalidOperationException">The text writer is currently in use by a previous write operation. </exception>
        Task WriteLineAsync();

        /// <summary>Writes a character followed by a line terminator asynchronously to the text string or stream.</summary>
        /// <returns>A task that represents the asynchronous write operation.</returns>
        /// <param name="value">The character to write to the text stream.</param>
        /// <exception cref="T:System.ObjectDisposedException">The text writer is disposed.</exception>
        /// <exception cref="T:System.InvalidOperationException">The text writer is currently in use by a previous write operation. </exception>
        Task WriteLineAsync(char value);

        /// <summary>Writes an array of characters followed by a line terminator asynchronously to the text string or stream.</summary>
        /// <returns>A task that represents the asynchronous write operation.</returns>
        /// <param name="buffer">
        ///     The character array to write to the text stream. If the character array is null, only the line
        ///     terminator is written.
        /// </param>
        /// <exception cref="T:System.ObjectDisposedException">The text writer is disposed.</exception>
        /// <exception cref="T:System.InvalidOperationException">The text writer is currently in use by a previous write operation. </exception>
        Task WriteLineAsync(char[] buffer);

        /// <summary>Writes a subarray of characters followed by a line terminator asynchronously to the text string or stream.</summary>
        /// <returns>A task that represents the asynchronous write operation.</returns>
        /// <param name="buffer">The character array to write data from. </param>
        /// <param name="index">The character position in the buffer at which to start retrieving data. </param>
        /// <param name="count">The number of characters to write. </param>
        /// <exception cref="T:System.ArgumentNullException">
        ///     <paramref name="buffer" /> is null.
        /// </exception>
        /// <exception cref="T:System.ArgumentException">
        ///     The <paramref name="index" /> plus <paramref name="count" /> is greater
        ///     than the buffer length.
        /// </exception>
        /// <exception cref="T:System.ArgumentOutOfRangeException">
        ///     <paramref name="index" /> or <paramref name="count" /> is negative.
        /// </exception>
        /// <exception cref="T:System.ObjectDisposedException">The text writer is disposed.</exception>
        /// <exception cref="T:System.InvalidOperationException">The text writer is currently in use by a previous write operation. </exception>
        Task WriteLineAsync(char[] buffer, int index, int count);

        /// <summary>Writes a string followed by a line terminator asynchronously to the text string or stream. </summary>
        /// <returns>A task that represents the asynchronous write operation.</returns>
        /// <param name="value">The string to write. If the value is null, only a line terminator is written. </param>
        /// <exception cref="T:System.ObjectDisposedException">The text writer is disposed.</exception>
        /// <exception cref="T:System.InvalidOperationException">The text writer is currently in use by a previous write operation. </exception>
        Task WriteLineAsync(string value);

#endif

    }
}