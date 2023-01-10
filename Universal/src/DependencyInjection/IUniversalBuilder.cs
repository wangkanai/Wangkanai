// Copyright (c) 2014-2022 Sarin Na Wangkanai, All Rights Reserved.Apache License, Version 2.0

namespace Microsoft.Extensions.DependencyInjection;

/// <summary>
///     Helper function for configuring google universal analytics services.
/// </summary>
public interface IUniversalBuilder
{
	/// <summary>
	///     Get the <see cref="IServiceCollection" /> services are attached to.
	/// </summary>
	/// <value>
	///     The <see cref="IServiceCollection" /> services are attached to.
	/// </value>
	IServiceCollection Services { get; }
}