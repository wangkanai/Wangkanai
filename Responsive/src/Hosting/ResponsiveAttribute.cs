// Copyright (c) 2014-2022 Sarin Na Wangkanai, All Rights Reserved.Apache License, Version 2.0

using Wangkanai.Detection.Models;

namespace Wangkanai.Responsive.Hosting;

public sealed class ResponsiveAttribute : Attribute, IResponsiveMetadata
{
	public ResponsiveAttribute(Device device)
	{
		Device = device;
	}

	public Device Device { get; }
}