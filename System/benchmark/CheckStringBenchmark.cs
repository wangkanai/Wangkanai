﻿// Copyright (c) 2014-2022 Sarin Na Wangkanai, All Rights Reserved.Apache License, Version 2.0

using BenchmarkDotNet.Jobs;

using Xunit;

namespace Wangkanai;

[SimpleJob(RuntimeMoniker.Net70, baseline: true)]
// [SimpleJob(RuntimeMoniker.Net80)]
[RPlotExporter]
[MemoryDiagnoser]
public class CheckStringBenchmark
{
	private string? _string = null;
	private string? _empty  = string.Empty;
	private string? _space  = " ";
	
	[Benchmark] public void String()     => Assert.Throws<ArgumentNullException>(() => _string.ThrowIfNull());
	[Benchmark] public void Empty()      => Assert.Throws<ArgumentNullException>(() => _empty.ThrowIfNullOrEmpty());
	[Benchmark] public void Whitespace() => Assert.Throws<ArgumentNullException>(() => _space.ThrowIfNullOrWhitespace());
}