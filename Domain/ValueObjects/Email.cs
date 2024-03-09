using System;
using System.Text.RegularExpressions;

namespace Domain.ValueObjects
{
    public record Email
    {
        private const string EmailRegexPattern = @"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$";

        public string Value { get; }

        private Email(string value)
        {
            Value = value;
        }

        public static Email? Create(string value)
        {
            if (string.IsNullOrEmpty(value) || !IsValidFormat(value))
            {
                return null;
            }

            return new Email(value);
        }

        private static bool IsValidFormat(string value)
        {
            return Regex.IsMatch(value, EmailRegexPattern);
        }
    }
}
