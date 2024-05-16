// Copyright (c) 2014-2024 Sarin Na Wangkanai, All Rights Reserved.Apache License, Version 2.0

using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.ValueGeneration;

namespace Wangkanai.EntityFramework;

public sealed class NowDateTimeGenerator : ValueGenerator<DateTime>
{
	public override bool GeneratesTemporaryValues => false;

	public override DateTime Next(EntityEntry entry)
		=> DateTime.Now;

	public override ValueTask<DateTime> NextAsync(EntityEntry entry, CancellationToken cancellationToken = new CancellationToken())
		=> ValueTask.FromResult(DateTime.Now);
}
