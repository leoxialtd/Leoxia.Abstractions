# Leoxia.Abstractions
Abstractions for Assembly, Console, File, FileInfo and other static classes or static methods not mockable.

[![.NET Core](https://img.shields.io/badge/Build_For-.NetCore-5C2D91.svg)](https://www.microsoft.com/net/core#windowsvs2017)

[![.NET Standard](https://img.shields.io/badge/Build_For-.NetStandard-0073AE.svg)](https://docs.microsoft.com/en-us/dotnet/standard/net-standard)

## Original repository

This repository is a clone of [Leoxia.Abstractions on GitLab](https://gitlab.leoxia.com/leoxia/Leoxia.Abstractions)

## Build status

OS  | Compiler | Status 
-------- | :------------ | :------------ 
Windows | Visual Studio 2017 | [![Build status](https://ci.appveyor.com/api/projects/status/dv2p17pi7aqq4mj5?svg=true)](https://ci.appveyor.com/project/leoxialtd/leoxia-abstractions)

## Packages 

Package  | NuGet 
-------- | :------------ 
[Leoxia.Abstractions](https://github.com/leoxialtd/Leoxia.Abstractions/tree/master/src/Leoxia.Abstractions) | [![NuGet version](https://badge.fury.io/nu/Leoxia.Abstractions.svg)](https://www.nuget.org/packages/Leoxia.Abstractions/)
[Leoxia.Abstractions.Diagnostics](https://github.com/leoxialtd/Leoxia.Abstractions/tree/master/src/Leoxia.Abstractions.Diagnostics) | [![NuGet version](https://badge.fury.io/nu/Leoxia.Abstractions.Diagnostics.svg)](https://www.nuget.org/packages/Leoxia.Abstractions.Diagnostics/)
[Leoxia.Abstractions.IO](https://github.com/leoxialtd/Leoxia.Abstractions/tree/master/src/Leoxia.Abstractions.IO) | [![NuGet version](https://badge.fury.io/nu/Leoxia.Abstractions.IO.svg)](https://www.nuget.org/packages/Leoxia.Abstractions.IO/)
[Leoxia.Abstractions.IO.FileSystem.DriveInfo](https://github.com/leoxialtd/Leoxia.Abstractions/tree/master/src/Leoxia.Abstractions.IO.FileSystem.DriveInfo) | [![NuGet version](https://badge.fury.io/nu/Leoxia.Abstractions.IO.FileSystem.DriveInfo.svg)](https://www.nuget.org/packages/Leoxia.Abstractions.IO.FileSystem.DriveInfo/)
[Leoxia.Abstractions.IO.FileSystem.Watcher](https://github.com/leoxialtd/Leoxia.Abstractions/tree/master/src/Leoxia.Abstractions.IO.FileSystem.Watcher) | [![NuGet version](https://badge.fury.io/nu/Leoxia.Abstractions.IO.FileSystem.Watcher.svg)](https://www.nuget.org/packages/Leoxia.Abstractions.IO.FileSystem.Watcher/)
[Leoxia.Implementations](https://github.com/leoxialtd/Leoxia.Abstractions/tree/master/src/Leoxia.Implementations) | [![NuGet version](https://badge.fury.io/nu/Leoxia.Implementations.svg)](https://www.nuget.org/packages/Leoxia.Implementations/)
[Leoxia.Implementations.Diagnostics](https://github.com/leoxialtd/Leoxia.Abstractions/tree/master/src/Leoxia.Implementations.Diagnostics) | [![NuGet version](https://badge.fury.io/nu/Leoxia.Implementations.Diagnostics.svg)](https://www.nuget.org/packages/Leoxia.Implementations.Diagnostics/)
[Leoxia.Implementations.IO](https://github.com/leoxialtd/Leoxia.Abstractions/tree/master/src/Leoxia.Implementations.IO) | [![NuGet version](https://badge.fury.io/nu/Leoxia.Implementations.IO.svg)](https://www.nuget.org/packages/Leoxia.Implementations.IO/)
[Leoxia.Implementations.IO.FileSystem.DriveInfo](https://github.com/leoxialtd/Leoxia.Abstractions/tree/master/src/Leoxia.Implementations.IO.FileSystem.DriveInfo) | [![NuGet version](https://badge.fury.io/nu/Leoxia.Implementations.IO.FileSystem.DriveInfo.svg)](https://www.nuget.org/packages/Leoxia.Implementations.IO.FileSystem.DriveInfo/)
[Leoxia.Implementations.IO.FileSystem.Watcher](https://github.com/leoxialtd/Leoxia.Abstractions/tree/master/src/Leoxia.Implementations.IO.FileSystem.Watcher) | [![NuGet version](https://badge.fury.io/nu/Leoxia.Implementations.IO.FileSystem.Watcher.svg)](https://www.nuget.org/packages/Leoxia.Implementations.IO.FileSystem.Watcher/)
[Leoxia.Implementations.Time](https://github.com/leoxialtd/Leoxia.Abstractions/tree/master/src/Leoxia.Implementations.Time) | [![NuGet version](https://badge.fury.io/nu/Leoxia.Implementations.Time.svg)](https://www.nuget.org/packages/Leoxia.Implementations.Time/)

## Specificities

- All abstractions are interfaces as we don't expect abstractions to have any behavior (not even the fancy implicit cast). 
We don't want the abstractions to be secretely casted to another "not-so-abstract" type under the hood.
- We use a convenient extension method Adap() to adap all classes instances intended to be adapted to the mockable interface. See [Design Pattern Adapter](https://en.wikipedia.org/wiki/Adapter_pattern)
- Abstractions are in the separate library. Implementations are in another.
- If abstractions are interfaces, they don't need to be tested.
- We don't provide any kind of test tools. Use a mock library instead, like [Moq](https://github.com/Moq/moq4/wiki/Quickstart)
- We use a library name because it's not part of the framework and we don't want any namespace conflicts.
Furthermore we followed the namespace policy : https://msdn.microsoft.com/en-us/library/ms229026(v=vs.110).aspx
ie:	`[CompanyName].[ProductName].[Something_That_Follow_The_Other_Rules]`
- Implementations are generated through [Resharper](https://www.jetbrains.com/resharper/) delegating members function.
- Abstractions and implementations are .NET Standard Libraries.
- Documentation of framework is copied as it is important for developpers who use intellisense to still have a clear view
on what the framework will do for each calls, especially in case of Exception, and parameter expectations.
- Everything is public so everything is testable. 
- There is no god class FileSystem :). Each interface is named and surfaced with the related underlying framework class : IFile for File,
IFileInfo for FileInfo, etc... You can use Build method or IFileInfoFactory and IDirectoryInfoFactory to build related abstractions above files and directory.

## Additional Notes

Microsoft has released a IFileInfo which a [much reduced interface](https://docs.microsoft.com/en-us/aspnet/core/api/microsoft.extensions.fileproviders.ifileinfo) and very different for the surface of FileInfo which poses several problems:

- If your program need to access to unexposed properties, you cannot do so. You are very likely to run into this issue especially if you are migrating from FileInfo to an abstraction of it.
- Current IFileInfo exposes only read stream. So you cannot write in files with this interface, which is a pretty common usecase.
- The IsDirectory property tells us that IFileInfo represents either directory or file which is a different approach from core framework where FileInfo and DirectoryInfo refers to either file or directory (with FileSystemInfo as a base class).
- The implementation of such a transformed interface brings inherently a testability issue of the implementation itself. Because the implementation is not trivial (or autogenerated like in this library) and then not needing any tests, implementation of the transformaed interface should be tested. But it cannot be done with unit tests, only with integration tests. This is not really a problem for integrators, but more for Microsoft architects. By the way, it just make us wondering why to provide a IFileInfo surface which is different from FileInfo one.

## Usage 

With the following code:

```csharp
    public class MyClass
    {
        private readonly IFile _fileSystem;
        private readonly IConfigurationFileInitializer _initializer;

        public MyClass(IFile fileSystem, IConfigurationFileInitializer initializer)
        {
            _fileSystem = fileSystem;
            _initializer = initializer;
        }

        public string Init(string fileName)
        {
            if (!_fileSystem.Exists(fileName))
            {
                return _initializer.Init(fileName);
            }
            return null;
        }
    }

    public interface IConfigurationFileInitializer
    {
        string Init(string fileName);
    }
```

And the test class :

```csharp
    public class UsageTest
    {
        [Fact]
        public void Check_Init_When_File_Doesnt_Exist()
        {
            var initializerMock = new Mock<IConfigurationFileInitializer>(MockBehavior.Strict);
            initializerMock.Setup(x => x.Init("myFile")).Returns("fooBar");
            var initializer = initializerMock.Object;
            var fileSystemMock = new Mock<IFile>(MockBehavior.Strict);
            fileSystemMock.Setup(f => f.Exists("myFile")).Returns(false);
            var fileSystem = fileSystemMock.Object;
            var myClass = new MyClass(fileSystem, initializer);
            Assert.Equal("fooBar", myClass.Init("myFile"));
        }
    }
```

Note: The best is to avoid reference the implementations outside of the main program (which does the IOC resolution of interfaces to classes).

## Credits

Thanks to https://github.com/tathamoddie/System.IO.Abstractions which was a good source of inspiration for this library.
