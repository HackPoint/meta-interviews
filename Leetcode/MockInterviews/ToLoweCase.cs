using Xunit;

namespace Leetcode.MockInterviews;

/// <summary>
/// Converts all uppercase English letters in the input string to lowercase without 
/// using built-in casing methods.
/// 
/// Problem:
/// Given a string s, return the same string with all uppercase letters ('A'..'Z')
/// converted to their lowercase equivalents ('a'..'z'). Non-alphabetic characters 
/// remain unchanged.
///
/// Approach:
/// - Iterate over each character of the input string.
/// - If the character is uppercase (ASCII range 'A'..'Z'), shift it to lowercase 
///   by adding the constant offset ('a' - 'A') to its code point.
/// - Otherwise, leave the character as-is.
/// - Store results in a char array to avoid repeated string concatenations.
/// - Return a new string from the char array at the end.
///
/// Time Complexity:
/// - O(n), where n = length of s (each character processed once).
///
/// Space Complexity:
/// - O(n) additional space for the char array holding the transformed characters.
/// 
/// Correctness & Edge Cases:
/// - Null input: throws ArgumentNullException.
/// - Empty string: returns empty string.
/// - No uppercase letters: returns original string unchanged.
/// - All uppercase letters: returns all lowercase equivalents.
/// - Mixed letters and non-letter characters (digits, punctuation): only letters 
///   in 'A'..'Z' range are transformed.
///
/// Example:
/// Input: "Hello WORLD!"
/// Output: "hello world!"
///   Explanation: 'H'→'h', 'W'→'w', rest unchanged.
/// </summary>
public class ToLoweCase {
    public string ToLowerCase(string s) {
        if (s == null) throw new ArgumentNullException(nameof(s));

        char[] lower = new char[s.Length];
        for (int i = 0; i < s.Length; i++) {
            char c = s[i];
            // Convert uppercase letters to lowercase
            if (c >= 'A' && c <= 'Z')
                lower[i] = (char)(c + ('a' - 'A'));
            else
                lower[i] = c; // keep other characters unchanged
        }

        return new string(lower);
    }
}

public class ToLowerCaseTests {
    private readonly ToLoweCase _sut = new();

    [Fact]
    public void ToLowerCase_WhenInputIsUpperCase_ReturnsLowerCase() {
        // Arrange
        var input = "HELLO";

        // Act
        var result = _sut.ToLowerCase(input);

        // Assert
        Assert.Equal("hello", result);
    }

    [Fact]
    public void ToLowerCase_WhenInputHasMixedCase_ReturnsLowerCase() {
        // Arrange
        var input = "HeLLo";

        // Act
        var result = _sut.ToLowerCase(input);

        // Assert
        Assert.Equal("hello", result);
    }

    [Fact]
    public void ToLowerCase_WhenInputHasSpecialCharacters_PreservesCharacters() {
        // Arrange
        var input = "Hello123!@#";

        // Act
        var result = _sut.ToLowerCase(input);

        // Assert
        Assert.Equal("hello123!@#", result);
    }

    [Fact]
    public void ToLowerCase_WhenInputIsEmpty_ReturnsEmptyString() {
        // Arrange
        var input = string.Empty;

        // Act
        var result = _sut.ToLowerCase(input);

        // Assert
        Assert.Equal(string.Empty, result);
    }

    [Fact]
    public void ToLowerCase_WhenInputIsNull_ThrowsArgumentNullException() {
        // Act & Assert
        Assert.Throws<ArgumentNullException>(() => _sut.ToLowerCase(null));
    }
}