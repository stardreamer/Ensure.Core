using System;
using Xunit;
using Ensure.Core.Ensure;
using System.Collections.Generic;
using System.IO;

namespace Ensure.Core.Ensure.Tests
{
    
    public class EnsureColletionTests
    {
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

        public static IEnumerable<object[]> GetUniqueElementsCollections
        {
            get
            {
                return new[] 
                {
                    new object[] { new List<int>() {12} },
                    new object[] { new List<int>() {12, 13, 214} },
                    new object[] { new List<float>() {(float)23.5} },
                    new object[] { new List<string>() {"12"} },
                    new object[] { new object[] {"12"} }
                };
            }
        }

        public static IEnumerable<object[]> GetNotUniqueElementsCollections
        {
            get
            {
                return new[] 
                {
                    new object[] { new List<int>() {12, 12} },
                    new object[] { new List<int>() {12, 13, 214, 13} },
                    new object[] { new List<float>() {(float)23.5, (float)23.5} },
                    new object[] { new List<string>() {"12", "12"} },
                    new object[] { new object[] {"12", "12"} }
                };
            }
        }

        public static IEnumerable<object[]> GetColWithEl
        {
            get
            {
                return new[] 
                {
                    new object[] { new List<int>() {12}, 12 },
                    new object[] { new List<int>() {12, 13, 214}, 214},
                    new object[] { new List<float>() {(float)23.5, (float)23.6},  (float)23.5},
                    new object[] { new List<string>() {"12", "13"}, "12" }
                };
            }
        }

        public static IEnumerable<object[]> GetColWithoutEl
        {
            get
            {
                return new[] 
                {
                    new object[] { new List<int>() {12}, 0 },
                    new object[] { new List<int>() {12, 13, 214}, 777},
                    new object[] { new List<float>() {(float)23.5, (float)23.6},  (float)34.2},
                    new object[] { new List<string>() {"12", "13"}, "deer" }
                };
            }
        }

        public static IEnumerable<object[]> GetCohCol
        {
            get
            {
                return new[] 
                {
                    new object[] { new List<int>() {12}, new List<int>() {12, 13, 214} },
                    new object[] { new List<int>() {12, 13, 214}, new List<int>() {12, 13, 214, 545}},
                    new object[] { new List<float>() {(float)23.5, (float)23.6},  new List<float>() {(float)23.5, (float)23.6, (float) 12}},
                    new object[] { new List<string>() {"12", "13"}, new List<string>() {"12", "13", "deer"}}
                };
            }
        }

        public static IEnumerable<object[]> GetNotCohCol
        {
            get
            {
                return new[] 
                {
                    new object[] { new List<int>() {12, 555}, new List<int>() {12, 13, 214} },
                    new object[] { new List<int>() {12, 13, 214, 17}, new List<int>() {12, 13, 214, 545}},
                    new object[] { new List<float>() {(float)23.5, (float)23.6, 0},  new List<float>() {(float)23.5, (float)23.6, (float) 12}},
                    new object[] { new List<string>() {"12", "13", "mice"}, new List<string>() {"12", "13", "deer"}}
                };
            }
        }


        [Theory]
        [MemberData("GetEmptyCollections")]
        public void ShouldWorkWhenNonEmptyCollectionIsGivenToIsEmpty<T>(IEnumerable<T> nonEmptyCollection)
        {
            var ex = Record.Exception(() => Ensure.Collection.IsEmpty(nameof(nonEmptyCollection), nonEmptyCollection));
            Assert.Null(ex);
        }

        [Theory]
        [MemberData("GetNotEmptyCollections")]
        public void ShouldThrowExceptionWhenNonEmptyColletionIsGivenToIsEmpty<T>(IEnumerable<T> nonEmptyCollectio)
        {
            var ex = Assert.Throws<EnsureException>(() => Ensure.Collection.IsEmpty(nameof(nonEmptyCollectio),nonEmptyCollectio));
            Assert.True(ex.Message.Contains(nameof(nonEmptyCollectio)) && ex.Message.Contains("empty"));
        }

        [Theory]
        [MemberData("GetNotEmptyCollections")]
        public void ShouldWorkWhenNonEmptyCollectionIsGivenToIsNotEmpty<T>(IEnumerable<T> nonEmptyCollection)
        {
            var ex = Record.Exception(() => Ensure.Collection.IsNotEmpty(nameof(nonEmptyCollection), nonEmptyCollection));
            Assert.Null(ex);
        }

        [Theory]
        [MemberData("GetEmptyCollections")]
        public void ShouldThrowExceptionWhenEmptyCollectionIsGivenToIsNotEmpty<T>(IEnumerable<T> emptyCollection)
        {
            var ex = Assert.Throws<EnsureException>(() => Ensure.Collection.IsNotEmpty<T>(nameof(emptyCollection),emptyCollection));
            Assert.True(ex.Message.Contains(nameof(emptyCollection)) && ex.Message.Contains("empty"));
        }

        [Theory]
        [MemberData("GetUniqueElementsCollections")]
        public void ShouldWorkWhenUniqueElementsCollectionIsGivenToUniqueness<T>(IEnumerable<T> uniqueCollection)
        {
            var ex = Record.Exception(() => Ensure.Collection.Uniqueness(nameof(uniqueCollection), uniqueCollection));
            Assert.Null(ex);
        }

        [Theory]
        [MemberData("GetNotUniqueElementsCollections")]
        public void ShouldThrowExceptionWhenNonUniqueElementsCollectionIsGivenToUniqueness<T>(IEnumerable<T> nonUniqueCollection)
        {
            var ex = Assert.Throws<EnsureException>(() => Ensure.Collection.Uniqueness<T>(nameof(nonUniqueCollection),nonUniqueCollection));
            Assert.True(ex.Message.Contains(nameof(nonUniqueCollection)) );
        }

        [Theory]
        [MemberData("GetColWithEl")]
        public void ShouldWorkWhenColletionContainsSpecifiedElement<T>(IEnumerable<T> col, T element)
        {
            var ex = Record.Exception(() => Ensure.Collection.Contains(nameof(col), col, nameof(element), element));
            Assert.Null(ex);
        }

        [Theory]
        [MemberData("GetColWithoutEl")]
        public void ShouldThrowExceptionWhenColletionDoesNotContainSpecifiedElement<T>(IEnumerable<T> col, T element)
        {
            var ex = Assert.Throws<EnsureException>(() => Ensure.Collection.Contains(nameof(col), col, nameof(element), element));
            Assert.True(ex.Message.Contains(nameof(col)) );
        }

        [Theory]
        [MemberData("GetCohCol")]
        public void ShouldWorkWhenColletionsAreCoherent<T>(IEnumerable<T> col, IEnumerable<T> colSource)
        {
            var ex = Record.Exception(() => Ensure.Collection.Coherence(nameof(col), col, nameof(colSource), colSource));
            Assert.Null(ex);
        }

        [Theory]
        [MemberData("GetNotCohCol")]
        public void ShouldThrowExceptionWhenColletionsAreNotCoherent<T>(IEnumerable<T> col, IEnumerable<T> colSource)
        {
            var ex = Assert.Throws<EnsureException>(() => Ensure.Collection.Coherence(nameof(col), col, nameof(colSource), colSource));
            Assert.True(ex.Message.Contains(nameof(col)) );
        }

    }
}