using System.Reflection;

namespace CleanArch.Infrastructure
{
	public static class AssemblyReference
	{
		public static readonly Assembly assembly = typeof(AssemblyReference).Assembly;
	}
}
