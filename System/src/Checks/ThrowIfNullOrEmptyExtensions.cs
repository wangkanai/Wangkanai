// Copyright (c) 2014-2024 Sarin Na Wangkanai,All Rights Reserved.Apache License,Version 2.0

using Wangkanai.Exceptions;
using Wangkanai.Extensions;

namespace Wangkanai;

[DebuggerStepThrough]
public static class ThrowIfNullOrEmptyExtensions
{
	// Throw is value string is null or empty
	public static string ThrowIfNullOrEmpty(this string? value)
	{
		return value.ThrowIfNullOrEmpty<ArgumentNullOrEmptyException>();
	}

	public static string ThrowIfNullOrEmpty(this string? value, string message)
	{
		return value.ThrowIfNullOrEmpty<ArgumentNullOrEmptyException>(message);
	}

	public static string ThrowIfNullOrEmpty(this string? value, string message, [InvokerParameterName] string paramName)
	{
		return value.ThrowIfNullOrEmpty<ArgumentNullOrEmptyException>(message, paramName);
	}

	public static string ThrowIfNullOrEmpty<T>(this string? value)
		where T : ArgumentException
	{
		if (value.IsNullOrEmpty())
			throw ExceptionActivator.CreateArgumentInstance<T>(nameof(value));
		return value!;
	}

	public static string ThrowIfNullOrEmpty<T>(this string? value, string message)
		where T : ArgumentException
	{
		if (value.IsNullOrEmpty())
			throw ExceptionActivator.CreateArgumentInstance<T>(nameof(value), message);
		return value!;
	}

	public static string ThrowIfNullOrEmpty<T>(this string? value, string message, [InvokerParameterName] string paramName)
		where T : ArgumentException
	{
		if (value.IsNullOrEmpty())
			throw ExceptionActivator.CreateArgumentInstance<T>(paramName, message);
		return value!;
	}
}
