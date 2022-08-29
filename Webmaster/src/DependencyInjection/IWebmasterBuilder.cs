// Copyright (c) 2014-2022 Sarin Na Wangkanai, All Rights Reserved.Apache License, Version 2.0

namespace Microsoft.Extensions.DependencyInjection;

/// <summary>
/// Webmaster builder interface
/// </summary>
public interface IWebmasterBuilder
{
    /// <summary>
    /// Gets the <see cref="IServiceCollection" /> services are attached to.
    /// </summary>
    /// <value>
    /// The <see cref="IServiceCollection" /> services are attached to.
    /// </value>
    IServiceCollection Services { get; }
}