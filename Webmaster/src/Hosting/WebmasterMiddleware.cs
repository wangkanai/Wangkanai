// Copyright (c) 2014-2022 Sarin Na Wangkanai, All Rights Reserved.Apache License, Version 2.0

using Microsoft.AspNetCore.Http;

namespace Wangkanai.Webmaster;

public sealed class WebmasterMiddleware(RequestDelegate next)
{
	private readonly RequestDelegate _next = next.ThrowIfNull();

	public async Task InvokeAsync(HttpContext context)
	{
		context.ThrowIfNull();

		await _next(context).ConfigureAwait(false);
	}
}
