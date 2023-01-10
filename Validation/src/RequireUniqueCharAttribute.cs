// Copyright (c) 2014-2022 Sarin Na Wangkanai, All Rights Reserved.Apache License, Version 2.0

namespace System.ComponentModel.DataAnnotations;

[AttributeUsage(AttributeTargets.Property | AttributeTargets.Field | AttributeTargets.Parameter)]
public sealed class RequireUniqueCharAttribute : ValidationAttribute
{
	public RequireUniqueCharAttribute(int minimum = 1)
		: base(() => $"{minimum} unique characters are required")
	{
		Minimum = minimum;
	}

	public int Minimum { get; }

	public override bool IsValid(object value)
	{
		return value switch
		{
			null          => true,
			string actual => Unique(actual).Count >= Minimum,
			_             => false
		};
	}

	private static Dictionary<char, int> Unique(string value)
	{
		var range = value.IsUnicode() ? short.MaxValue : byte.MaxValue;
		var array = new byte[range]; // or longer for unicode
		foreach (var c in value)
			array[c]++;

		var unique = new Dictionary<char, int>();

		for (var i = 0; i < array.Length; i++)
			if (array[i] > 0)
				unique.Add((char)i, array[i]);

		return unique;
	}
}