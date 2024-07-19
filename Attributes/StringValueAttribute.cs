using System.Diagnostics.CodeAnalysis;

namespace FalconDatabase.Attributes
{
    /// <summary>
    /// Specifies a description for a property, enum, or event.
    /// </summary>
    [AttributeUsage(AttributeTargets.All)]
    public class StringValueAttribute : Attribute
    {
        /// <summary>
        /// Specifies the default value for the <see cref='StringValueAttribute'/>,
        /// which is an empty string (""). This <see langword='static'/> field is read-only.
        /// </summary>
        public static readonly StringValueAttribute Default = new StringValueAttribute();
        /// <summary>
        /// Constructs an empty String Value Attribute for an Enum.
        /// </summary>
        public StringValueAttribute() : this(string.Empty)
        {
        }
        /// <summary>
        /// Initializes a new instance of the <see cref='StringValueAttribute'/> class with the text in <paramref name="value"/>.
        /// </summary>
        public StringValueAttribute(string value)
        {
            _StringValue = value;
        }
        /// <summary>
        /// Gets the description stored in this attribute.
        /// </summary>
        public virtual string StringValue => _StringValue;
        /// <summary>
        /// Read/Write property that directly modifies the string stored in the StringValue
        /// attribute. The default implementation of the <see cref="StringValueAttribute"/> property
        /// simply returns this value.
        /// </summary>
        protected string _StringValue { get; set; } = "";
        /// <summary>
        /// Evaluates if two StringValueAttributes are the Same.
        /// </summary>
        /// <param name="obj">The target object to compare the Attribute against.</param>
        /// <returns><see langword=""/>true when the values are the same, otherwise <see langword="false"/>.</returns>
        public override bool Equals([NotNullWhen(true)] object? obj) =>
            obj is StringValueAttribute other && other.StringValue == StringValue;
        /// <summary>
        /// Generates a HashCode for the StringValueAttribute.
        /// </summary>
        /// <returns><see cref="Int32"/> value representing a Hash Code of teh Text in the StringValueAttribute.</returns>
        public override int GetHashCode() => StringValue?.GetHashCode() ?? 0;
        /// <summary>
        /// Indicates if the <see cref="StringValueAttribute"/> is initialized with a default value.
        /// </summary>
        /// <returns><see langword="true"/> when the <see cref="StringValueAttribute"/> is empty, null, or not set, otherwise <see langword="false"/>.</returns>
        public override bool IsDefaultAttribute() => Equals(Default);
    }
}
