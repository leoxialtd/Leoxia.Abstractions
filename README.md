# Leoxia.Abstractions
Abstractions for Assembly, Console, File, FileInfo and other static classes or static methods not mockable.

## Packages are available on Nuget.org

[Leoxia.Abstractions Package](https://www.nuget.org/packages/Leoxia.Abstractions/)

## Specificities

- All abstractions are interfaces as we don't expect abstractions to have any behavior (not even the fancy implicit cast). 
We don't want the abstractions to be secretely casted to another "not-so-abstract" type under the hood.
- We use a convenient extension method Adap() to adap all classes instances intended to be adapted to the mockable interface. See [Design Pattern Adapter](https://en.wikipedia.org/wiki/Adapter_pattern)
- Abstractions are in the separate library. Implementations are in another.
- If abstractions are interfaces, they don't need to be tested.
- We don't provide any kind of test tools. Use a mock library instead.
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

## Usage 

With the following code:

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

And the test class :

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

Note: The best is to avoid reference the implementations outside of the main program (which does the IOC resolution of interfaces to classes).

## Credits

Thanks to https://github.com/tathamoddie/System.IO.Abstractions which was a good source of inspiration for this library.
