using System;
using Xunit;
using Ensure.Core.Ensure;
using System.Collections.Generic;
using System.IO;
using System.Collections.Immutable;

namespace Ensure.Core.Ensure.Tests
{
    public class EnsureNumbersTests
    {
        public static IEnumerable<object[]> GetPositiveColletions
        {
            get
            {
                return new[] 
                {
                    new object[] { new List<double>() { 1 , 2 , 3 }},
                    new object[] {new List<double>() { 1 , 2.54, (float)3.2 }},
                };
            }
        }
        public static IEnumerable<object[]> GetNonNegativeColletions
        {
            get
            {
                return new[] 
                {
                    new object[] { new List<double>() { 0, 1, 2, 3 }},
                    new object[] {new List<double>() { 0, 1, 2.54, (float)3.2 }},
                    new object[] {new List<double>() { 1, 2.54, (float)3.2 }}
                };
            }
        }

        public static IEnumerable<object[]> GetNegativeColletions
        {
            get
            {
                return new[] 
                {
                    new object[] { new List<double>() {-1 ,-2 ,-3}},
                    new object[] {new List<double>() {-1 ,-2.54 ,(float)(-3.2)}},
                };
            }
        }

        public static IEnumerable<object[]> GetNonPositiveColletions
        {
            get
            {
                return new[] 
                {
                    new object[] { new List<double>() { 0, -1 ,-2 ,-3 }},
                    new object[] {new List<double>() { 0, -1 ,-2.54 ,(float)(-3.2) }},
                    new object[] {new List<double>() { -1 ,-2.54 ,(float)(-3.2) }}
                };
            }
        }
        public static IEnumerable<object[]> GetOddColletions
        {
            get
            {
                return new[] 
                {
                    new object[] { new List<int>() { 1, 3, 7}},
                    new object[] {new List<int>() { -1, -3, -7}},
                    new object[] {new List<int>() { 1, -3 , 7}}
                };
            }
        }

        public static IEnumerable<object[]> GetEvenColletions
        {
            get
            {
                return new[] 
                {
                    new object[] { new List<int>() { 0, 2, 6}},
                    new object[] {new List<int>() { 2, -6, 4}},
                    new object[] {new List<int>() { -2, -4, -6}}
                };
            }
        }


        [Fact]
        public void ShouldAlwaysWork()
        {
            Assert.True(true);
        }

        [Theory]
        [MemberData("GetPositiveColletions")]
        public void ShouldWorkWhenGoodValueIsPassedToArePositive(List<double> values)
        {
            var ex = Record.Exception(() => Ensure.Numbers.ArePositive(nameof(values),values));
            Assert.Null(ex);
        }

        [Theory]
        [MemberData("GetNonPositiveColletions")]
        public void ShouldThrowExceptionWhenWrongValueWasPassedToArePositive(List<double> values)
        {
            var ex = Assert.Throws<EnsureException>(() => Ensure.Numbers.ArePositive(nameof(values),values));
            Assert.True(ex.Message.Contains(nameof(values)) && ex.Message.Contains("positive"));
        }

        [Theory]
        [MemberData("GetNonNegativeColletions")]
        public void ShouldWorkWhenGoodValueIsPassedToAreNonNegative(List<double> values)
        {
            var ex = Record.Exception(() => Ensure.Numbers.AreNonNegative(nameof(values),values));
            Assert.Null(ex);
        }

        [Theory]
        [MemberData("GetNegativeColletions")]
        public void ShouldThrowExceptionWhenWrongValueWasPassedToAreNonNegative(List<double> values)
        {
            var ex = Assert.Throws<EnsureException>(() => Ensure.Numbers.AreNonNegative(nameof(values),values));
            Assert.True(ex.Message.Contains(nameof(values)) && ex.Message.Contains("nonnegative"));
        }

        [Theory]
        [MemberData("GetNegativeColletions")]
        public void ShouldWorkWhenGoodValueIsPassedToAreNegative(List<double> values)
        {
            var ex = Record.Exception(() => Ensure.Numbers.AreNegative(nameof(values),values));
            Assert.Null(ex);
        }


        [Theory]
        [MemberData("GetNonNegativeColletions")]
        public void ShouldThrowExceptionWhenWrongValueWasPassedToAreNegative(List<double> values)
        {
            var ex = Assert.Throws<EnsureException>(() => Ensure.Numbers.AreNegative(nameof(values),values));
            Assert.True(ex.Message.Contains(nameof(values)) && ex.Message.Contains("negative"));
        }

        [Theory]
        [MemberData("GetNonPositiveColletions")]
        public void ShouldWorkWhenGoodValueIsPassedToAreNonPositive(List<double> values)
        {
            var ex = Record.Exception(() => Ensure.Numbers.AreNonPositive(nameof(values), values));
            Assert.Null(ex);
        }

        [Theory]
        [MemberData("GetPositiveColletions")]
        public void ShouldThrowExceptionWhenWrongValueWasPassedToAreNonPositive(List<double> values)
        {
            var ex = Assert.Throws<EnsureException>(() => Ensure.Numbers.AreNonPositive(nameof(values),values));
            Assert.True(ex.Message.Contains(nameof(values)) && ex.Message.Contains("nonpositive"));
        }

        [Theory]
        [MemberData("GetEvenColletions")]
        public void ShouldThrowExceptionWhenWrongValueWasPassedToAreOdd(List<int> values)
        {
            var ex = Assert.Throws<EnsureException>(() => Ensure.Numbers.AreOdd(nameof(values),values));
            Assert.True(ex.Message.Contains(nameof(values)) && ex.Message.Contains("odd"));
        }

        [Theory]
        [MemberData("GetOddColletions")]
        public void ShouldThrowExceptionWhenWrongValueWasPassedToAreEven(List<int> values)
        {
            var ex = Assert.Throws<EnsureException>(() => Ensure.Numbers.AreEven(nameof(values),values));
            Assert.True(ex.Message.Contains(nameof(values)) && ex.Message.Contains("even"));
        }
    }
}