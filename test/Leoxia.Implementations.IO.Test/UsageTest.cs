#region Copyright (c) 2017 Leoxia Ltd

// --------------------------------------------------------------------------------------------------------------------
// <copyright file="UsageTest.cs" company="Leoxia Ltd">
//    Copyright (c) 2017 Leoxia Ltd
// </copyright>
// 
// .NET Software Development
// https://www.leoxia.com
// Build. Tomorrow. Together
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

using Leoxia.Abstractions.IO;
using Moq;
using Xunit;

#endregion

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