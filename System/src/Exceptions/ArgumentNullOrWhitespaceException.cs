﻿// Copyright (c) 2014-2022 Sarin Na Wangkanai, All Rights Reserved.Apache License, Version 2.0

using Wangkanai.Resources;

namespace Wangkanai.Exceptions;

[Serializable]
public class ArgumentNullOrWhitespaceException : ArgumentException
{
	public ArgumentNullOrWhitespaceException() : base(SystemResources.ArgumentNullOrEmptyGeneric) { }
	public ArgumentNullOrWhitespaceException(string paramName) : base(paramName, SystemResources.ArgumentNullOrEmptyGeneric) { }
	public ArgumentNullOrWhitespaceException(string paramName, string    message) : base(paramName, message) { }
	public ArgumentNullOrWhitespaceException(string message,   Exception innerException) : base(message, innerException) { }
}