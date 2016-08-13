namespace ArgumentValidator
{
    using System;
    using System.Data;
    using System.Collections;
    using System.Collections.Generic;
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
        /// Throws <exception cref="ArgumentException"/> if nullable argument does not have a valid value.
        /// </summary>
        /// <typeparam name="T">Type of the argument</typeparam>
        /// <param name="argumentValue">The argument value.</param>
        /// <param name="argumentName">The argument name.</param>
        public static void IfNull<T>(T? argumentValue, string argumentName) where T: struct 
        {
            if (!argumentValue.HasValue)
            {
                throw new ArgumentException("Should have a valid value for type", argumentName);
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

        /// <summary>
        /// Throws <exception cref="ArgumentNullException"/> if argument is null, and throws 
        /// <exception cref="ArgumentException"/> when the collection has a null value.
        /// </summary>
        /// <param name="argumentValue">The argument value.</param>
        /// <param name="argumentName">The argument name.</param>
        public static void IfNullOrHasNull<T>(ICollection<T> argumentValue, string argumentName)
        {
            IfNull(argumentValue, argumentName);

            if (argumentValue.Any(item => item == null))
            {
                throw new ArgumentException("Should not contain a null item in the collection", argumentName);
            }
        }

        /// <summary>
        /// Throws <exception cref="ArgumentException"/> if argument is empty Guid.
        /// </summary>
        /// <param name="argumentValue">The argument value.</param>
        /// <param name="argumentName">The argument name.</param>
        public static void IfEmpty(Guid argumentValue, string argumentName)
        {
            if (argumentValue == Guid.Empty)
            {
                throw new ArgumentException("Should not be an empty Guid", argumentName);
            }
        }

        /// <summary>
        /// Throws <exception cref="InvalidConstraintException"/> if constraint is true.
        /// </summary>
        /// <param name="lambda">The lambda expression.</param>
        public static void IfConstraint(Func<bool> lambda)
        {
            var ret = lambda.Invoke();
            if (ret)
            {
                throw new InvalidConstraintException();
            }
        }

        /// <summary>
        /// Throws <exception cref="InvalidConstraintException"/> when argument not in range. The range check is
        /// as follows: argumentValue less than startRange  and greater than startRange. 
        /// </summary>
        /// <param name="argumentValue">The argument value.</param>
        /// <param name="startRange">The start range valule.</param>
        /// <param name="endRange">The end range value.</param>
        /// <param name="argumentName">The argument name.</param>
        public static void IfNotInRange(int argumentValue, int startRange, int endRange, string argumentName)
        {
            if(argumentValue < startRange || argumentValue > endRange)
            {
                throw new ArgumentOutOfRangeException(
                    argumentName, 
                    argumentValue,
                    $"Should be outside the range {startRange} to {endRange}");
            }
        }

        /// <summary>
        /// Throws <exception cref="InvalidConstraintException"/> when argument is in range. The range check is 
        /// as follows: argumentValue greater or equal to startRange and less than or equal to endRange.
        /// </summary>
        /// <param name="argumentValue">The argument value.</param>
        /// <param name="startRange">The start range valule.</param>
        /// <param name="endRange">The end range value.</param>
        /// <param name="argumentName">The argument name.</param>
        public static void IfInRange(int argumentValue, int startRange, int endRange, string argumentName)
        {
            if(argumentValue >= startRange && argumentValue <= endRange)
            {
                throw new ArgumentOutOfRangeException(
                    argumentName,
                    argumentValue,
                    $"Should be inside the range {startRange} to {endRange}");
            }
        }
    }
}
