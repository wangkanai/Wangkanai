// Copyright (c) 2014-2021 Sarin Na Wangkanai, All Rights Reserved.
// The Apache v2. See License.txt in the project root for license information.

using Wangkanai;

namespace Microsoft.Extensions.DependencyInjection;

/// <summary>
/// Helper function for configuring detection services
/// </summary>
public class DetectionBuilder : IDetectionBuilder
{
    /// <summary>
    /// Creates a new instance of <see cref="IDetectionBuilder" />
    /// </summary>
    /// <param name="services">The <see cref="IServiceCollection" /> to attach to.</param>
    public DetectionBuilder(IServiceCollection services)
        => Services = services ?? Check.NotNull(services, nameof(services));

    /// <summary>
    /// Gets the <see cref="IServiceCollection" /> services are attached to
    /// </summary>
    /// <value>
    /// The <see cref="IServiceCollection" /> services are attached to
    /// </value>
    public IServiceCollection Services { get; }
}