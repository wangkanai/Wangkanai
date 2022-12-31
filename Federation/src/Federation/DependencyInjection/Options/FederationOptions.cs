﻿// Copyright (c) 2014-2022 Sarin Na Wangkanai, All Rights Reserved.Apache License, Version 2.0

namespace Wangkanai.Federation;

/// <summary>
///     Provides programmatic configuration for the <see cref="FederationMiddleware" />.
/// </summary>
public sealed class FederationOptions
{
	public DiscoveryOptions Discovery { get; set; } = new();
}