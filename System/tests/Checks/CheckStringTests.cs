// Copyright (c) 2014-2022 Sarin Na Wangkanai, All Rights Reserved.Apache License, Version 2.0

using Xunit;


#nullable enable

namespace Wangkanai.Checks;

public class CheckStringTests
{
	[Fact]
	public void StringThrowIfNull()
	{
		char?   _char   = null;
		string? _string = null;

		Assert.Throws<ArgumentNullException>(() => _char.ThrowIfNull());
		Assert.Throws<ArgumentNullException>(() => _string.ThrowIfNull());

		Assert.Throws<CustomNullException>(() => _char.ThrowIfNull<CustomNullException>());
		Assert.Throws<CustomNullException>(() => _string.ThrowIfNull<CustomNullException>());
	}

	[Fact]
	public void StringIsNullOrEmptyThrowNullException()
	{
		string? _null  = null;
		string? _empty = string.Empty;

		Assert.Throws<ArgumentNullException>(() => _null.ThrowIfNullOrEmpty());
		Assert.Throws<ArgumentNullException>(() => _null.ThrowIfNullOrEmpty<ArgumentNullException>());
		Assert.Throws<CustomNullException>(() => _null.ThrowIfNullOrEmpty<CustomNullException>());

		Assert.Throws<ArgumentNullException>(() => _empty.ThrowIfNullOrEmpty());
		Assert.Throws<ArgumentNullException>(() => _empty.ThrowIfNullOrEmpty<ArgumentNullException>());
		Assert.Throws<CustomNullException>(() => _empty.ThrowIfNullOrEmpty<CustomNullException>());
	}

	[Fact]
	public void StringIsNullOrEmptyThrowArgumentException()
	{
		string? _null  = null;
		string? _empty = string.Empty;

		Assert.Throws<ArgumentException>(() => _null.ThrowIfNullOrEmpty<ArgumentException>());
		Assert.Throws<ArgumentException>(() => _null.ThrowIfNullOrEmpty<ArgumentException>("Null Exception"));
		Assert.Throws<ArgumentException>(() => _null.ThrowIfNullOrEmpty<ArgumentException>("Null Exception", nameof(_null)));

		Assert.Throws<ArgumentException>(() => _empty.ThrowIfNullOrEmpty<ArgumentException>());
		Assert.Throws<ArgumentException>(() => _empty.ThrowIfNullOrEmpty<ArgumentException>("Null Exception"));
		Assert.Throws<ArgumentException>(() => _empty.ThrowIfNullOrEmpty<ArgumentException>("Null Exception", nameof(_null)));
	}

	[Fact]
	public void StringIsNotNullOrEmptyReturnValue()
	{
		string abc = "abc";

		Assert.Equal(abc, abc.ThrowIfNullOrEmpty());
		Assert.Equal(abc, abc.ThrowIfNullOrEmpty("Null Exception"));
		Assert.Equal(abc, abc.ThrowIfNullOrEmpty("Null Exception", nameof(abc)));

		Assert.Equal(abc, abc.ThrowIfNullOrEmpty<ArgumentNullException>());
		Assert.Equal(abc, abc.ThrowIfNullOrEmpty<ArgumentNullException>("Null Exception"));
		Assert.Equal(abc, abc.ThrowIfNullOrEmpty<CustomNullException>());
		Assert.Equal(abc, abc.ThrowIfNullOrEmpty<CustomNullException>("Null Exception"));
		Assert.Equal(abc, abc.ThrowIfNullOrEmpty<CustomNullException>("Null Exception", nameof(abc)));
	}

	[Fact]
	public void StringIsNullOrWhiteSpaceThrowException()
	{
		string? _null  = null;
		string? _empty = string.Empty;
		string? _space = " ";


		Assert.Throws<ArgumentNullException>(() => _null.ThrowIfNullOrWhitespace());
		Assert.Throws<ArgumentNullException>(() => _null.ThrowIfNullOrWhitespace("Null Exception"));
		Assert.Throws<ArgumentNullException>(() => _null.ThrowIfNullOrWhitespace<ArgumentNullException>());
		Assert.Throws<ArgumentNullException>(() => _null.ThrowIfNullOrWhitespace<ArgumentNullException>("Null Exception"));
		Assert.Throws<CustomNullException>(() => _null.ThrowIfNullOrWhitespace<CustomNullException>());
		Assert.Throws<CustomNullException>(() => _null.ThrowIfNullOrWhitespace<CustomNullException>("Null Exception"));

		Assert.Throws<ArgumentNullException>(() => _empty.ThrowIfNullOrWhitespace());
		Assert.Throws<ArgumentNullException>(() => _empty.ThrowIfNullOrWhitespace("Null Exception"));
		Assert.Throws<ArgumentNullException>(() => _empty.ThrowIfNullOrWhitespace<ArgumentNullException>());
		Assert.Throws<CustomNullException>(() => _empty.ThrowIfNullOrWhitespace<CustomNullException>());

		Assert.Throws<ArgumentNullException>(() => _space.ThrowIfNullOrWhitespace());
		Assert.Throws<ArgumentNullException>(() => _space.ThrowIfNullOrWhitespace("Null Exception"));
		Assert.Throws<ArgumentNullException>(() => _space.ThrowIfNullOrWhitespace<ArgumentNullException>());
		Assert.Throws<CustomNullException>(() => _space.ThrowIfNullOrWhitespace<CustomNullException>());
	}

	[Fact]
	public void StringIsNotNullOrWhitespaceThenReturn()
	{
		string? _abc = "abc";

		Assert.Equal(_abc, _abc.ThrowIfNullOrWhitespace());
		Assert.Equal(_abc, _abc.ThrowIfNullOrWhitespace("Null Exception"));
		Assert.Equal(_abc, _abc.ThrowIfNullOrWhitespace<ArgumentNullException>());
		Assert.Equal(_abc, _abc.ThrowIfNullOrWhitespace<ArgumentException>());
		Assert.Equal(_abc, _abc.ThrowIfNullOrWhitespace<ArgumentException>("Null Exception"));
		Assert.Equal(_abc, _abc.ThrowIfNullOrWhitespace<ArgumentException>("Null Exception", nameof(_abc)));
		Assert.Equal(_abc, _abc.ThrowIfNullOrWhitespace<CustomNullException>());
		Assert.Equal(_abc, _abc.ThrowIfNullOrWhitespace<CustomNullException>("Null Exception"));
	}
}