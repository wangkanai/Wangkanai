// Copyright (c) 2014-2022 Sarin Na Wangkanai, All Rights Reserved.Apache License, Version 2.0

using Microsoft.AspNetCore.Http;

namespace Wangkanai.Responsive.Mocks;

public class MockHttpContextAccessor : IHttpContextAccessor
{
	public HttpContext? HttpContext { get; set; } = new DefaultHttpContext();
}