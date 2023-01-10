// Copyright (c) 2014-2022 Sarin Na Wangkanai, All Rights Reserved.Apache License, Version 2.0

using Wangkanai.Universal.Options;

namespace Microsoft.Extensions.DependencyInjection;

/// <summary>
///     Contain extension methods to <see cref="IServiceCollection" /> for configuring client services.
/// </summary>
public static class UniversalCollectionExtensions
{
	public static IUniversalBuilder AddGoogleAnalytics(this IServiceCollection services)
	{
		return services.AddUniversalBuilder()
		               .AddRequiredPlatformServices()
		               .AddCoreServices()
		               .AddMarkerService();
	}

	public static IUniversalBuilder AddGoogleAnalytics(this IServiceCollection services, Action<UniversalOption> setAction)
	{
		return services.Configure(setAction)
		               .AddGoogleAnalytics();
	}

	internal static IUniversalBuilder AddUniversalBuilder(this IServiceCollection services)
	{
		return new UniversalBuilder(services);
	}
}