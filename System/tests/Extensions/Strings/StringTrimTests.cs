﻿// Copyright (c) 2014-2022 Sarin Na Wangkanai, All Rights Reserved.Apache License, Version 2.0

using Wangkanai.Exceptions;

using Xunit;

namespace Wangkanai.Extensions.Strings;

#nullable enable

public class StringTrimTests
{
	string? _null  = null;
	string? _empty = string.Empty;
	string? _space = " ";
	string? text   = "abcde";

	[Fact]
	public void LeftExist()
	{
		Assert.Equal("", text.Left(0));
		Assert.Equal("ab", text.Left(2));
		Assert.Equal("abcde", text.Left(5));
	}

	[Fact]
	public void LeftNull()
	{
		Assert.Throws<ArgumentNullException>(() => _null.Left(-1));
		Assert.Throws<ArgumentNullException>(() => _null.Left(0));
		Assert.Throws<ArgumentNullException>(() => _null.Left(1));
		Assert.Throws<ArgumentNullException>(() => _null.Left(2));
	}

	[Fact]
	public void LeftEmpty()
	{
		Assert.Equal(_empty, _empty.Left(0));
		Assert.Throws<ArgumentOutOfRangeException>(() => _empty.Left(-1));
		Assert.Throws<ArgumentOutOfRangeException>(() => _empty.Left(-2));
	}

	[Fact]
	public void LeftSpace()
	{
		Assert.Equal(_empty, _space.Left(0));
		Assert.Equal(_space, _space.Left(1));
		Assert.Throws<ArgumentLessThanException>(() => _space.Left(2));
		Assert.Throws<ArgumentLessThanException>(() => _space.Left(3));
		Assert.Throws<ArgumentLessThanException>(() => _space.Left(4));
	}

	[Fact]
	public void RightExist()
	{
		Assert.Equal("", text.Right(0));
		Assert.Equal("de", text.Right(2));
		Assert.Equal("abcde", text.Right(5));
	}

	[Fact]
	public void RightNull()
	{
		Assert.Throws<ArgumentNullException>(() => _null.Right(-1));
		Assert.Throws<ArgumentNullException>(() => _null.Right(0));
		Assert.Throws<ArgumentNullException>(() => _null.Right(1));
		Assert.Throws<ArgumentNullException>(() => _null.Right(2));
	}

	[Fact]
	public void RightEmpty()
	{
		Assert.Equal(_empty, _empty.Right(0));
		Assert.Throws<ArgumentOutOfRangeException>(() => _empty.Right(-1));
		Assert.Throws<ArgumentOutOfRangeException>(() => _empty.Right(-2));
	}

	[Fact]
	public void RightSpace()
	{
		Assert.Equal(_empty, _space.Right(0));
		Assert.Equal(_space, _space.Right(1));
		Assert.Throws<ArgumentLessThanException>(() => _space.Right(2));
		Assert.Throws<ArgumentLessThanException>(() => _space.Right(3));
		Assert.Throws<ArgumentLessThanException>(() => _space.Right(4));
	}

	[Fact]
	public void RemoveAllExist()
	{
		Assert.Empty(text.RemoveAll(text));
		Assert.NotNull(text.RemoveAll(text));
	}

	[Fact]
	public void RemoveAllNothing()
	{
		Assert.Throws<ArgumentNullException>(() => _null.RemoveAll());
		Assert.Empty(_empty.RemoveAll());
		Assert.Equal(_space, _space.RemoveAll());
	}
}