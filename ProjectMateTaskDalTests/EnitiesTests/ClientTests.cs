﻿using ProjectMateTask.DAL.Entities.Actors;
using ProjectMateTask.DAL.Entities.Base;
using ProjectMateTask.DAL.Entities.Types;
using ProjectMateTaskDalTests.Resources;

namespace ProjectMateTaskDalTests.EnitiesTests;

[TestClass]
public class ClientTests
{
    [TestMethod]
    public void IsTwoRandomClientsEquals()
    {
     
        // Arrange
        var rnd = new Random();
        
        var initializer = new EntitiesTestDataInitializer();
        
        Client randomEntity = initializer.TestClients[rnd.Next(0, EntitiesTestDataInitializer.TestClientsCount)];

        Client randomEntityCopy = (Client)randomEntity.Clone();
        
        //Act
        var originalResult = randomEntity.Equals(randomEntityCopy);

        var copyResult = randomEntityCopy.Equals(randomEntity);
        
        //Assert
        Assert.AreEqual(originalResult,copyResult);
    }
}