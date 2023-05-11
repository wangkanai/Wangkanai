﻿// Copyright (c) 2014-2022 Sarin Na Wangkanai, All Rights Reserved.Apache License, Version 2.0

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;

using Wangkanai.System.Extensions.Internal;
using Wangkanai.Routing.Controllers;

namespace Wangkanai.Mvc.Infrastructure;

internal class ControllerEndpointFilterInvocationContext: EndpointFilterInvocationContext
{
	public object Controller { get; }

	internal IActionResultTypeMapper Mapper { get; }

	internal ActionContext ActionContext { get; }

	internal ObjectMethodExecutor Executor { get; }

	internal ControllerActionDescriptor ActionDescriptor { get; }

	public override HttpContext HttpContext => ActionContext.HttpContext;

	public override IList<object?> Arguments { get; }
	
	public ControllerEndpointFilterInvocationContext(
		ControllerActionDescriptor actionDescriptor,
		ActionContext              actionContext,
		ObjectMethodExecutor       executor,
		IActionResultTypeMapper    mapper,
		object                     controller,
		object?[]?                 arguments)
	{
		ActionDescriptor = actionDescriptor;
		ActionContext    = actionContext;
		Mapper           = mapper;
		Executor         = executor;
		Controller       = controller;
		Arguments        = arguments ?? Array.Empty<object?>();
	}
	
	public override T GetArgument<T>(int index) 
		=> (T)Arguments[index]!;
}
