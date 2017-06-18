#region Copyright (c) 2017 Leoxia Ltd

// --------------------------------------------------------------------------------------------------------------------
// <copyright file="TimeProvider.cs" company="Leoxia Ltd">
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

// ReSharper disable once CheckNamespace

#region Usings

using System;
using Leoxia.Abstractions;

#endregion

namespace Leoxia.Implementations
{
    /// <summary>
    ///     Provide Now property as implementation of <see cref="ITimeProvider" />
    /// </summary>
    /// <seealso cref="Leoxia.Abstractions.ITimeProvider" />
    public class TimeProvider : ITimeProvider
    {
        /// <summary>
        ///     Gets a <see cref="T:System.DateTime" /> object that is set to the current date and time on this computer,
        ///     expressed as the local time.
        /// </summary>
        /// <returns>An object whose value is the current local date and time.</returns>
        /// <filterpriority>1</filterpriority>
        public DateTime Now => DateTime.Now;

        /// <summary>Gets the current date.</summary>
        /// <returns>An object that is set to today's date, with the time component set to 00:00:00.</returns>
        /// <filterpriority>1</filterpriority>
        public DateTime Today => DateTime.Today;

        /// <summary>
        ///     Gets a <see cref="T:System.DateTime" /> object that is set to the current date and time on this computer,
        ///     expressed as the Coordinated Universal Time (UTC).
        /// </summary>
        /// <returns>An object whose value is the current UTC date and time.</returns>
        /// <filterpriority>1</filterpriority>
        public DateTime UtcNow => DateTime.UtcNow;
    }
}