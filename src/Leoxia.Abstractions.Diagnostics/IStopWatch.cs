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

#endregion

namespace Leoxia.Abstractions.Diagnostics
{
    /// <summary>
    ///     Provides a set of methods and properties that you can use to accurately measure elapsed time.To browse the
    ///     .NET Framework source code for this type, see the Reference Source.
    /// </summary>
    /// <filterpriority>1</filterpriority>
    public interface IStopwatch
    {
        /// <summary>Gets the total elapsed time measured by the current instance.</summary>
        /// <returns>
        ///     A read-only <see cref="T:System.TimeSpan" /> representing the total elapsed time measured by the current
        ///     instance.
        /// </returns>
        /// <filterpriority>1</filterpriority>
        TimeSpan Elapsed { get; }

        /// <summary>Gets the total elapsed time measured by the current instance, in milliseconds.</summary>
        /// <returns>A read-only long integer representing the total number of milliseconds measured by the current instance.</returns>
        /// <filterpriority>1</filterpriority>
        long ElapsedMilliseconds { get; }

        /// <summary>Gets the total elapsed time measured by the current instance, in timer ticks.</summary>
        /// <returns>A read-only long integer representing the total number of timer ticks measured by the current instance.</returns>
        /// <filterpriority>1</filterpriority>
        long ElapsedTicks { get; }

        /// <summary>Gets the frequency of the timer as the number of ticks per second. This field is read-only.</summary>
        /// <filterpriority>1</filterpriority>
        long Frequency { get; }

        /// <summary>Indicates whether the timer is based on a high-resolution performance counter. This field is read-only.</summary>
        /// <filterpriority>1</filterpriority>
        bool IsHighResolution { get; }

        /// <summary>Gets a value indicating whether the <see cref="T:System.Diagnostics.Stopwatch" /> timer is running.</summary>
        /// <returns>
        ///     true if the <see cref="T:System.Diagnostics.Stopwatch" /> instance is currently running and measuring elapsed
        ///     time for an interval; otherwise, false.
        /// </returns>
        /// <filterpriority>1</filterpriority>
        bool IsRunning { get; }

        /// <summary>Gets the current number of ticks in the timer mechanism.</summary>
        /// <returns>A long integer representing the tick counter value of the underlying timer mechanism.</returns>
        /// <filterpriority>1</filterpriority>
        long GetTimestamp();

        /// <summary>Stops time interval measurement and resets the elapsed time to zero.</summary>
        /// <filterpriority>1</filterpriority>
        void Reset();

        /// <summary>Stops time interval measurement, resets the elapsed time to zero, and starts measuring elapsed time.</summary>
        void Restart();

        /// <summary>Starts, or resumes, measuring elapsed time for an interval.</summary>
        /// <filterpriority>1</filterpriority>
        void Start();

        /// <summary>
        ///     Initializes a new <see cref="T:System.Diagnostics.Stopwatch" /> instance, sets the elapsed time property to
        ///     zero, and starts measuring elapsed time.
        /// </summary>
        /// <returns>A <see cref="T:System.Diagnostics.Stopwatch" /> that has just begun measuring elapsed time.</returns>
        /// <filterpriority>1</filterpriority>
        IStopwatch StartNew();

        /// <summary>Stops measuring elapsed time for an interval.</summary>
        /// <filterpriority>1</filterpriority>
        void Stop();
    }
}