using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;

namespace Leoxia.Abstractions
{
    /// <summary>
    /// Abstraction over Assembly
    /// </summary>
    public interface IAssembly
    {
        /// <summary>
        /// Gets the code base.
        /// </summary>
        /// <value>
        /// The code base.
        /// </value>
        string CodeBase { get; }

        /// <summary>Gets a collection that contains this assembly's custom attributes.</summary>
        /// <returns>A collection that contains this assembly's custom attributes.</returns>
        IEnumerable<CustomAttributeData> CustomAttributes { get; }

        /// <summary>Gets a collection of the types defined in this assembly.</summary>
        /// <returns>A collection of the types defined in this assembly.</returns>
        IEnumerable<TypeInfo> DefinedTypes { get; }

        /// <summary>
        /// Gets the entry point.
        /// </summary>
        /// <value>
        /// The entry point.
        /// </value>
        MethodInfo EntryPoint { get; }

        /// <summary>Gets a collection of the public types defined in this assembly that are visible outside the assembly.</summary>
        /// <returns>A collection of the public types defined in this assembly that are visible outside the assembly.</returns>
        IEnumerable<Type> ExportedTypes { get; }

        /// <summary>Gets the display name of the assembly.</summary>
        /// <returns>The display name of the assembly.</returns>
        string FullName { get; }

        /// <summary>
        /// Gets the image runtime version.
        /// </summary>
        /// <value>
        /// The image runtime version.
        /// </value>
        string ImageRuntimeVersion { get; }

        /// <summary>Gets a value that indicates whether the current assembly was generated dynamically in the current process by using reflection emit.</summary>
        /// <returns>true if the current assembly was generated dynamically in the current process; otherwise, false.</returns>
        bool IsDynamic { get; }

        /// <summary>
        /// Gets the location.
        /// </summary>
        /// <value>
        /// The location.
        /// </value>
        string Location { get; }

        /// <summary>Gets the module that contains the manifest for the current assembly. </summary>
        /// <returns>The module that contains the manifest for the assembly. </returns>
        Module ManifestModule { get; }

        /// <summary>Gets a collection that contains the modules in this assembly.</summary>
        /// <returns>A collection that contains the modules in this assembly.</returns>
        IEnumerable<Module> Modules { get; }

        /// <summary>
        /// Creates the instance.
        /// </summary>
        /// <param name="typeName">Name of the type.</param>
        /// <returns></returns>
        object CreateInstance(string typeName);
        /// <summary>
        /// Creates the instance.
        /// </summary>
        /// <param name="typeName">Name of the type.</param>
        /// <param name="ignoreCase">if set to <c>true</c> [ignore case].</param>
        /// <returns></returns>
        object CreateInstance(string typeName, bool ignoreCase);
        /// <summary>
        /// Gets the custom attributes.
        /// </summary>
        /// <param name="inherit">if set to <c>true</c> [inherit].</param>
        /// <returns></returns>
        object[] GetCustomAttributes(bool inherit);
        /// <summary>
        /// Gets the custom attributes.
        /// </summary>
        /// <param name="attributeType">Type of the attribute.</param>
        /// <param name="inherit">if set to <c>true</c> [inherit].</param>
        /// <returns></returns>
        object[] GetCustomAttributes(Type attributeType, bool inherit);
        /// <summary>
        /// Gets the exported types.
        /// </summary>
        /// <returns></returns>
        Type[] GetExportedTypes();

        /// <summary>Returns information about how the given resource has been persisted.</summary>
        /// <returns>An object that is populated with information about the resource's topology, or null if the resource is not found.</returns>
        /// <param name="resourceName">The case-sensitive name of the resource. </param>
        /// <exception cref="T:System.ArgumentNullException">
        /// <paramref name="resourceName" /> is null. </exception>
        /// <exception cref="T:System.ArgumentException">The <paramref name="resourceName" /> parameter is an empty string (""). </exception>
        ManifestResourceInfo GetManifestResourceInfo(string resourceName);

        /// <summary>Returns the names of all the resources in this assembly.</summary>
        /// <returns>An array that contains the names of all the resources.</returns>
        string[] GetManifestResourceNames();

        /// <summary>Loads the specified manifest resource from this assembly.</summary>
        /// <returns>The manifest resource; or null if no resources were specified during compilation or if the resource is not visible to the caller.</returns>
        /// <param name="name">The case-sensitive name of the manifest resource being requested. </param>
        /// <exception cref="T:System.ArgumentNullException">The <paramref name="name" /> parameter is null. </exception>
        /// <exception cref="T:System.ArgumentException">The <paramref name="name" /> parameter is an empty string (""). </exception>
        /// <exception cref="T:System.IO.FileLoadException">In the .NET for Windows Store apps or the Portable Class Library, catch the base class exception, <see cref="T:System.IO.IOException" />, instead.A file that was found could not be loaded. </exception>
        /// <exception cref="T:System.IO.FileNotFoundException">
        /// <paramref name="name" /> was not found. </exception>
        /// <exception cref="T:System.BadImageFormatException">
        /// <paramref name="name" /> is not a valid assembly. </exception>
        /// <exception cref="T:System.NotImplementedException">Resource length is greater than <see cref="F:System.Int64.MaxValue" />.</exception>
        Stream GetManifestResourceStream(string name);

        /// <summary>Gets an <see cref="T:System.Reflection.AssemblyName" /> for this assembly.</summary>
        /// <returns>An object that contains the fully parsed display name for this assembly.</returns>
        /// <PermissionSet>
        ///   <IPermission class="System.Security.Permissions.FileIOPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" />
        /// </PermissionSet>
        AssemblyName GetName();

        /// <summary>
        /// Gets the referenced assemblies.
        /// </summary>
        /// <returns></returns>
        AssemblyName[] GetReferencedAssemblies();
        /// <summary>
        /// Gets the type.
        /// </summary>
        /// <param name="name">The name.</param>
        /// <param name="throwOnError">if set to <c>true</c> [throw on error].</param>
        /// <returns></returns>
        Type GetType(string name, bool throwOnError);

        /// <summary>Gets the <see cref="T:System.Type" /> object with the specified name in the assembly instance, with the options of ignoring the case, and of throwing an exception if the type is not found.</summary>
        /// <returns>An object that represents the specified class.</returns>
        /// <param name="name">The full name of the type. </param>
        /// <param name="throwOnError">true to throw an exception if the type is not found; false to return null. </param>
        /// <param name="ignoreCase">true to ignore the case of the type name; otherwise, false. </param>
        /// <exception cref="T:System.ArgumentException">
        /// <paramref name="name" /> is invalid.-or- The length of <paramref name="name" /> exceeds 1024 characters. </exception>
        /// <exception cref="T:System.ArgumentNullException">
        /// <paramref name="name" /> is null. </exception>
        /// <exception cref="T:System.TypeLoadException">
        /// <paramref name="throwOnError" /> is true, and the type cannot be found.</exception>
        /// <exception cref="T:System.IO.FileNotFoundException">
        /// <paramref name="name" /> requires a dependent assembly that could not be found. </exception>
        /// <exception cref="T:System.IO.FileLoadException">
        /// <paramref name="name" /> requires a dependent assembly that was found but could not be loaded.-or-The current assembly was loaded into the reflection-only context, and <paramref name="name" /> requires a dependent assembly that was not preloaded. </exception>
        /// <exception cref="T:System.BadImageFormatException">
        /// <paramref name="name" /> requires a dependent assembly, but the file is not a valid assembly. -or-<paramref name="name" /> requires a dependent assembly which was compiled for a version of the runtime later than the currently loaded version.</exception>
        Type GetType(string name, bool throwOnError, bool ignoreCase);

        /// <summary>Gets the <see cref="T:System.Type" /> object with the specified name in the assembly instance.</summary>
        /// <returns>An object that represents the specified class, or null if the class is not found.</returns>
        /// <param name="name">The full name of the type. </param>
        /// <exception cref="T:System.ArgumentException">
        /// <paramref name="name" /> is invalid. </exception>
        /// <exception cref="T:System.ArgumentNullException">
        /// <paramref name="name" /> is null. </exception>
        /// <exception cref="T:System.IO.FileNotFoundException">
        /// <paramref name="name" /> requires a dependent assembly that could not be found. </exception>
        /// <exception cref="T:System.IO.FileLoadException">In the .NET for Windows Store apps or the Portable Class Library, catch the base class exception, <see cref="T:System.IO.IOException" />, instead.<paramref name="name" /> requires a dependent assembly that was found but could not be loaded.-or-The current assembly was loaded into the reflection-only context, and <paramref name="name" /> requires a dependent assembly that was not preloaded. </exception>
        /// <exception cref="T:System.BadImageFormatException">
        /// <paramref name="name" /> requires a dependent assembly, but the file is not a valid assembly. -or-<paramref name="name" /> requires a dependent assembly which was compiled for a version of the runtime later than the currently loaded version. </exception>
        Type GetType(string name);

        /// <summary>
        /// Gets the types.
        /// </summary>
        /// <returns></returns>
        Type[] GetTypes();
        /// <summary>
        /// Determines whether the specified attribute type is defined.
        /// </summary>
        /// <param name="attributeType">Type of the attribute.</param>
        /// <param name="inherit">if set to <c>true</c> [inherit].</param>
        /// <returns>
        ///   <c>true</c> if the specified attribute type is defined; otherwise, <c>false</c>.
        /// </returns>
        bool IsDefined(Type attributeType, bool inherit);

        /// <summary>Loads an assembly given its <see cref="T:System.Reflection.AssemblyName" />.</summary>
        /// <returns>The loaded assembly.</returns>
        /// <param name="assemblyRef">The object that describes the assembly to be loaded. </param>
        /// <exception cref="T:System.ArgumentNullException">
        /// <paramref name="assemblyRef" /> is null. </exception>
        /// <exception cref="T:System.IO.FileNotFoundException">
        /// <paramref name="assemblyRef" /> is not found. </exception>
        /// <exception cref="T:System.IO.FileLoadException">In the .NET for Windows Store apps or the Portable Class Library, catch the base class exception, <see cref="T:System.IO.IOException" />, instead.A file that was found could not be loaded. </exception>
        /// <exception cref="T:System.BadImageFormatException">
        /// <paramref name="assemblyRef" /> is not a valid assembly. -or-Version 2.0 or later of the common language runtime is currently loaded and <paramref name="assemblyRef" /> was compiled with a later version.</exception>
        /// <PermissionSet>
        ///   <IPermission class="System.Security.Permissions.FileIOPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Read="*AllFiles*" PathDiscovery="*AllFiles*" />
        /// </PermissionSet>
        IAssembly Load(AssemblyName assemblyRef);

        /// <summary>
        /// Gets the entry assembly.
        /// </summary>
        /// <returns></returns>
        IAssembly GetEntryAssembly();

        /// <summary>
        /// Creates the name of the qualified.
        /// </summary>
        /// <param name="assemblyName">Name of the assembly.</param>
        /// <param name="typeName">Name of the type.</param>
        /// <returns></returns>
        string CreateQualifiedName(string assemblyName, string typeName);
    }
}