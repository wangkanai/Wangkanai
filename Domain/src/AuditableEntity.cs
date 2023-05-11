// Copyright (c) 2014-2022 Sarin Na Wangkanai, All Rights Reserved.Apache License, Version 2.0

using System;

namespace Wangkanai.System.Domain;

public abstract class AuditableEntity<T> : Entity<T>, IAuditable
{
	#region IAuditable Members

	public DateTime  Created { get; set; }
	public DateTime? Updated { get; set; }

	#endregion

	public virtual bool ShouldSerializeAuditableProperties => true;

	public virtual bool ShouldSerializeCreated() => ShouldSerializeAuditableProperties;
	public virtual bool ShouldSerializeUpdated() => ShouldSerializeAuditableProperties;
}