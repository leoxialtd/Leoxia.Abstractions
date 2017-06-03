namespace Leoxia.Abstractions
{
    /// <summary>
    /// Interface for Clone method that only clone properties.
    /// </summary>
    /// <typeparam name="T">Type of cloned object</typeparam>
    public interface IShallowCloneable<T>
    {
        /// <summary>
        /// Clones this instance.
        /// </summary>
        /// <returns></returns>
        T Clone();
    }

    /// <summary>
    /// Interface for Clone method that only clone properties.
    /// </summary>
    public interface IShallowCloneable
    {
        /// <summary>
        /// Clones this instance.
        /// </summary>
        /// <returns></returns>
        object Clone();
    }
}
