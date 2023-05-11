// Copyright (c) 2014-2022 Sarin Na Wangkanai, All Rights Reserved.Apache License, Version 2.0

using System.Globalization;
using System.Text;
using System.Text.RegularExpressions;

namespace Wangkanai.System.Extensions;

public static class StringExtensions
{
	[DebuggerStepThrough]
	public static bool IsNotNullOrEmpty(this string value)
		=> !string.IsNullOrEmpty(value);

	[ContractAnnotation("null => true")]
	[DebuggerStepThrough]
	public static bool IsNullOrEmpty(this string input)
		=> string.IsNullOrEmpty(input);

	[ContractAnnotation("null => true")]
	[DebuggerStepThrough]
	public static bool IsNullOrWhiteSpace(this string input)
		=> string.IsNullOrWhiteSpace(input);
	
	[DebuggerStepThrough]
	public static bool IsExist(this string input)
		=> !string.IsNullOrWhiteSpace(input);

	[DebuggerStepThrough]
	public static bool IsUnicode(this string input)
		=> Encoding.ASCII.GetByteCount(input) != Encoding.UTF8.GetByteCount(input);

	[DebuggerStepThrough]
	public static string EnsureLeadingSlash(this string input)
		=> input.IsNotNullOrEmpty() && !input.StartsWith("/")
			   ? "/" + input
			   : input;

	[DebuggerStepThrough]
	public static string EnsureTrailingSlash(this string input)
		=> input.IsNotNullOrEmpty() && !input.EndsWith("/")
			   ? input + "/"
			   : input;
	
	[DebuggerStepThrough]
	public static string RemoveLeadingSlash(this string input)
		=> input.IsNotNullOrEmpty() && input.StartsWith("/")
			   ? input.Substring(1)
			   : input;
	
	[DebuggerStepThrough]
	public static string RemoveTrailingSlash(this string input)
		=> input.IsNotNullOrEmpty() && input.EndsWith("/")
			   ? input.Substring(0, input.Length - 1)
			   : input;

	[DebuggerStepThrough]
	public static string EnsureEndsWith(this string input, char c)
		=> input.EnsureEndsWith(c, StringComparison.Ordinal);

	[DebuggerStepThrough]
	public static string EnsureEndsWith(this string input, char c, StringComparison comparison)
	{
		input.ThrowIfNull();

		return input.EndsWith(c.ToString(), comparison)
			       ? input
			       : input + c;
	}

	[DebuggerStepThrough]
	public static string EnsureEndsWith(this string input, char c, bool ignoreCase, CultureInfo culture)
	{
		input.ThrowIfNull();

		return input.EndsWith(c.ToString(culture), ignoreCase, culture)
			       ? input
			       : input + c;
	}

	[DebuggerStepThrough]
	public static string EnsureStartsWith(this string input, char c)
		=> input.EnsureStartsWith(c, StringComparison.Ordinal);

	[DebuggerStepThrough]
	public static string EnsureStartsWith(this string input, char c, StringComparison comparison)
	{
		input.ThrowIfNull();

		return input.StartsWith(c.ToString(), comparison)
			       ? input
			       : c + input;
	}

	[DebuggerStepThrough]
	public static string EnsureStartsWith(this string input, char c, bool ignoreCase, CultureInfo culture)
	{
		input.ThrowIfNull();

		return input.StartsWith(c.ToString(culture), ignoreCase, culture)
			       ? input
			       : c + input;
	}

	[DebuggerStepThrough]
	public static Match RegexMatch(this Regex regex, string source)
	{
		var match = regex.Match(source);
		return match.Success ? match : Match.Empty;
	}


	[DebuggerStepThrough]
	public static string Left(this string input, int length)
	{
		input.ThrowIfNull();
		input.Length.NotLessThan(length, nameof(length));

		return input.Substring(0, length);
	}

	[DebuggerStepThrough]
	public static string Right(this string input, int length)
	{
		input.ThrowIfNull();
		input.Length.NotMoreThan(length);

		return input.Substring(input.Length - length, length);
	}

	[DebuggerStepThrough]
	public static string RemoveAll(this string source, params string[] strings)
		=> strings.Aggregate(source, ReplaceOrdinal);

	[DebuggerStepThrough]
	private static string ReplaceOrdinal(string current, string target)
		=> current.Replace(target, "", StringComparison.Ordinal);

	[DebuggerStepThrough]
	public static string RemovePostFix(this string value, params string[] postfixes)
	{
		if (value is null)
			return null;
		if (value.IsNullOrEmpty())
			return string.Empty;
		if (postfixes.IsNullOrEmpty())
			return value;

		foreach (var postfix in postfixes)
			if (value.EndsWith(postfix))
				return value.Left(value.Length - postfix.Length);

		return value;
	}

	[DebuggerStepThrough]
	public static string RemovePreFix(this string value, params string[] prefixes)
	{
		if (value.TrueIfNull())
			return null;
		if (value.IsNullOrEmpty())
			return string.Empty;
		if (prefixes.IsNullOrEmpty())
			return value;

		foreach (var prefix in prefixes)
			if (value.StartsWith(prefix))
				return value.Right(value.Length - prefix.Length);

		return value;
	}

	[DebuggerStepThrough]
	public static T ToEnum<T>(this string value, bool ignoreCase = true) where T : struct
	{
		value.ThrowIfNull();

		return (T)Enum.Parse(typeof(T), value, ignoreCase);
	}

	[DebuggerStepThrough]
	public static string Truncate(this string value, int maxLength)
	{
		if (value.TrueIfNull())
			return null;

		return value.Length <= maxLength
			       ? value
			       : value.Left(maxLength);
	}

	[DebuggerStepThrough]
	public static string TruncateWithPostfix(this string value, int maxLength, string postfix = "...")
	{
		if (value.TrueIfNull())
			return null;
		if (value.IsNullOrEmpty() || maxLength == 0)
			return string.Empty;
		if (value.Length <= maxLength)
			return value;
		if (maxLength <= postfix.Length)
			return postfix.Left(maxLength);

		return value.Left(maxLength - postfix.Length) + postfix;
	}

	[DebuggerStepThrough]
	public static string SubstringSafe(this string input, int start, int length)
		=> input.Length <= start
			   ? ""
			   : input.Length - start <= length
				   ? input[start..]
				   : input.Substring(start, length);

	[DebuggerStepThrough]
	public static string SubstringSafe(this string input, int start)
		=> input.Length <= start
			   ? ""
			   : input[start..];

	[DebuggerStepThrough]
	public static string ToTitleCase(this string input)
		=> input.First().ToString().ToUpper() + input.Substring(1);

	[DebuggerStepThrough]
	public static string EscapeSearchTerm(this string term)
	{
		char[] specialCharacters = { '+', '-', '!', '(', ')', '{', '}', '[', ']', '^', '"', '~', '*', '?', ':', '\\' };
		var    result            = new StringBuilder("");
		//'&&', '||',
		foreach (var ch in term)
		{
			if (specialCharacters.Any(x => x == ch))
				result.Append("\\");

			result.Append(ch);
		}

		result = result.Replace("&&", @"\&&");
		result = result.Replace("||", @"\||");

		return result.ToString().Trim();
	}

	/// <summary>
	/// Escapes the selector. Query requires special characters to be escaped in query
	/// http://api.jquery.com/category/selectors/
	/// </summary>
	public static string EscapeSelector(this string attribute)
		=> Regex.Replace(attribute, string.Format("([{0}])", "/[!\"#$%&'()*+,./:;<=>?@^`{|}~\\]"), @"\\$1");

	public static string GenerateSlug(this string phrase)
	{
		string str = phrase.RemoveAccent().ToLower();

		// invalid chars
		str = Regex.Replace(str, @"[^a-z0-9\s-]", "");
		// convert multiple spaces into one space
		str = Regex.Replace(str, @"\s+", " ").Trim();
		// cut and trim it
		str = str.Substring(0, str.Length <= 240 ? str.Length : 240).Trim();
		// hyphens
		str = Regex.Replace(str, @"\s", "-");

		return str;
	}

	[DebuggerStepThrough]
	public static string RemoveAccent(this string input)
	{
		byte[] bytes = Encoding.GetEncoding("Cyrillic").GetBytes(input);
		return Encoding.ASCII.GetString(bytes);
	}

	/// <summary>
	/// Equals invariant
	/// </summary>
	/// <param name="str1">The STR1.</param>
	/// <param name="str2">The STR2.</param>
	/// <returns></returns>
	public static bool EqualsInvariant(this string str1, string str2)
		=> string.Equals(str1, str2, StringComparison.OrdinalIgnoreCase);

	[DebuggerStepThrough]
	public static string ToSpaceSeparatedString(this IEnumerable<string> list) 
		=> list.IsNullOrEmpty() 
			   ? string.Empty 
			   : string.Join(' ', list);

	[DebuggerStepThrough]
	public static IEnumerable<string> FromSpaceSeparatedString(this string input)
	{
		input = input.Trim();
		return input.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
	}
}