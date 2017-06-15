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
using System.IO;
using System.Text;
using Leoxia.Abstractions.IO;

#endregion

namespace Leoxia.Implementations.IO
{
    /// <summary>
    ///     Adapter for System.Console to IConsole
    /// </summary>
    /// <seealso cref="Leoxia.Abstractions.IO.IConsole" />
    /// <seealso cref="Leoxia.Abstractions.IO.INotClsConsole" />
    public class ConsoleAdapter : IConsole, INotClsConsole
    {
        /// <summary>Gets or sets the background color of the console.</summary>
        /// <returns>
        ///     A value that specifies the background color of the console; that is, the color that appears behind each
        ///     character. The default is black.
        /// </returns>
        /// <exception cref="T:System.ArgumentException">
        ///     The color specified in a set operation is not a valid member of
        ///     <see cref="T:System.ConsoleColor" />.
        /// </exception>
        /// <exception cref="T:System.Security.SecurityException">The user does not have permission to perform this action. </exception>
        /// <exception cref="T:System.IO.IOException">An I/O error occurred. </exception>
        /// <filterpriority>1</filterpriority>
        /// <PermissionSet>
        ///     <IPermission
        ///         class="System.Security.Permissions.UIPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"
        ///         version="1" Window="SafeTopLevelWindows" />
        /// </PermissionSet>
        public ConsoleColor BackgroundColor
        {
            get => Console.BackgroundColor;
            set => Console.BackgroundColor = value;
        }

        /// <summary>
        ///     Gets or sets the height of the buffer.
        /// </summary>
        /// <value>
        ///     The height of the buffer.
        /// </value>
        public int BufferHeight
        {
            get => Console.BufferHeight;
            set => Console.BufferHeight = value;
        }

        /// <summary>
        ///     Gets or sets the width of the buffer.
        /// </summary>
        /// <value>
        ///     The width of the buffer.
        /// </value>
        public int BufferWidth
        {
            get => Console.BufferWidth;
            set => Console.BufferWidth = value;
        }

        /// <summary>
        ///     Gets a value indicating whether [caps lock].
        /// </summary>
        /// <value>
        ///     <c>true</c> if [caps lock]; otherwise, <c>false</c>.
        /// </value>
        public bool CapsLock => Console.CapsLock;

        /// <summary>
        ///     Gets or sets the cursor left.
        /// </summary>
        /// <value>
        ///     The cursor left.
        /// </value>
        public int CursorLeft
        {
            get => Console.CursorLeft;
            set => Console.CursorLeft = value;
        }

        /// <summary>
        ///     Gets or sets the size of the cursor.
        /// </summary>
        /// <value>
        ///     The size of the cursor.
        /// </value>
        public int CursorSize
        {
            get => Console.CursorSize;
            set => Console.CursorSize = value;
        }

        /// <summary>
        ///     Gets or sets the cursor top.
        /// </summary>
        /// <value>
        ///     The cursor top.
        /// </value>
        public int CursorTop
        {
            get => Console.CursorTop;
            set => Console.CursorTop = value;
        }

        /// <summary>
        ///     Gets or sets a value indicating whether [cursor visible].
        /// </summary>
        /// <value>
        ///     <c>true</c> if [cursor visible]; otherwise, <c>false</c>.
        /// </value>
        public bool CursorVisible
        {
            get => Console.CursorVisible;
            set => Console.CursorVisible = value;
        }

        /// <summary>Gets the standard error output stream.</summary>
        /// <returns>A <see cref="T:System.IO.TextWriter" /> that represents the standard error output stream.</returns>
        /// <filterpriority>1</filterpriority>
        public ITextWriter Error => new TextWriterAdapter(Console.Error);

        /// <summary>Gets or sets the foreground color of the console.</summary>
        /// <returns>
        ///     A <see cref="T:System.ConsoleColor" /> that specifies the foreground color of the console; that is, the color
        ///     of each character that is displayed. The default is gray.
        /// </returns>
        /// <exception cref="T:System.ArgumentException">
        ///     The color specified in a set operation is not a valid member of
        ///     <see cref="T:System.ConsoleColor" />.
        /// </exception>
        /// <exception cref="T:System.Security.SecurityException">The user does not have permission to perform this action. </exception>
        /// <exception cref="T:System.IO.IOException">An I/O error occurred. </exception>
        /// <filterpriority>1</filterpriority>
        /// <PermissionSet>
        ///     <IPermission
        ///         class="System.Security.Permissions.UIPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"
        ///         version="1" Window="SafeTopLevelWindows" />
        /// </PermissionSet>
        public ConsoleColor ForegroundColor
        {
            get => Console.ForegroundColor;
            set => Console.ForegroundColor = value;
        }

        /// <summary>
        ///     Gets or sets the input encoding.
        /// </summary>
        /// <value>
        ///     The input encoding.
        /// </value>
        public Encoding InputEncoding
        {
            get => Console.InputEncoding;
            set => Console.InputEncoding = value;
        }

        /// <summary>
        ///     Gets a value indicating whether this instance is error redirected.
        /// </summary>
        /// <value>
        ///     <c>true</c> if this instance is error redirected; otherwise, <c>false</c>.
        /// </value>
        public bool IsErrorRedirected => Console.IsErrorRedirected;

        /// <summary>
        ///     Gets a value indicating whether this instance is input redirected.
        /// </summary>
        /// <value>
        ///     <c>true</c> if this instance is input redirected; otherwise, <c>false</c>.
        /// </value>
        public bool IsInputRedirected => Console.IsInputRedirected;

        /// <summary>
        ///     Gets a value indicating whether this instance is output redirected.
        /// </summary>
        /// <value>
        ///     <c>true</c> if this instance is output redirected; otherwise, <c>false</c>.
        /// </value>
        public bool IsOutputRedirected => Console.IsOutputRedirected;

        /// <summary>Gets the standard input stream.</summary>
        /// <returns>A <see cref="T:System.IO.TextReader" /> that represents the standard input stream.</returns>
        /// <filterpriority>1</filterpriority>
        public ITextReader In => new TextReaderAdapter(Console.In);

        /// <summary>
        ///     Gets a value indicating whether [key available].
        /// </summary>
        /// <value>
        ///     <c>true</c> if [key available]; otherwise, <c>false</c>.
        /// </value>
        public bool KeyAvailable => Console.KeyAvailable;

        /// <summary>
        ///     Gets the width of the largest window.
        /// </summary>
        /// <value>
        ///     The width of the largest window.
        /// </value>
        public int LargestWindowWidth => Console.LargestWindowWidth;

        /// <summary>
        ///     Gets the height of the largest window.
        /// </summary>
        /// <value>
        ///     The height of the largest window.
        /// </value>
        public int LargestWindowHeight => Console.LargestWindowHeight;

        /// <summary>
        ///     Gets a value indicating whether [number lock].
        /// </summary>
        /// <value>
        ///     <c>true</c> if [number lock]; otherwise, <c>false</c>.
        /// </value>
        public bool NumberLock => Console.NumberLock;

        /// <summary>Gets the standard output stream.</summary>
        /// <returns>A <see cref="T:System.IO.TextWriter" /> that represents the standard output stream.</returns>
        /// <filterpriority>1</filterpriority>
        public ITextWriter Out => new TextWriterAdapter(Console.Out);

        /// <summary>
        ///     Gets or sets the output encoding.
        /// </summary>
        /// <value>
        ///     The output encoding.
        /// </value>
        public Encoding OutputEncoding
        {
            get => Console.OutputEncoding;
            set => Console.OutputEncoding = value;
        }

        /// <summary>
        ///     Gets or sets the title.
        /// </summary>
        /// <value>
        ///     The title.
        /// </value>
        public string Title
        {
            get => Console.Title;
            set => Console.Title = value;
        }

        /// <summary>
        ///     Gets or sets a value indicating whether [treat control c as input].
        /// </summary>
        /// <value>
        ///     <c>true</c> if [treat control c as input]; otherwise, <c>false</c>.
        /// </value>
        public bool TreatControlCAsInput
        {
            get => Console.TreatControlCAsInput;
            set => Console.TreatControlCAsInput = value;
        }

        /// <summary>
        ///     Gets or sets the height of the window.
        /// </summary>
        /// <value>
        ///     The height of the window.
        /// </value>
        public int WindowHeight
        {
            get => Console.WindowHeight;
            set => Console.WindowHeight = value;
        }

        /// <summary>
        ///     Gets or sets the width of the window.
        /// </summary>
        /// <value>
        ///     The width of the window.
        /// </value>
        public int WindowWidth
        {
            get => Console.WindowWidth;
            set => Console.WindowWidth = value;
        }

        /// <summary>
        ///     Gets or sets the window left.
        /// </summary>
        /// <value>
        ///     The window left.
        /// </value>
        public int WindowLeft
        {
            get => Console.WindowLeft;
            set => Console.WindowLeft = value;
        }

        /// <summary>
        ///     Gets or sets the window top.
        /// </summary>
        /// <value>
        ///     The window top.
        /// </value>
        public int WindowTop
        {
            get => Console.WindowTop;
            set => Console.WindowTop = value;
        }

        /// <summary>
        ///     Occurs when the <see cref="F:System.ConsoleModifiers.Control" /> modifier key (Ctrl) and either the
        ///     <see cref="F:System.ConsoleKey.C" /> console key (C) or the Break key are pressed simultaneously (Ctrl+C or
        ///     Ctrl+Break).
        /// </summary>
        public event ConsoleCancelEventHandler CancelKeyPress
        {
            add => Console.CancelKeyPress += value;
            remove => Console.CancelKeyPress -= value;
        }

        /// <summary>
        ///     Beeps this instance.
        /// </summary>
        public void Beep()
        {
            Console.Beep();
        }

        /// <summary>
        ///     Beeps the specified frequency.
        /// </summary>
        /// <param name="frequency">The frequency.</param>
        /// <param name="duration">The duration.</param>
        public void Beep(int frequency, int duration)
        {
            Console.Beep(frequency, duration);
        }

        /// <summary>
        ///     Clears this instance.
        /// </summary>
        public void Clear()
        {
            Console.Clear();
        }

        /// <summary>
        ///     Moves the buffer area.
        /// </summary>
        /// <param name="sourceLeft">The source left.</param>
        /// <param name="sourceTop">The source top.</param>
        /// <param name="sourceWidth">Width of the source.</param>
        /// <param name="sourceHeight">Height of the source.</param>
        /// <param name="targetLeft">The target left.</param>
        /// <param name="targetTop">The target top.</param>
        public void MoveBufferArea(int sourceLeft, int sourceTop, int sourceWidth, int sourceHeight, int targetLeft,
            int targetTop)
        {
            Console.MoveBufferArea(sourceLeft, sourceTop, sourceWidth, sourceHeight, targetLeft, targetTop);
        }

        /// <summary>
        ///     Moves the buffer area.
        /// </summary>
        /// <param name="sourceLeft">The source left.</param>
        /// <param name="sourceTop">The source top.</param>
        /// <param name="sourceWidth">Width of the source.</param>
        /// <param name="sourceHeight">Height of the source.</param>
        /// <param name="targetLeft">The target left.</param>
        /// <param name="targetTop">The target top.</param>
        /// <param name="sourceChar">The source character.</param>
        /// <param name="sourceForeColor">Color of the source fore.</param>
        /// <param name="sourceBackColor">Color of the source back.</param>
        public void MoveBufferArea(int sourceLeft, int sourceTop, int sourceWidth, int sourceHeight, int targetLeft,
            int targetTop,
            char sourceChar, ConsoleColor sourceForeColor, ConsoleColor sourceBackColor)
        {
            Console.MoveBufferArea(sourceLeft, sourceTop, sourceWidth, sourceHeight, targetLeft, targetTop, sourceChar,
                sourceForeColor, sourceBackColor);
        }

        /// <summary>Acquires the standard error stream.</summary>
        /// <returns>The standard error stream.</returns>
        /// <filterpriority>1</filterpriority>
        public Stream OpenStandardError()
        {
            return Console.OpenStandardError();
        }

        /// <summary>Acquires the standard input stream.</summary>
        /// <returns>The standard input stream.</returns>
        /// <filterpriority>1</filterpriority>
        public Stream OpenStandardInput()
        {
            return Console.OpenStandardInput();
        }

        /// <summary>Acquires the standard output stream.</summary>
        /// <returns>The standard output stream.</returns>
        /// <filterpriority>1</filterpriority>
        public Stream OpenStandardOutput()
        {
            return Console.OpenStandardOutput();
        }

        /// <summary>Reads the next character from the standard input stream.</summary>
        /// <returns>
        ///     The next character from the input stream, or negative one (-1) if there are currently no more characters to be
        ///     read.
        /// </returns>
        /// <exception cref="T:System.IO.IOException">An I/O error occurred. </exception>
        /// <filterpriority>1</filterpriority>
        public int Read()
        {
            return Console.Read();
        }

        /// <summary>
        ///     Reads the key.
        /// </summary>
        /// <returns></returns>
        public ConsoleKeyInfo ReadKey()
        {
            return Console.ReadKey();
        }

        /// <summary>
        ///     Reads the key.
        /// </summary>
        /// <param name="intercept">if set to <c>true</c> [intercept].</param>
        /// <returns></returns>
        public ConsoleKeyInfo ReadKey(bool intercept)
        {
            return Console.ReadKey(intercept);
        }

        /// <summary>Reads the next line of characters from the standard input stream.</summary>
        /// <returns>The next line of characters from the input stream, or null if no more lines are available.</returns>
        /// <exception cref="T:System.IO.IOException">An I/O error occurred. </exception>
        /// <exception cref="T:System.OutOfMemoryException">
        ///     There is insufficient memory to allocate a buffer for the returned
        ///     string.
        /// </exception>
        /// <exception cref="T:System.ArgumentOutOfRangeException">
        ///     The number of characters in the next line of characters is
        ///     greater than <see cref="F:System.Int32.MaxValue" />.
        /// </exception>
        /// <filterpriority>1</filterpriority>
        public string ReadLine()
        {
            return Console.ReadLine();
        }

        /// <summary>Sets the foreground and background console colors to their defaults.</summary>
        /// <exception cref="T:System.Security.SecurityException">The user does not have permission to perform this action. </exception>
        /// <exception cref="T:System.IO.IOException">An I/O error occurred. </exception>
        /// <filterpriority>1</filterpriority>
        /// <PermissionSet>
        ///     <IPermission
        ///         class="System.Security.Permissions.UIPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"
        ///         version="1" Window="SafeTopLevelWindows" />
        /// </PermissionSet>
        public void ResetColor()
        {
            Console.ResetColor();
        }

        /// <summary>
        ///     Sets the size of the buffer.
        /// </summary>
        /// <param name="width">The width.</param>
        /// <param name="height">The height.</param>
        public void SetBufferSize(int width, int height)
        {
            Console.SetBufferSize(width, height);
        }

        /// <summary>
        ///     Sets the cursor position.
        /// </summary>
        /// <param name="left">The left.</param>
        /// <param name="top">The top.</param>
        public void SetCursorPosition(int left, int top)
        {
            Console.SetCursorPosition(left, top);
        }

        /// <summary>
        ///     Sets the <see cref="P:System.Console.Error" /> property to the specified <see cref="T:System.IO.TextWriter" />
        ///     object.
        /// </summary>
        /// <param name="newError">A stream that is the new standard error output. </param>
        /// <exception cref="T:System.ArgumentNullException">
        ///     <paramref name="newError" /> is null.
        /// </exception>
        /// <exception cref="T:System.Security.SecurityException">The caller does not have the required permission. </exception>
        /// <filterpriority>1</filterpriority>
        /// <PermissionSet>
        ///     <IPermission
        ///         class="System.Security.Permissions.SecurityPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"
        ///         version="1" Flags="UnmanagedCode" />
        /// </PermissionSet>
        public void SetError(TextWriter newError)
        {
            Console.SetError(newError);
        }

        /// <summary>
        ///     Sets the <see cref="P:System.Console.In" /> property to the specified <see cref="T:System.IO.TextReader" />
        ///     object.
        /// </summary>
        /// <param name="newIn">A stream that is the new standard input. </param>
        /// <exception cref="T:System.ArgumentNullException">
        ///     <paramref name="newIn" /> is null.
        /// </exception>
        /// <exception cref="T:System.Security.SecurityException">The caller does not have the required permission. </exception>
        /// <filterpriority>1</filterpriority>
        /// <PermissionSet>
        ///     <IPermission
        ///         class="System.Security.Permissions.SecurityPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"
        ///         version="1" Flags="UnmanagedCode" />
        /// </PermissionSet>
        public void SetIn(TextReader newIn)
        {
            Console.SetIn(newIn);
        }

        /// <summary>
        ///     Sets the <see cref="P:System.Console.Out" /> property to the specified <see cref="T:System.IO.TextWriter" />
        ///     object.
        /// </summary>
        /// <param name="newOut">A stream that is the new standard output. </param>
        /// <exception cref="T:System.ArgumentNullException">
        ///     <paramref name="newOut" /> is null.
        /// </exception>
        /// <exception cref="T:System.Security.SecurityException">The caller does not have the required permission. </exception>
        /// <filterpriority>1</filterpriority>
        /// <PermissionSet>
        ///     <IPermission
        ///         class="System.Security.Permissions.SecurityPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"
        ///         version="1" Flags="UnmanagedCode" />
        /// </PermissionSet>
        public void SetOut(TextWriter newOut)
        {
            Console.SetOut(newOut);
        }

        /// <summary>
        ///     Sets the window position.
        /// </summary>
        /// <param name="left">The left.</param>
        /// <param name="top">The top.</param>
        public void SetWindowPosition(int left, int top)
        {
            Console.SetWindowPosition(left, top);
        }

        /// <summary>
        ///     Sets the size of the window.
        /// </summary>
        /// <param name="width">The width.</param>
        /// <param name="height">The height.</param>
        public void SetWindowSize(int width, int height)
        {
            Console.SetWindowSize(width, height);
        }

        /// <summary>Writes the text representation of the specified Boolean value to the standard output stream.</summary>
        /// <param name="value">The value to write. </param>
        /// <exception cref="T:System.IO.IOException">An I/O error occurred. </exception>
        /// <filterpriority>1</filterpriority>
        public void Write(bool value)
        {
            Console.Write(value);
        }

        /// <summary>Writes the specified Unicode character value to the standard output stream.</summary>
        /// <param name="value">The value to write. </param>
        /// <exception cref="T:System.IO.IOException">An I/O error occurred. </exception>
        /// <filterpriority>1</filterpriority>
        public void Write(char value)
        {
            Console.Write(value);
        }

        /// <summary>Writes the specified array of Unicode characters to the standard output stream.</summary>
        /// <param name="buffer">A Unicode character array. </param>
        /// <exception cref="T:System.IO.IOException">An I/O error occurred. </exception>
        /// <filterpriority>1</filterpriority>
        public void Write(char[] buffer)
        {
            Console.Write(buffer);
        }

        /// <summary>Writes the specified subarray of Unicode characters to the standard output stream.</summary>
        /// <param name="buffer">An array of Unicode characters. </param>
        /// <param name="index">The starting position in <paramref name="buffer" />. </param>
        /// <param name="count">The number of characters to write. </param>
        /// <exception cref="T:System.ArgumentNullException">
        ///     <paramref name="buffer" /> is null.
        /// </exception>
        /// <exception cref="T:System.ArgumentOutOfRangeException">
        ///     <paramref name="index" /> or <paramref name="count" /> is less than zero.
        /// </exception>
        /// <exception cref="T:System.ArgumentException">
        ///     <paramref name="index" /> plus <paramref name="count" /> specify a position that is not within
        ///     <paramref name="buffer" />.
        /// </exception>
        /// <exception cref="T:System.IO.IOException">An I/O error occurred. </exception>
        /// <filterpriority>1</filterpriority>
        public void Write(char[] buffer, int index, int count)
        {
            Console.Write(buffer, index, count);
        }

        /// <summary>
        ///     Writes the text representation of the specified <see cref="T:System.Decimal" /> value to the standard output
        ///     stream.
        /// </summary>
        /// <param name="value">The value to write. </param>
        /// <exception cref="T:System.IO.IOException">An I/O error occurred. </exception>
        /// <filterpriority>1</filterpriority>
        public void Write(decimal value)
        {
            Console.Write(value);
        }

        /// <summary>
        ///     Writes the text representation of the specified double-precision floating-point value to the standard output
        ///     stream.
        /// </summary>
        /// <param name="value">The value to write. </param>
        /// <exception cref="T:System.IO.IOException">An I/O error occurred. </exception>
        /// <filterpriority>1</filterpriority>
        public void Write(double value)
        {
            Console.Write(value);
        }

        /// <summary>Writes the text representation of the specified 32-bit signed integer value to the standard output stream.</summary>
        /// <param name="value">The value to write. </param>
        /// <exception cref="T:System.IO.IOException">An I/O error occurred. </exception>
        /// <filterpriority>1</filterpriority>
        public void Write(int value)
        {
            Console.Write(value);
        }

        /// <summary>Writes the text representation of the specified 64-bit signed integer value to the standard output stream.</summary>
        /// <param name="value">The value to write. </param>
        /// <exception cref="T:System.IO.IOException">An I/O error occurred. </exception>
        /// <filterpriority>1</filterpriority>
        public void Write(long value)
        {
            Console.Write(value);
        }

        /// <summary>Writes the text representation of the specified object to the standard output stream.</summary>
        /// <param name="value">The value to write, or null. </param>
        /// <exception cref="T:System.IO.IOException">An I/O error occurred. </exception>
        /// <filterpriority>1</filterpriority>
        public void Write(object value)
        {
            Console.Write(value);
        }

        /// <summary>
        ///     Writes the text representation of the specified single-precision floating-point value to the standard output
        ///     stream.
        /// </summary>
        /// <param name="value">The value to write. </param>
        /// <exception cref="T:System.IO.IOException">An I/O error occurred. </exception>
        /// <filterpriority>1</filterpriority>
        public void Write(float value)
        {
            Console.Write(value);
        }

        /// <summary>Writes the specified string value to the standard output stream.</summary>
        /// <param name="value">The value to write. </param>
        /// <exception cref="T:System.IO.IOException">An I/O error occurred. </exception>
        /// <filterpriority>1</filterpriority>
        public void Write(string value)
        {
            Console.Write(value);
        }

        /// <summary>
        ///     Writes the text representation of the specified object to the standard output stream using the specified
        ///     format information.
        /// </summary>
        /// <param name="format">A composite format string (see Remarks). </param>
        /// <param name="arg0">An object to write using <paramref name="format" />. </param>
        /// <exception cref="T:System.IO.IOException">An I/O error occurred. </exception>
        /// <exception cref="T:System.ArgumentNullException">
        ///     <paramref name="format" /> is null.
        /// </exception>
        /// <exception cref="T:System.FormatException">The format specification in <paramref name="format" /> is invalid. </exception>
        /// <filterpriority>1</filterpriority>
        public void Write(string format, object arg0)
        {
            Console.Write(format, arg0);
        }

        /// <summary>
        ///     Writes the text representation of the specified objects to the standard output stream using the specified
        ///     format information.
        /// </summary>
        /// <param name="format">A composite format string (see Remarks).</param>
        /// <param name="arg0">The first object to write using <paramref name="format" />. </param>
        /// <param name="arg1">The second object to write using <paramref name="format" />. </param>
        /// <exception cref="T:System.IO.IOException">An I/O error occurred. </exception>
        /// <exception cref="T:System.ArgumentNullException">
        ///     <paramref name="format" /> is null.
        /// </exception>
        /// <exception cref="T:System.FormatException">The format specification in <paramref name="format" /> is invalid. </exception>
        /// <filterpriority>1</filterpriority>
        public void Write(string format, object arg0, object arg1)
        {
            Console.Write(format, arg0, arg1);
        }

        /// <summary>
        ///     Writes the text representation of the specified objects to the standard output stream using the specified
        ///     format information.
        /// </summary>
        /// <param name="format">A composite format string (see Remarks).</param>
        /// <param name="arg0">The first object to write using <paramref name="format" />. </param>
        /// <param name="arg1">The second object to write using <paramref name="format" />. </param>
        /// <param name="arg2">The third object to write using <paramref name="format" />. </param>
        /// <exception cref="T:System.IO.IOException">An I/O error occurred. </exception>
        /// <exception cref="T:System.ArgumentNullException">
        ///     <paramref name="format" /> is null.
        /// </exception>
        /// <exception cref="T:System.FormatException">The format specification in <paramref name="format" /> is invalid. </exception>
        /// <filterpriority>1</filterpriority>
        public void Write(string format, object arg0, object arg1, object arg2)
        {
            Console.Write(format, arg0, arg1, arg2);
        }

        /// <summary>
        ///     Writes the text representation of the specified array of objects to the standard output stream using the
        ///     specified format information.
        /// </summary>
        /// <param name="format">A composite format string (see Remarks).</param>
        /// <param name="arg">An array of objects to write using <paramref name="format" />. </param>
        /// <exception cref="T:System.IO.IOException">An I/O error occurred. </exception>
        /// <exception cref="T:System.ArgumentNullException">
        ///     <paramref name="format" /> or <paramref name="arg" /> is null.
        /// </exception>
        /// <exception cref="T:System.FormatException">The format specification in <paramref name="format" /> is invalid. </exception>
        /// <filterpriority>1</filterpriority>
        public void Write(string format, params object[] arg)
        {
            Console.Write(format, arg);
        }

        /// <summary>Writes the current line terminator to the standard output stream.</summary>
        /// <exception cref="T:System.IO.IOException">An I/O error occurred. </exception>
        /// <filterpriority>1</filterpriority>
        public void WriteLine()
        {
            Console.WriteLine();
        }

        /// <summary>
        ///     Writes the text representation of the specified Boolean value, followed by the current line terminator, to the
        ///     standard output stream.
        /// </summary>
        /// <param name="value">The value to write. </param>
        /// <exception cref="T:System.IO.IOException">An I/O error occurred. </exception>
        /// <filterpriority>1</filterpriority>
        public void WriteLine(bool value)
        {
            Console.WriteLine(value);
        }

        /// <summary>
        ///     Writes the specified Unicode character, followed by the current line terminator, value to the standard output
        ///     stream.
        /// </summary>
        /// <param name="value">The value to write. </param>
        /// <exception cref="T:System.IO.IOException">An I/O error occurred. </exception>
        /// <filterpriority>1</filterpriority>
        public void WriteLine(char value)
        {
            Console.WriteLine(value);
        }

        /// <summary>
        ///     Writes the specified array of Unicode characters, followed by the current line terminator, to the standard
        ///     output stream.
        /// </summary>
        /// <param name="buffer">A Unicode character array. </param>
        /// <exception cref="T:System.IO.IOException">An I/O error occurred. </exception>
        /// <filterpriority>1</filterpriority>
        public void WriteLine(char[] buffer)
        {
            Console.WriteLine(buffer);
        }

        /// <summary>
        ///     Writes the specified subarray of Unicode characters, followed by the current line terminator, to the standard
        ///     output stream.
        /// </summary>
        /// <param name="buffer">An array of Unicode characters. </param>
        /// <param name="index">The starting position in <paramref name="buffer" />. </param>
        /// <param name="count">The number of characters to write. </param>
        /// <exception cref="T:System.ArgumentNullException">
        ///     <paramref name="buffer" /> is null.
        /// </exception>
        /// <exception cref="T:System.ArgumentOutOfRangeException">
        ///     <paramref name="index" /> or <paramref name="count" /> is less than zero.
        /// </exception>
        /// <exception cref="T:System.ArgumentException">
        ///     <paramref name="index" /> plus <paramref name="count" /> specify a position that is not within
        ///     <paramref name="buffer" />.
        /// </exception>
        /// <exception cref="T:System.IO.IOException">An I/O error occurred. </exception>
        /// <filterpriority>1</filterpriority>
        public void WriteLine(char[] buffer, int index, int count)
        {
            Console.WriteLine(buffer, index, count);
        }

        /// <summary>
        ///     Writes the text representation of the specified <see cref="T:System.Decimal" /> value, followed by the current
        ///     line terminator, to the standard output stream.
        /// </summary>
        /// <param name="value">The value to write. </param>
        /// <exception cref="T:System.IO.IOException">An I/O error occurred. </exception>
        /// <filterpriority>1</filterpriority>
        public void WriteLine(decimal value)
        {
            Console.WriteLine(value);
        }

        /// <summary>
        ///     Writes the text representation of the specified double-precision floating-point value, followed by the current
        ///     line terminator, to the standard output stream.
        /// </summary>
        /// <param name="value">The value to write. </param>
        /// <exception cref="T:System.IO.IOException">An I/O error occurred. </exception>
        /// <filterpriority>1</filterpriority>
        public void WriteLine(double value)
        {
            Console.WriteLine(value);
        }

        /// <summary>
        ///     Writes the text representation of the specified 32-bit signed integer value, followed by the current line
        ///     terminator, to the standard output stream.
        /// </summary>
        /// <param name="value">The value to write. </param>
        /// <exception cref="T:System.IO.IOException">An I/O error occurred. </exception>
        /// <filterpriority>1</filterpriority>
        public void WriteLine(int value)
        {
            Console.WriteLine(value);
        }

        /// <summary>
        ///     Writes the text representation of the specified 64-bit signed integer value, followed by the current line
        ///     terminator, to the standard output stream.
        /// </summary>
        /// <param name="value">The value to write. </param>
        /// <exception cref="T:System.IO.IOException">An I/O error occurred. </exception>
        /// <filterpriority>1</filterpriority>
        public void WriteLine(long value)
        {
            Console.WriteLine(value);
        }

        /// <summary>
        ///     Writes the text representation of the specified object, followed by the current line terminator, to the
        ///     standard output stream.
        /// </summary>
        /// <param name="value">The value to write. </param>
        /// <exception cref="T:System.IO.IOException">An I/O error occurred. </exception>
        /// <filterpriority>1</filterpriority>
        public void WriteLine(object value)
        {
            Console.WriteLine(value);
        }

        /// <summary>
        ///     Writes the text representation of the specified single-precision floating-point value, followed by the current
        ///     line terminator, to the standard output stream.
        /// </summary>
        /// <param name="value">The value to write. </param>
        /// <exception cref="T:System.IO.IOException">An I/O error occurred. </exception>
        /// <filterpriority>1</filterpriority>
        public void WriteLine(float value)
        {
            Console.WriteLine(value);
        }

        /// <summary>Writes the specified string value, followed by the current line terminator, to the standard output stream.</summary>
        /// <param name="value">The value to write. </param>
        /// <exception cref="T:System.IO.IOException">An I/O error occurred. </exception>
        /// <filterpriority>1</filterpriority>
        public void WriteLine(string value)
        {
            Console.WriteLine(value);
        }

        /// <summary>
        ///     Writes the text representation of the specified object, followed by the current line terminator, to the
        ///     standard output stream using the specified format information.
        /// </summary>
        /// <param name="format">A composite format string (see Remarks).</param>
        /// <param name="arg0">An object to write using <paramref name="format" />. </param>
        /// <exception cref="T:System.IO.IOException">An I/O error occurred. </exception>
        /// <exception cref="T:System.ArgumentNullException">
        ///     <paramref name="format" /> is null.
        /// </exception>
        /// <exception cref="T:System.FormatException">The format specification in <paramref name="format" /> is invalid. </exception>
        /// <filterpriority>1</filterpriority>
        public void WriteLine(string format, object arg0)
        {
            Console.WriteLine(format, arg0);
        }

        /// <summary>
        ///     Writes the text representation of the specified objects, followed by the current line terminator, to the
        ///     standard output stream using the specified format information.
        /// </summary>
        /// <param name="format">A composite format string (see Remarks).</param>
        /// <param name="arg0">The first object to write using <paramref name="format" />. </param>
        /// <param name="arg1">The second object to write using <paramref name="format" />. </param>
        /// <exception cref="T:System.IO.IOException">An I/O error occurred. </exception>
        /// <exception cref="T:System.ArgumentNullException">
        ///     <paramref name="format" /> is null.
        /// </exception>
        /// <exception cref="T:System.FormatException">The format specification in <paramref name="format" /> is invalid. </exception>
        /// <filterpriority>1</filterpriority>
        public void WriteLine(string format, object arg0, object arg1)
        {
            Console.WriteLine(format, arg0, arg1);
        }

        /// <summary>
        ///     Writes the text representation of the specified objects, followed by the current line terminator, to the
        ///     standard output stream using the specified format information.
        /// </summary>
        /// <param name="format">A composite format string (see Remarks).</param>
        /// <param name="arg0">The first object to write using <paramref name="format" />. </param>
        /// <param name="arg1">The second object to write using <paramref name="format" />. </param>
        /// <param name="arg2">The third object to write using <paramref name="format" />. </param>
        /// <exception cref="T:System.IO.IOException">An I/O error occurred. </exception>
        /// <exception cref="T:System.ArgumentNullException">
        ///     <paramref name="format" /> is null.
        /// </exception>
        /// <exception cref="T:System.FormatException">The format specification in <paramref name="format" /> is invalid. </exception>
        /// <filterpriority>1</filterpriority>
        public void WriteLine(string format, object arg0, object arg1, object arg2)
        {
            Console.WriteLine(format, arg0, arg1, arg2);
        }

        /// <summary>
        ///     Writes the text representation of the specified array of objects, followed by the current line terminator, to
        ///     the standard output stream using the specified format information.
        /// </summary>
        /// <param name="format">A composite format string (see Remarks).</param>
        /// <param name="arg">An array of objects to write using <paramref name="format" />. </param>
        /// <exception cref="T:System.IO.IOException">An I/O error occurred. </exception>
        /// <exception cref="T:System.ArgumentNullException">
        ///     <paramref name="format" /> or <paramref name="arg" /> is null.
        /// </exception>
        /// <exception cref="T:System.FormatException">The format specification in <paramref name="format" /> is invalid. </exception>
        /// <filterpriority>1</filterpriority>
        public void WriteLine(string format, params object[] arg)
        {
            Console.WriteLine(format, arg);
        }

        /// <summary>Writes the text representation of the specified 32-bit unsigned integer value to the standard output stream.</summary>
        /// <param name="value">The value to write. </param>
        /// <exception cref="T:System.IO.IOException">An I/O error occurred. </exception>
        /// <filterpriority>1</filterpriority>
        public void Write(uint value)
        {
            Console.Write(value);
        }

        /// <summary>Writes the text representation of the specified 64-bit unsigned integer value to the standard output stream.</summary>
        /// <param name="value">The value to write. </param>
        /// <exception cref="T:System.IO.IOException">An I/O error occurred. </exception>
        /// <filterpriority>1</filterpriority>
        public void Write(ulong value)
        {
            Console.Write(value);
        }

        /// <summary>
        ///     Writes the text representation of the specified 32-bit unsigned integer value, followed by the current line
        ///     terminator, to the standard output stream.
        /// </summary>
        /// <param name="value">The value to write. </param>
        /// <exception cref="T:System.IO.IOException">An I/O error occurred. </exception>
        /// <filterpriority>1</filterpriority>
        public void WriteLine(uint value)
        {
            Console.WriteLine(value);
        }

        /// <summary>
        ///     Writes the text representation of the specified 64-bit unsigned integer value, followed by the current line
        ///     terminator, to the standard output stream.
        /// </summary>
        /// <param name="value">The value to write. </param>
        /// <exception cref="T:System.IO.IOException">An I/O error occurred. </exception>
        /// <filterpriority>1</filterpriority>
        public void WriteLine(ulong value)
        {
            Console.WriteLine(value);
        }
    }
}