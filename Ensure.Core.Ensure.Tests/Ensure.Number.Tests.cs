using System;
using Xunit;
using Ensure.Core.Ensure;
using System.Collections.Generic;
using System.IO;

namespace Ensure.Core.Ensure.Tests
{
    public class EnsureNumberTests
    {
        [Fact]
        public void ShouldAlwaysWork()
        {
            Assert.True(true);
        }

        [Theory]
        [InlineData(1)]
        [InlineData(2.23)]
        [InlineData(0.5)]
        [InlineData(1e-5)]
        [InlineData((float)15.45)]
        public void ShouldWorkWhenGoodValueIsPassedToIsPositive(double value)
        {
            var ex = Record.Exception(() => Ensure.Number.IsPositive(nameof(value),value));
            Assert.Null(ex);
        }

        [Theory]
        [InlineData(0)]
        [InlineData(-1)]
        [InlineData(-0.5)]
        [InlineData(-1e-5)]
        [InlineData((float)-15.45)]
        public void ShouldThrowExceptionWhenWrongValueWasPassedToIsPositive(double testValue)
        {
            var ex = Assert.Throws<EnsureException>(() => Ensure.Number.IsPositive(nameof(testValue),testValue));
            Assert.True(ex.Message.Contains(nameof(testValue)) && ex.Message.Contains("positive"));
        }

        [Theory]
        [InlineData(0)]
        [InlineData(1)]
        [InlineData(2.23)]
        [InlineData(0.5)]
        [InlineData(1e-5)]
        [InlineData((float)15.45)]
        public void ShouldWorkWhenGoodValueIsPassedToIsNonNegative(double testValue)
        {
            var ex = Record.Exception(() => Ensure.Number.IsNonNegative(nameof(testValue),testValue));
            Assert.Null(ex);
        }

        [Theory]
        [InlineData(-1)]
        [InlineData(-2.23)]
        [InlineData(-0.5)]
        [InlineData(-1e-5)]
        [InlineData((float)-15.45)]
        public void ShouldThrowExceptionWhenWrongValueWasPassedToIsNonNegative(double testValue)
        {
            var ex = Assert.Throws<EnsureException>(() => Ensure.Number.IsNonNegative(nameof(testValue),testValue));
            Assert.True(ex.Message.Contains(nameof(testValue)) && ex.Message.Contains("nonnegative"));
        }

        [Theory]
        [InlineData(-1)]
        [InlineData(-2.23)]
        [InlineData(-0.5)]
        [InlineData(-1e-5)]
        [InlineData((float)-15.45)]
        public void ShouldWorkWhenGoodValueIsPassedToIsNegative(double testValue)
        {
            var ex = Record.Exception(() => Ensure.Number.IsNegative(nameof(testValue),testValue));
            Assert.Null(ex);
        }


        [Theory]
        [InlineData(1)]
        [InlineData(2.23)]
        [InlineData(0.5)]
        [InlineData(1e-5)]
        [InlineData((float)15.45)]
        public void ShouldThrowExceptionWhenWrongValueWasPassedToIsNegative(double testValue)
        {
            var ex = Assert.Throws<EnsureException>(() => Ensure.Number.IsNegative(nameof(testValue),testValue));
            Assert.True(ex.Message.Contains(nameof(testValue)) && ex.Message.Contains("negative"));
        }

        [Theory]
        [InlineData(0)]
        [InlineData(-1)]
        [InlineData(-2.23)]
        [InlineData(-0.5)]
        [InlineData(-1e-5)]
        [InlineData((float)-15.45)]
        public void ShouldWorkWhenGoodValueIsPassedToIsNonPositive(double testValue)
        {
            var ex = Record.Exception(() => Ensure.Number.IsNonPositive(nameof(testValue), testValue));
            Assert.Null(ex);
        }

        [Theory]
        [InlineData(1)]
        [InlineData(2.23)]
        [InlineData(0.5)]
        [InlineData(1e-5)]
        [InlineData((float)15.45)]
        public void ShouldThrowExceptionWhenWrongValueWasPassedToIsNonPositive(double testValue)
        {
            var ex = Assert.Throws<EnsureException>(() => Ensure.Number.IsNonPositive(nameof(testValue),testValue));
            Assert.True(ex.Message.Contains(nameof(testValue)) && ex.Message.Contains("nonpositive"));
        }

        [Theory]
        [InlineData(0)]
        [InlineData(2)]
        [InlineData(4)]
        [InlineData(-2)]
        [InlineData(-4)]
        public void ShouldThrowExceptionWhenWrongValueWasPassedToIsOdd(int testValue)
        {
            var ex = Assert.Throws<EnsureException>(() => Ensure.Number.IsOdd(nameof(testValue),testValue));
            Assert.True(ex.Message.Contains(nameof(testValue)) && ex.Message.Contains("odd"));
        }

        [Theory]
        [InlineData(1)]
        [InlineData(3)]
        [InlineData(-1)]
        [InlineData(-3)]
        public void ShouldThrowExceptionWhenWrongValueWasPassedToIsEven(int testValue)
        {
            var ex = Assert.Throws<EnsureException>(() => Ensure.Number.IsEven(nameof(testValue),testValue));
            Assert.True(ex.Message.Contains(nameof(testValue)) && ex.Message.Contains("even"));
        }
    }
}