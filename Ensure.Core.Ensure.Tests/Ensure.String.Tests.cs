using System;
using Xunit;
using Ensure.Core.Ensure;
using System.Collections.Generic;
using System.IO;

namespace Ensure.Core.Ensure.Tests
{
    public class EnsureStringTests
    {
        [Theory]
        [InlineData("12")]
        [InlineData("   ")]
        public void ShouldWorkWhenGoodValueIsPassedToIsNotNullOrEmpty(string testValue)
        {
            var ex = Record.Exception(() => Ensure.String.IsNotNullOrEmpty(nameof(testValue), testValue));
            Assert.Null(ex);
        }

        [Theory]
        [InlineData(null)]
        [InlineData("")]
        public void ShouldThrowExceptionWhenNullStringIsPassedToIsNotNullOrEmpty(string testValue)
        {
            var ex = Assert.Throws<EnsureException>(() => Ensure.String.IsNotNullOrEmpty(nameof(testValue),testValue));
            Assert.True(ex.Message.Contains(nameof(testValue)) && (ex.Message.Contains("null") || ex.Message.Contains("empty")));
        }

        [Theory]
        [InlineData(null)]
        public void ShouldWorkWhenGoodValueIsPassedToIsNull(string testValue)
        {
            var ex = Record.Exception(() => Ensure.String.IsNull(nameof(testValue), testValue));
            Assert.Null(ex);
        }

        [Theory]
        [InlineData("")]
        [InlineData("12")]
        public void ShouldThrowExceptionWhenNullStringIsPassedToIsNull(string testValue)
        {
            var ex = Assert.Throws<EnsureException>(() => Ensure.String.IsNull(nameof(testValue),testValue));
            Assert.True(ex.Message.Contains(nameof(testValue)) && (ex.Message.Contains("null") || ex.Message.Contains("empty")));
        }

        [Theory]
        [InlineData("")]
        public void ShouldWorkWhenGoodValueIsPassedToIsEmpty(string testValue)
        {
            var ex = Record.Exception(() => Ensure.String.IsEmpty(nameof(testValue), testValue));
            Assert.Null(ex);
        }

        [Theory]
        [InlineData("12")]
        public void ShouldThrowExceptionWhenNullStringIsPassedToIsEmpty(string testValue)
        {
            var ex = Assert.Throws<EnsureException>(() => Ensure.String.IsEmpty(nameof(testValue),testValue));
            Assert.True(ex.Message.Contains(nameof(testValue)) && (ex.Message.Contains("null") || ex.Message.Contains("empty")));
        }
    }
}