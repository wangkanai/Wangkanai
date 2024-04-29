// Copyright (c) 2014-2022 Sarin Na Wangkanai, All Rights Reserved.Apache License, Version 2.0

namespace Wangkanai.Extensions;

public static class EnumValues
{
	[DebuggerStepThrough]
	public static T[] GetValues<T>(this T value)
		where T : Enum
		=> Enum.GetValues(typeof(T)).Cast<T>().ToArray();
}

public static class EnumValues<T> where T : Enum
{
	[DebuggerStepThrough]
	public static T[] GetValues()
		=> Values;

	[DebuggerStepThrough]
	public static Dictionary<T, string> GetNames()
		=> Names;

	[DebuggerStepThrough]
	public static bool TryGetSingleName(T value, out string result)
		=> Names.TryGetValue(value, out result!);

	[DebuggerStepThrough]
	public static string GetName(T value)
		=> Names.TryGetValue(value, out var result)
			   ? result
			   : string.Join(',', value.GetFlags().Select(x => Names[x]));

	private static T[] Values
		=> (T[])Enum.GetValues(typeof(T));

	private static Dictionary<T, string> Names
		=> Values.ToDictionary(value => value, value => value.ToString().ToLowerInvariant());
}
