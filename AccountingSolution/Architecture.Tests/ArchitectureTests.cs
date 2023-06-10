
using System;
using System.Reflection;
using System.Xml.Linq;
using Microsoft.AspNetCore.Hosting;
using NetArchTest.Rules;
using Xunit;
using NetArchTest.Rules.Extensions;

namespace Architecture.Tests
{
    public class ArchitectureTests
    {
        private const string ApplicationNameSpace = "Application";
        private const string DomainNameSpace = "Domain";
        private const string InfrastructureNameSpace = "Infrastructure";
        private const string WebAPINameSpace = "WebAPI";

        [Fact]
        public void Donain_Shoud_Not_HaveDependencyOnOtherProject()
        {
            //Arrange

            var assembly = typeof(Domain.Model.Customer.CustomerModel).Assembly;


            //Act

            var otherProjects = new[]
            {
                ApplicationNameSpace,
                InfrastructureNameSpace,
                WebAPINameSpace

            };

            var testResult = Types.InAssembly(assembly)
                  .ShouldNot()
                  .HaveDependencyOnAll(otherProjects)
                  .GetResult();


            //Assert


            Assert.True(testResult.IsSuccessful);
        }


        [Fact]
        public void Application_Shoud_Not_HaveDependencyOnOtherProject()
        {
            //Arrange

            var assembly = typeof(Application.DependencyInjection).Assembly;


            //Act

            var otherProjects = new[]
            {


                InfrastructureNameSpace,
                WebAPINameSpace

            };

            var testResult = Types.InAssembly(assembly)
                  .ShouldNot()
                  .HaveDependencyOnAll(otherProjects)
                  .GetResult();


            //Assert


            Assert.True(testResult.IsSuccessful);
        }



        [Fact]
        public void WebAPI_Shoud_Not_HaveDependencyOnOtherProject()
        {
            //Arrange

            var assembly = typeof(Application.DependencyInjection).Assembly;


            //Act

            var otherProjects = new[]
            {


                InfrastructureNameSpace


            };

            var testResult = Types.InAssembly(assembly)
                  .ShouldNot()
                  .HaveDependencyOnAll(otherProjects)
                  .GetResult();


            //Assert


            Assert.True(testResult.IsSuccessful);
        }


        [Fact]
        public void Handlers_Shoud_Have_DependencyOnDomain()
        {
            //Arrange

            var assembly = typeof(Application.DependencyInjection).Assembly;


            //Act



            var testResult = Types.InAssembly(assembly)
                 .That()
                 .HaveNameEndingWith("Handler")
                 .Should()
                  .HaveDependencyOn(DomainNameSpace)
                  .GetResult();


            //Assert


            Assert.True(testResult.IsSuccessful);
        }



        [Fact]
        public void Infrastructure_Shoud_Not_HaveDependencyOnOtherProject()
        {
            //Arrange

            var assembly = typeof(Infrastructure.DependencyInjection).Assembly;


            //Act

            var otherProjects = new[]
            {


                WebAPINameSpace

            };

            var testResult = Types.InAssembly(assembly)
                  .ShouldNot()
                  .HaveDependencyOnAll(otherProjects)
                  .GetResult();


            //Assert


            Assert.True(testResult.IsSuccessful);
        }



        [Fact]
        public void Controller_Shoud_HaveDependencyOnMediatR()
        {
            //Arrange

            var assembly = typeof(WebAPI.Program).Assembly;


            //Act



            var testResult = Types.InAssembly(assembly)
                 .That()
                 .HaveNameEndingWith("Controller")
                 .Should()
                  .HaveDependencyOn("MediatR")
                  .GetResult();


            //Assert


            Assert.True(testResult.IsSuccessful);
        }

        [Fact]
        public void Controllers_Should_EndingWithController()
        {
            //Arrange
            var assembly = typeof(WebAPI.Program).Assembly;


            //Act

            var testResult = Types.InAssembly(assembly)
                .That()
                .ResideInNamespaceStartingWith("WebAPI.Controllers")
                .Should()
                .HaveNameEndingWith("Controller")
                .GetResult();

            //Assert

              Assert.True(testResult.IsSuccessful);
        }

    }

}