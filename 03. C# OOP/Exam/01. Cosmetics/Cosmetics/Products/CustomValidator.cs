namespace Cosmetics.Products
{
    using System;

    using Common;

    public static class CustomValidator
    {
        public static void StrInRangeAndNotNullOrEmpty(string value, int minLength, int maxLength, string name)
        {
            string message = string.Format(GlobalErrorMessages.StringCannotBeNullOrEmpty, name);
            Validator.CheckIfStringIsNullOrEmpty(value, message);

            message = string.Format(GlobalErrorMessages.InvalidStringLength, name, minLength, maxLength);
            Validator.CheckIfStringLengthIsValid(value, maxLength, minLength, message);
        }
    }
}