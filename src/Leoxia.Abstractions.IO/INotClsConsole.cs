using System;
using System.Collections.Generic;
using System.Text;

namespace Leoxia.Abstractions.IO
{
    /// <summary>
    /// The Non Cls compliant of IConsole
    /// </summary>
    [CLSCompliant(false)]
    public interface INotClsConsole
    {
        /// <summary>Writes the text representation of the specified 32-bit unsigned integer value to the standard output stream.</summary>
        /// <param name="value">The value to write. </param>
        /// <exception cref="T:System.IO.IOException">An I/O error occurred. </exception>
        /// <filterpriority>1</filterpriority>
        [CLSCompliant(false)]
        void Write(uint value);



        /// <summary>Writes the text representation of the specified 64-bit unsigned integer value to the standard output stream.</summary>
        /// <param name="value">The value to write. </param>
        /// <exception cref="T:System.IO.IOException">An I/O error occurred. </exception>
        /// <filterpriority>1</filterpriority>
        [CLSCompliant(false)]
        void Write(ulong value);

        /// <summary>Writes the text representation of the specified 32-bit unsigned integer value, followed by the current line terminator, to the standard output stream.</summary>
        /// <param name="value">The value to write. </param>
        /// <exception cref="T:System.IO.IOException">An I/O error occurred. </exception>
        /// <filterpriority>1</filterpriority>
        [CLSCompliant(false)]
        void WriteLine(uint value);



        /// <summary>Writes the text representation of the specified 64-bit unsigned integer value, followed by the current line terminator, to the standard output stream.</summary>
        /// <param name="value">The value to write. </param>
        /// <exception cref="T:System.IO.IOException">An I/O error occurred. </exception>
        /// <filterpriority>1</filterpriority>
        [CLSCompliant(false)]
        void WriteLine(ulong value);
    }
}
