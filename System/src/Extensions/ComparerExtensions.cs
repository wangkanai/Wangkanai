﻿// Copyright (c) 2014-2022 Sarin Na Wangkanai, All Rights Reserved.Apache License, Version 2.0

using Wangkanai.Collections;

namespace Wangkanai.Extensions;

public static class ComparerExtensions
{
	/// <summary>
	/// Reverse the original comparer, if it was already a reverse comparer, it will return the original comparer.
	/// </summary>
	public static IComparer<T> Reverse<T>(this IComparer<T> original)
	{
		if (original is ReverseComparer<T> reverse)
			return reverse.Original;

		return new ReverseComparer<T>(original);
	}

	/// <summary>
	/// Combine a comparer with another comparer to implement a compound comparer.
	/// </summary>
	public static IComparer<T> ThenBy<T>(this IComparer<T> first, IComparer<T> second)
	{
		return new LinkedComparer<T>(first, second);
	}

	/// <summary>
	/// Combine a comparer with a projection to implement a compound comparer.
	/// </summary>
	public static IComparer<T> ThenBy<T, TKey>(this IComparer<T> first, Func<T, TKey> projection)
	{
		return new LinkedComparer<T>(first, new ProjectionComparer<T, TKey>(projection));
	}
}