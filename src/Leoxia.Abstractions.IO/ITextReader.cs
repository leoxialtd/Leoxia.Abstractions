#region Copyright (c) 2017 Leoxia Ltd

// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ITextReader.cs" company="Leoxia Ltd">
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
using System.Threading.Tasks;

#endregion

namespace Leoxia.Abstractions.IO
{
    /// <summary>Represents a reader that can read a sequential series of characters.</summary>
    /// <filterpriority>2</filterpriority>
    public interface ITextReader : IDisposable
    {
        /// <summary>
        ///     Reads the next character without changing the state of the reader or the character source. Returns the next
        ///     available character without actually reading it from the reader.
        /// </summary>
        /// <returns>
        ///     An integer representing the next character to be read, or -1 if no more characters are available or the reader
        ///     does not support seeking.
        /// </returns>
        /// <exception cref="T:System.ObjectDisposedException">The <see cref="T:System.IO.TextReader" /> is closed. </exception>
        /// <exception cref="T:System.IO.IOException">An I/O error occurs. </exception>
        /// <filterpriority>1</filterpriority>
        int Peek();

        /// <summary>Reads the next character from the text reader and advances the character position by one character.</summary>
        /// <returns>
        ///     The next character from the text reader, or -1 if no more characters are available. The default implementation
        ///     returns -1.
        /// </returns>
        /// <exception cref="T:System.ObjectDisposedException">The <see cref="T:System.IO.TextReader" /> is closed. </exception>
        /// <exception cref="T:System.IO.IOException">An I/O error occurs. </exception>
        /// <filterpriority>1</filterpriority>
        int Read();

        /// <summary>
        ///     Reads a specified maximum number of characters from the current reader and writes the data to a buffer,
        ///     beginning at the specified index.
        /// </summary>
        /// <returns>
        ///     The number of characters that have been read. The number will be less than or equal to
        ///     <paramref name="count" />, depending on whether the data is available within the reader. This method returns 0
        ///     (zero) if it is called when no more characters are left to read.
        /// </returns>
        /// <param name="buffer">
        ///     When this method returns, contains the specified character array with the values between
        ///     <paramref name="index" /> and (<paramref name="index" /> + <paramref name="count" /> - 1) replaced by the
        ///     characters read from the current source.
        /// </param>
        /// <param name="index">The position in <paramref name="buffer" /> at which to begin writing. </param>
        /// <param name="count">
        ///     The maximum number of characters to read. If the end of the reader is reached before the specified
        ///     number of characters is read into the buffer, the method returns.
        /// </param>
        /// <exception cref="T:System.ArgumentNullException">
        ///     <paramref name="buffer" /> is null.
        /// </exception>
        /// <exception cref="T:System.ArgumentException">
        ///     The buffer length minus <paramref name="index" /> is less than
        ///     <paramref name="count" />.
        /// </exception>
        /// <exception cref="T:System.ArgumentOutOfRangeException">
        ///     <paramref name="index" /> or <paramref name="count" /> is negative.
        /// </exception>
        /// <exception cref="T:System.ObjectDisposedException">The <see cref="T:System.IO.TextReader" /> is closed. </exception>
        /// <exception cref="T:System.IO.IOException">An I/O error occurs. </exception>
        /// <filterpriority>1</filterpriority>
        int Read(char[] buffer, int index, int count);

#if (!NET40)

        /// <summary>
        ///     Reads a specified maximum number of characters from the current text reader asynchronously and writes the data
        ///     to a buffer, beginning at the specified index.
        /// </summary>
        /// <returns>
        ///     A task that represents the asynchronous read operation. The value of the string parameter
        ///     contains the total number of bytes read into the buffer. The result value can be less than the number of bytes
        ///     requested if the number of bytes currently available is less than the requested number, or it can be 0 (zero) if
        ///     the end of the text has been reached.
        /// </returns>
        /// <param name="buffer">
        ///     When this method returns, contains the specified character array with the values between
        ///     <paramref name="index" /> and (<paramref name="index" /> + <paramref name="count" /> - 1) replaced by the
        ///     characters read from the current source.
        /// </param>
        /// <param name="index">The position in <paramref name="buffer" /> at which to begin writing.</param>
        /// <param name="count">
        ///     The maximum number of characters to read. If the end of the text is reached before the specified
        ///     number of characters is read into the buffer, the current method returns.
        /// </param>
        /// <exception cref="T:System.ArgumentNullException">
        ///     <paramref name="buffer" /> is null.
        /// </exception>
        /// <exception cref="T:System.ArgumentOutOfRangeException">
        ///     <paramref name="index" /> or <paramref name="count" /> is negative.
        /// </exception>
        /// <exception cref="T:System.ArgumentException">
        ///     The sum of <paramref name="index" /> and <paramref name="count" /> is
        ///     larger than the buffer length.
        /// </exception>
        /// <exception cref="T:System.ObjectDisposedException">The text reader has been disposed.</exception>
        /// <exception cref="T:System.InvalidOperationException">The reader is currently in use by a previous read operation. </exception>
        Task<int> ReadAsync(char[] buffer, int index, int count);

#endif

        /// <summary>
        ///     Reads a specified maximum number of characters from the current text reader and writes the data to a buffer,
        ///     beginning at the specified index.
        /// </summary>
        /// <returns>
        ///     The number of characters that have been read. The number will be less than or equal to
        ///     <paramref name="count" />, depending on whether all input characters have been read.
        /// </returns>
        /// <param name="buffer">
        ///     When this method returns, this parameter contains the specified character array with the values
        ///     between <paramref name="index" /> and (<paramref name="index" /> + <paramref name="count" /> -1) replaced by the
        ///     characters read from the current source.
        /// </param>
        /// <param name="index">The position in <paramref name="buffer" /> at which to begin writing.</param>
        /// <param name="count">The maximum number of characters to read. </param>
        /// <exception cref="T:System.ArgumentNullException">
        ///     <paramref name="buffer" /> is null.
        /// </exception>
        /// <exception cref="T:System.ArgumentException">
        ///     The buffer length minus <paramref name="index" /> is less than
        ///     <paramref name="count" />.
        /// </exception>
        /// <exception cref="T:System.ArgumentOutOfRangeException">
        ///     <paramref name="index" /> or <paramref name="count" /> is negative.
        /// </exception>
        /// <exception cref="T:System.ObjectDisposedException">The <see cref="T:System.IO.TextReader" /> is closed. </exception>
        /// <exception cref="T:System.IO.IOException">An I/O error occurs. </exception>
        /// <filterpriority>2</filterpriority>
        int ReadBlock(char[] buffer, int index, int count);

#if (!NET40)

        /// <summary>
        ///     Reads a specified maximum number of characters from the current text reader asynchronously and writes the data
        ///     to a buffer, beginning at the specified index.
        /// </summary>
        /// <returns>
        ///     A task that represents the asynchronous read operation. The value of the string parameter
        ///     contains the total number of bytes read into the buffer. The result value can be less than the number of bytes
        ///     requested if the number of bytes currently available is less than the requested number, or it can be 0 (zero) if
        ///     the end of the text has been reached.
        /// </returns>
        /// <param name="buffer">
        ///     When this method returns, contains the specified character array with the values between
        ///     <paramref name="index" /> and (<paramref name="index" /> + <paramref name="count" /> - 1) replaced by the
        ///     characters read from the current source.
        /// </param>
        /// <param name="index">The position in <paramref name="buffer" /> at which to begin writing.</param>
        /// <param name="count">
        ///     The maximum number of characters to read. If the end of the text is reached before the specified
        ///     number of characters is read into the buffer, the current method returns.
        /// </param>
        /// <exception cref="T:System.ArgumentNullException">
        ///     <paramref name="buffer" /> is null.
        /// </exception>
        /// <exception cref="T:System.ArgumentOutOfRangeException">
        ///     <paramref name="index" /> or <paramref name="count" /> is negative.
        /// </exception>
        /// <exception cref="T:System.ArgumentException">
        ///     The sum of <paramref name="index" /> and <paramref name="count" /> is
        ///     larger than the buffer length.
        /// </exception>
        /// <exception cref="T:System.ObjectDisposedException">The text reader has been disposed.</exception>
        /// <exception cref="T:System.InvalidOperationException">The reader is currently in use by a previous read operation. </exception>
        Task<int> ReadBlockAsync(char[] buffer, int index, int count);

#endif

        /// <summary>Reads a line of characters from the text reader and returns the data as a string.</summary>
        /// <returns>The next line from the reader, or null if all characters have been read.</returns>
        /// <exception cref="T:System.IO.IOException">An I/O error occurs. </exception>
        /// <exception cref="T:System.OutOfMemoryException">
        ///     There is insufficient memory to allocate a buffer for the returned
        ///     string.
        /// </exception>
        /// <exception cref="T:System.ObjectDisposedException">The <see cref="T:System.IO.TextReader" /> is closed. </exception>
        /// <exception cref="T:System.ArgumentOutOfRangeException">
        ///     The number of characters in the next line is larger than
        ///     <see cref="F:System.Int32.MaxValue" />
        /// </exception>
        /// <filterpriority>1</filterpriority>
        string ReadLine();

#if (!NET40)

        /// <summary>Reads a line of characters asynchronously and returns the data as a string. </summary>
        /// <returns>
        ///     A task that represents the asynchronous read operation. The value of the string parameter
        ///     contains the next line from the text reader, or is null if all of the characters have been read.
        /// </returns>
        /// <exception cref="T:System.ArgumentOutOfRangeException">
        ///     The number of characters in the next line is larger than
        ///     <see cref="F:System.Int32.MaxValue" />.
        /// </exception>
        /// <exception cref="T:System.ObjectDisposedException">The text reader has been disposed.</exception>
        /// <exception cref="T:System.InvalidOperationException">The reader is currently in use by a previous read operation. </exception>
        Task<string> ReadLineAsync();

#endif

        /// <summary>Reads all characters from the current position to the end of the text reader and returns them as one string.</summary>
        /// <returns>A string that contains all characters from the current position to the end of the text reader.</returns>
        /// <exception cref="T:System.IO.IOException">An I/O error occurs. </exception>
        /// <exception cref="T:System.ObjectDisposedException">The <see cref="T:System.IO.TextReader" /> is closed. </exception>
        /// <exception cref="T:System.OutOfMemoryException">
        ///     There is insufficient memory to allocate a buffer for the returned
        ///     string.
        /// </exception>
        /// <exception cref="T:System.ArgumentOutOfRangeException">
        ///     The number of characters in the next line is larger than
        ///     <see cref="F:System.Int32.MaxValue" />
        /// </exception>
        /// <filterpriority>1</filterpriority>
        string ReadToEnd();

#if (!NET40)

        /// <summary>
        ///     Reads all characters from the current position to the end of the text reader asynchronously and returns them
        ///     as one string.
        /// </summary>
        /// <returns>
        ///     A task that represents the asynchronous read operation. The value of the string
        ///     contains a string with the characters from the current position to the end of the text reader.
        /// </returns>
        /// <exception cref="T:System.ArgumentOutOfRangeException">
        ///     The number of characters is larger than
        ///     <see cref="F:System.Int32.MaxValue" />.
        /// </exception>
        /// <exception cref="T:System.ObjectDisposedException">The text reader has been disposed.</exception>
        /// <exception cref="T:System.InvalidOperationException">The reader is currently in use by a previous read operation. </exception>
        Task<string> ReadToEndAsync();

#endif

    }
}