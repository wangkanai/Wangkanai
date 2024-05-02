// Copyright (c) 2014-2024 Sarin Na Wangkanai, All Rights Reserved.Apache License, Version 2.0

using System.Reflection;

namespace Wangkanai.Attributes;

public class ZeroIntegerAttributeTests
{
	[Fact]
	public void ZeroIntegerAttribute_Constructor()
	{
		var attribute = new ZeroIntegerAttribute();
		Assert.NotNull(attribute);
	}

	[Fact]
	public void Struct_Default_WithNoAttribute()
	{
		var attribute = typeof(ZeroIntegerStructDefault).GetCustomAttribute<ZeroIntegerAttribute>();
		Assert.Null(attribute);
	}

	[Fact]
	public void Struct_Attribute_Exist()
	{
		var attribute = typeof(ZeroIntegerStructExist).GetCustomAttribute<ZeroIntegerAttribute>();
		var expected  = "The value must be zero integer.";
		Assert.NotNull(attribute);
		Assert.Equal(expected, attribute!.Message);
	}

	[Fact]
	public void Struct_Attribute_Error()
	{
		var attribute = typeof(ZeroIntegerStructError).GetCustomAttribute<ZeroIntegerAttribute>();
		var expected  = "error";
		Assert.NotNull(attribute);
		Assert.Equal(expected, attribute!.Message);
		Assert.True(attribute.IsError);
	}

	[Fact]
	public void Constructor_Attribute_Exist()
	{
		var type      = typeof(ZeroIntegerConstructorExist);
		var ctor      = type.GetConstructors();
		var attribute = ctor[0].GetCustomAttribute<ZeroIntegerAttribute>();
		var expected  = "The value must be zero integer.";
		Assert.NotNull(attribute);
		Assert.Equal(expected, attribute!.Message);
	}

	[Fact]
	public void Constructor_Attribute_Error()
	{
		var type      = typeof(ZeroIntegerConstructorError);
		var ctor      = type.GetConstructors();
		var attribute = ctor[0].GetCustomAttribute<ZeroIntegerAttribute>();
		var expected  = "error";
		Assert.NotNull(attribute);
		Assert.Equal(expected, attribute!.Message);
		Assert.True(attribute.IsError);
	}
}
