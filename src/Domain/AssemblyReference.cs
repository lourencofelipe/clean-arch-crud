﻿using System.Reflection;

namespace CleanArch.Domain;
public static class AssemblyReference
{
	public static readonly Assembly assembly = typeof(AssemblyReference).Assembly;
}
