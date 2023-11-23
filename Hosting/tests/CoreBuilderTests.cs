// Copyright (c) 2014-2024 Sarin Na Wangkanai, All Rights Reserved.Apache License, Version 2.0

using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

using Wangkanai.Hosting.DependencyInjection;
using Wangkanai.Hosting.Services;

namespace Wangkanai.Hosting.Tests;

public class CoreBuilderTests
{
	[Fact]
	public void AddMarkerService()
	{
		var services = new ServiceCollection();
		services.AddMarkerService<MarkerService>();
		var provider = services.BuildServiceProvider();
		var marker = provider.GetService<MarkerService>();
		Assert.NotNull(marker);
	}

	[Fact]
	public void AddMarkerService_VerifyIsRegistered()
	{
		var services = new ServiceCollection();
		services.AddMarkerService<MarkerService>();
		var provider = services.BuildServiceProvider();
		var app = new ApplicationBuilder(provider);
		app.VerifyMarkerIsRegistered<MarkerService>();
		Assert.NotNull(services);
		Assert.NotNull(provider);
		Assert.NotNull(app);
	}

	[Fact]
	public void AddMarkerService_ThrowsInvalidOptionException_IfMarkerServiceIsNotRegistered()
	{
		var services = new ServiceCollection();
		var provider = services.BuildServiceProvider();
		var app = new ApplicationBuilder(provider);
		var exception = Assert.Throws<InvalidOperationException>(() => app.VerifyMarkerIsRegistered<MarkerService>());
		Assert.Equal("MarkerService is not added to ConfigureServices(...)", exception.Message);
	}
}
