using System.ComponentModel;
using NetArchTest.Rules;
using FluentAssertions;
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
				.GetResult();

			// Assert
			testResult.IsSuccessful.Should().BeTrue();
		}
	}
}
