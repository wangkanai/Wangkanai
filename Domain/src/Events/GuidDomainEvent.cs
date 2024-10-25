// Copyright (c) 2014-2024 Sarin Na Wangkanai, All Rights Reserved.Apache License, Version 2.0

namespace Wangkanai.Domain.Events;

public class GuidDomainEvent : DomainEvent<Guid>
{
	public GuidDomainEvent() => Id = Guid.NewGuid();
}
