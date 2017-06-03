using System;

namespace Leoxia.Abstractions
{
    /// <summary>
    /// Interface of abstractions of time.
    /// </summary>
    public interface ITimeProvider
    {
        /// <summary>Gets a <see cref="T:System.DateTime" /> object that is set to the current date and time on this computer, expressed as the local time.</summary>
        /// <returns>An object whose value is the current local date and time.</returns>
        /// <filterpriority>1</filterpriority>
        DateTime Now { get; }

        /// <summary>Gets the current date.</summary>
        /// <returns>An object that is set to today's date, with the time component set to 00:00:00.</returns>
        /// <filterpriority>1</filterpriority>
        DateTime Today { get; }

        /// <summary>Gets a <see cref="T:System.DateTime" /> object that is set to the current date and time on this computer, expressed as the Coordinated Universal Time (UTC).</summary>
        /// <returns>An object whose value is the current UTC date and time.</returns>
        /// <filterpriority>1</filterpriority>
        DateTime UtcNow { get; }
    }
}
