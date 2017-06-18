#region Copyright (c) 2017 Leoxia Ltd

// --------------------------------------------------------------------------------------------------------------------
// <copyright file="StreamReaderUsageTest.cs" company="Leoxia Ltd">
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
    public class FileLineCounter
    {
        private readonly IFile _fileSystem;

        public FileLineCounter(IFile fileSystem)
        {
            _fileSystem = fileSystem;
        }

        public int CountLines(string fileName)
        {
            using (var reader = _fileSystem.OpenText(fileName))
            {
                var count = -1;
                string line;
                do
                {
                    count++;
                    line = reader.ReadLine();
                } while (line != null);
                return count;
            }
        }
    }

    public class StreamReaderUsageTest
    {
        private int _count;

        [Fact]
        public void Check_Lines_Count_Is_Equal_To_42()
        {
            var streamMock = new Mock<IStreamReader>();
            streamMock.Setup(s => s.ReadLine()).Returns(() => LineGetter(42));
            var streamReader = streamMock.Object;
            var fileSystemMock = new Mock<IFile>(MockBehavior.Strict);
            fileSystemMock.Setup(f => f.OpenText("myFile")).Returns(streamReader);
            var fileSystem = fileSystemMock.Object;
            var myCounter = new FileLineCounter(fileSystem);
            Assert.Equal(42, myCounter.CountLines("myFile"));
        }

        [Fact]
        public void Check_Lines_Count_Is_Equal_To_0()
        {
            var streamMock = new Mock<IStreamReader>();
            streamMock.Setup(s => s.ReadLine()).Returns(() => LineGetter(0));
            var streamReader = streamMock.Object;
            var fileSystemMock = new Mock<IFile>(MockBehavior.Strict);
            fileSystemMock.Setup(f => f.OpenText("myFile")).Returns(streamReader);
            var fileSystem = fileSystemMock.Object;
            var myCounter = new FileLineCounter(fileSystem);
            Assert.Equal(0, myCounter.CountLines("myFile"));
        }

        private string LineGetter(int maxCount)
        {
            if (_count >= maxCount)
            {
                return null;
            }
            _count++;
            return string.Empty;
        }
    }
}