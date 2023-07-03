﻿// Copyright (c) 2014-2022 Sarin Na Wangkanai, All Rights Reserved.Apache License, Version 2.0

#nullable enable

using Wangkanai.Exceptions;

using Xunit;

namespace Wangkanai.Checks;

public class CheckCompareTests
{
	[Fact]
	public void ThrowIfEqualCondition()
	{
		Assert.False(1.ThrowIfEqual(0));
		Assert.Throws<ArgumentEqualException>(() => 1.ThrowIfEqual(1));
	}

	[Fact]
	public void ThrowIfEqualExtension()
	{
		var test = "test";
		Assert.False(test.Length.ThrowIfEqual(8));
		Assert.Throws<ArgumentEqualException>(() => test.Length.ThrowIfEqual(4));
		Assert.Throws<ArgumentEqualException>(() => test.Length.ThrowIfEqual<ArgumentEqualException>(4));
		Assert.Throws<ArgumentEqualException>(() => test.Length.ThrowIfEqual<ArgumentEqualException>(4, nameof(test)));
	}

	[Fact]
	public void ThrowIfNotEqualCondition()
	{
		Assert.True(1.ThrowIfNotEqual(1));
		Assert.Throws<ArgumentNotEqualException>(() => 1.ThrowIfNotEqual(0));
	}

	[Fact]
	public void ThrowIfNotEqualExtension()
	{
		var test = "test";
		Assert.True(test.Length.ThrowIfNotEqual(4));
		Assert.Throws<ArgumentNotEqualException>(() => test.Length.ThrowIfNotEqual(8));
		Assert.Throws<ArgumentNotEqualException>(() => test.Length.ThrowIfNotEqual<ArgumentNotEqualException>(8));
		Assert.Throws<ArgumentNotEqualException>(() => test.Length.ThrowIfNotEqual<ArgumentNotEqualException>(8, nameof(test)));
	}

	[Fact]
	public void LessThanExpectedTrue()
	{
		Assert.True(1.ThrowIfLessThan(0));
		Assert.True(1.ThrowIfLessThan(1));
		Assert.True(0.ThrowIfLessThan(0));
		Assert.True(1.ThrowIfLessThan(0, nameof(LessThanExpectedTrue)));
		Assert.True(1.ThrowIfLessThan(1, nameof(LessThanExpectedTrue)));
		Assert.True(0.ThrowIfLessThan(0, nameof(LessThanExpectedTrue)));
	}

	[Fact]
	public void LessThanExpectedThrow()
	{
		Assert.Throws<ArgumentLessThanException>(() => 0.ThrowIfLessThan(1));
		Assert.Throws<ArgumentLessThanException>(() => 0.ThrowIfLessThan(1, nameof(LessThanExpectedThrow)));
		Assert.Throws<ArgumentLessThanException>(() => 0.ThrowIfLessThan<ArgumentLessThanException>(1));
		Assert.Throws<ArgumentLessThanException>(() => 0.ThrowIfLessThan<ArgumentLessThanException>(1, nameof(LessThanExpectedThrow)));
	}

	[Fact]
	public void MoreThanExpectedTrue()
	{
		Assert.True(0.ThrowIfMoreThan(1));
		Assert.True(1.ThrowIfMoreThan(1));
		Assert.True(0.ThrowIfMoreThan(0));
		Assert.True(0.ThrowIfMoreThan(1, nameof(MoreThanExpectedTrue)));
		Assert.True(1.ThrowIfMoreThan(1, nameof(MoreThanExpectedTrue)));
		Assert.True(0.ThrowIfMoreThan(0, nameof(MoreThanExpectedTrue)));
	}

	[Fact]
	public void MoreThanExpectedThrow()
	{
		Assert.Throws<ArgumentMoreThanException>(() => 1.ThrowIfMoreThan(0));
		Assert.Throws<ArgumentMoreThanException>(() => 1.ThrowIfMoreThan(0, nameof(MoreThanExpectedThrow)));
		Assert.Throws<ArgumentMoreThanException>(() => 1.ThrowIfMoreThan<ArgumentMoreThanException>(0));
		Assert.Throws<ArgumentMoreThanException>(() => 1.ThrowIfMoreThan<ArgumentMoreThanException>(0, nameof(MoreThanExpectedThrow)));
	}

	[Fact]
	public void ThrowIfZeroTruePositive()
	{
		var positive = 1;
		Assert.True(positive.ThrowIfZero());
		Assert.True(positive.ThrowIfZero(nameof(ThrowIfZeroTruePositive)));
		Assert.True(positive.ThrowIfZero<ArgumentZeroException>());
		Assert.True(positive.ThrowIfZero<ArgumentZeroException>(nameof(ThrowIfZeroTruePositive)));
	}

	[Fact]
	public void ThrowIfZeroTrueNegative()
	{
		var negative = -1;
		Assert.True(negative.ThrowIfZero());
		Assert.True(negative.ThrowIfZero(nameof(ThrowIfZeroTrueNegative)));
		Assert.True(negative.ThrowIfZero<ArgumentZeroException>());
		Assert.True(negative.ThrowIfZero<ArgumentZeroException>(nameof(ThrowIfZeroTrueNegative)));
	}

	[Fact]
	public void ThrowIfZeroFail()
	{
		var zero = 0;
		Assert.Throws<ArgumentZeroException>(() => zero.ThrowIfZero());
		Assert.Throws<ArgumentZeroException>(() => zero.ThrowIfZero(nameof(ThrowIfZeroFail)));
		Assert.Throws<ArgumentZeroException>(() => zero.ThrowIfZero<ArgumentZeroException>());
		Assert.Throws<ArgumentZeroException>(() => zero.ThrowIfZero<ArgumentZeroException>(nameof(ThrowIfZeroFail)));
	}
}