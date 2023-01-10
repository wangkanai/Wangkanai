// Copyright (c) 2014-2022 Sarin Na Wangkanai, All Rights Reserved.Apache License, Version 2.0

namespace Microsoft.Extensions.DependencyInjection;

public sealed class UniversalBuilder : IUniversalBuilder
{
	public UniversalBuilder(IServiceCollection services)
	{
		Services = services.ThrowIfNull();
	}

	public IServiceCollection Services { get; }
}