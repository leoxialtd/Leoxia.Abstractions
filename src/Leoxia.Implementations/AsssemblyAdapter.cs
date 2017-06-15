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
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using Leoxia.Abstractions;

#endregion

namespace Leoxia.Implementations
{
    /// <summary>
    ///     Adapter for <see cref="Assembly" /> into <see cref="IAssembly" /> interface.
    /// </summary>
    /// <seealso cref="Leoxia.Abstractions.IAssembly" />
    public class AsssemblyAdapter : IAssembly
    {
        private readonly Assembly _assembly;

        /// <summary>
        ///     Initializes a new instance of the <see cref="AsssemblyAdapter" /> class.
        /// </summary>
        /// <param name="assembly">The assembly.</param>
        public AsssemblyAdapter(Assembly assembly)
        {
            _assembly = assembly;
        }

        /// <summary>
        ///     Gets the code base.
        /// </summary>
        /// <value>
        ///     The code base.
        /// </value>
        public string CodeBase => _assembly.CodeBase;

        /// <summary>
        ///     Creates the instance.
        /// </summary>
        /// <param name="typeName">Name of the type.</param>
        /// <returns></returns>
        public object CreateInstance(string typeName)
        {
            return _assembly.CreateInstance(typeName);
        }

        /// <summary>
        ///     Creates the instance.
        /// </summary>
        /// <param name="typeName">Name of the type.</param>
        /// <param name="ignoreCase">if set to <c>true</c> [ignore case].</param>
        /// <returns></returns>
        public object CreateInstance(string typeName, bool ignoreCase)
        {
            return _assembly.CreateInstance(typeName, ignoreCase);
        }

        /// <summary>Gets a collection that contains this assembly's custom attributes.</summary>
        /// <returns>A collection that contains this assembly's custom attributes.</returns>
        public IEnumerable<CustomAttributeData> CustomAttributes => _assembly.CustomAttributes;

        /// <summary>Gets a collection of the types defined in this assembly.</summary>
        /// <returns>A collection of the types defined in this assembly.</returns>
        public IEnumerable<TypeInfo> DefinedTypes => _assembly.DefinedTypes;

        /// <summary>
        ///     Gets the entry point.
        /// </summary>
        /// <value>
        ///     The entry point.
        /// </value>
        public MethodInfo EntryPoint => _assembly.EntryPoint;

        /// <summary>Gets a collection of the public types defined in this assembly that are visible outside the assembly.</summary>
        /// <returns>A collection of the public types defined in this assembly that are visible outside the assembly.</returns>
        public IEnumerable<Type> ExportedTypes => _assembly.ExportedTypes;

        /// <summary>Gets the display name of the assembly.</summary>
        /// <returns>The display name of the assembly.</returns>
        public string FullName => _assembly.FullName;

        /// <summary>
        ///     Gets the custom attributes.
        /// </summary>
        /// <param name="inherit">if set to <c>true</c> [inherit].</param>
        /// <returns></returns>
        public object[] GetCustomAttributes(bool inherit)
        {
            return ((ICustomAttributeProvider) _assembly).GetCustomAttributes(inherit);
        }

        /// <summary>
        ///     Gets the custom attributes.
        /// </summary>
        /// <param name="attributeType">Type of the attribute.</param>
        /// <param name="inherit">if set to <c>true</c> [inherit].</param>
        /// <returns></returns>
        public object[] GetCustomAttributes(Type attributeType, bool inherit)
        {
            return ((ICustomAttributeProvider) _assembly).GetCustomAttributes(attributeType, inherit);
        }

        /// <summary>
        ///     Gets the exported types.
        /// </summary>
        /// <returns></returns>
        public Type[] GetExportedTypes()
        {
            return _assembly.GetExportedTypes();
        }

        /// <summary>Returns information about how the given resource has been persisted.</summary>
        /// <returns>
        ///     An object that is populated with information about the resource's topology, or null if the resource is not
        ///     found.
        /// </returns>
        /// <param name="resourceName">The case-sensitive name of the resource. </param>
        /// <exception cref="T:System.ArgumentNullException">
        ///     <paramref name="resourceName" /> is null.
        /// </exception>
        /// <exception cref="T:System.ArgumentException">The <paramref name="resourceName" /> parameter is an empty string (""). </exception>
        public ManifestResourceInfo GetManifestResourceInfo(string resourceName)
        {
            return _assembly.GetManifestResourceInfo(resourceName);
        }

        /// <summary>Returns the names of all the resources in this assembly.</summary>
        /// <returns>An array that contains the names of all the resources.</returns>
        public string[] GetManifestResourceNames()
        {
            return _assembly.GetManifestResourceNames();
        }

        /// <summary>Loads the specified manifest resource from this assembly.</summary>
        /// <returns>
        ///     The manifest resource; or null if no resources were specified during compilation or if the resource is not
        ///     visible to the caller.
        /// </returns>
        /// <param name="name">The case-sensitive name of the manifest resource being requested. </param>
        /// <exception cref="T:System.ArgumentNullException">The <paramref name="name" /> parameter is null. </exception>
        /// <exception cref="T:System.ArgumentException">The <paramref name="name" /> parameter is an empty string (""). </exception>
        /// <exception cref="T:System.IO.FileLoadException">
        ///     In the .NET for Windows Store apps or the Portable Class Library, catch
        ///     the base class exception, <see cref="T:System.IO.IOException" />, instead.A file that was found could not be
        ///     loaded.
        /// </exception>
        /// <exception cref="T:System.IO.FileNotFoundException">
        ///     <paramref name="name" /> was not found.
        /// </exception>
        /// <exception cref="T:System.BadImageFormatException">
        ///     <paramref name="name" /> is not a valid assembly.
        /// </exception>
        /// <exception cref="T:System.NotImplementedException">
        ///     Resource length is greater than
        ///     <see cref="F:System.Int64.MaxValue" />.
        /// </exception>
        public Stream GetManifestResourceStream(string name)
        {
            return _assembly.GetManifestResourceStream(name);
        }

        /// <summary>Gets an <see cref="T:System.Reflection.AssemblyName" /> for this assembly.</summary>
        /// <returns>An object that contains the fully parsed display name for this assembly.</returns>
        /// <PermissionSet>
        ///     <IPermission
        ///         class="System.Security.Permissions.FileIOPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"
        ///         version="1" Unrestricted="true" />
        /// </PermissionSet>
        public AssemblyName GetName()
        {
            return _assembly.GetName();
        }

        /// <summary>
        ///     Gets the referenced assemblies.
        /// </summary>
        /// <returns></returns>
        public AssemblyName[] GetReferencedAssemblies()
        {
            return _assembly.GetReferencedAssemblies();
        }

        /// <summary>
        ///     Gets the type.
        /// </summary>
        /// <param name="name">The name.</param>
        /// <param name="throwOnError">if set to <c>true</c> [throw on error].</param>
        /// <returns></returns>
        public Type GetType(string name, bool throwOnError)
        {
            return _assembly.GetType(name, throwOnError);
        }

        /// <summary>
        ///     Gets the <see cref="T:System.Type" /> object with the specified name in the assembly instance, with the
        ///     options of ignoring the case, and of throwing an exception if the type is not found.
        /// </summary>
        /// <returns>An object that represents the specified class.</returns>
        /// <param name="name">The full name of the type. </param>
        /// <param name="throwOnError">true to throw an exception if the type is not found; false to return null. </param>
        /// <param name="ignoreCase">true to ignore the case of the type name; otherwise, false. </param>
        /// <exception cref="T:System.ArgumentException">
        ///     <paramref name="name" /> is invalid.-or- The length of <paramref name="name" /> exceeds 1024 characters.
        /// </exception>
        /// <exception cref="T:System.ArgumentNullException">
        ///     <paramref name="name" /> is null.
        /// </exception>
        /// <exception cref="T:System.TypeLoadException">
        ///     <paramref name="throwOnError" /> is true, and the type cannot be found.
        /// </exception>
        /// <exception cref="T:System.IO.FileNotFoundException">
        ///     <paramref name="name" /> requires a dependent assembly that could not be found.
        /// </exception>
        /// <exception cref="T:System.IO.FileLoadException">
        ///     <paramref name="name" /> requires a dependent assembly that was found but could not be loaded.-or-The current
        ///     assembly was loaded into the reflection-only context, and <paramref name="name" /> requires a dependent assembly
        ///     that was not preloaded.
        /// </exception>
        /// <exception cref="T:System.BadImageFormatException">
        ///     <paramref name="name" /> requires a dependent assembly, but the file is not a valid assembly. -or-
        ///     <paramref name="name" /> requires a dependent assembly which was compiled for a version of the runtime later than
        ///     the currently loaded version.
        /// </exception>
        public Type GetType(string name, bool throwOnError, bool ignoreCase)
        {
            return _assembly.GetType(name, throwOnError, ignoreCase);
        }

        /// <summary>Gets the <see cref="T:System.Type" /> object with the specified name in the assembly instance.</summary>
        /// <returns>An object that represents the specified class, or null if the class is not found.</returns>
        /// <param name="name">The full name of the type. </param>
        /// <exception cref="T:System.ArgumentException">
        ///     <paramref name="name" /> is invalid.
        /// </exception>
        /// <exception cref="T:System.ArgumentNullException">
        ///     <paramref name="name" /> is null.
        /// </exception>
        /// <exception cref="T:System.IO.FileNotFoundException">
        ///     <paramref name="name" /> requires a dependent assembly that could not be found.
        /// </exception>
        /// <exception cref="T:System.IO.FileLoadException">
        ///     In the .NET for Windows Store apps or the Portable Class Library, catch
        ///     the base class exception, <see cref="T:System.IO.IOException" />, instead.<paramref name="name" /> requires a
        ///     dependent assembly that was found but could not be loaded.-or-The current assembly was loaded into the
        ///     reflection-only context, and <paramref name="name" /> requires a dependent assembly that was not preloaded.
        /// </exception>
        /// <exception cref="T:System.BadImageFormatException">
        ///     <paramref name="name" /> requires a dependent assembly, but the file is not a valid assembly. -or-
        ///     <paramref name="name" /> requires a dependent assembly which was compiled for a version of the runtime later than
        ///     the currently loaded version.
        /// </exception>
        public Type GetType(string name)
        {
            return _assembly.GetType(name);
        }

        /// <summary>
        ///     Gets the types.
        /// </summary>
        /// <returns></returns>
        public Type[] GetTypes()
        {
            return _assembly.GetTypes();
        }

        /// <summary>
        ///     Gets the image runtime version.
        /// </summary>
        /// <value>
        ///     The image runtime version.
        /// </value>
        public string ImageRuntimeVersion => _assembly.ImageRuntimeVersion;

        /// <summary>
        ///     Determines whether the specified attribute type is defined.
        /// </summary>
        /// <param name="attributeType">Type of the attribute.</param>
        /// <param name="inherit">if set to <c>true</c> [inherit].</param>
        /// <returns>
        ///     <c>true</c> if the specified attribute type is defined; otherwise, <c>false</c>.
        /// </returns>
        public bool IsDefined(Type attributeType, bool inherit)
        {
            return ((ICustomAttributeProvider) _assembly).IsDefined(attributeType, inherit);
        }

        /// <summary>Loads an assembly given its <see cref="T:System.Reflection.AssemblyName" />.</summary>
        /// <returns>The loaded assembly.</returns>
        /// <param name="assemblyRef">The object that describes the assembly to be loaded. </param>
        /// <exception cref="T:System.ArgumentNullException">
        ///     <paramref name="assemblyRef" /> is null.
        /// </exception>
        /// <exception cref="T:System.IO.FileNotFoundException">
        ///     <paramref name="assemblyRef" /> is not found.
        /// </exception>
        /// <exception cref="T:System.IO.FileLoadException">
        ///     In the .NET for Windows Store apps or the Portable Class Library, catch
        ///     the base class exception, <see cref="T:System.IO.IOException" />, instead.A file that was found could not be
        ///     loaded.
        /// </exception>
        /// <exception cref="T:System.BadImageFormatException">
        ///     <paramref name="assemblyRef" /> is not a valid assembly. -or-Version 2.0 or later of the common language runtime is
        ///     currently loaded and <paramref name="assemblyRef" /> was compiled with a later version.
        /// </exception>
        /// <PermissionSet>
        ///     <IPermission
        ///         class="System.Security.Permissions.FileIOPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"
        ///         version="1" Read="*AllFiles*" PathDiscovery="*AllFiles*" />
        /// </PermissionSet>
        public IAssembly Load(AssemblyName assemblyRef)
        {
            return Assembly.Load(assemblyRef).Wrap();
        }

        /// <summary>
        ///     Gets the entry assembly.
        /// </summary>
        /// <returns></returns>
        public IAssembly GetEntryAssembly()
        {
            return Assembly.GetEntryAssembly().Wrap();
        }

        /// <summary>
        ///     Creates the name of the qualified.
        /// </summary>
        /// <param name="assemblyName">Name of the assembly.</param>
        /// <param name="typeName">Name of the type.</param>
        /// <returns></returns>
        public string CreateQualifiedName(string assemblyName, string typeName)
        {
            return Assembly.CreateQualifiedName(assemblyName, typeName);
        }

        /// <summary>
        ///     Gets a value that indicates whether the current assembly was generated dynamically in the current process by
        ///     using reflection emit.
        /// </summary>
        /// <returns>true if the current assembly was generated dynamically in the current process; otherwise, false.</returns>
        public bool IsDynamic => _assembly.IsDynamic;

        /// <summary>
        ///     Gets the location.
        /// </summary>
        /// <value>
        ///     The location.
        /// </value>
        public string Location => _assembly.Location;

        /// <summary>Gets the module that contains the manifest for the current assembly. </summary>
        /// <returns>The module that contains the manifest for the assembly. </returns>
        public Module ManifestModule => _assembly.ManifestModule;

        /// <summary>Gets a collection that contains the modules in this assembly.</summary>
        /// <returns>A collection that contains the modules in this assembly.</returns>
        public IEnumerable<Module> Modules => _assembly.Modules;
    }
}