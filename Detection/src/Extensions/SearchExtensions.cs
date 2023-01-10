// Copyright (c) 2014-2022 Sarin Na Wangkanai, All Rights Reserved.Apache License, Version 2.0

namespace Wangkanai.Detection.Extensions;

public static class SearchExtensions
{
	public static IndexTree BuildIndexTree(this string[] keywords)
	{
		return new(keywords);
	}

	public static IndexTree BuildIndexTree(this IEnumerable<string> keywords)
	{
		return new(keywords.Distinct().ToArray());
	}

	public static bool SearchStartsWith(this string searchString, IndexTree searchTree)
	{
		return searchString.AsSpan().SearchStartsWith(searchTree);
	}

	private static bool SearchStartsWith(this ReadOnlySpan<char> searchString, IndexTree searchTree)
	{
		return searchTree.StartsWithAnyIn(searchString);
	}

	public static bool SearchContains(this string searchString, IndexTree searchTree)
	{
		return searchString.AsSpan().SearchContains(searchTree);
	}

	public static bool SearchContains(this ReadOnlySpan<char> searchString, IndexTree searchTree)
	{
		return searchTree.ContainsWithAnyIn(searchString);
	}
}