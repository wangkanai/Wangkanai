﻿// Copyright (c) 2014-2022 Sarin Na Wangkanai, All Rights Reserved.Apache License, Version 2.0

using Wangkanai.Federation.Models;

namespace Wangkanai.Federation.Responses;


/// <summary>
/// Discovery endpoint response maker contract
/// </summary>
public interface IDiscoveryResponseMaker
{
	Task<Dictionary<string, object>> CreateResultAsync(string issuerUri, string baseUri);

	Task<IEnumerable<JsonWebKey>> CreateJwkAsync();
}