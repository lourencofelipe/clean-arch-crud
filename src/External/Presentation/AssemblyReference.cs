using System.Reflection;

namespace CleanArch.Presentation
{
	public static class AssemblyReference
	{
		public static readonly Assembly assembly = typeof(AssemblyReference).Assembly;
	}
}
