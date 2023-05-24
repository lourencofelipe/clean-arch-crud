using System.ComponentModel;
using NetArchTest.Rules;
using Xunit;

namespace CleanArch.Tests.Architecture.API
{
	public class ControllerTest
	{
		[Fact]
		[Description("Controllers should reference MediatR.")]
		public void Controllers_Should_HaveDependencyOnMediatR()
		{
			// Arrange
			var assembly = typeof(WebApi.AssemblyReference).Assembly;

			// Act
			var testResult = Types
				.InAssembly(assembly)
				.That()
				.ResideInNamespace("CleanArch.WebApi.Controllers")
				.Should()
				.HaveDependencyOn("MediatR")
				.GetResult()
				.IsSuccessful;

			// Assert
			Assert.True(testResult, "Controllers should reference MediatR.");
		}

		[Fact]
		[Description("Controllers cannot access repositories directly.")]
		public void Controllers_ShouldNot_HaveDependencyOnRepositories() 
		{
			
			// Arrange
			var assembly = typeof(WebApi.AssemblyReference).Assembly;

			// Act
			var testResult = Types
				.InAssembly(assembly)
				.That()
				.ResideInNamespace("CleanArch.WebApi.Controllers")
				.ShouldNot()
				.HaveDependencyOn("CleanArch.Persistence.Repositories")
				.GetResult()
				.IsSuccessful;

			// Assert
			Assert.True(testResult, "Controllers cannot access repositories directly.");
		}
	}
}
