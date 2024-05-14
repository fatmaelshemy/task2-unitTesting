using CarAPI.Entities;
using CarAPI.Repositories_DAL;
using CarFactoryAPI.Entities;
using CarFactoryAPI.Repositories_DAL;
using Microsoft.EntityFrameworkCore;
using Moq;
using Moq.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;
using Xunit.Abstractions;
using Xunit.Sdk;

namespace CarFactoryAPI_test
{
    public class OwnerRepositoryTest
    {
        private Mock<FactoryContext> factoryContextMock;
        private OwnerRepository ownerRepository;
        private readonly ITestOutputHelper outputHelper;

        public OwnerRepositoryTest()
        {
            outputHelper = new TestOutputHelper();
          
            factoryContextMock = new Mock<FactoryContext>();
           
            ownerRepository = new OwnerRepository(factoryContextMock.Object);
        }

        [Fact]
        [Trait("Author", "Doaa")]
        public void GetOwnerById_AskForOwner100_ReturnOwner()
        {
            // Arrange
            // Build the mock Data
            List<Owner> owners = new List<Owner>() { new Owner() { Id = 100 } };
            // setup called DbSets
            factoryContextMock.Setup(fcm => fcm.Owners).ReturnsDbSet(owners);

            // Act 
            Owner owner = ownerRepository.GetOwnerById(100);

            // Assert
            Assert.NotNull(owner);
        }

        [Fact]
        [Trait("Author", "Doaa")]
        public void AddOwner_AskForOwner_OwnerId600()
        {
            // Arrange
            // Build the mock Data
            List<Owner> owners = new List<Owner>();
            Owner owner = new Owner() { Id = 600 };

            // setup called DbSets
            factoryContextMock.Setup(fcm => fcm.Owners).ReturnsDbSet(owners);

            // Act 
            bool result = ownerRepository.AddOwner(owner);

            // Assert
            Assert.True(result);
        }
    }

}
