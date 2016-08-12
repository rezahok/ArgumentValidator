namespace ArgumentValidator.Tests
{
    using System;

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
        [ExpectedException(typeof(ArgumentException))]
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
    }
}
