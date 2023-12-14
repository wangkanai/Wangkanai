// Copyright (c) 2014-2024 Sarin Na Wangkanai, All Rights Reserved.Apache License, Version 2.0

namespace Wangkanai;

[AttributeUsage(AttributeTargets.Struct | AttributeTargets.Constructor | AttributeTargets.Parameter)]
public class NegativeIntegerAttribute : Attribute { }

[AttributeUsage(AttributeTargets.Struct | AttributeTargets.Constructor | AttributeTargets.Parameter)]
public class PositiveIntegerAttribute : Attribute { }
