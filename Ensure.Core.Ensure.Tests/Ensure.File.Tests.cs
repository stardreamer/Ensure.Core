using System;
using Xunit;
using Ensure.Core.Ensure;
using System.Collections.Generic;
using System.IO;

namespace Ensure.Core.Ensure.Tests
{
    public class EnsureFileTests
    {
        [Fact]
        public void ShouldAlwaysWork()
        {
            Assert.True(true);
        }

        [Theory]
        [InlineData("../../../files/nonemptyfile.txt")]
        public void ShouldWorkWhenGoodValueIsPassedToIsNotEmpty(string filePath)
        {
            var ex = Record.Exception(() => Ensure.File.IsNotEmpty(nameof(filePath), filePath));
            Assert.Null(ex);
        }

        [Theory]
        [InlineData("../../../files/emptyfile.txt")]
        public void ShouldThrowExceptionWhenWrongValueWasPassedToIsNotEmpty(string filePath)
        {
            var ex = Assert.Throws<EnsureException>(() => Ensure.File.IsNotEmpty(nameof(filePath),filePath));
            Assert.True(ex.Message.Contains(nameof(filePath)) && ex.Message.Contains("empty"));
        }

        [Theory]
        [InlineData("../../../files/emptyfile.txt")]
        public void ShouldWorkWhenGoodValueIsPassedToIsEmpty(string filePath)
        {
            var ex = Record.Exception(() => Ensure.File.IsEmpty(nameof(filePath), filePath));
            Assert.Null(ex);
        }

        [Theory]
        [InlineData("../../../files/nonemptyfile.txt")]
        public void ShouldThrowExceptionWhenWrongValueWasPassedToIsEmpty(string filePath)
        {
            var ex = Assert.Throws<EnsureException>(() => Ensure.File.IsEmpty(nameof(filePath),filePath));
            Assert.True(ex.Message.Contains(nameof(filePath)) && ex.Message.Contains("empty"));
        }

        [Theory]
        [InlineData("../../../files/nonemptyfile.txt")]
        public void ShouldWorkWhenGoodValueIsPassedToExists(string filePath)
        {
            var ex = Record.Exception(() => Ensure.File.Exists(nameof(filePath), filePath));
            Assert.Null(ex);
        }

        [Theory]
        [InlineData("../../../files/nonexisting.txt")]
        public void ShouldThrowExceptionWhenWrongValueWasPassedToExists(string filePath)
        {
            var ex = Assert.Throws<EnsureException>(() => Ensure.File.Exists(nameof(filePath),filePath));
            Assert.True(ex.Message.Contains(nameof(filePath)) && ex.Message.Contains("exist"));
        }

        [Theory]
        [InlineData("../../../files/filewithoutblanklines.txt")]
        public void ShouldWorkWhenGoodValueIsPassedToDoesNotContainBlankLines(string filePath)
        {
            var ex = Record.Exception(() => Ensure.File.DoesNotContainBlankLines(nameof(filePath), filePath));
            Assert.Null(ex);
        }

        [Theory]
        [InlineData("../../../files/filewithblanklines.txt")]
        public void ShouldThrowExceptionWhenWrongValueWasPassedToDoesNotContainBlankLines(string filePath)
        {
            var ex = Assert.Throws<EnsureException>(() => Ensure.File.DoesNotContainBlankLines(nameof(filePath),filePath));
            Assert.True(ex.Message.Contains(nameof(filePath)));
        }
    }
}