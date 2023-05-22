using System.Reflection;

namespace CleanArch.WebApi
{
	public static class AssemblyReference
	{
		public static readonly Assembly assembly = typeof(AssemblyReference).Assembly;
	}
}
