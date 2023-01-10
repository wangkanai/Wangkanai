// Copyright (c) 2014-2022 Sarin Na Wangkanai, All Rights Reserved.Apache License, Version 2.0

using Wangkanai.Solver.Abstractions;

namespace Wangkanai.Solver;

public partial class Solver : ISolver
{
	public Solver(SolverType type)
	{
		Type = type;
	}

	public SolverType Type { get; }

	public void Dispose() { }
}