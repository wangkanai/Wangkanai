﻿// Copyright (c) 2014-2024 Sarin Na Wangkanai, All Rights Reserved.Apache License, Version 2.0

using Microsoft.Extensions.DependencyInjection.Extensions;

using Wangkanai.Testing;

namespace Microsoft.Extensions.DependencyInjection;

/// <summary>Contains extensions method to <see cref="IServiceCollection"/> for configuring client services</summary>
public static class AssertionCollectionExtensions
{
	/// <summary>Add Assertion service to the services container</summary>
	/// <param name="services">The services available in the application</param>
	/// <returns>An <see cref="IAssertionBuilder" /> so that additional calls can be chained</returns>
	public static IAssertionBuilder AddAssertion(this IServiceCollection services)
		=> services.AddAssertionBuilder()
		           .AddMarkerService();

	/// <summary>Add Assertion service to the service container</summary>
	/// <param name="services">The services available in the application</param>
	/// <param name="configure">An <see cref="Action{AssertionOptions}" /> to configure the provided<see cref="ResponsiveOptions" /></param>
	/// <returns>An <see cref="IAssertionBuilder" /> so that additional calls can be chained</returns>
	public static IAssertionBuilder AddAssertion(this IServiceCollection services, Action<AssertionOptions> configure)
		=> services.Configure(configure)
		           .AddAssertionBuilder();

	// For internal unit tests
	internal static IAssertionBuilder AddAssertionBuilder(this IServiceCollection services)
		=> new AssertionBuilder(services);

	// For internal unit tests
	internal static IAssertionBuilder AddMarkerService(this IAssertionBuilder builder)
	{
		builder.Services.TryAddSingleton<AssertionMarkerService>();
		return builder;
	}
}