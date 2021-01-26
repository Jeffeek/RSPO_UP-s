﻿#region Using namespaces

using System;

#endregion

namespace RSPO_UP_5.Model.NonLinear
{
	// ReSharper disable once IdentifierTypo
	public sealed class SinXminusA : EquationBase
	{
		public override double Calculate(double x, double a) => Math.Sin(x - a);
	}
}