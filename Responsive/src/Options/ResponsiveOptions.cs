// Copyright (c) 2014-2022 Sarin Na Wangkanai, All Rights Reserved.Apache License, Version 2.0

using Wangkanai.Detection.Models;

namespace Wangkanai.Responsive;

/// <summary>
///     The <see cref="ResponsiveOptions" /> class is the ResponsiveWeb container for all configuration settings of Responsive.
/// </summary>
public sealed class ResponsiveOptions
{
	/// <summary>
	///     Gets or sets a value that determine the default view for Mobile
	/// </summary>
	public Device DefaultMobile { get; set; } = Device.Mobile;

	/// <summary>
	///     Gets or sets a value that determine the default view for Tablet
	/// </summary>
	public Device DefaultTablet { get; set; } = Device.Tablet;

	/// <summary>
	///     Gets or sets a value that determine the default view for Desktop
	/// </summary>
	public Device DefaultDesktop { get; set; } = Device.Desktop;

	/// <summary>
	///     Gets or sets a value that determine the responsive middleware to include Web Api Endpoint also.
	/// </summary>
	public bool IncludeWebApi { get; set; } = false;

	/// <summary>
	///     Gets or sets a value that determine the default Web Api convention path.
	/// </summary>
	public string WebApiPath { get; set; } = "/api";

	/// <summary>
	///     Gets or sets a value that determine the responsive middleware is totally disable.
	/// </summary>
	public bool Disable { get; set; } = false;
}