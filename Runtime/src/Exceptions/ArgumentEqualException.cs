﻿// Copyright (c) 2014-2022 Sarin Na Wangkanai, All Rights Reserved.Apache License, Version 2.0

namespace Wangkanai;

[Serializable]
public class ArgumentEqualException : ArgumentException
{
    public ArgumentEqualException()
        : base(SystemResources.ArgumentEqual_Generic)
    {
    }

    public ArgumentEqualException(string paramName)
        : base(SystemResources.ArgumentEqual_Generic, paramName)
    {
    }

    public ArgumentEqualException(string message, Exception innerException)
        : base(message, innerException)
    {
    }

    public ArgumentEqualException(string paramName, string message)
        : base(message, paramName)
    {
    }
}