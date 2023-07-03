﻿// Copyright (c) 2014-2022 Sarin Na Wangkanai, All Rights Reserved.Apache License, Version 2.0

using System.Globalization;
#nullable enable
using Xunit;

namespace Wangkanai.Extensions.Strings;

public class StringRemoveFix
{
	string? _null  = null;
	string? _empty = string.Empty;
	string? _space = " ";
	string? abcde  = "abcde";

	[Fact]
	public void RemovePreFixTest()
	{
		Assert.Equal("cde", abcde.RemovePreFixes("ab"));
	}

	[Fact]
	public void RemovePreFixNullTest()
	{
		Assert.Throws<ArgumentNullException>(() => _null.RemovePreFixes("ab"));
	}

	[Fact]
	public void RemovePreFixEmptyTest()
	{
		Assert.Equal(_empty, _empty.RemovePreFixes("ab"));
	}

	[Fact]
	public void RemovePreFixSpaceTest()
	{
		Assert.Equal(_space, _space.RemovePreFixes("ab"));
	}

	[Fact]
	public void RemovePreFixNoMatchTest()
	{
		Assert.Equal(abcde, abcde.RemovePreFixes("abx"));
	}

	[Fact]
	public void RemovePreFixNoMatchIgnoreCaseTest()
	{
		Assert.Equal(abcde, abcde.RemovePreFixes("ABx"));
	}

	[Fact]
	public void RemovePreFixIgnoreCaseTest()
	{
		Assert.Equal("cde", abcde.RemovePreFixes(true, CultureInfo.InvariantCulture, "AB"));
	}

	[Fact]
	public void RemovePreFixCultureTest()
	{
		Assert.Equal("cde", abcde.RemovePreFixes(true, CultureInfo.InvariantCulture, "AB"));
	}

	[Fact]
	public void RemovePreFixCultureIgnoreCaseTest()
	{
		Assert.Equal("cde", abcde.RemovePreFixes(true, CultureInfo.InvariantCulture, "AB"));
	}

	[Fact]
	public void RemovePreFixCultureNoMatchTest()
	{
		Assert.Equal(abcde, abcde.RemovePreFixes(true, CultureInfo.InvariantCulture, "ABx"));
	}

	[Fact]
	public void RemovePreFixCultureNoMatchIgnoreCaseTest()
	{
		Assert.Equal(abcde, abcde.RemovePreFixes(true, CultureInfo.InvariantCulture, "ABx"));
	}

	[Fact]
	public void RemovePreFixCultureNullTest()
	{
		Assert.Throws<ArgumentNullException>(() => _null.RemovePreFixes(true, CultureInfo.InvariantCulture, "AB"));
	}

	[Fact]
	public void RemovePreFixCultureEmptyTest()
	{
		Assert.Equal(_empty, _empty.RemovePreFixes(true, CultureInfo.InvariantCulture, "AB"));
	}

	[Fact]
	public void RemovePreFixCultureSpaceTest()
	{
		Assert.Equal(_space, _space.RemovePreFixes(true, CultureInfo.InvariantCulture, "AB"));
	}

	[Fact]
	public void RemovePreFixCultureNoMatchNullTest()
	{
		Assert.Throws<ArgumentNullException>(() => _null.RemovePreFixes(true, CultureInfo.InvariantCulture, "ABx"));
	}

	[Fact]
	public void RemovePreFixCultureNoMatchEmptyTest()
	{
		Assert.Equal(_empty, _empty.RemovePreFixes(true, CultureInfo.InvariantCulture, "ABx"));
	}

	[Fact]
	public void RemovePreFixCultureNoMatchSpaceTest()
	{
		Assert.Equal(_space, _space.RemovePreFixes(true, CultureInfo.InvariantCulture, "ABx"));
	}

	[Fact]
	public void RemovePreFixCultureNoMatchIgnoreCaseNullTest()
	{
		Assert.Throws<ArgumentNullException>(() => _null.RemovePreFixes(true, CultureInfo.InvariantCulture, "ABx"));
	}

	[Fact]
	public void RemovePreFixCultureNoMatchIgnoreCaseEmptyTest()
	{
		Assert.Equal(_empty, _empty.RemovePreFixes(true, CultureInfo.InvariantCulture, "ABx"));
	}

	[Fact]
	public void RemovePreFixCultureNoMatchIgnoreCaseSpaceTest()
	{
		Assert.Equal(_space, _space.RemovePreFixes(true, CultureInfo.InvariantCulture, "ABx"));
	}

	[Fact]
	public void RemovePreFixCultureIgnoreCaseNullTest()
	{
		Assert.Throws<ArgumentNullException>(() => _null.RemovePreFixes(true, CultureInfo.InvariantCulture, "AB"));
	}

	[Fact]
	public void RemovePreFixCultureIgnoreCaseEmptyTest()
	{
		Assert.Equal(_empty, _empty.RemovePreFixes(true, CultureInfo.InvariantCulture, "AB"));
	}

	[Fact]
	public void RemovePreFixCultureIgnoreCaseSpaceTest()
	{
		Assert.Equal(_space, _space.RemovePreFixes(true, CultureInfo.InvariantCulture, "AB"));
	}

	[Fact]
	public void RemovePreFixCultureIgnoreCaseNoMatchNullTest()
	{
		Assert.Throws<ArgumentNullException>(() => _null.RemovePreFixes(true, CultureInfo.InvariantCulture, "ABx"));
	}

	[Fact]
	public void RemovePreFixCultureIgnoreCaseNoMatchEmptyTest()
	{
		Assert.Equal(_empty, _empty.RemovePreFixes(true, CultureInfo.InvariantCulture, "ABx"));
	}

	[Fact]
	public void RemovePreFixCultureIgnoreCaseNoMatchSpaceTest()
	{
		Assert.Equal(_space, _space.RemovePreFixes(true, CultureInfo.InvariantCulture, "ABx"));
	}

	[Fact]
	public void RemovePreFixCultureIgnoreCaseNoMatchTest()
	{
		Assert.Equal(abcde, abcde.RemovePreFixes(true, CultureInfo.InvariantCulture, "ABx"));
	}

	[Fact]
	public void RemovePostFixTest()
	{
		Assert.Equal("abc", abcde.RemovePostFixes("de"));
	}

	[Fact]
	public void RemovePostFixNullTest()
	{
		Assert.Throws<ArgumentNullException>(() => _null.RemovePostFixes());
	}

	[Fact]
	public void RemovePostFixEmptyTest()
	{
		Assert.Equal(_empty, _empty.RemovePostFixes("de"));
	}

	[Fact]
	public void RemovePostFixSpaceTest()
	{
		Assert.Equal(_space, _space.RemovePostFixes("de"));
	}

	[Fact]
	public void RemovePostFixNoMatchTest()
	{
		Assert.Equal(abcde, abcde.RemovePostFixes("dex"));
	}

	[Fact]
	public void RemovePostFixNoMatchIgnoreCaseTest()
	{
		Assert.Equal(abcde, abcde.RemovePostFixes("dEx"));
	}

	[Fact]
	public void RemovePostFixIgnoreCaseTest()
	{
		Assert.Equal("abc", abcde.RemovePostFixes(true, CultureInfo.InvariantCulture, "DE"));
	}

	[Fact]
	public void RemovePostFixCultureTest()
	{
		Assert.Equal("abc", abcde.RemovePostFixes(true, CultureInfo.InvariantCulture, "DE"));
	}

	[Fact]
	public void RemovePostFixCultureIgnoreCaseTest()
	{
		Assert.Equal("abc", abcde.RemovePostFixes(true, CultureInfo.InvariantCulture, "DE"));
	}

	[Fact]
	public void RemovePostFixCultureNoMatchTest()
	{
		Assert.Equal(abcde, abcde.RemovePostFixes(true, CultureInfo.InvariantCulture, "DEx"));
	}

	[Fact]
	public void RemovePostFixCultureNoMatchIgnoreCaseTest()
	{
		Assert.Equal(abcde, abcde.RemovePostFixes(true, CultureInfo.InvariantCulture, "DEx"));
	}

	[Fact]
	public void RemovePostFixCultureNullTest()
	{
		Assert.Throws<ArgumentNullException>(() => _null.RemovePostFixes(true, CultureInfo.InvariantCulture, "DE"));
	}

	[Fact]
	public void RemovePostFixCultureEmptyTest()
	{
		Assert.Equal(_empty, _empty.RemovePostFixes(true, CultureInfo.InvariantCulture, "DE"));
	}

	[Fact]
	public void RemovePostFixCultureSpaceTest()
	{
		Assert.Equal(_space, _space.RemovePostFixes(true, CultureInfo.InvariantCulture, "DE"));
	}

	[Fact]
	public void RemovePostFixCultureNoMatchNullTest()
	{
		Assert.Throws<ArgumentNullException>(() => _null.RemovePostFixes(true, CultureInfo.InvariantCulture, "DEx"));
	}

	[Fact]
	public void RemovePostFixCultureNoMatchEmptyTest()
	{
		Assert.Equal(_empty, _empty.RemovePostFixes(true, CultureInfo.InvariantCulture, "DEx"));
	}

	[Fact]
	public void RemovePostFixCultureNoMatchSpaceTest()
	{
		Assert.Equal(_space, _space.RemovePostFixes(true, CultureInfo.InvariantCulture, "DEx"));
	}

	[Fact]
	public void RemovePostFixCultureNoMatchIgnoreCaseNullTest()
	{
		Assert.Throws<ArgumentNullException>(() => _null.RemovePostFixes(true, CultureInfo.InvariantCulture, "DEx"));
	}

	[Fact]
	public void RemovePostFixCultureNoMatchIgnoreCaseEmptyTest()
	{
		Assert.Equal(_empty, _empty.RemovePostFixes(true, CultureInfo.InvariantCulture, "DEx"));
	}

	[Fact]
	public void RemovePostFixCultureNoMatchIgnoreCaseSpaceTest()
	{
		Assert.Equal(_space, _space.RemovePostFixes(true, CultureInfo.InvariantCulture, "DEx"));
	}

	[Fact]
	public void RemovePostFixCultureIgnoreCaseNullTest()
	{
		Assert.Throws<ArgumentNullException>(() => _null.RemovePostFixes(true, CultureInfo.InvariantCulture, "DE"));
	}

	[Fact]
	public void RemovePostFixCultureIgnoreCaseEmptyTest()
	{
		Assert.Equal(_empty, _empty.RemovePostFixes(true, CultureInfo.InvariantCulture, "DE"));
	}
}