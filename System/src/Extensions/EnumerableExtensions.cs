// Copyright (c) 2014-2022 Sarin Na Wangkanai, All Rights Reserved.Apache License, Version 2.0

#pragma warning disable CS8777 // Parameter must have a non-null value when exiting.

namespace Wangkanai.Extensions;

public static class EnumerableExtensions
{
	[DebuggerStepThrough]
	public static bool IsNull<T>([NotNull] this IEnumerable<T>? list)
		=> list is null;

	[DebuggerStepThrough]
	public static bool IsEmpty<T>([NotNull] this IEnumerable<T>? list)
		=> list is null || !list.Any();

	[DebuggerStepThrough]
	public static bool IsNullOrEmpty<T>([NotNull] this IEnumerable<T>? list)
		=> list is null || !list.Any();

	[DebuggerStepThrough]
	public static bool HasDuplicates<T, TProp>(this IEnumerable<T> list, Func<T, TProp> selector)
	{
		var hash = new HashSet<TProp>();
		foreach (var value in list)
			hash.Add(selector(value));
		var result = hash.Count != list.Count();
		return result;
	}

	[DebuggerStepThrough]
	public static IEnumerable<IEnumerable<T>> Paginate<T>(this IEnumerable<T> items, int pageSize)
	{
		var page = new List<T>();

		foreach (var item in items ?? Enumerable.Empty<T>())
		{
			page.Add(item);
			if (page.Count >= pageSize)
			{
				yield return page;
				page = new List<T>();
			}
		}

		if (page.Count > 0)
			yield return page;
	}

	/// <summary>
	/// Performs the indicated action on each item.
	/// </summary>
	/// <param name="items"></param>
	/// <param name="action">The action to be performed.</param>
	/// <remarks>If an exception occurs, the action will not be performed on the remaining items.</remarks>
	[DebuggerStepThrough]
	public static void Apply<T>(this IEnumerable<T> items, Action<T> action)
	{
		foreach (var item in items ?? Enumerable.Empty<T>())
			action(item);
	}

	/// <summary>
	/// Performs the indicated action on each item.
	/// </summary>
	/// <param name="items"></param>
	/// <param name="action">The action to be performed.</param>
	/// <remarks>If an exception occurs, the action will not be performed on the remaining items.</remarks>
	[DebuggerStepThrough]
	public static void Apply<T>(this List<T> items, Action<T> action)
	{
		foreach (var item in items ?? Enumerable.Empty<T>())
			action(item);
	}

	/// <summary>
	/// Performs the indicated action on each item.
	/// </summary>
	/// <param name="items"></param>
	/// <param name="action">The action to be performed.</param>
	/// <remarks>If an exception occurs, the action will not be performed on the remaining items.</remarks>
	[DebuggerStepThrough]
	public static void Apply<T1, T2>([NotNull] this IDictionary<T1, T2>? items, Action<T1, T2> action)
	{
		if (items is null)
			return;

		foreach (var key in items.Keys)
			action(key, items[key]!);
	}

	[DebuggerStepThrough]
	public static IDictionary<TKey, TValue> ToIDictionary<TKey, TValue>(this IEnumerable<TValue> source, Func<TValue, TKey> selector)
		where TKey : notnull
		=> source.ToDictionary(selector);

	[DebuggerStepThrough]
	public static IDictionary<TKey, TValue> ToIDictionary<TKey, TValue>(this IEnumerable<TValue> source, Func<TValue, TKey> selector, IEqualityComparer<TKey> comparer)
		where TKey : notnull
		=> source.ToDictionary(selector, comparer);
}
