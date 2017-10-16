using System;
using Xunit;
using Ensure.Core.Ensure;

namespace Ensure.Core.Ensure.Tests
{
    public class EnsureTests
    {
        [Fact]
        public void ShouldAlwaysWork()
        {
            Assert.True(true);
        }

        [Fact]
        public void ShouldThrowExceptionWhenWrongValueWasPassedToIsPositive()
        {
            var testValue = -11;
            var ex = Assert.Throws<EnsureException>(() => Ensure.IsPositive(nameof(testValue),testValue));
            Assert.True(ex.Message.Contains(nameof(testValue)) && ex.Message.Contains("positive"));
        }

        [Fact]
        public void ShouldThrowExceptionWhenWrongValueWasPassedToIsNonNegative()
        {
            var testValue = -11;
            var ex = Assert.Throws<EnsureException>(() => Ensure.IsNonNegative(nameof(testValue),testValue));
            Assert.True(ex.Message.Contains(nameof(testValue)) && ex.Message.Contains("nonnegative"));
        }

        [Fact]
        public void ShouldThrowExceptionWhenWrongValueWasPassedToIsNegative()
        {
            var testValue = 11;
            var ex = Assert.Throws<EnsureException>(() => Ensure.IsNegative(nameof(testValue),testValue));
            Assert.True(ex.Message.Contains(nameof(testValue)) && ex.Message.Contains("negative"));
        }

        [Fact]
        public void ShouldThrowExceptionWhenWrongValueWasPassedToIsNonPositive()
        {
            var testValue = 11;
            var ex = Assert.Throws<EnsureException>(() => Ensure.IsNonPositive(nameof(testValue),testValue));
            Assert.True(ex.Message.Contains(nameof(testValue)) && ex.Message.Contains("nonpositive"));
        }

        [Fact]
        public void ShouldThrowExceptionWhenNullValueIsPassedToIsNotNull()
        {
            object testValue = null;
            var ex = Assert.Throws<EnsureException>(() => Ensure.IsNotNull(nameof(testValue),testValue));
            Assert.True(ex.Message.Contains(nameof(testValue)) && ex.Message.Contains("null"));
        }

        [Fact]
        public void ShouldThrowExceptionWhenNullStringIsPassedToIsNotNullOrEmpty()
        {
            string testValue = null;
            var ex = Assert.Throws<EnsureException>(() => Ensure.IsNotNullOrEmpty(nameof(testValue),testValue));
            Assert.True(ex.Message.Contains(nameof(testValue)) && ex.Message.Contains("null"));
        }

        [Fact]
        public void ShouldThrowExceptionWhenEmptyStringIsPassedToIsNotNullOrEmpty()
        {
            string testValue = "";
            var ex = Assert.Throws<EnsureException>(() => Ensure.IsNotNullOrEmpty(nameof(testValue),testValue));
            Assert.True(ex.Message.Contains(nameof(testValue)) && ex.Message.Contains("empty"));
        }

        [Fact]
        public void ShouldThrowExceptionWhenNotExistingFileWasPassedToFileExists()
        {
            var wrongPath = "notexistingpath/notexistingfile";
            var ex = Assert.Throws<EnsureException>(() => Ensure.FileExists(nameof(wrongPath),wrongPath));
            Assert.True(ex.Message.Contains(nameof(wrongPath)) && ex.Message.Contains("exist"));
        }


    }
}
