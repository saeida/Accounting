namespace Architecture.Tests
{
    public class ArchitectureTests
    {
        private const string ApplicationNameSpace= "Application";
        private const string DomainNameSpace = "Domain";
        private const string InfrastructureNameSpace = "Infrastructure";
        private const string WebAPINameSpace = "WebAPI";


        [Fact]
        public void Donain_Shoud_Not_HaveDependencyOnOtherProject()
        {
            //Arrange
            
            var assembly=typeof(Domain.AssemblyRefrence)
            //Act

            //Assert

        }
    }
}