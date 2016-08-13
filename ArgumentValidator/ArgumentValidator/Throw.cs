namespace ArgumentValidator
{
    using System;
    using System.Collections;
    using System.Linq;

    /// <summary>
    /// Provides methods to do argument validations.
    /// </summary>
    public static class Throw
    {
        /// <summary>
        /// Throws <exception cref="ArgumentNullException"/> if argument is null, and throws 
        /// <exception cref="ArgumentException"/> when argument is empty.
        /// </summary>
        /// <param name="argumentValue">The argument value.</param>
        /// <param name="argumentName">The argument name.</param>
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

        /// <summary>
        /// Throws <exception cref="ArgumentNullException"/> if argument is null, and throws 
        /// <exception cref="ArgumentException"/> when argument is empty.
        /// </summary>
        /// <param name="argumentValue">The argument value.</param>
        /// <param name="argumentName">The argument name.</param>
        public static void IfNullOrEmpty(ICollection argumentValue, string argumentName)
        {
            IfNull(argumentValue, argumentName);

            if (argumentValue.Count == 0)
            {
                throw new ArgumentException("Should not be an empty collection", argumentName);
            }
        }

        public static void IfHasNull(ICollection argumentValue, string argumentName)
        {
            IfNull(argumentValue, argumentName);

            if (argumentValue.Cast<object>().Any(item => item == null))
            {
                throw new ArgumentException("Should not contain a null item in the collection", argumentName);
            }
        }
    }
}
