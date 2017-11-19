using System;

namespace SmartEngineer.Framework.Cache
{
    /// <summary>
    /// Event arguments for cache actions.
    /// </summary>
    public sealed class CacheActionEventArgs : EventArgs
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CacheActionEventArgs"/> class.
        /// </summary>
        /// <param name="key">The key.</param>
        public CacheActionEventArgs(string key, object value)
        {
            Key = key;
            Value = value;
        }

        /// <summary>
        /// Gets the key.
        /// </summary>
        /// <value>The key.</value>
        public string Key { get; }

        /// <summary>
        /// Gets the value.
        /// </summary>
        /// <value>The value.</value>
        public object Value { get; }

        /// <inheritdoc />
        public override string ToString()
        {
            return $"CacheActionEventArgs CacheKey:{Key} - {Value}";
        }
    }
}
