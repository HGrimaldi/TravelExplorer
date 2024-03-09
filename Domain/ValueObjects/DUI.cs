namespace Domain.ValueObjects
{
    public record DUI
    {
        private const string Format = @"^\d{8}-\d{1}$";

        public string Value { get; }

        private DUI(string value)
        {
            Value = value;
        }

        public static DUI? Create(string value)
        {
            if (string.IsNullOrEmpty(value) || !IsValidFormat(value))
            {
                return null;
            }

            return new DUI(value);
        }

        private static bool IsValidFormat(string value)
        {
            return Regex.IsMatch(value, Format);
        }
    }
}
