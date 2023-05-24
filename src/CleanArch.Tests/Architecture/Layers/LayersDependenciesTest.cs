using System.ComponentModel;
using NetArchTest.Rules;
using FluentAssertions;
using Xunit;

namespace CleanArch.Tests.Architecture.Layers
{
	public class LayersDependenciesTest
	{
		private readonly string ApplicationNamespace = NamespaceIdentifiers.ApplicationNamespace;
		private readonly string InfrastructureNamespace = NamespaceIdentifiers.InfrastructureNamespace;
		private readonly string WebApiNamespace = NamespaceIdentifiers.WebApiNamespace;

		[Fact]
		[Description("The Domain layer cannot have any dependency of another layer.")]
		public void Domain_Should_Not_HaveDependencyOnAnyProject()
		{
			// Arrange
			var assembly = typeof(Domain.AssemblyReference).Assembly;

			var projects = new[]
			{
				ApplicationNamespace,
				InfrastructureNamespace,
				WebApiNamespace
			};

			// Act
			var testResult = Types
				.InAssembly(assembly)
				.ShouldNot()
				.HaveDependencyOnAny(projects)
				.GetResult();

			// Assert
			testResult.IsSuccessful.Should().BeTrue();
		}

		[Fact]
		[Description("The Application layer cannot be referencing infrastructure, presentation, and Web.")]
		public void Application_Should_Not_HaveDependencyOnDefinedProjects()
		{
			// Arrange
			var assembly = typeof(Application.AssemblyReference).Assembly;

			var projects = new[]
			{
				InfrastructureNamespace,
				WebApiNamespace
			};

			// Act
			var testResult = Types
				.InAssembly(assembly)
				.ShouldNot()
				.HaveDependencyOnAny(projects)
				.GetResult();

			// Assert
			testResult.IsSuccessful.Should().BeTrue();
		}

		[Fact]
		[Description("The Infrastructure layer cannot be referencing Presentation and Web.")]
		public void InfraStructure_Should_Not_HaveDependencyOnDefinedProjects() 
		{
			// Arrange
			var assembly = typeof(Application.AssemblyReference).Assembly;

			var projects = new[]
			{
				WebApiNamespace
			};

			// Act
			var testResult = Types
				.InAssembly(assembly)
				.ShouldNot()
				.HaveDependencyOnAny(projects)
				.GetResult();

			// Assert
			testResult.IsSuccessful.Should().BeTrue();
		}

		[Fact]
		[Description("The Presentation layer cannot reference Infrastructure and Web.")]
		public void Presentation_Should_Not_HaveDependencyOnDefinedProjects()
		{
			// Arrange
			var assembly = typeof(Application.AssemblyReference).Assembly;

			var projects = new[]
			{
				InfrastructureNamespace,
				WebApiNamespace
			};

			// Act
			var testResult = Types
				.InAssembly(assembly)
				.ShouldNot()
				.HaveDependencyOnAny(projects)
				.GetResult();

			// Assert
			testResult.IsSuccessful.Should().BeTrue();
		}
	}
}
