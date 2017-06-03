using System;
using System.IO;
using System.Text;

namespace Leoxia.Abstractions.IO
{

    /// <summary>Represents the standard input, output, and error streams for console applications. This class cannot be inherited.To browse the .NET Framework source code for this type, see the Reference Source.</summary>
    /// <filterpriority>1</filterpriority>
    [CLSCompliant(true)]
    public interface IConsole 
    {
        /// <summary>Gets or sets the background color of the console.</summary>
        /// <returns>A value that specifies the background color of the console; that is, the color that appears behind each character. The default is black.</returns>
        /// <exception cref="T:System.ArgumentException">The color specified in a set operation is not a valid member of <see cref="T:System.ConsoleColor" />. </exception>
        /// <exception cref="T:System.Security.SecurityException">The user does not have permission to perform this action. </exception>
        /// <exception cref="T:System.IO.IOException">An I/O error occurred. </exception>
        /// <filterpriority>1</filterpriority>
        /// <PermissionSet>
        ///   <IPermission class="System.Security.Permissions.UIPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Window="SafeTopLevelWindows" />
        /// </PermissionSet>
        ConsoleColor BackgroundColor

        { get; set; }



        /// <summary>
        /// Gets or sets the height of the buffer.
        /// </summary>
        /// <value>
        /// The height of the buffer.
        /// </value>
        int BufferHeight

        { get; set; }




        /// <summary>
        /// Gets or sets the width of the buffer.
        /// </summary>
        /// <value>
        /// The width of the buffer.
        /// </value>
        int BufferWidth

        { get; set; }




        /// <summary>
        /// Gets a value indicating whether [caps lock].
        /// </summary>
        /// <value>
        ///   <c>true</c> if [caps lock]; otherwise, <c>false</c>.
        /// </value>
        bool CapsLock

        { get; }



        /// <summary>
        /// Gets or sets the cursor left.
        /// </summary>
        /// <value>
        /// The cursor left.
        /// </value>
        int CursorLeft

        { get; set; }




        /// <summary>
        /// Gets or sets the size of the cursor.
        /// </summary>
        /// <value>
        /// The size of the cursor.
        /// </value>
        int CursorSize

        { get; set; }




        /// <summary>
        /// Gets or sets the cursor top.
        /// </summary>
        /// <value>
        /// The cursor top.
        /// </value>
        int CursorTop

        { get; set; }



        /// <summary>
        /// Gets or sets a value indicating whether [cursor visible].
        /// </summary>
        /// <value>
        ///   <c>true</c> if [cursor visible]; otherwise, <c>false</c>.
        /// </value>
        bool CursorVisible

        { get; set; }




        /// <summary>Gets the standard error output stream.</summary>
        /// <returns>A <see cref="T:System.IO.TextWriter" /> that represents the standard error output stream.</returns>
        /// <filterpriority>1</filterpriority>
        ITextWriter Error

        { get;  }



    /// <summary>Gets or sets the foreground color of the console.</summary>
    /// <returns>A <see cref="T:System.ConsoleColor" /> that specifies the foreground color of the console; that is, the color of each character that is displayed. The default is gray.</returns>
    /// <exception cref="T:System.ArgumentException">The color specified in a set operation is not a valid member of <see cref="T:System.ConsoleColor" />. </exception>
    /// <exception cref="T:System.Security.SecurityException">The user does not have permission to perform this action. </exception>
    /// <exception cref="T:System.IO.IOException">An I/O error occurred. </exception>
    /// <filterpriority>1</filterpriority>
    /// <PermissionSet>
    ///   <IPermission class="System.Security.Permissions.UIPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Window="SafeTopLevelWindows" />
    /// </PermissionSet>
    ConsoleColor ForegroundColor

        { get; set; }




        /// <summary>
        /// Gets or sets the input encoding.
        /// </summary>
        /// <value>
        /// The input encoding.
        /// </value>
        Encoding InputEncoding

        { get; set; }




        /// <summary>
        /// Gets a value indicating whether this instance is error redirected.
        /// </summary>
        /// <value>
        /// <c>true</c> if this instance is error redirected; otherwise, <c>false</c>.
        /// </value>
        bool IsErrorRedirected

        { get;  }



        /// <summary>
        /// Gets a value indicating whether this instance is input redirected.
        /// </summary>
        /// <value>
        /// <c>true</c> if this instance is input redirected; otherwise, <c>false</c>.
        /// </value>
        bool IsInputRedirected

        { get;  }



        /// <summary>
        /// Gets a value indicating whether this instance is output redirected.
        /// </summary>
        /// <value>
        /// <c>true</c> if this instance is output redirected; otherwise, <c>false</c>.
        /// </value>
        bool IsOutputRedirected

        { get; }



        /// <summary>Gets the standard input stream.</summary>
        /// <returns>A <see cref="T:System.IO.TextReader" /> that represents the standard input stream.</returns>
        /// <filterpriority>1</filterpriority>
        ITextReader In

        { get; }



        /// <summary>
        /// Gets a value indicating whether [key available].
        /// </summary>
        /// <value>
        ///   <c>true</c> if [key available]; otherwise, <c>false</c>.
        /// </value>
        bool KeyAvailable

        { get; }



        /// <summary>
        /// Gets the width of the largest window.
        /// </summary>
        /// <value>
        /// The width of the largest window.
        /// </value>
        int LargestWindowWidth

        { get; }



        /// <summary>
        /// Gets the height of the largest window.
        /// </summary>
        /// <value>
        /// The height of the largest window.
        /// </value>
        int LargestWindowHeight
        { get; }



        /// <summary>
        /// Gets a value indicating whether [number lock].
        /// </summary>
        /// <value>
        ///   <c>true</c> if [number lock]; otherwise, <c>false</c>.
        /// </value>
        bool NumberLock

        { get; }



        /// <summary>Gets the standard output stream.</summary>
        /// <returns>A <see cref="T:System.IO.TextWriter" /> that represents the standard output stream.</returns>
        /// <filterpriority>1</filterpriority>
        ITextWriter Out
        { get; }



        /// <summary>
        /// Gets or sets the output encoding.
        /// </summary>
        /// <value>
        /// The output encoding.
        /// </value>
        Encoding OutputEncoding

        { get; set; }




        /// <summary>
        /// Gets or sets the title.
        /// </summary>
        /// <value>
        /// The title.
        /// </value>
        string Title

        { get; set; }




        /// <summary>
        /// Gets or sets a value indicating whether [treat control c as input].
        /// </summary>
        /// <value>
        /// <c>true</c> if [treat control c as input]; otherwise, <c>false</c>.
        /// </value>
        bool TreatControlCAsInput

        { get; set; }




        /// <summary>
        /// Gets or sets the height of the window.
        /// </summary>
        /// <value>
        /// The height of the window.
        /// </value>
        int WindowHeight

        { get; set; }




        /// <summary>
        /// Gets or sets the width of the window.
        /// </summary>
        /// <value>
        /// The width of the window.
        /// </value>
        int WindowWidth

        { get; set; }




        /// <summary>
        /// Gets or sets the window left.
        /// </summary>
        /// <value>
        /// The window left.
        /// </value>
        int WindowLeft { get; set; }




        /// <summary>
        /// Gets or sets the window top.
        /// </summary>
        /// <value>
        /// The window top.
        /// </value>
        int WindowTop { get; set; }




        /// <summary>Occurs when the <see cref="F:System.ConsoleModifiers.Control" /> modifier key (Ctrl) and either the <see cref="F:System.ConsoleKey.C" /> console key (C) or the Break key are pressed simultaneously (Ctrl+C or Ctrl+Break).</summary>
        /// <filterpriority>1</filterpriority>
        event ConsoleCancelEventHandler CancelKeyPress;




        /// <summary>
        /// Beeps this instance.
        /// </summary>
        void Beep();



        /// <summary>
        /// Beeps the specified frequency.
        /// </summary>
        /// <param name="frequency">The frequency.</param>
        /// <param name="duration">The duration.</param>
        void Beep(int frequency, int duration);



        /// <summary>
        /// Clears this instance.
        /// </summary>
        void Clear();



        /// <summary>
        /// Moves the buffer area.
        /// </summary>
        /// <param name="sourceLeft">The source left.</param>
        /// <param name="sourceTop">The source top.</param>
        /// <param name="sourceWidth">Width of the source.</param>
        /// <param name="sourceHeight">Height of the source.</param>
        /// <param name="targetLeft">The target left.</param>
        /// <param name="targetTop">The target top.</param>
        void MoveBufferArea(int sourceLeft, int sourceTop, int sourceWidth, int sourceHeight,
            int targetLeft, int targetTop);



        /// <summary>
        /// Moves the buffer area.
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
        void MoveBufferArea(int sourceLeft, int sourceTop, int sourceWidth, int sourceHeight,
            int targetLeft, int targetTop, char sourceChar, ConsoleColor sourceForeColor, ConsoleColor sourceBackColor);



        /// <summary>Acquires the standard error stream.</summary>
        /// <returns>The standard error stream.</returns>
        /// <filterpriority>1</filterpriority>
        Stream OpenStandardError();



        /// <summary>Acquires the standard input stream.</summary>
        /// <returns>The standard input stream.</returns>
        /// <filterpriority>1</filterpriority>
        Stream OpenStandardInput();


        /// <summary>Acquires the standard output stream.</summary>
        /// <returns>The standard output stream.</returns>
        /// <filterpriority>1</filterpriority>
        Stream OpenStandardOutput();



        /// <summary>Reads the next character from the standard input stream.</summary>
        /// <returns>The next character from the input stream, or negative one (-1) if there are currently no more characters to be read.</returns>
        /// <exception cref="T:System.IO.IOException">An I/O error occurred. </exception>
        /// <filterpriority>1</filterpriority>
        int Read();



        /// <summary>
        /// Reads the key.
        /// </summary>
        /// <returns></returns>
        ConsoleKeyInfo ReadKey();


        /// <summary>
        /// Reads the key.
        /// </summary>
        /// <param name="intercept">if set to <c>true</c> [intercept].</param>
        /// <returns></returns>
        ConsoleKeyInfo ReadKey(bool intercept);


        /// <summary>Reads the next line of characters from the standard input stream.</summary>
        /// <returns>The next line of characters from the input stream, or null if no more lines are available.</returns>
        /// <exception cref="T:System.IO.IOException">An I/O error occurred. </exception>
        /// <exception cref="T:System.OutOfMemoryException">There is insufficient memory to allocate a buffer for the returned string. </exception>
        /// <exception cref="T:System.ArgumentOutOfRangeException">The number of characters in the next line of characters is greater than <see cref="F:System.Int32.MaxValue" />.</exception>
        /// <filterpriority>1</filterpriority>
        string ReadLine();



        /// <summary>Sets the foreground and background console colors to their defaults.</summary>
        /// <exception cref="T:System.Security.SecurityException">The user does not have permission to perform this action. </exception>
        /// <exception cref="T:System.IO.IOException">An I/O error occurred. </exception>
        /// <filterpriority>1</filterpriority>
        /// <PermissionSet>
        ///   <IPermission class="System.Security.Permissions.UIPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Window="SafeTopLevelWindows" />
        /// </PermissionSet>
        void ResetColor();



        /// <summary>
        /// Sets the size of the buffer.
        /// </summary>
        /// <param name="width">The width.</param>
        /// <param name="height">The height.</param>
        void SetBufferSize(int width, int height);



        /// <summary>
        /// Sets the cursor position.
        /// </summary>
        /// <param name="left">The left.</param>
        /// <param name="top">The top.</param>
        void SetCursorPosition(int left, int top);



        /// <summary>Sets the <see cref="P:System.Console.Error" /> property to the specified <see cref="T:System.IO.TextWriter" /> object.</summary>
        /// <param name="newError">A stream that is the new standard error output. </param>
        /// <exception cref="T:System.ArgumentNullException">
        /// <paramref name="newError" /> is null. </exception>
        /// <exception cref="T:System.Security.SecurityException">The caller does not have the required permission. </exception>
        /// <filterpriority>1</filterpriority>
        /// <PermissionSet>
        ///   <IPermission class="System.Security.Permissions.SecurityPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Flags="UnmanagedCode" />
        /// </PermissionSet>
        void SetError(TextWriter newError);



        /// <summary>Sets the <see cref="P:System.Console.In" /> property to the specified <see cref="T:System.IO.TextReader" /> object.</summary>
        /// <param name="newIn">A stream that is the new standard input. </param>
        /// <exception cref="T:System.ArgumentNullException">
        /// <paramref name="newIn" /> is null. </exception>
        /// <exception cref="T:System.Security.SecurityException">The caller does not have the required permission. </exception>
        /// <filterpriority>1</filterpriority>
        /// <PermissionSet>
        ///   <IPermission class="System.Security.Permissions.SecurityPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Flags="UnmanagedCode" />
        /// </PermissionSet>
        void SetIn(TextReader newIn);


        /// <summary>Sets the <see cref="P:System.Console.Out" /> property to the specified <see cref="T:System.IO.TextWriter" /> object.</summary>
        /// <param name="newOut">A stream that is the new standard output. </param>
        /// <exception cref="T:System.ArgumentNullException">
        /// <paramref name="newOut" /> is null. </exception>
        /// <exception cref="T:System.Security.SecurityException">The caller does not have the required permission. </exception>
        /// <filterpriority>1</filterpriority>
        /// <PermissionSet>
        ///   <IPermission class="System.Security.Permissions.SecurityPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Flags="UnmanagedCode" />
        /// </PermissionSet>
        void SetOut(TextWriter newOut);



        /// <summary>
        /// Sets the window position.
        /// </summary>
        /// <param name="left">The left.</param>
        /// <param name="top">The top.</param>
        void SetWindowPosition(int left, int top);



        /// <summary>
        /// Sets the size of the window.
        /// </summary>
        /// <param name="width">The width.</param>
        /// <param name="height">The height.</param>
        void SetWindowSize(int width, int height);



        /// <summary>Writes the text representation of the specified Boolean value to the standard output stream.</summary>
        /// <param name="value">The value to write. </param>
        /// <exception cref="T:System.IO.IOException">An I/O error occurred. </exception>
        /// <filterpriority>1</filterpriority>
        void Write(bool value);



        /// <summary>Writes the specified Unicode character value to the standard output stream.</summary>
        /// <param name="value">The value to write. </param>
        /// <exception cref="T:System.IO.IOException">An I/O error occurred. </exception>
        /// <filterpriority>1</filterpriority>
        void Write(char value);



        /// <summary>Writes the specified array of Unicode characters to the standard output stream.</summary>
        /// <param name="buffer">A Unicode character array. </param>
        /// <exception cref="T:System.IO.IOException">An I/O error occurred. </exception>
        /// <filterpriority>1</filterpriority>
        void Write(char[] buffer);



        /// <summary>Writes the specified subarray of Unicode characters to the standard output stream.</summary>
        /// <param name="buffer">An array of Unicode characters. </param>
        /// <param name="index">The starting position in <paramref name="buffer" />. </param>
        /// <param name="count">The number of characters to write. </param>
        /// <exception cref="T:System.ArgumentNullException">
        /// <paramref name="buffer" /> is null. </exception>
        /// <exception cref="T:System.ArgumentOutOfRangeException">
        /// <paramref name="index" /> or <paramref name="count" /> is less than zero. </exception>
        /// <exception cref="T:System.ArgumentException">
        /// <paramref name="index" /> plus <paramref name="count" /> specify a position that is not within <paramref name="buffer" />. </exception>
        /// <exception cref="T:System.IO.IOException">An I/O error occurred. </exception>
        /// <filterpriority>1</filterpriority>
        void Write(char[] buffer, int index, int count);



        /// <summary>Writes the text representation of the specified <see cref="T:System.Decimal" /> value to the standard output stream.</summary>
        /// <param name="value">The value to write. </param>
        /// <exception cref="T:System.IO.IOException">An I/O error occurred. </exception>
        /// <filterpriority>1</filterpriority>
        void Write(Decimal value);



        /// <summary>Writes the text representation of the specified double-precision floating-point value to the standard output stream.</summary>
        /// <param name="value">The value to write. </param>
        /// <exception cref="T:System.IO.IOException">An I/O error occurred. </exception>
        /// <filterpriority>1</filterpriority>
        void Write(double value);



        /// <summary>Writes the text representation of the specified 32-bit signed integer value to the standard output stream.</summary>
        /// <param name="value">The value to write. </param>
        /// <exception cref="T:System.IO.IOException">An I/O error occurred. </exception>
        /// <filterpriority>1</filterpriority>
        void Write(int value);



        /// <summary>Writes the text representation of the specified 64-bit signed integer value to the standard output stream.</summary>
        /// <param name="value">The value to write. </param>
        /// <exception cref="T:System.IO.IOException">An I/O error occurred. </exception>
        /// <filterpriority>1</filterpriority>
        void Write(long value);



        /// <summary>Writes the text representation of the specified object to the standard output stream.</summary>
        /// <param name="value">The value to write, or null. </param>
        /// <exception cref="T:System.IO.IOException">An I/O error occurred. </exception>
        /// <filterpriority>1</filterpriority>
        void Write(object value);



        /// <summary>Writes the text representation of the specified single-precision floating-point value to the standard output stream.</summary>
        /// <param name="value">The value to write. </param>
        /// <exception cref="T:System.IO.IOException">An I/O error occurred. </exception>
        /// <filterpriority>1</filterpriority>
        void Write(float value);



        /// <summary>Writes the specified string value to the standard output stream.</summary>
        /// <param name="value">The value to write. </param>
        /// <exception cref="T:System.IO.IOException">An I/O error occurred. </exception>
        /// <filterpriority>1</filterpriority>
        void Write(string value);



        /// <summary>Writes the text representation of the specified object to the standard output stream using the specified format information.</summary>
        /// <param name="format">A composite format string (see Remarks). </param>
        /// <param name="arg0">An object to write using <paramref name="format" />. </param>
        /// <exception cref="T:System.IO.IOException">An I/O error occurred. </exception>
        /// <exception cref="T:System.ArgumentNullException">
        /// <paramref name="format" /> is null. </exception>
        /// <exception cref="T:System.FormatException">The format specification in <paramref name="format" /> is invalid. </exception>
        /// <filterpriority>1</filterpriority>
        void Write(string format, object arg0);



        /// <summary>Writes the text representation of the specified objects to the standard output stream using the specified format information.</summary>
        /// <param name="format">A composite format string (see Remarks).</param>
        /// <param name="arg0">The first object to write using <paramref name="format" />. </param>
        /// <param name="arg1">The second object to write using <paramref name="format" />. </param>
        /// <exception cref="T:System.IO.IOException">An I/O error occurred. </exception>
        /// <exception cref="T:System.ArgumentNullException">
        /// <paramref name="format" /> is null. </exception>
        /// <exception cref="T:System.FormatException">The format specification in <paramref name="format" /> is invalid. </exception>
        /// <filterpriority>1</filterpriority>
        void Write(string format, object arg0, object arg1);



        /// <summary>Writes the text representation of the specified objects to the standard output stream using the specified format information.</summary>
        /// <param name="format">A composite format string (see Remarks).</param>
        /// <param name="arg0">The first object to write using <paramref name="format" />. </param>
        /// <param name="arg1">The second object to write using <paramref name="format" />. </param>
        /// <param name="arg2">The third object to write using <paramref name="format" />. </param>
        /// <exception cref="T:System.IO.IOException">An I/O error occurred. </exception>
        /// <exception cref="T:System.ArgumentNullException">
        /// <paramref name="format" /> is null. </exception>
        /// <exception cref="T:System.FormatException">The format specification in <paramref name="format" /> is invalid. </exception>
        /// <filterpriority>1</filterpriority>
        void Write(string format, object arg0, object arg1, object arg2);



        /// <summary>Writes the text representation of the specified array of objects to the standard output stream using the specified format information.</summary>
        /// <param name="format">A composite format string (see Remarks).</param>
        /// <param name="arg">An array of objects to write using <paramref name="format" />. </param>
        /// <exception cref="T:System.IO.IOException">An I/O error occurred. </exception>
        /// <exception cref="T:System.ArgumentNullException">
        /// <paramref name="format" /> or <paramref name="arg" /> is null. </exception>
        /// <exception cref="T:System.FormatException">The format specification in <paramref name="format" /> is invalid. </exception>
        /// <filterpriority>1</filterpriority>
        void Write(string format, params object[] arg);







        /// <summary>Writes the current line terminator to the standard output stream.</summary>
        /// <exception cref="T:System.IO.IOException">An I/O error occurred. </exception>
        /// <filterpriority>1</filterpriority>
        void WriteLine();



        /// <summary>Writes the text representation of the specified Boolean value, followed by the current line terminator, to the standard output stream.</summary>
        /// <param name="value">The value to write. </param>
        /// <exception cref="T:System.IO.IOException">An I/O error occurred. </exception>
        /// <filterpriority>1</filterpriority>
        void WriteLine(bool value);



        /// <summary>Writes the specified Unicode character, followed by the current line terminator, value to the standard output stream.</summary>
        /// <param name="value">The value to write. </param>
        /// <exception cref="T:System.IO.IOException">An I/O error occurred. </exception>
        /// <filterpriority>1</filterpriority>
        void WriteLine(char value);



        /// <summary>Writes the specified array of Unicode characters, followed by the current line terminator, to the standard output stream.</summary>
        /// <param name="buffer">A Unicode character array. </param>
        /// <exception cref="T:System.IO.IOException">An I/O error occurred. </exception>
        /// <filterpriority>1</filterpriority>
        void WriteLine(char[] buffer);



        /// <summary>Writes the specified subarray of Unicode characters, followed by the current line terminator, to the standard output stream.</summary>
        /// <param name="buffer">An array of Unicode characters. </param>
        /// <param name="index">The starting position in <paramref name="buffer" />. </param>
        /// <param name="count">The number of characters to write. </param>
        /// <exception cref="T:System.ArgumentNullException">
        /// <paramref name="buffer" /> is null. </exception>
        /// <exception cref="T:System.ArgumentOutOfRangeException">
        /// <paramref name="index" /> or <paramref name="count" /> is less than zero. </exception>
        /// <exception cref="T:System.ArgumentException">
        /// <paramref name="index" /> plus <paramref name="count" /> specify a position that is not within <paramref name="buffer" />. </exception>
        /// <exception cref="T:System.IO.IOException">An I/O error occurred. </exception>
        /// <filterpriority>1</filterpriority>
        void WriteLine(char[] buffer, int index, int count);



        /// <summary>Writes the text representation of the specified <see cref="T:System.Decimal" /> value, followed by the current line terminator, to the standard output stream.</summary>
        /// <param name="value">The value to write. </param>
        /// <exception cref="T:System.IO.IOException">An I/O error occurred. </exception>
        /// <filterpriority>1</filterpriority>
        void WriteLine(Decimal value);



        /// <summary>Writes the text representation of the specified double-precision floating-point value, followed by the current line terminator, to the standard output stream.</summary>
        /// <param name="value">The value to write. </param>
        /// <exception cref="T:System.IO.IOException">An I/O error occurred. </exception>
        /// <filterpriority>1</filterpriority>
        void WriteLine(double value);



        /// <summary>Writes the text representation of the specified 32-bit signed integer value, followed by the current line terminator, to the standard output stream.</summary>
        /// <param name="value">The value to write. </param>
        /// <exception cref="T:System.IO.IOException">An I/O error occurred. </exception>
        /// <filterpriority>1</filterpriority>
        void WriteLine(int value);



        /// <summary>Writes the text representation of the specified 64-bit signed integer value, followed by the current line terminator, to the standard output stream.</summary>
        /// <param name="value">The value to write. </param>
        /// <exception cref="T:System.IO.IOException">An I/O error occurred. </exception>
        /// <filterpriority>1</filterpriority>
        void WriteLine(long value);



        /// <summary>Writes the text representation of the specified object, followed by the current line terminator, to the standard output stream.</summary>
        /// <param name="value">The value to write. </param>
        /// <exception cref="T:System.IO.IOException">An I/O error occurred. </exception>
        /// <filterpriority>1</filterpriority>
        void WriteLine(object value);



        /// <summary>Writes the text representation of the specified single-precision floating-point value, followed by the current line terminator, to the standard output stream.</summary>
        /// <param name="value">The value to write. </param>
        /// <exception cref="T:System.IO.IOException">An I/O error occurred. </exception>
        /// <filterpriority>1</filterpriority>
        void WriteLine(float value);



        /// <summary>Writes the specified string value, followed by the current line terminator, to the standard output stream.</summary>
        /// <param name="value">The value to write. </param>
        /// <exception cref="T:System.IO.IOException">An I/O error occurred. </exception>
        /// <filterpriority>1</filterpriority>
        void WriteLine(string value);



        /// <summary>Writes the text representation of the specified object, followed by the current line terminator, to the standard output stream using the specified format information.</summary>
        /// <param name="format">A composite format string (see Remarks).</param>
        /// <param name="arg0">An object to write using <paramref name="format" />. </param>
        /// <exception cref="T:System.IO.IOException">An I/O error occurred. </exception>
        /// <exception cref="T:System.ArgumentNullException">
        /// <paramref name="format" /> is null. </exception>
        /// <exception cref="T:System.FormatException">The format specification in <paramref name="format" /> is invalid. </exception>
        /// <filterpriority>1</filterpriority>
        void WriteLine(string format, object arg0);



        /// <summary>Writes the text representation of the specified objects, followed by the current line terminator, to the standard output stream using the specified format information.</summary>
        /// <param name="format">A composite format string (see Remarks).</param>
        /// <param name="arg0">The first object to write using <paramref name="format" />. </param>
        /// <param name="arg1">The second object to write using <paramref name="format" />. </param>
        /// <exception cref="T:System.IO.IOException">An I/O error occurred. </exception>
        /// <exception cref="T:System.ArgumentNullException">
        /// <paramref name="format" /> is null. </exception>
        /// <exception cref="T:System.FormatException">The format specification in <paramref name="format" /> is invalid. </exception>
        /// <filterpriority>1</filterpriority>
        void WriteLine(string format, object arg0, object arg1);



        /// <summary>Writes the text representation of the specified objects, followed by the current line terminator, to the standard output stream using the specified format information.</summary>
        /// <param name="format">A composite format string (see Remarks).</param>
        /// <param name="arg0">The first object to write using <paramref name="format" />. </param>
        /// <param name="arg1">The second object to write using <paramref name="format" />. </param>
        /// <param name="arg2">The third object to write using <paramref name="format" />. </param>
        /// <exception cref="T:System.IO.IOException">An I/O error occurred. </exception>
        /// <exception cref="T:System.ArgumentNullException">
        /// <paramref name="format" /> is null. </exception>
        /// <exception cref="T:System.FormatException">The format specification in <paramref name="format" /> is invalid. </exception>
        /// <filterpriority>1</filterpriority>
        void WriteLine(string format, object arg0, object arg1, object arg2);



        /// <summary>Writes the text representation of the specified array of objects, followed by the current line terminator, to the standard output stream using the specified format information.</summary>
        /// <param name="format">A composite format string (see Remarks).</param>
        /// <param name="arg">An array of objects to write using <paramref name="format" />. </param>
        /// <exception cref="T:System.IO.IOException">An I/O error occurred. </exception>
        /// <exception cref="T:System.ArgumentNullException">
        /// <paramref name="format" /> or <paramref name="arg" /> is null. </exception>
        /// <exception cref="T:System.FormatException">The format specification in <paramref name="format" /> is invalid. </exception>
        /// <filterpriority>1</filterpriority>
        void WriteLine(string format, params object[] arg);

    }
}

