﻿// Copyright (c) 2014-2022 Sarin Na Wangkanai, All Rights Reserved.Apache License, Version 2.0

namespace Wangkanai.Blazor.Components.Sections;

internal interface ISectionContentSubscriber
{
	void ContentChanged(RenderFragment? content);
}