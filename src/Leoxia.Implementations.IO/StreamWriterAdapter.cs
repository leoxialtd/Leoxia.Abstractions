#region Copyright (c) 2017 Leoxia Ltd

// --------------------------------------------------------------------------------------------------------------------
// <copyright file="StreamWriterAdapter.cs" company="Leoxia Ltd">
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
using System.Text;
using System.Threading.Tasks;
using Leoxia.Abstractions.IO;

#endregion

namespace Leoxia.Implementations.IO
{
    /// <summary>
    ///     Adapter for <see cref="StreamWriter" /> into <see cref="IStreamWriter" />
    /// </summary>
    /// <seealso cref="Leoxia.Abstractions.IO.IStreamWriter" />
    /// <seealso cref="Leoxia.Abstractions.IO.INotClsTextWriter" />
    public class StreamWriterAdapter : IStreamWriter, INotClsTextWriter
    {
        private readonly StreamWriter _streamWriter;

        /// <summary>
        ///     Initializes a new instance of the <see cref="T:System.IO.StreamWriter" /> class for the specified stream by
        ///     using UTF-8 encoding and the default buffer size.
        /// </summary>
        /// <param name="stream">The stream to write to. </param>
        /// <exception cref="T:System.ArgumentException">
        ///     <paramref name="stream" /> is not writable.
        /// </exception>
        /// <exception cref="T:System.ArgumentNullException">
        ///     <paramref name="stream" /> is null.
        /// </exception>
        public StreamWriterAdapter(Stream stream)
        {
            _streamWriter = new StreamWriter(stream);
        }

        /// <summary>
        ///     Initializes a new instance of the <see cref="T:System.IO.StreamWriter" /> class for the specified stream by
        ///     using the specified encoding and the default buffer size.
        /// </summary>
        /// <param name="stream">The stream to write to. </param>
        /// <param name="encoding">The character encoding to use. </param>
        /// <exception cref="T:System.ArgumentNullException">
        ///     <paramref name="stream" /> or <paramref name="encoding" /> is null.
        /// </exception>
        /// <exception cref="T:System.ArgumentException">
        ///     <paramref name="stream" /> is not writable.
        /// </exception>
        public StreamWriterAdapter(Stream stream, Encoding encoding)
        {
            _streamWriter = new StreamWriter(stream, encoding);
        }

        /// <summary>
        ///     Initializes a new instance of the <see cref="T:System.IO.StreamWriter" /> class for the specified stream by
        ///     using the specified encoding and buffer size.
        /// </summary>
        /// <param name="stream">The stream to write to. </param>
        /// <param name="encoding">The character encoding to use. </param>
        /// <param name="bufferSize">The buffer size, in bytes. </param>
        /// <exception cref="T:System.ArgumentNullException">
        ///     <paramref name="stream" /> or <paramref name="encoding" /> is null.
        /// </exception>
        /// <exception cref="T:System.ArgumentOutOfRangeException">
        ///     <paramref name="bufferSize" /> is negative.
        /// </exception>
        /// <exception cref="T:System.ArgumentException">
        ///     <paramref name="stream" /> is not writable.
        /// </exception>
        public StreamWriterAdapter(Stream stream, Encoding encoding, int bufferSize)
        {
            _streamWriter = new StreamWriter(stream, encoding, bufferSize);
        }

        /// <summary>
        ///     Initializes a new instance of the <see cref="T:System.IO.StreamWriter" /> class for the specified stream by
        ///     using the specified encoding and buffer size, and optionally leaves the stream open.
        /// </summary>
        /// <param name="stream">The stream to write to.</param>
        /// <param name="encoding">The character encoding to use.</param>
        /// <param name="bufferSize">The buffer size, in bytes.</param>
        /// <param name="leaveOpen">
        ///     true to leave the stream open after the <see cref="T:System.IO.StreamWriter" /> object is
        ///     disposed; otherwise, false.
        /// </param>
        /// <exception cref="T:System.ArgumentNullException">
        ///     <paramref name="stream" /> or <paramref name="encoding" /> is null.
        /// </exception>
        /// <exception cref="T:System.ArgumentOutOfRangeException">
        ///     <paramref name="bufferSize" /> is negative.
        /// </exception>
        /// <exception cref="T:System.ArgumentException">
        ///     <paramref name="stream" /> is not writable.
        /// </exception>
        public StreamWriterAdapter(Stream stream, Encoding encoding, int bufferSize, bool leaveOpen)
        {
            _streamWriter = new StreamWriter(stream, encoding, bufferSize, leaveOpen);
        }

        /// <summary>
        ///     Initializes a new instance of the <see cref="StreamWriterAdapter" /> class.
        /// </summary>
        /// <param name="streamWriter">The stream writer.</param>
        public StreamWriterAdapter(StreamWriter streamWriter)
        {
            _streamWriter = streamWriter;
        }

        /// <summary>Writes the text representation of an 8-byte unsigned integer to the text string or stream.</summary>
        /// <param name="value">The 8-byte unsigned integer to write. </param>
        /// <exception cref="T:System.ObjectDisposedException">The <see cref="T:System.IO.TextWriter" /> is closed. </exception>
        /// <exception cref="T:System.IO.IOException">An I/O error occurs. </exception>
        public void Write(ulong value)
        {
            _streamWriter.Write(value);
        }

        /// <summary>Writes the text representation of a 4-byte unsigned integer to the text string or stream.</summary>
        /// <param name="value">The 4-byte unsigned integer to write. </param>
        /// <exception cref="T:System.ObjectDisposedException">The <see cref="T:System.IO.TextWriter" /> is closed. </exception>
        /// <exception cref="T:System.IO.IOException">An I/O error occurs. </exception>
        public void Write(uint value)
        {
            _streamWriter.Write(value);
        }

        /// <summary>
        ///     Writes the text representation of an 8-byte unsigned integer followed by a line terminator to the text string
        ///     or stream.
        /// </summary>
        /// <param name="value">The 8-byte unsigned integer to write. </param>
        /// <exception cref="T:System.ObjectDisposedException">The <see cref="T:System.IO.TextWriter" /> is closed. </exception>
        /// <exception cref="T:System.IO.IOException">An I/O error occurs. </exception>
        public void WriteLine(ulong value)
        {
            _streamWriter.WriteLine(value);
        }

        /// <summary>
        ///     Writes the text representation of a 4-byte unsigned integer followed by a line terminator to the text string
        ///     or stream.
        /// </summary>
        /// <param name="value">The 4-byte unsigned integer to write. </param>
        /// <exception cref="T:System.ObjectDisposedException">The <see cref="T:System.IO.TextWriter" /> is closed. </exception>
        /// <exception cref="T:System.IO.IOException">An I/O error occurs. </exception>
        public void WriteLine(uint value)
        {
            _streamWriter.WriteLine(value);
        }

        /// <summary>
        ///     Gets or sets a value indicating whether the <see cref="T:System.IO.StreamWriter" /> will flush its buffer to
        ///     the underlying stream after every call to <see cref="M:System.IO.StreamWriter.Write(System.Char)" />.
        /// </summary>
        /// <returns>true to force <see cref="T:System.IO.StreamWriter" /> to flush its buffer; otherwise, false.</returns>
        public bool AutoFlush
        {
            get => _streamWriter.AutoFlush;
            set => _streamWriter.AutoFlush = value;
        }

        /// <summary>Gets the underlying stream that interfaces with a backing store.</summary>
        /// <returns>The stream this StreamWriter is writing to.</returns>
        public Stream BaseStream => _streamWriter.BaseStream;

        /// <summary>Releases all resources used by the <see cref="T:System.IO.TextWriter" /> object.</summary>
        public void Dispose()
        {
            _streamWriter.Dispose();
        }

        /// <summary>Gets the <see cref="T:System.Text.Encoding" /> in which the output is written.</summary>
        /// <returns>
        ///     The <see cref="T:System.Text.Encoding" /> specified in the constructor for the current instance, or
        ///     <see cref="T:System.Text.UTF8Encoding" /> if an encoding was not specified.
        /// </returns>
        public Encoding Encoding => _streamWriter.Encoding;

        /// <summary>Clears all buffers for the current writer and causes any buffered data to be written to the underlying stream.</summary>
        /// <exception cref="T:System.ObjectDisposedException">The current writer is closed. </exception>
        /// <exception cref="T:System.IO.IOException">An I/O error has occurred. </exception>
        /// <exception cref="T:System.Text.EncoderFallbackException">
        ///     The current encoding does not support displaying half of a
        ///     Unicode surrogate pair.
        /// </exception>
        public void Flush()
        {
            _streamWriter.Flush();
        }

        /// <summary>
        ///     Clears all buffers for this stream asynchronously and causes any buffered data to be written to the underlying
        ///     device.
        /// </summary>
        /// <returns>A task that represents the asynchronous flush operation.</returns>
        /// <exception cref="T:System.ObjectDisposedException">The stream has been disposed.</exception>
        public Task FlushAsync()
        {
            return _streamWriter.FlushAsync();
        }

        /// <summary>Gets an object that controls formatting.</summary>
        /// <returns>
        ///     An <see cref="T:System.IFormatProvider" /> object for a specific culture, or the formatting of the current
        ///     culture if no other culture is specified.
        /// </returns>
        public IFormatProvider FormatProvider => _streamWriter.FormatProvider;

        /// <summary>Gets or sets the line terminator string used by the current TextWriter.</summary>
        /// <returns>The line terminator string for the current TextWriter.</returns>
        public string NewLine
        {
            get => _streamWriter.NewLine;
            set => _streamWriter.NewLine = value;
        }

        /// <summary>Writes the text representation of a 4-byte floating-point value to the text string or stream.</summary>
        /// <param name="value">The 4-byte floating-point value to write. </param>
        /// <exception cref="T:System.ObjectDisposedException">The <see cref="T:System.IO.TextWriter" /> is closed. </exception>
        /// <exception cref="T:System.IO.IOException">An I/O error occurs. </exception>
        public void Write(float value)
        {
            _streamWriter.Write(value);
        }

        /// <summary>Writes a character to the stream.</summary>
        /// <param name="value">The character to write to the stream. </param>
        /// <exception cref="T:System.IO.IOException">An I/O error occurs. </exception>
        /// <exception cref="T:System.ObjectDisposedException">
        ///     <see cref="P:System.IO.StreamWriter.AutoFlush" /> is true or the <see cref="T:System.IO.StreamWriter" /> buffer is
        ///     full, and current writer is closed.
        /// </exception>
        /// <exception cref="T:System.NotSupportedException">
        ///     <see cref="P:System.IO.StreamWriter.AutoFlush" /> is true or the <see cref="T:System.IO.StreamWriter" /> buffer is
        ///     full, and the contents of the buffer cannot be written to the underlying fixed size stream because the
        ///     <see cref="T:System.IO.StreamWriter" /> is at the end the stream.
        /// </exception>
        public void Write(char value)
        {
            _streamWriter.Write(value);
        }

        /// <summary>Writes a character array to the stream.</summary>
        /// <param name="buffer">
        ///     A character array containing the data to write. If <paramref name="buffer" /> is null, nothing is
        ///     written.
        /// </param>
        /// <exception cref="T:System.IO.IOException">An I/O error occurs. </exception>
        /// <exception cref="T:System.ObjectDisposedException">
        ///     <see cref="P:System.IO.StreamWriter.AutoFlush" /> is true or the <see cref="T:System.IO.StreamWriter" /> buffer is
        ///     full, and current writer is closed.
        /// </exception>
        /// <exception cref="T:System.NotSupportedException">
        ///     <see cref="P:System.IO.StreamWriter.AutoFlush" /> is true or the <see cref="T:System.IO.StreamWriter" /> buffer is
        ///     full, and the contents of the buffer cannot be written to the underlying fixed size stream because the
        ///     <see cref="T:System.IO.StreamWriter" /> is at the end the stream.
        /// </exception>
        public void Write(char[] buffer)
        {
            _streamWriter.Write(buffer);
        }

        /// <summary>Writes a subarray of characters to the stream.</summary>
        /// <param name="buffer">A character array that contains the data to write. </param>
        /// <param name="index">The character position in the buffer at which to start reading data. </param>
        /// <param name="count">The maximum number of characters to write. </param>
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
        /// <exception cref="T:System.IO.IOException">An I/O error occurs. </exception>
        /// <exception cref="T:System.ObjectDisposedException">
        ///     <see cref="P:System.IO.StreamWriter.AutoFlush" /> is true or the <see cref="T:System.IO.StreamWriter" /> buffer is
        ///     full, and current writer is closed.
        /// </exception>
        /// <exception cref="T:System.NotSupportedException">
        ///     <see cref="P:System.IO.StreamWriter.AutoFlush" /> is true or the <see cref="T:System.IO.StreamWriter" /> buffer is
        ///     full, and the contents of the buffer cannot be written to the underlying fixed size stream because the
        ///     <see cref="T:System.IO.StreamWriter" /> is at the end the stream.
        /// </exception>
        public void Write(char[] buffer, int index, int count)
        {
            _streamWriter.Write(buffer, index, count);
        }

        /// <summary>Writes a string to the stream.</summary>
        /// <param name="value">The string to write to the stream. If <paramref name="value" /> is null, nothing is written. </param>
        /// <exception cref="T:System.ObjectDisposedException">
        ///     <see cref="P:System.IO.StreamWriter.AutoFlush" /> is true or the <see cref="T:System.IO.StreamWriter" /> buffer is
        ///     full, and current writer is closed.
        /// </exception>
        /// <exception cref="T:System.NotSupportedException">
        ///     <see cref="P:System.IO.StreamWriter.AutoFlush" /> is true or the <see cref="T:System.IO.StreamWriter" /> buffer is
        ///     full, and the contents of the buffer cannot be written to the underlying fixed size stream because the
        ///     <see cref="T:System.IO.StreamWriter" /> is at the end the stream.
        /// </exception>
        /// <exception cref="T:System.IO.IOException">An I/O error occurs. </exception>
        public void Write(string value)
        {
            _streamWriter.Write(value);
        }

        /// <summary>Writes the text representation of a decimal value to the text string or stream.</summary>
        /// <param name="value">The decimal value to write. </param>
        /// <exception cref="T:System.ObjectDisposedException">The <see cref="T:System.IO.TextWriter" /> is closed. </exception>
        /// <exception cref="T:System.IO.IOException">An I/O error occurs. </exception>
        public void Write(decimal value)
        {
            _streamWriter.Write(value);
        }

        /// <summary>Writes the text representation of an 8-byte floating-point value to the text string or stream.</summary>
        /// <param name="value">The 8-byte floating-point value to write. </param>
        /// <exception cref="T:System.ObjectDisposedException">The <see cref="T:System.IO.TextWriter" /> is closed. </exception>
        /// <exception cref="T:System.IO.IOException">An I/O error occurs. </exception>
        public void Write(double value)
        {
            _streamWriter.Write(value);
        }

        /// <summary>Writes the text representation of a Boolean value to the text string or stream.</summary>
        /// <param name="value">The Boolean value to write. </param>
        /// <exception cref="T:System.ObjectDisposedException">The <see cref="T:System.IO.TextWriter" /> is closed. </exception>
        /// <exception cref="T:System.IO.IOException">An I/O error occurs. </exception>
        public void Write(bool value)
        {
            _streamWriter.Write(value);
        }

        /// <summary>Writes the text representation of an 8-byte signed integer to the text string or stream.</summary>
        /// <param name="value">The 8-byte signed integer to write. </param>
        /// <exception cref="T:System.ObjectDisposedException">The <see cref="T:System.IO.TextWriter" /> is closed. </exception>
        /// <exception cref="T:System.IO.IOException">An I/O error occurs. </exception>
        public void Write(long value)
        {
            _streamWriter.Write(value);
        }

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
        public void Write(string format, params object[] arg)
        {
            _streamWriter.Write(format, arg);
        }

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
        public void Write(string format, object arg0, object arg1, object arg2)
        {
            _streamWriter.Write(format, arg0, arg1, arg2);
        }

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
        public void Write(string format, object arg0, object arg1)
        {
            _streamWriter.Write(format, arg0, arg1);
        }

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
        public void Write(string format, object arg0)
        {
            _streamWriter.Write(format, arg0);
        }

        /// <summary>
        ///     Writes the text representation of an object to the text string or stream by calling the ToString method on
        ///     that object.
        /// </summary>
        /// <param name="value">The object to write. </param>
        /// <exception cref="T:System.ObjectDisposedException">The <see cref="T:System.IO.TextWriter" /> is closed. </exception>
        /// <exception cref="T:System.IO.IOException">An I/O error occurs. </exception>
        public void Write(object value)
        {
            _streamWriter.Write(value);
        }

        /// <summary>Writes the text representation of a 4-byte signed integer to the text string or stream.</summary>
        /// <param name="value">The 4-byte signed integer to write. </param>
        /// <exception cref="T:System.ObjectDisposedException">The <see cref="T:System.IO.TextWriter" /> is closed. </exception>
        /// <exception cref="T:System.IO.IOException">An I/O error occurs. </exception>
        public void Write(int value)
        {
            _streamWriter.Write(value);
        }

        /// <summary>Writes a subarray of characters to the stream asynchronously.</summary>
        /// <returns>A task that represents the asynchronous write operation.</returns>
        /// <param name="buffer">A character array that contains the data to write.</param>
        /// <param name="index">The character position in the buffer at which to begin reading data.</param>
        /// <param name="count">The maximum number of characters to write.</param>
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
        /// <exception cref="T:System.ObjectDisposedException">The stream writer is disposed.</exception>
        /// <exception cref="T:System.InvalidOperationException">
        ///     The stream writer is currently in use by a previous write
        ///     operation.
        /// </exception>
        public Task WriteAsync(char[] buffer, int index, int count)
        {
            return _streamWriter.WriteAsync(buffer, index, count);
        }

        /// <summary>Writes a string to the stream asynchronously.</summary>
        /// <returns>A task that represents the asynchronous write operation.</returns>
        /// <param name="value">The string to write to the stream. If <paramref name="value" /> is null, nothing is written.</param>
        /// <exception cref="T:System.ObjectDisposedException">The stream writer is disposed.</exception>
        /// <exception cref="T:System.InvalidOperationException">
        ///     The stream writer is currently in use by a previous write
        ///     operation.
        /// </exception>
        public Task WriteAsync(string value)
        {
            return _streamWriter.WriteAsync(value);
        }

        /// <summary>Writes a character array to the text string or stream asynchronously.</summary>
        /// <returns>A task that represents the asynchronous write operation.</returns>
        /// <param name="buffer">
        ///     The character array to write to the text stream. If <paramref name="buffer" /> is null, nothing is
        ///     written.
        /// </param>
        /// <exception cref="T:System.ObjectDisposedException">The text writer is disposed.</exception>
        /// <exception cref="T:System.InvalidOperationException">The text writer is currently in use by a previous write operation. </exception>
        public Task WriteAsync(char[] buffer)
        {
            return _streamWriter.WriteAsync(buffer);
        }

        /// <summary>Writes a character to the stream asynchronously.</summary>
        /// <returns>A task that represents the asynchronous write operation.</returns>
        /// <param name="value">The character to write to the stream.</param>
        /// <exception cref="T:System.ObjectDisposedException">The stream writer is disposed.</exception>
        /// <exception cref="T:System.InvalidOperationException">
        ///     The stream writer is currently in use by a previous write
        ///     operation.
        /// </exception>
        public Task WriteAsync(char value)
        {
            return _streamWriter.WriteAsync(value);
        }

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
        public void WriteLine(string format, object arg0)
        {
            _streamWriter.WriteLine(format, arg0);
        }

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
        public void WriteLine(string format, object arg0, object arg1, object arg2)
        {
            _streamWriter.WriteLine(format, arg0, arg1, arg2);
        }

        /// <summary>Writes a line terminator to the text string or stream.</summary>
        /// <exception cref="T:System.ObjectDisposedException">The <see cref="T:System.IO.TextWriter" /> is closed. </exception>
        /// <exception cref="T:System.IO.IOException">An I/O error occurs. </exception>
        public void WriteLine()
        {
            _streamWriter.WriteLine();
        }

        /// <summary>Writes the text representation of a Boolean value followed by a line terminator to the text string or stream.</summary>
        /// <param name="value">The Boolean value to write. </param>
        /// <exception cref="T:System.ObjectDisposedException">The <see cref="T:System.IO.TextWriter" /> is closed. </exception>
        /// <exception cref="T:System.IO.IOException">An I/O error occurs. </exception>
        public void WriteLine(bool value)
        {
            _streamWriter.WriteLine(value);
        }

        /// <summary>Writes a character followed by a line terminator to the text string or stream.</summary>
        /// <param name="value">The character to write to the text stream. </param>
        /// <exception cref="T:System.ObjectDisposedException">The <see cref="T:System.IO.TextWriter" /> is closed. </exception>
        /// <exception cref="T:System.IO.IOException">An I/O error occurs. </exception>
        public void WriteLine(char value)
        {
            _streamWriter.WriteLine(value);
        }

        /// <summary>Writes an array of characters followed by a line terminator to the text string or stream.</summary>
        /// <param name="buffer">The character array from which data is read. </param>
        /// <exception cref="T:System.ObjectDisposedException">The <see cref="T:System.IO.TextWriter" /> is closed. </exception>
        /// <exception cref="T:System.IO.IOException">An I/O error occurs. </exception>
        public void WriteLine(char[] buffer)
        {
            _streamWriter.WriteLine(buffer);
        }

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
        public void WriteLine(string format, params object[] arg)
        {
            _streamWriter.WriteLine(format, arg);
        }

        /// <summary>Writes the text representation of a decimal value followed by a line terminator to the text string or stream.</summary>
        /// <param name="value">The decimal value to write. </param>
        /// <exception cref="T:System.ObjectDisposedException">The <see cref="T:System.IO.TextWriter" /> is closed. </exception>
        /// <exception cref="T:System.IO.IOException">An I/O error occurs. </exception>
        public void WriteLine(decimal value)
        {
            _streamWriter.WriteLine(value);
        }

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
        public void WriteLine(char[] buffer, int index, int count)
        {
            _streamWriter.WriteLine(buffer, index, count);
        }

        /// <summary>
        ///     Writes the text representation of a 4-byte signed integer followed by a line terminator to the text string or
        ///     stream.
        /// </summary>
        /// <param name="value">The 4-byte signed integer to write. </param>
        /// <exception cref="T:System.ObjectDisposedException">The <see cref="T:System.IO.TextWriter" /> is closed. </exception>
        /// <exception cref="T:System.IO.IOException">An I/O error occurs. </exception>
        public void WriteLine(int value)
        {
            _streamWriter.WriteLine(value);
        }

        /// <summary>
        ///     Writes the text representation of an 8-byte signed integer followed by a line terminator to the text string or
        ///     stream.
        /// </summary>
        /// <param name="value">The 8-byte signed integer to write. </param>
        /// <exception cref="T:System.ObjectDisposedException">The <see cref="T:System.IO.TextWriter" /> is closed. </exception>
        /// <exception cref="T:System.IO.IOException">An I/O error occurs. </exception>
        public void WriteLine(long value)
        {
            _streamWriter.WriteLine(value);
        }

        /// <summary>
        ///     Writes the text representation of an object by calling the ToString method on that object, followed by a line
        ///     terminator to the text string or stream.
        /// </summary>
        /// <param name="value">The object to write. If <paramref name="value" /> is null, only the line terminator is written. </param>
        /// <exception cref="T:System.ObjectDisposedException">The <see cref="T:System.IO.TextWriter" /> is closed. </exception>
        /// <exception cref="T:System.IO.IOException">An I/O error occurs. </exception>
        public void WriteLine(object value)
        {
            _streamWriter.WriteLine(value);
        }

        /// <summary>Writes a string followed by a line terminator to the text string or stream.</summary>
        /// <param name="value">The string to write. If <paramref name="value" /> is null, only the line terminator is written. </param>
        /// <exception cref="T:System.ObjectDisposedException">The <see cref="T:System.IO.TextWriter" /> is closed. </exception>
        /// <exception cref="T:System.IO.IOException">An I/O error occurs. </exception>
        public void WriteLine(string value)
        {
            _streamWriter.WriteLine(value);
        }

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
        public void WriteLine(string format, object arg0, object arg1)
        {
            _streamWriter.WriteLine(format, arg0, arg1);
        }

        /// <summary>
        ///     Writes the text representation of a 8-byte floating-point value followed by a line terminator to the text
        ///     string or stream.
        /// </summary>
        /// <param name="value">The 8-byte floating-point value to write. </param>
        /// <exception cref="T:System.ObjectDisposedException">The <see cref="T:System.IO.TextWriter" /> is closed. </exception>
        /// <exception cref="T:System.IO.IOException">An I/O error occurs. </exception>
        public void WriteLine(double value)
        {
            _streamWriter.WriteLine(value);
        }

        /// <summary>
        ///     Writes the text representation of a 4-byte floating-point value followed by a line terminator to the text
        ///     string or stream.
        /// </summary>
        /// <param name="value">The 4-byte floating-point value to write. </param>
        /// <exception cref="T:System.ObjectDisposedException">The <see cref="T:System.IO.TextWriter" /> is closed. </exception>
        /// <exception cref="T:System.IO.IOException">An I/O error occurs. </exception>
        public void WriteLine(float value)
        {
            _streamWriter.WriteLine(value);
        }

        /// <summary>Writes a line terminator asynchronously to the stream.</summary>
        /// <returns>A task that represents the asynchronous write operation.</returns>
        /// <exception cref="T:System.ObjectDisposedException">The stream writer is disposed.</exception>
        /// <exception cref="T:System.InvalidOperationException">
        ///     The stream writer is currently in use by a previous write
        ///     operation.
        /// </exception>
        public Task WriteLineAsync()
        {
            return _streamWriter.WriteLineAsync();
        }

        /// <summary>Writes a character followed by a line terminator asynchronously to the stream.</summary>
        /// <returns>A task that represents the asynchronous write operation.</returns>
        /// <param name="value">The character to write to the stream.</param>
        /// <exception cref="T:System.ObjectDisposedException">The stream writer is disposed.</exception>
        /// <exception cref="T:System.InvalidOperationException">
        ///     The stream writer is currently in use by a previous write
        ///     operation.
        /// </exception>
        public Task WriteLineAsync(char value)
        {
            return _streamWriter.WriteLineAsync(value);
        }

        /// <summary>Writes a subarray of characters followed by a line terminator asynchronously to the stream.</summary>
        /// <returns>A task that represents the asynchronous write operation.</returns>
        /// <param name="buffer">The character array to write data from.</param>
        /// <param name="index">The character position in the buffer at which to start reading data.</param>
        /// <param name="count">The maximum number of characters to write.</param>
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
        /// <exception cref="T:System.ObjectDisposedException">The stream writer is disposed.</exception>
        /// <exception cref="T:System.InvalidOperationException">
        ///     The stream writer is currently in use by a previous write
        ///     operation.
        /// </exception>
        public Task WriteLineAsync(char[] buffer, int index, int count)
        {
            return _streamWriter.WriteLineAsync(buffer, index, count);
        }

        /// <summary>Writes a string followed by a line terminator asynchronously to the stream.</summary>
        /// <returns>A task that represents the asynchronous write operation.</returns>
        /// <param name="value">The string to write. If the value is null, only a line terminator is written. </param>
        /// <exception cref="T:System.ObjectDisposedException">The stream writer is disposed.</exception>
        /// <exception cref="T:System.InvalidOperationException">
        ///     The stream writer is currently in use by a previous write
        ///     operation.
        /// </exception>
        public Task WriteLineAsync(string value)
        {
            return _streamWriter.WriteLineAsync(value);
        }

        /// <summary>Writes an array of characters followed by a line terminator asynchronously to the text string or stream.</summary>
        /// <returns>A task that represents the asynchronous write operation.</returns>
        /// <param name="buffer">
        ///     The character array to write to the text stream. If the character array is null, only the line
        ///     terminator is written.
        /// </param>
        /// <exception cref="T:System.ObjectDisposedException">The text writer is disposed.</exception>
        /// <exception cref="T:System.InvalidOperationException">The text writer is currently in use by a previous write operation. </exception>
        public Task WriteLineAsync(char[] buffer)
        {
            return _streamWriter.WriteLineAsync(buffer);
        }
    }
}