using Microsoft.VisualStudio.TestTools.UnitTesting;
using VendingMachine.Modules;
using VendingMachine.Modules.AcceptMoney;

namespace VendingMachineUnitTest
{
    [TestClass]
    public class UnitTest
    {
        [TestMethod]
        public void ValidatePoundUnitTest()
        {
            bool result;
            int total = 0;

            AcceptMoney acceptMoney = new AcceptMoney();

            result = acceptMoney.IsValidPound(1, ref total);
            // Assert
            Assert.AreEqual(true, result, "Pound Validation Failed");

            result = acceptMoney.IsValidPound(2, ref total);
            // Assert
            Assert.AreEqual(true, result, "Pound Validation Failed");

            result = acceptMoney.IsValidPound(3, ref total);
            // Assert
            Assert.AreEqual(false, result, "Pound Validation Failed");
        }

        public void ValidatePenceUnitTest()
        {
            bool result;
            int total = 0;

            AcceptMoney acceptMoney = new AcceptMoney();

            result = acceptMoney.IsValidPence(1, ref total);
            // Assert
            Assert.AreEqual(false, result, "Pence Validation Failed");

            result = acceptMoney.IsValidPence(2, ref total);
            // Assert
            Assert.AreEqual(false, result, "Pence Validation Failed");

            result = acceptMoney.IsValidPence(5, ref total);
            // Assert
            Assert.AreEqual(true, result, "Pence Validation Failed");

            result = acceptMoney.IsValidPence(10, ref total);
            // Assert
            Assert.AreEqual(true, result, "Pence Validation Failed");

            result = acceptMoney.IsValidPence(20, ref total);
            // Assert
            Assert.AreEqual(true, result, "Pence Validation Failed");

            result = acceptMoney.IsValidPence(50, ref total);
            // Assert
            Assert.AreEqual(true, result, "Pence Validation Failed");
        }
    }
}
