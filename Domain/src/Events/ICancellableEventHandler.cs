// Copyright (c) 2014-2023 Sarin Na Wangkanai, All Rights Reserved.Apache License, Version 2.0

using System.Threading;
using System.Threading.Tasks;

using Wangkanai.Domain.Messages;

namespace Wangkanai.Domain.Events;

public interface ICancellableEventHandler<in T>
	where T : IMessage
{
	Task Handle(T message, CancellationToken token = default);
}

public interface ICancellableEventHandlerAsync<in T>
	where T : IMessage
{
	Task HandleAsync(T message, CancellationToken token = default);
}