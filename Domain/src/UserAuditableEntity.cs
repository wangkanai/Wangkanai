﻿// Copyright (c) 2014-2023 Sarin Na Wangkanai, All Rights Reserved.Apache License, Version 2.0

using System;
using System.ComponentModel.DataAnnotations;

namespace Wangkanai.Domain;

public abstract class UserAuditableEntity<T> : Entity<T>, IUserAuditable
{
	#region IUserAuditable Members

	public DateTime? CreatedDate { get; set; }
	public DateTime? UpdatedDate { get; set; }

	[StringLength(128)]
	public string CreatedBy { get; set; }

	[StringLength(128)]
	public string UpdatedBy { get; set; }

	#endregion

	public virtual bool ShouldSerializeAuditableProperties => true;

	public virtual bool ShouldSerializeCreatedDate() => ShouldSerializeAuditableProperties;
	public virtual bool ShouldSerializeUpdatedDate() => ShouldSerializeAuditableProperties;
	public virtual bool ShouldSerializeCreatedBy()   => ShouldSerializeAuditableProperties;
	public virtual bool ShouldSerializeUpdatedBy()   => ShouldSerializeAuditableProperties;
}