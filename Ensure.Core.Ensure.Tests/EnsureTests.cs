using System;
using Xunit;
using Ensure.Core.Ensure;
using System.Collections.Generic;
using System.IO;

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

        [Fact]
        public void ShouldThrowExceptionWhenEmptyCollectionIsGivenToIsNotEmpty()
        {
            var emptyIntCollection = new List<int>();
            var ex1 = Assert.Throws<EnsureException>(() => Ensure.IsNotEmpty(nameof(emptyIntCollection), emptyIntCollection, "ex1IntTest"));
            Assert.True(ex1.Message.Contains(nameof(emptyIntCollection)) && ex1.Message.Contains("ex1IntTest"));

            var emptyFloatColletion = new List<float>();
            var ex2 = Assert.Throws<EnsureException>(() => Ensure.IsNotEmpty(nameof(emptyFloatColletion), emptyFloatColletion, "ex2FloatTest"));
            Assert.True(ex2.Message.Contains(nameof(emptyFloatColletion)) && ex2.Message.Contains("ex2FloatTest"));

            var emptyDict = new Dictionary<int,int>();
            var ex3 = Assert.Throws<EnsureException>(() => Ensure.IsNotEmpty(nameof(emptyDict), emptyDict, "ex3DictTest"));
            Assert.True(ex3.Message.Contains(nameof(emptyDict)) && ex3.Message.Contains("ex3DictTest"));
        }

        [Fact]
        public void ShouldThrowExceptionWhenNonEMptyColletionIsGivenToIsEmpty()
        {
            var notEmptyIntCollection = new List<int>() { 1 };
            var ex1 = Assert.Throws<EnsureException>(() => Ensure.IsEmpty(nameof(notEmptyIntCollection), notEmptyIntCollection, "ex1IntTest"));
            Assert.True(ex1.Message.Contains(nameof(notEmptyIntCollection)) && ex1.Message.Contains("ex1IntTest"));

            var notEmptyFloatColletion = new List<float>() { (float)1.0 };
            var ex2 = Assert.Throws<EnsureException>(() => Ensure.IsEmpty(nameof(notEmptyFloatColletion), notEmptyFloatColletion, "ex2FloatTest"));
            Assert.True(ex2.Message.Contains(nameof(notEmptyFloatColletion)) && ex2.Message.Contains("ex2FloatTest"));

            var notEmptyDict = new Dictionary<int,int>() { { 1, 1 } };
            var ex3 = Assert.Throws<EnsureException>(() => Ensure.IsEmpty(nameof(notEmptyDict), notEmptyDict, "ex3DictTest"));
            Assert.True(ex3.Message.Contains(nameof(notEmptyDict)) && ex3.Message.Contains("ex3DictTest"));
        }

        [Fact]
        public void ShouldThrowExceptionWhenCustomConditionIsNotSatisfied()
        {
            var testValue = -11;
            var ex1 = Assert.Throws<EnsureException>(() => Ensure.SatisfiesCondition(nameof(testValue), testValue, (v) => v > 0, "ex1SatCheck"));
            Assert.True(ex1.Message.Contains(nameof(testValue)) && ex1.Message.Contains("ex1SatCheck"));

            var testValue2 = 11;
            var ex2 = Assert.Throws<EnsureException>(() => Ensure.SatisfiesCondition(nameof(testValue2), testValue2, (v) => v < 0, "ex2SatCheck"));
            Assert.True(ex2.Message.Contains(nameof(testValue2)) && ex2.Message.Contains("ex2SatCheck"));

            var wrongPath = "notexistingpath/notexistingfile";
            var ex3 = Assert.Throws<EnsureException>(() => Ensure.SatisfiesCondition(nameof(wrongPath), wrongPath, (v) => File.Exists(v), "ex3SatCheck"));
            Assert.True(ex3.Message.Contains(nameof(wrongPath)) && ex3.Message.Contains("ex3SatCheck"));
        }



    }
}
