using System.Text.RegularExpressions;

namespace Domain.ValueObjects;

public partial record DuiNumber
{
    private const int DefaultLenght = 10;

    private const string Pattern = @"^(?:-*\d-*){9}$";

    private DuiNumber(string value) => Value = value;

    public static DuiNumber? Create(string value)
    {
        if (string.IsNullOrEmpty(value) || !DuiNumberRegex().IsMatch(value) || value.Length != DefaultLenght)
        {
            return null;
        }

        return new DuiNumber(value);

    }
    public string Value { get; init; }

    [GeneratedRegex(Pattern)]
    private static partial Regex DuiNumberRegex();
}