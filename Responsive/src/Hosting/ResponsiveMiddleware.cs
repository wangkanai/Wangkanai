// Copyright (c) 2014-2022 Sarin Na Wangkanai, All Rights Reserved.Apache License, Version 2.0

using Microsoft.AspNetCore.Http;

using Wangkanai.Responsive.Extensions;
using Wangkanai.Responsive.Services;

namespace Wangkanai.Responsive.Hosting;

public sealed class ResponsiveMiddleware
{
    private readonly RequestDelegate _next;

    public ResponsiveMiddleware(RequestDelegate next)
    {
        _next = Check.NotNull(next);
    }

    public async Task InvokeAsync(HttpContext context, IResponsiveService responsive)
    {
        Check.NotNull(context);

        context.SetDevice(responsive.View);

        await _next(context);
    }
}