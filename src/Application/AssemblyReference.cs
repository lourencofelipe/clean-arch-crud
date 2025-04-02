using System.Reflection;

namespace CleanArch.Application;
public static class AssemblyReference
{
	public static readonly Assembly assembly = typeof(AssemblyReference).Assembly;
}
