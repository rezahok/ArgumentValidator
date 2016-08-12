namespace ArgumentValidator
{
    using System;

    /// <summary>
    /// Provides methods to do argument validations.
    /// </summary>
    public static class Throw
    {
        /// <summary>
        /// Throws <exception cref="ArgumentException"/> if argument is null or empty.
        /// </summary>
        /// <param name="argumentValue">The argument value.</param>
        /// <param name="argumentName">The argument name.</param>
        /// <exception cref="ArgumentException">An argument exception</exception>
        public static void IfNullOrEmpty(string argumentValue, string argumentName)
        {
            IfNull(argumentValue, argumentName);

            if (argumentValue.Length == 0)
            {
                throw new ArgumentException("Should not be empty", argumentName);
            }
        }

        /// <summary>
        /// Throws <exception cref="ArgumentNullException"/> if argument is null.
        /// </summary>
        /// <typeparam name="T">Type of the argument</typeparam>
        /// <param name="argumentValue">The argument value.</param>
        /// <param name="argumentName">The argument name.</param>
        public static void IfNull<T>(T argumentValue, string argumentName)
        {
            if (argumentValue == null)
            {
                throw new ArgumentNullException(argumentName, "Should not be null");
            }
        }
    }
}
