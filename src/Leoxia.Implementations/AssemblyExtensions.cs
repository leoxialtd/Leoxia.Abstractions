using System.Reflection;
using Leoxia.Abstractions;

namespace Leoxia.Implementations
{
    /// <summary>
    /// Extension method for wrapping assemblies.
    /// </summary>
    public static class AssemblyExtensions
    {
        /// <summary>
        /// Wraps the specified assembly into the testable interface.
        /// </summary>
        /// <param name="assembly">The assembly.</param>
        /// <returns></returns>
        public static IAssembly Wrap(this Assembly assembly)
        {
            return new AsssemblyAdapter(assembly);
        }
    }
}