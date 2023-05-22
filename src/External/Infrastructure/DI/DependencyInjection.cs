﻿using Microsoft.Extensions.DependencyInjection;
using CleanArch.Application.Repositories;
using CleanArch.Persistence.Repositories;

namespace Persistence.DI
{
	public static class DependencyInjection
	{
		public static IServiceCollection AddPersistence(this IServiceCollection services)
		{
			ConfigureRepositories(services);

			return services;
		}

		public static void ConfigureRepositories(IServiceCollection services)
		{
			services.AddTransient<IProductRepository, ProductRepository>();
		}
	}
}
