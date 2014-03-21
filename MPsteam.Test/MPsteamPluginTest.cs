using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MPsteam.Test
{
   [TestClass]
   public class MPsteamPluginTest
   {
      [TestMethod]
      public void Constructor_ShouldCreateInstance()
      {
         //Arrange / Act
         var mpSteam = new MPsteamPlugin();

         //Assert
         Assert.IsNotNull(mpSteam);
      }
   }
}
