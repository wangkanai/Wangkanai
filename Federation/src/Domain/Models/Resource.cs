// Copyright (c) 2014-2024 Sarin Na Wangkanai, All Rights Reserved.Apache License, Version 2.0

using System.Diagnostics;

namespace Wangkanai.Federation.Models;

/// <summary>
/// Models the common data Api and identity resources.
/// </summary>
[DebuggerDisplay("{DebuggerDisplay,nq}")]
public abstract class Resource
{
	private string DebuggerDisplay => Name ?? $"{{{typeof(Resource)}}}";

	/// <summary>
	/// Indicates if this resource is enabled. Defaults to true.
	/// </summary>
	public bool Enable { get; set; } = true;

	/// <summary>
	/// The unique name of the resource.
	/// </summary>
	public string Name { get; set; } = default!;

	/// <summary>
	/// Display name of the resource.
	/// </summary>
	public string? DisplayName { get; set; }

	/// <summary>
	/// Description of the resource.
	/// </summary>
	public string? Description { get; set; }

	/// <summary>
	/// Specifies whether this scope is shown in the discovery document. Defaults to true.
	/// </summary>
	public bool ShowInDiscoveryDocument { get; set; } = true;

	/// <summary>
	/// List of associated user claims that should be included when this resource is requested.
	/// </summary>
	public ICollection<string> Claims { get; set; } = new HashSet<string>();

	/// <summary>
	/// List of custom properties for the resource.
	/// </summary>
	public IDictionary<string, string> Properties { get; set; } = new Dictionary<string, string>();
}
