using Ecommerce.Domain.Common;
using Ecommerce.Domain.ValueObjects.Exceptions;

namespace Ecommerce.Domain.ValueObjects.Auditables
{
    public class LookupNameEn : ValueObject
    {
        /// <summary>
        /// MAX_ALLOWED_CHAR 255
        /// </summary>
        public static readonly int MAX_ALLOWED_CHAR = 255;

        /// <summary>
        /// LookupNameEn value
        /// </summary>
        public override string Value { get; }

        private LookupNameEn(string value)
        {
            Value = value ?? throw new ArgumentNullException(nameof(value));
        }



        /// <summary>
        /// Create LookupNameEn 
        /// </summary>
        /// <param name="nameEn"></param>
        /// <returns></returns>
        public static LookupNameEn Create(string nameEn)
        {
            if (string.IsNullOrWhiteSpace(nameEn) || nameEn.Length > MAX_ALLOWED_CHAR)
            {
                throw new InvalidNameEnException(nameEn);
            }
            return new LookupNameEn(nameEn);
        }
        /// <summary>
        /// to convert from string to value object
        /// </summary>
        /// <param name="nameEn"></param>
        public static explicit operator LookupNameEn(string nameEn)
        {
            return (LookupNameEn)Create(nameEn).Value;
        }
        public static implicit operator string(LookupNameEn nameEn)
        {
            return nameEn.Value;
        }
    }
}
