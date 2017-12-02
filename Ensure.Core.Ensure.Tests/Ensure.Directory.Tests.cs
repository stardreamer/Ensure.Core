using Xunit;

namespace Ensure.Core.Ensure.Tests
{
    public class EnsureDirectoryTests
    {
        [Fact]
        public void ShouldAlwaysWork()
        {
            Assert.True(true);
        }

        [Theory]
        [InlineData("../../../files")]
        public void ShouldWorkWhenGoodValueIsPassedToIsNotEmpty(string directoryPath)
        {
            var ex = Record.Exception(() => Ensure.Directory.IsNotEmpty(nameof(directoryPath), directoryPath));
            Assert.Null(ex);
        }

        [Theory]
        [InlineData("../../../EmptyDirectory")]
        public void ShouldThrowExceptionWhenWrongValueWasPassedToIsNotEmpty(string directoryPath)
        {
            var ex = Assert.Throws<EnsureException>(() => Ensure.Directory.IsNotEmpty(nameof(directoryPath),directoryPath));
            Assert.True(ex.Message.Contains(nameof(directoryPath)) && ex.Message.Contains("empty"));
        }

        [Theory]
        [InlineData("../../../EmptyDirectory")]
        public void ShouldWorkWhenGoodValueIsPassedToIsEmpty(string directoryPath)
        {
            var ex = Record.Exception(() => Ensure.Directory.IsEmpty(nameof(directoryPath), directoryPath));
            Assert.Null(ex);
        }

        [Theory]
        [InlineData("../../../files")]
        public void ShouldThrowExceptionWhenWrongValueWasPassedToIsEmpty(string directoryPath)
        {
            var ex = Assert.Throws<EnsureException>(() => Ensure.Directory.IsEmpty(nameof(directoryPath),directoryPath));
            Assert.True(ex.Message.Contains(nameof(directoryPath)) && ex.Message.Contains("empty"));
        }

        [Theory]
        [InlineData("../../../files")]
        public void ShouldWorkWhenGoodValueIsPassedToExists(string directoryPath)
        {
            var ex = Record.Exception(() => Ensure.Directory.Exists(nameof(directoryPath), directoryPath));
            Assert.Null(ex);
        }

        [Theory]
        [InlineData("../../../nonexistingDirectory")]
        public void ShouldThrowExceptionWhenWrongValueWasPassedToExists(string directoryPath)
        {
            var ex = Assert.Throws<EnsureException>(() => Ensure.File.Exists(nameof(directoryPath),directoryPath));
            Assert.True(ex.Message.Contains(nameof(directoryPath)) && ex.Message.Contains("exist"));
        }
    }
}