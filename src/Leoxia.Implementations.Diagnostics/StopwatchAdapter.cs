#region Copyright (c) 2017 Leoxia Ltd

// --------------------------------------------------------------------------------------------------------------------
// <copyright file="StopwatchAdapter.cs" company="Leoxia Ltd">
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
using System.Diagnostics;
using Leoxia.Abstractions.Diagnostics;

#endregion

namespace Leoxia.Implementations.Diagnostics
{
    /// <summary>
    ///     Implementation of <see cref="IStopwatch" />
    /// </summary>
    public class StopwatchAdapter : IStopwatch
    {
        private readonly Stopwatch _stopwatchImplementation;

        /// <summary>Initializes a new instance of the <see cref="T:System.Object" /> class.</summary>
        public StopwatchAdapter()
        {
            _stopwatchImplementation = new Stopwatch();
        }

        /// <summary>Initializes a new instance of the <see cref="T:System.Object" /> class.</summary>
        public StopwatchAdapter(Stopwatch stopwatchImplementation)
        {
            _stopwatchImplementation = stopwatchImplementation;
        }

        /// <summary>Gets the frequency of the timer as the number of ticks per second. This field is read-only.</summary>
        /// <filterpriority>1</filterpriority>
        public long Frequency => Stopwatch.Frequency;

        /// <summary>Indicates whether the timer is based on a high-resolution performance counter. This field is read-only.</summary>
        /// <filterpriority>1</filterpriority>
        public bool IsHighResolution => Stopwatch.IsHighResolution;

        /// <summary>Gets the total elapsed time measured by the current instance.</summary>
        /// <returns>
        ///     A read-only <see cref="T:System.TimeSpan" /> representing the total elapsed time measured by the current
        ///     instance.
        /// </returns>
        /// <filterpriority>1</filterpriority>
        public TimeSpan Elapsed => _stopwatchImplementation.Elapsed;

        /// <summary>Gets the total elapsed time measured by the current instance, in milliseconds.</summary>
        /// <returns>A read-only long integer representing the total number of milliseconds measured by the current instance.</returns>
        /// <filterpriority>1</filterpriority>
        public long ElapsedMilliseconds => _stopwatchImplementation.ElapsedMilliseconds;

        /// <summary>Gets the total elapsed time measured by the current instance, in timer ticks.</summary>
        /// <returns>A read-only long integer representing the total number of timer ticks measured by the current instance.</returns>
        /// <filterpriority>1</filterpriority>
        public long ElapsedTicks => _stopwatchImplementation.ElapsedTicks;

        /// <summary>Gets a value indicating whether the <see cref="T:System.Diagnostics.Stopwatch" /> timer is running.</summary>
        /// <returns>
        ///     true if the <see cref="T:System.Diagnostics.Stopwatch" /> instance is currently running and measuring elapsed
        ///     time for an interval; otherwise, false.
        /// </returns>
        /// <filterpriority>1</filterpriority>
        public bool IsRunning => _stopwatchImplementation.IsRunning;

        /// <summary>Gets the current number of ticks in the timer mechanism.</summary>
        /// <returns>A long integer representing the tick counter value of the underlying timer mechanism.</returns>
        /// <filterpriority>1</filterpriority>
        public long GetTimestamp()
        {
            return Stopwatch.GetTimestamp();
        }

        /// <summary>Stops time interval measurement and resets the elapsed time to zero.</summary>
        /// <filterpriority>1</filterpriority>
        public void Reset()
        {
            _stopwatchImplementation.Reset();
        }

        /// <summary>Stops time interval measurement, resets the elapsed time to zero, and starts measuring elapsed time.</summary>
        public void Restart()
        {
            _stopwatchImplementation.Restart();
        }

        /// <summary>Starts, or resumes, measuring elapsed time for an interval.</summary>
        /// <filterpriority>1</filterpriority>
        public void Start()
        {
            _stopwatchImplementation.Start();
        }

        /// <summary>
        ///     Initializes a new <see cref="T:System.Diagnostics.Stopwatch" /> instance, sets the elapsed time property to
        ///     zero, and starts measuring elapsed time.
        /// </summary>
        /// <returns>A <see cref="T:System.Diagnostics.Stopwatch" /> that has just begun measuring elapsed time.</returns>
        /// <filterpriority>1</filterpriority>
        public IStopwatch StartNew()
        {
            return new StopwatchAdapter(Stopwatch.StartNew());
        }

        /// <summary>Stops measuring elapsed time for an interval.</summary>
        /// <filterpriority>1</filterpriority>
        public void Stop()
        {
            _stopwatchImplementation.Stop();
        }
    }
}