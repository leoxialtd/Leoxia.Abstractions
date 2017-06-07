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

using System.IO;
using System.Text;
using System.Threading.Tasks;
using Leoxia.Abstractions.IO;

#endregion

namespace Leoxia.Implementations.IO
{
    /// <summary>
    ///     Adapter for <see cref="StreamReader" /> to <see cref="IStreamReader" />
    /// </summary>
    /// <seealso cref="Leoxia.Abstractions.IO.IStreamReader" />
    public class StreamReaderAdapter : IStreamReader
    {
        private readonly StreamReader _streamReader;

        /// <summary>Initializes a new instance of the <see cref="T:System.IO.StreamReader" /> class for the specified stream.</summary>
        /// <param name="stream">The stream to be read. </param>
        /// <exception cref="T:System.ArgumentException">
        ///     <paramref name="stream" /> does not support reading.
        /// </exception>
        /// <exception cref="T:System.ArgumentNullException">
        ///     <paramref name="stream" /> is null.
        /// </exception>
        public StreamReaderAdapter(Stream stream)
        {
            _streamReader = new StreamReader(stream);
        }

        /// <summary>
        ///     Initializes a new instance of the <see cref="T:System.IO.StreamReader" /> class for the specified stream, with
        ///     the specified byte order mark detection option.
        /// </summary>
        /// <param name="stream">The stream to be read. </param>
        /// <param name="detectEncodingFromByteOrderMarks">
        ///     Indicates whether to look for byte order marks at the beginning of the
        ///     file.
        /// </param>
        /// <exception cref="T:System.ArgumentException">
        ///     <paramref name="stream" /> does not support reading.
        /// </exception>
        /// <exception cref="T:System.ArgumentNullException">
        ///     <paramref name="stream" /> is null.
        /// </exception>
        public StreamReaderAdapter(Stream stream, bool detectEncodingFromByteOrderMarks)
        {
            _streamReader = new StreamReader(stream, detectEncodingFromByteOrderMarks);
        }

        /// <summary>
        ///     Initializes a new instance of the <see cref="T:System.IO.StreamReader" /> class for the specified stream, with
        ///     the specified character encoding.
        /// </summary>
        /// <param name="stream">The stream to be read. </param>
        /// <param name="encoding">The character encoding to use. </param>
        /// <exception cref="T:System.ArgumentException">
        ///     <paramref name="stream" /> does not support reading.
        /// </exception>
        /// <exception cref="T:System.ArgumentNullException">
        ///     <paramref name="stream" /> or <paramref name="encoding" /> is null.
        /// </exception>
        public StreamReaderAdapter(Stream stream, Encoding encoding)
        {
            _streamReader = new StreamReader(stream, encoding);
        }

        /// <summary>
        ///     Initializes a new instance of the <see cref="T:System.IO.StreamReader" /> class for the specified stream, with
        ///     the specified character encoding and byte order mark detection option.
        /// </summary>
        /// <param name="stream">The stream to be read. </param>
        /// <param name="encoding">The character encoding to use. </param>
        /// <param name="detectEncodingFromByteOrderMarks">
        ///     Indicates whether to look for byte order marks at the beginning of the
        ///     file.
        /// </param>
        /// <exception cref="T:System.ArgumentException">
        ///     <paramref name="stream" /> does not support reading.
        /// </exception>
        /// <exception cref="T:System.ArgumentNullException">
        ///     <paramref name="stream" /> or <paramref name="encoding" /> is null.
        /// </exception>
        public StreamReaderAdapter(Stream stream, Encoding encoding, bool detectEncodingFromByteOrderMarks)
        {
            _streamReader = new StreamReader(stream, encoding, detectEncodingFromByteOrderMarks);
        }

        /// <summary>
        ///     Initializes a new instance of the <see cref="T:System.IO.StreamReader" /> class for the specified stream, with
        ///     the specified character encoding, byte order mark detection option, and buffer size.
        /// </summary>
        /// <param name="stream">The stream to be read. </param>
        /// <param name="encoding">The character encoding to use. </param>
        /// <param name="detectEncodingFromByteOrderMarks">
        ///     Indicates whether to look for byte order marks at the beginning of the
        ///     file.
        /// </param>
        /// <param name="bufferSize">The minimum buffer size. </param>
        /// <exception cref="T:System.ArgumentException">The stream does not support reading. </exception>
        /// <exception cref="T:System.ArgumentNullException">
        ///     <paramref name="stream" /> or <paramref name="encoding" /> is null.
        /// </exception>
        /// <exception cref="T:System.ArgumentOutOfRangeException">
        ///     <paramref name="bufferSize" /> is less than or equal to zero.
        /// </exception>
        public StreamReaderAdapter(Stream stream, Encoding encoding, bool detectEncodingFromByteOrderMarks,
            int bufferSize)
        {
            _streamReader = new StreamReader(stream, encoding, detectEncodingFromByteOrderMarks, bufferSize);
        }

        /// <summary>
        ///     Initializes a new instance of the <see cref="T:System.IO.StreamReader" /> class for the specified stream based
        ///     on the specified character encoding, byte order mark detection option, and buffer size, and optionally leaves the
        ///     stream open.
        /// </summary>
        /// <param name="stream">The stream to read.</param>
        /// <param name="encoding">The character encoding to use.</param>
        /// <param name="detectEncodingFromByteOrderMarks">
        ///     true to look for byte order marks at the beginning of the file;
        ///     otherwise, false.
        /// </param>
        /// <param name="bufferSize">The minimum buffer size.</param>
        /// <param name="leaveOpen">
        ///     true to leave the stream open after the <see cref="T:System.IO.StreamReader" /> object is
        ///     disposed; otherwise, false.
        /// </param>
        public StreamReaderAdapter(Stream stream, Encoding encoding, bool detectEncodingFromByteOrderMarks,
            int bufferSize, bool leaveOpen)
        {
            _streamReader = new StreamReader(stream, encoding, detectEncodingFromByteOrderMarks, bufferSize, leaveOpen);
        }

        /// <summary>
        ///     Initializes a new instance of the <see cref="StreamReaderAdapter" /> class.
        /// </summary>
        /// <param name="streamReader">The stream reader.</param>
        public StreamReaderAdapter(StreamReader streamReader)
        {
            _streamReader = streamReader;
        }

        /// <summary>Returns the underlying stream.</summary>
        /// <returns>The underlying stream.</returns>
        public Stream BaseStream => _streamReader.BaseStream;

        /// <summary>Gets the current character encoding that the current <see cref="T:System.IO.StreamReader" /> object is using.</summary>
        /// <returns>
        ///     The current character encoding used by the current reader. The value can be different after the first call to
        ///     any <see cref="System.IO.StreamReader.Read()" /> method of <see cref="T:System.IO.StreamReader" />, since encoding
        ///     autodetection is not done until the first call to a <see cref="System.IO.StreamReader.Read()" /> method.
        /// </returns>
        public Encoding CurrentEncoding => _streamReader.CurrentEncoding;

        /// <summary>Clears the internal buffer.</summary>
        public void DiscardBufferedData()
        {
            _streamReader.DiscardBufferedData();
        }

        /// <summary>Releases all resources used by the <see cref="T:System.IO.TextReader" /> object.</summary>
        public void Dispose()
        {
            _streamReader.Dispose();
        }

        /// <summary>Gets a value that indicates whether the current stream position is at the end of the stream.</summary>
        /// <returns>true if the current stream position is at the end of the stream; otherwise false.</returns>
        /// <exception cref="T:System.ObjectDisposedException">The underlying stream has been disposed.</exception>
        public bool EndOfStream => _streamReader.EndOfStream;

        /// <summary>Returns the next available character but does not consume it.</summary>
        /// <returns>
        ///     An integer representing the next character to be read, or -1 if there are no characters to be read or if the
        ///     stream does not support seeking.
        /// </returns>
        /// <exception cref="T:System.IO.IOException">An I/O error occurs. </exception>
        public int Peek()
        {
            return _streamReader.Peek();
        }

        /// <summary>Reads the next character from the input stream and advances the character position by one character.</summary>
        /// <returns>
        ///     The next character from the input stream represented as an <see cref="T:System.Int32" /> object, or -1 if no
        ///     more characters are available.
        /// </returns>
        /// <exception cref="T:System.IO.IOException">An I/O error occurs. </exception>
        public int Read()
        {
            return _streamReader.Read();
        }

        /// <summary>
        ///     Reads a specified maximum of characters from the current stream into a buffer, beginning at the specified
        ///     index.
        /// </summary>
        /// <returns>
        ///     The number of characters that have been read, or 0 if at the end of the stream and no data was read. The
        ///     number will be less than or equal to the <paramref name="count" /> parameter, depending on whether the data is
        ///     available within the stream.
        /// </returns>
        /// <param name="buffer">
        ///     When this method returns, contains the specified character array with the values between
        ///     <paramref name="index" /> and (index + count - 1) replaced by the characters read from the current source.
        /// </param>
        /// <param name="index">The index of <paramref name="buffer" /> at which to begin writing. </param>
        /// <param name="count">The maximum number of characters to read. </param>
        /// <exception cref="T:System.ArgumentException">
        ///     The buffer length minus <paramref name="index" /> is less than
        ///     <paramref name="count" />.
        /// </exception>
        /// <exception cref="T:System.ArgumentNullException">
        ///     <paramref name="buffer" /> is null.
        /// </exception>
        /// <exception cref="T:System.ArgumentOutOfRangeException">
        ///     <paramref name="index" /> or <paramref name="count" /> is negative.
        /// </exception>
        /// <exception cref="T:System.IO.IOException">An I/O error occurs, such as the stream is closed. </exception>
        public int Read(char[] buffer, int index, int count)
        {
            return _streamReader.Read(buffer, index, count);
        }

        /// <summary>
        ///     Reads a specified maximum number of characters from the current stream asynchronously and writes the data to a
        ///     buffer, beginning at the specified index.
        /// </summary>
        /// <returns>
        ///     A task that represents the asynchronous read operation. The value of the Task.Result parameter contains the
        ///     total number of bytes read into the buffer. The result value can be less than the number of bytes requested if the
        ///     number of bytes currently available is less than the requested number, or it can be 0 (zero) if the end of the
        ///     stream has been reached.
        /// </returns>
        /// <param name="buffer">
        ///     When this method returns, contains the specified character array with the values between
        ///     <paramref name="index" /> and (<paramref name="index" /> + <paramref name="count" /> - 1) replaced by the
        ///     characters read from the current source.
        /// </param>
        /// <param name="index">The position in <paramref name="buffer" /> at which to begin writing.</param>
        /// <param name="count">
        ///     The maximum number of characters to read. If the end of the stream is reached before the specified
        ///     number of characters is written into the buffer, the current method returns.
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
        /// <exception cref="T:System.ObjectDisposedException">The stream has been disposed.</exception>
        /// <exception cref="T:System.InvalidOperationException">The reader is currently in use by a previous read operation. </exception>
        public Task<int> ReadAsync(char[] buffer, int index, int count)
        {
            return _streamReader.ReadAsync(buffer, index, count);
        }

        /// <summary>
        ///     Reads a specified maximum number of characters from the current stream and writes the data to a buffer,
        ///     beginning at the specified index.
        /// </summary>
        /// <returns>
        ///     The number of characters that have been read. The number will be less than or equal to
        ///     <paramref name="count" />, depending on whether all input characters have been read.
        /// </returns>
        /// <param name="buffer">
        ///     When this method returns, contains the specified character array with the values between
        ///     <paramref name="index" /> and (index + count - 1) replaced by the characters read from the current source.
        /// </param>
        /// <param name="index">The position in <paramref name="buffer" /> at which to begin writing.</param>
        /// <param name="count">The maximum number of characters to read.</param>
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
        /// <exception cref="T:System.ObjectDisposedException">The <see cref="T:System.IO.StreamReader" /> is closed. </exception>
        /// <exception cref="T:System.IO.IOException">An I/O error occurred. </exception>
        public int ReadBlock(char[] buffer, int index, int count)
        {
            return _streamReader.ReadBlock(buffer, index, count);
        }

        /// <summary>
        ///     Reads a specified maximum number of characters from the current stream asynchronously and writes the data to a
        ///     buffer, beginning at the specified index.
        /// </summary>
        /// <returns>
        ///     A task that represents the asynchronous read operation. The value of the Task.Result parameter contains the
        ///     total number of bytes read into the buffer. The result value can be less than the number of bytes requested if the
        ///     number of bytes currently available is less than the requested number, or it can be 0 (zero) if the end of the
        ///     stream has been reached.
        /// </returns>
        /// <param name="buffer">
        ///     When this method returns, contains the specified character array with the values between
        ///     <paramref name="index" /> and (<paramref name="index" /> + <paramref name="count" /> - 1) replaced by the
        ///     characters read from the current source.
        /// </param>
        /// <param name="index">The position in <paramref name="buffer" /> at which to begin writing.</param>
        /// <param name="count">
        ///     The maximum number of characters to read. If the end of the stream is reached before the specified
        ///     number of characters is written into the buffer, the method returns.
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
        /// <exception cref="T:System.ObjectDisposedException">The stream has been disposed.</exception>
        /// <exception cref="T:System.InvalidOperationException">The reader is currently in use by a previous read operation. </exception>
        public Task<int> ReadBlockAsync(char[] buffer, int index, int count)
        {
            return _streamReader.ReadBlockAsync(buffer, index, count);
        }

        /// <summary>Reads a line of characters from the current stream and returns the data as a string.</summary>
        /// <returns>The next line from the input stream, or null if the end of the input stream is reached.</returns>
        /// <exception cref="T:System.OutOfMemoryException">
        ///     There is insufficient memory to allocate a buffer for the returned
        ///     string.
        /// </exception>
        /// <exception cref="T:System.IO.IOException">An I/O error occurs. </exception>
        public string ReadLine()
        {
            return _streamReader.ReadLine();
        }

        /// <summary>Reads a line of characters asynchronously from the current stream and returns the data as a string.</summary>
        /// <returns>
        ///     A task that represents the asynchronous read operation. The value of the Task.Result contains the next line
        ///     from the stream, or is null if all the characters have been read.
        /// </returns>
        /// <exception cref="T:System.ArgumentOutOfRangeException">
        ///     The number of characters in the next line is larger than
        ///     <see cref="F:System.Int32.MaxValue" />.
        /// </exception>
        /// <exception cref="T:System.ObjectDisposedException">The stream has been disposed.</exception>
        /// <exception cref="T:System.InvalidOperationException">The reader is currently in use by a previous read operation. </exception>
        public Task<string> ReadLineAsync()
        {
            return _streamReader.ReadLineAsync();
        }

        /// <summary>Reads all characters from the current position to the end of the stream.</summary>
        /// <returns>
        ///     The rest of the stream as a string, from the current position to the end. If the current position is at the
        ///     end of the stream, returns an empty string ("").
        /// </returns>
        /// <exception cref="T:System.OutOfMemoryException">
        ///     There is insufficient memory to allocate a buffer for the returned
        ///     string.
        /// </exception>
        /// <exception cref="T:System.IO.IOException">An I/O error occurs. </exception>
        public string ReadToEnd()
        {
            return _streamReader.ReadToEnd();
        }

        /// <summary>
        ///     Reads all characters from the current position to the end of the stream asynchronously and returns them as one
        ///     string.
        /// </summary>
        /// <returns>
        ///     A task that represents the asynchronous read operation. The value of the Task.Result parameter contains a
        ///     string with the characters from the current position to the end of the stream.
        /// </returns>
        /// <exception cref="T:System.ArgumentOutOfRangeException">
        ///     The number of characters is larger than
        ///     <see cref="F:System.Int32.MaxValue" />.
        /// </exception>
        /// <exception cref="T:System.ObjectDisposedException">The stream has been disposed.</exception>
        /// <exception cref="T:System.InvalidOperationException">The reader is currently in use by a previous read operation. </exception>
        public Task<string> ReadToEndAsync()
        {
            return _streamReader.ReadToEndAsync();
        }
    }
}