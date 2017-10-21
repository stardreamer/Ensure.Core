using System;
using Xunit;
using Ensure.Core.Ensure;
using System.Collections.Generic;
using System.IO;

namespace Ensure.Core.Ensure.Tests
{
    public class EnsureTests
    {
        public static IEnumerable<object[]> GetObjects
        {
            get
            {
                return new[] 
                {
                    new object[] { new List<int>()},
                    new object[] {15},
                    new object[] {new object()},
                    new object[] {new Dictionary<double,double>()}
                };
            }
        }

        public static IEnumerable<object[]> GetEmptyCollections
        {
            get
            {
                return new[] 
                {
                    new object[] { new List<int>()},
                    new object[] {new List<float>()},
                    new object[] {new List<string>()},
                    new object[] {new object[] {}}
                };
            }
        }

        public static IEnumerable<object[]> GetNotEmptyCollections
        {
            get
            {
                return new[] 
                {
                    new object[] { new List<int>() {12} },
                    new object[] { new List<float>() {(float)23.5} },
                    new object[] { new List<string>() {"12"} },
                    new object[] { new object[] {"12"} }
                };
            }
        }

        public static IEnumerable<object[]> GetCustomFailedChecks
        {
            get
            {
                return new[] 
                {
                    new object[] { (Func<double, bool>)((v) => v>0), -1},
                    new object[] { (Func<double, bool>)((v) => v>0), 0},
                    new object[] { (Func<string, bool>)((v) => !string.IsNullOrEmpty(v)), (string) null},
                    new object[] { (Func<string, bool>)((v) => !string.IsNullOrEmpty(v)), ""}
                };
            }
        }
        public static IEnumerable<object[]> GetCustomPassedChecks
        {
            get
            {
                return new[] 
                {
                    new object[] { (Func<double, bool>)((v) => v>0), 10},
                    new object[] { (Func<double, bool>)((v) => v>0), 10.53},
                    new object[] { (Func<string, bool>)((v) => !string.IsNullOrEmpty(v)), "12"},
                    new object[] { (Func<string, bool>)((v) => !string.IsNullOrEmpty(v)), "   "}
                };
            }
        }

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
            var ex = Record.Exception(() => Ensure.IsPositive(nameof(value),value));
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
            var ex = Assert.Throws<EnsureException>(() => Ensure.IsPositive(nameof(testValue),testValue));
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
            var ex = Record.Exception(() => Ensure.IsNonNegative(nameof(testValue),testValue));
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
            var ex = Assert.Throws<EnsureException>(() => Ensure.IsNonNegative(nameof(testValue),testValue));
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
            var ex = Record.Exception(() => Ensure.IsNegative(nameof(testValue),testValue));
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
            var ex = Assert.Throws<EnsureException>(() => Ensure.IsNegative(nameof(testValue),testValue));
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
            var ex = Record.Exception(() => Ensure.IsNonPositive(nameof(testValue), testValue));
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
            var ex = Assert.Throws<EnsureException>(() => Ensure.IsNonPositive(nameof(testValue),testValue));
            Assert.True(ex.Message.Contains(nameof(testValue)) && ex.Message.Contains("nonpositive"));
        }

        [Theory]
        [MemberData("GetObjects")]
        public void ShouldWorkWhenGoodValueIsPassedToIsNotNull(object testValue)
        {
            var ex = Record.Exception(() => Ensure.IsNotNull(nameof(testValue), testValue));
            Assert.Null(ex);
        }

        [Fact]
        public void ShouldThrowExceptionWhenNullValueIsPassedToIsNotNull()
        {
            object testValue = null;
            var ex = Assert.Throws<EnsureException>(() => Ensure.IsNotNull(nameof(testValue),testValue));
            Assert.True(ex.Message.Contains(nameof(testValue)) && ex.Message.Contains("null"));
        }

        [Theory]
        [InlineData("12")]
        [InlineData("   ")]
        public void ShouldWorkWhenGoodValueIsPassedToIsNotNullOrEmpty(string testValue)
        {
            var ex = Record.Exception(() => Ensure.IsNotNullOrEmpty(nameof(testValue), testValue));
            Assert.Null(ex);
        }

        [Theory]
        [InlineData(null)]
        [InlineData("")]
        public void ShouldThrowExceptionWhenNullStringIsPassedToIsNotNullOrEmpty(string testValue)
        {
            var ex = Assert.Throws<EnsureException>(() => Ensure.IsNotNullOrEmpty(nameof(testValue),testValue));
            Assert.True(ex.Message.Contains(nameof(testValue)) && (ex.Message.Contains("null") || ex.Message.Contains("empty")));
        }

        [Theory]
        [InlineData("notexistingpath/notexistingfile")]
        [InlineData("")]
        [InlineData("12")]
        [InlineData(null)]
        public void ShouldThrowExceptionWhenNotExistingFileWasPassedToFileExists(string wrongPath)
        {
            var ex = Assert.Throws<EnsureException>(() => Ensure.FileExists(nameof(wrongPath),wrongPath));
            Assert.True(ex.Message.Contains(nameof(wrongPath)) && ex.Message.Contains("exist"));
        }


        [Theory]
        [MemberData("GetNotEmptyCollections")]
        public void ShouldWorkWhenNonEmptyCollectionIsGivenToIsNotEmpty<T>(IEnumerable<T> nonEmptyCollection)
        {
            var ex = Record.Exception(() => Ensure.IsNotEmpty(nameof(nonEmptyCollection), nonEmptyCollection));
            Assert.Null(ex);
        }

        [Theory]
        [MemberData("GetEmptyCollections")]
        public void ShouldThrowExceptionWhenEmptyCollectionIsGivenToIsNotEmpty<T>(IEnumerable<T> emptyCollection)
        {
            var ex = Assert.Throws<EnsureException>(() => Ensure.IsNotEmpty<T>(nameof(emptyCollection),emptyCollection));
            Assert.True(ex.Message.Contains(nameof(emptyCollection)) && ex.Message.Contains("empty"));
        }

        [Theory]
        [MemberData("GetNotEmptyCollections")]
        public void ShouldThrowExceptionWhenNonEmptyColletionIsGivenToIsEmpty<T>(IEnumerable<T> nonEmptyCollectio)
        {
            var ex = Assert.Throws<EnsureException>(() => Ensure.IsEmpty(nameof(nonEmptyCollectio),nonEmptyCollectio));
            Assert.True(ex.Message.Contains(nameof(nonEmptyCollectio)) && ex.Message.Contains("empty"));
        }

        [Theory]
        [MemberData("GetCustomPassedChecks")]
        public void ShouldTWorkWhenCustomConditionIsSatisfied<T>(Func<T, bool> condition, T value)
        {
            var ex = Record.Exception(() => Ensure.SatisfiesCondition(nameof(value), value, condition, "exSatCheck"));
            Assert.Null(ex);
        }

        [Theory]
        [MemberData("GetCustomFailedChecks")]
        public void ShouldThrowExceptionWhenCustomConditionIsNotSatisfied<T>(Func<T, bool> condition, T value)
        {
            var ex1 = Assert.Throws<EnsureException>(() => Ensure.SatisfiesCondition(nameof(value), value, condition, "exSatCheck"));
            Assert.True(ex1.Message.Contains(nameof(value)) && ex1.Message.Contains("exSatCheck"));
        }
    }
}
