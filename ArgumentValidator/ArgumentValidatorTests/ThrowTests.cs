namespace ArgumentValidator.Tests
{
    using System;
    using System.Data;
    using System.Collections;
    using System.Collections.Generic;

    using Microsoft.VisualStudio.TestTools.UnitTesting;

    /// <summary>
    /// Testing the argument validations.
    /// </summary>
    [TestClass]
    public class ThrowTests
    {
        /// <summary>
        /// IfNullOrEmpty throws <exception cref="ArgumentException"/> when the argument is empty.
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(ArgumentException))
            ]
        public void IfNullOrEmpty_Empty_ThrowsArgumentException()
        {
            // Arrange
            var argument = string.Empty;

            // Act
            Throw.IfNullOrEmpty(argument, nameof(argument));
        }

        /// <summary>
        /// IfNullOrEmpty throws <exception cref="ArgumentNullException"/> when the argument is null.
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void IfNullOrEmpty_Null_ThrowsArgumentNullException()
        {
            // Arrange
            string argument = null;

            // Act
            Throw.IfNullOrEmpty(argument, nameof(argument));
        }

        /// <summary>
        /// IfNullOrEmpty does not throw any exception when argument is white space.
        /// </summary>
        [TestMethod]
        public void IfNullOrEmpty_WhiteSpace_NoExceptionThrown()
        {
            // Arrange
            string argument = "  ";

            // Act
            Throw.IfNullOrEmpty(argument, nameof(argument));
        }

        /// <summary>
        /// IfNullOrEmpty does not throw any exception when argument is not null and not empty.
        /// </summary>
        [TestMethod]
        public void IfNullOrEmpty_NotNullNotEmpty_NoExceptionThrown()
        {
            // Arrange
            string argument = "dummy";

            // Act
            Throw.IfNullOrEmpty(argument, nameof(argument));
        }

        /// <summary>
        /// IfNull throws <exception cref="ArgumentNullException"/> when the argument is null.
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void IfNull_Null_ThrowsArgumentNullException()
        {
            // Arrange
            object argument = null;

            // Act
            Throw.IfNull(argument, nameof(argument));
        }

        /// <summary>
        /// IfNull does not throw any exception when argument is not null.
        /// </summary>
        [TestMethod]
        public void IfNull_NotNull_NoExceptionThrown()
        {
            // Arrange
            object argument = 42;

            // Act
            Throw.IfNull(argument, nameof(argument));
        }

        /// <summary>
        /// IfNullOrEmpty throws <exception cref="ArgumentNullException"/> when the collection is null.
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void IfNullOrEmpty_NullCollection_ThrowsArgumentNullException()
        {
            // Arrange
            ICollection argument = null;

            // Act
            Throw.IfNullOrEmpty(argument, nameof(argument));
        }

        /// <summary>
        /// IfNullOrEmpty throws <exception cref="ArgumentException"/> when the argument is an empty collection.
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void IfNullOrEmpty_EmptyCollection_ThrowsArgumentNullException()
        {
            // Arrange
            var argument = new List<string>();

            // Act
            Throw.IfNullOrEmpty(argument, nameof(argument));
        }

        /// <summary>
        /// IfNullOrEmpty does not throw any exception when argument is not an empty collection.
        /// </summary>
        [TestMethod]
        public void IfNullOrEmpty_NonEmptyCollection_NoExceptionThrown()
        {
            // Arrange
            var argument = new List<string>() { "oneitme" };

            // Act
            Throw.IfNullOrEmpty(argument, nameof(argument));
        }

        /// <summary>
        /// IfHasNull throws <exception cref="ArgumentException"/> when the collection has null.
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void IfNullOrHasNull_CollectionHasNull_ThrowsArgumentException()
        {
            // Arrange
            var argument = new List<string>() { "oneitem", null, "seconditem" };

            // Act
            Throw.IfHasNull(argument, nameof(argument));
        }

        /// <summary>
        /// IfHasNull does not throw any exception when collection does not have a null value.
        /// </summary>
        [TestMethod]
        public void IfNullOrHasNull_CollectionHasNoNull_NoExceptionThrown()
        {
            // Arrange
            var argument = new List<string> { "oneitem", "seconditem" };

            // Act
            Throw.IfHasNull(argument, nameof(argument));
        }

        /// <summary>
        /// IfHasNull does not throw any exception when collection is null.
        /// </summary>
        [TestMethod]
        public void IfNullOrHasNull_CollectionIsNull_NoExceptionThrown()
        {
            // Arrange
            ICollection<int> argument = null;

            // Act
            Throw.IfHasNull(argument, nameof(argument));
        }

        /// <summary>
        /// IfEmpty throws <exception cref="ArgumentException"/> when the argument is an empty Guid.
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void IfEmpty_EmptyGuid_ThrowsArgumentException()
        {
            // Arrange
            var argument = Guid.Empty;

            // Act
            Throw.IfEmpty(argument, nameof(argument));
        }

        /// <summary>
        /// IfEmpty does not throw any exception when argument is a non empty guid.
        /// </summary>
        [TestMethod]
        public void IfEmpty_NonEmptyGuid_NoExceptionThrown()
        {
            // Arrange
            var argument = Guid.NewGuid();

            // Act
            Throw.IfEmpty(argument, nameof(argument));
        }

        /// <summary>
        /// IfNot throws <exception cref="InvalidConstraintException"/> when constraint is false.
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(InvalidConstraintException))]
        public void IfNot_ExpressionTrue_ThrowInvalidConstraintException()
        {
            // Arrange
            var argumentValue = 10;

            // Act
            Throw.IfNot(() => argumentValue > 100);
        }

        /// <summary>
        /// IfNot does not throw any exception when constraint is true.
        /// </summary>
        [TestMethod]
        public void IfNot_ExpressionFalse_NoExceptionThrown()
        {
            // Arrange
            var argumentValue = 43;

            // Act
            Throw.IfNot(() => argumentValue > 42);
        }

        /// <summary>
        /// IfNull throws <exception cref="ArgumentNullException"/> when the nullable argument is null.
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void IfNull_NullableTypeUndefinedValue_ThrowsArgumentException()
        {
            // Arrange
            int? argument = null;

            // Act
            Throw.IfNull(argument, nameof(argument));
        }

        /// <summary>
        /// IfNull does not throw any exception when nullable argument is valid value.
        /// </summary>
        [TestMethod]
        public void IfNull_NullableTypeValidValue_NoExceptionThrown()
        {
            // Arrange
            int? argument = 31412;

            // Act
            Throw.IfNull(argument, nameof(argument));
        }

        /// <summary>
        /// IfOutOfRange throws <exception cref="ArgumentOutOfRangeException"/> when the argument 
        /// is not given inside the range.
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void IfOutOfRange_GreaterThanEndRangeValue_ThrowsInvalidConstraintException()
        {
            // Arrange
            var argument = 500;
            var startRange = 1;
            var endRange = 100;

            // Act
            Throw.IfOutOfRange(argument, startRange, endRange, nameof(argument));
        }

        /// <summary>
        /// IfOutOfRange throws <exception cref="ArgumentOutOfRangeException"/> when the argument 
        /// is not given inside the range.
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void IfOutOfRange_LessThanStartRangeValue_ThrowsInvalidConstraintException()
        {
            // Arrange
            var argument = 0;
            var startRange = 1;
            var endRange = 100;

            // Act
            Throw.IfOutOfRange(argument, startRange, endRange, nameof(argument));
        }

        /// <summary>
        /// IfOutOfRange throws no exception when argument is in range.
        /// </summary>
        [TestMethod]
        public void IfOutOfRange_StartRangeValue_NoExceptionThrown()
        {
            // Arrange
            var argument = 1;
            var startRange = 1;
            var endRange = 100;

            // Act
            Throw.IfOutOfRange(argument, startRange, endRange, nameof(argument));
        }

        /// <summary>
        /// IfOutOfRange throws no exception when argument is in range.
        /// </summary>
        [TestMethod]
        public void IfOutOfRange_EndRangeValue_NoExceptionThrown()
        {
            // Arrange
            var argument = 100;
            var startRange = 1;
            var endRange = 100;

            // Act
            Throw.IfOutOfRange(argument, startRange, endRange, nameof(argument));
        }
        
        /// <summary>
        /// IfOutOfRange does not throw any exception when argument is inside the given range.
        /// </summary>
        [TestMethod]
        public void IfOutOfRange_InRange_NoExceptionThrown()
        {
            // Arrange
            var argument = 50;
            var startRange = 1;
            var endRange = 100;

            // Acts
            Throw.IfOutOfRange(argument, startRange, endRange, nameof(argument));
        }

        /// <summary>
        /// IfInRange throws no exception when argument is not in range.
        /// </summary>
        [TestMethod]
        public void IfInRange_GreaterThanEndRangeValue_NoExceptionThrown()
        {
            // Arrange
            var argument = 500;
            var startRange = 1;
            var endRange = 100;

            // Act
            Throw.IfInRange(argument, startRange, endRange, nameof(argument));
        }

        /// <summary>
        /// IfInRange throws no exception when argument is not in range.
        /// </summary>
        [TestMethod]
        public void IfInRange_LessThanStartRangeValue_NoExceptionThrown()
        {
            // Arrange
            var argument = 0;
            var startRange = 1;
            var endRange = 100;

            // Act
            Throw.IfInRange(argument, startRange, endRange, nameof(argument));
        }

        /// <summary>
        /// IfInRange throws <exception cref="ArgumentOutOfRangeException"/> when the argument 
        /// is equal to start range value.
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void IfInRange_StartRangeValue_ThrowsInvalidConstraintException()
        {
            // Arrange
            var argument = 1;
            var startRange = 1;
            var endRange = 100;

            // Act
            Throw.IfInRange(argument, startRange, endRange, nameof(argument));
        }

        /// <summary>
        /// IfInRange throws <exception cref="ArgumentOutOfRangeException"/> when the argument 
        /// is equal to the end range value.
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void IfInRange_EndRangeValue_ThrowsInvalidConstraintException()
        {
            // Arrange
            var argument = 100;
            var startRange = 1;
            var endRange = 100;

            // Act
            Throw.IfInRange(argument, startRange, endRange, nameof(argument));
        }

        /// <summary>
        /// IfInRange throws <exception cref="ArgumentOutOfRangeException"/> when the argument 
        /// is inside the range.
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void IfInRange_InRange_NoExceptionThrowsInvalidConstraintException()
        {
            // Arrange
            var argument = 50;
            var startRange = 1;
            var endRange = 100;

            // Acts
            Throw.IfInRange(argument, startRange, endRange, nameof(argument));
        }
    }
}
