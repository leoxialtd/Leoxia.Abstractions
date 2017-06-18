using Leoxia.Abstractions.IO;
using Moq;
using Xunit;

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
        private int _count = 0;

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