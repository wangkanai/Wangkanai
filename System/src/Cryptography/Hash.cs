// Copyright (c) 2014-2022 Sarin Na Wangkanai, All Rights Reserved.Apache License, Version 2.0

using System.Security.Cryptography;
using System.Text;

namespace Wangkanai.Cryptography;

public static class Hash
{
	public static string HashMd5([NotNull] this string value)
		=> MD5.Create()
		      .ComputeHash(value.GetAsciiBytes())
		      .HashDataToString();

	public static string HashSha512([NotNull] this string value)
		=> SHA512.Create()
		         .ComputeHash(value.GetAsciiBytes())
		         .HashDataToString();

	public static string HashSha384([NotNull] this string value)
		=> SHA384.Create()
		         .ComputeHash(value.GetAsciiBytes())
		         .HashDataToString();

	public static string HashSha256([NotNull] this string value)
		=> SHA256.Create()
		         .ComputeHash(value.GetAsciiBytes())
		         .HashDataToString();

	#region Internal

	private static byte[] GetAsciiBytes([NotNull] this string value)
		=> Encoding.ASCII.GetBytes(value);

	private static string HashDataToString([NotNull] this IEnumerable<byte> data)
	{
		var builder = new StringBuilder();
		foreach (var index in data)
			builder.Append(index.ToString("x2"));

		return builder.ToString();
	}

	#endregion
}