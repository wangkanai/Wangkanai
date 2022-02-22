﻿using System;

using Wangkanai.Analytics.DependencyInjection.Options;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class AnalyticsCollectionExtensions
    {
        public static IAnalyticsBuilder AddAnalytics(this IServiceCollection services)
            => services.AddAnalyticsBuilder()
                       .AddRequiredPlatformServices()
                       .AddCoreServices()
                       .AddMarkerService();

        public static IAnalyticsBuilder AddAnalytics(this IServiceCollection services, Action<AnalyticsOptions> setAction)
            => services.Configure(setAction)
                       .AddAnalytics();

        internal static IAnalyticsBuilder AddAnalyticsBuilder(this IServiceCollection services)
            => new AnalyticsBuilder(services);
    }
}