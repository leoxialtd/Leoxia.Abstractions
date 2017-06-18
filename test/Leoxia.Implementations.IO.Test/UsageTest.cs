using System;
using System.Collections.Generic;
using System.Text;
using Leoxia.Abstractions.IO;
using Moq;
using Xunit;

namespace Leoxia.Implementations.IO.Test
{
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
}
