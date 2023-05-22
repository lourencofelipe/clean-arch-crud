using Microsoft.Extensions.DependencyInjection;

namespace Presentation.DI
{
	public static class DependencyInjection
	{
		public static IServiceCollection AddPresentation(this IServiceCollection services) 
		{
			return services;
		}
	}
}
